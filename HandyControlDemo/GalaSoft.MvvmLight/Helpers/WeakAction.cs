// Decompiled with JetBrains decompiler
// Type: GalaSoft.MvvmLight.Helpers.WeakAction
// Assembly: GalaSoft.MvvmLight, Version=5.1.1.35049, Culture=neutral, PublicKeyToken=e7570ab207bcb616
// MVID: 5BEDB485-56A9-4001-8E5C-95D46B1034CD
// Assembly location: C:\Users\Asus\OneDrive\Repos\MyDiary\packages\MvvmLightLibs.5.1.1.0\lib\net45\GalaSoft.MvvmLight.dll

using System;
using System.Reflection;

namespace GalaSoft.MvvmLight.Helpers
{
  /// <summary>
  /// Stores an <see cref="T:System.Action" /> without causing a hard reference
  /// to be created to the Action's owner. The owner can be garbage collected at any time.
  /// </summary>
  public class WeakAction
  {
    private Action _staticAction;

    /// <summary>
    /// Gets or sets the <see cref="T:System.Reflection.MethodInfo" /> corresponding to this WeakAction's
    /// method passed in the constructor.
    /// </summary>
    protected MethodInfo Method { get; set; }

    /// <summary>
    /// Gets the name of the method that this WeakAction represents.
    /// </summary>
    public virtual string MethodName => this._staticAction != null ? this._staticAction.GetMethodInfo().Name : this.Method.Name;

    /// <summary>
    /// Gets or sets a WeakReference to this WeakAction's action's target.
    /// This is not necessarily the same as
    /// <see cref="P:GalaSoft.MvvmLight.Helpers.WeakAction.Reference" />, for example if the
    /// method is anonymous.
    /// </summary>
    protected WeakReference ActionReference { get; set; }

    /// <summary>
    /// Gets or sets a WeakReference to the target passed when constructing
    /// the WeakAction. This is not necessarily the same as
    /// <see cref="P:GalaSoft.MvvmLight.Helpers.WeakAction.ActionReference" />, for example if the
    /// method is anonymous.
    /// </summary>
    protected WeakReference Reference { get; set; }

    /// <summary>
    /// Gets a value indicating whether the WeakAction is static or not.
    /// </summary>
    public bool IsStatic => this._staticAction != null;

    /// <summary>
    /// Initializes an empty instance of the <see cref="T:GalaSoft.MvvmLight.Helpers.WeakAction" /> class.
    /// </summary>
    protected WeakAction()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:GalaSoft.MvvmLight.Helpers.WeakAction" /> class.
    /// </summary>
    /// <param name="action">The action that will be associated to this instance.</param>
    public WeakAction(Action action)
      : this(action == null ? (object) null : action.Target, action)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:GalaSoft.MvvmLight.Helpers.WeakAction" /> class.
    /// </summary>
    /// <param name="target">The action's owner.</param>
    /// <param name="action">The action that will be associated to this instance.</param>
    public WeakAction(object target, Action action)
    {
      if (action.GetMethodInfo().IsStatic)
      {
        this._staticAction = action;
        if (target == null)
          return;
        this.Reference = new WeakReference(target);
      }
      else
      {
        this.Method = action.GetMethodInfo();
        this.ActionReference = new WeakReference(action.Target);
        this.Reference = new WeakReference(target);
      }
    }

    /// <summary>
    /// Gets a value indicating whether the Action's owner is still alive, or if it was collected
    /// by the Garbage Collector already.
    /// </summary>
    public virtual bool IsAlive
    {
      get
      {
        if (this._staticAction == null && this.Reference == null)
          return false;
        return this._staticAction != null && this.Reference == null || this.Reference.IsAlive;
      }
    }

    /// <summary>
    /// Gets the Action's owner. This object is stored as a
    /// <see cref="T:System.WeakReference" />.
    /// </summary>
    public object Target => this.Reference == null ? (object) null : this.Reference.Target;

    /// <summary>The target of the weak reference.</summary>
    protected object ActionTarget => this.ActionReference == null ? (object) null : this.ActionReference.Target;

    /// <summary>
    /// Executes the action. This only happens if the action's owner
    /// is still alive.
    /// </summary>
    public void Execute()
    {
      if (this._staticAction != null)
      {
        this._staticAction();
      }
      else
      {
        object actionTarget = this.ActionTarget;
        if (!this.IsAlive || this.Method == null || (this.ActionReference == null || actionTarget == null))
          return;
        this.Method.Invoke(actionTarget, (object[]) null);
      }
    }

    /// <summary>Sets the reference that this instance stores to null.</summary>
    public void MarkForDeletion()
    {
      this.Reference = (WeakReference) null;
      this.ActionReference = (WeakReference) null;
      this.Method = (MethodInfo) null;
      this._staticAction = (Action) null;
    }
  }
}
