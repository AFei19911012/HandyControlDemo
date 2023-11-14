// Decompiled with JetBrains decompiler
// Type: GalaSoft.MvvmLight.Helpers.WeakAction`1
// Assembly: GalaSoft.MvvmLight, Version=5.1.1.35049, Culture=neutral, PublicKeyToken=e7570ab207bcb616
// MVID: 5BEDB485-56A9-4001-8E5C-95D46B1034CD
// Assembly location: C:\Users\Asus\OneDrive\Repos\MyDiary\packages\MvvmLightLibs.5.1.1.0\lib\net45\GalaSoft.MvvmLight.dll

using System;
using System.Reflection;

namespace GalaSoft.MvvmLight.Helpers
{
  /// <summary>
  /// Stores an Action without causing a hard reference
  /// to be created to the Action's owner. The owner can be garbage collected at any time.
  /// </summary>
  /// <typeparam name="T">The type of the Action's parameter.</typeparam>
  public class WeakAction<T> : WeakAction, IExecuteWithObject
  {
    private Action<T> _staticAction;

    /// <summary>
    /// Gets the name of the method that this WeakAction represents.
    /// </summary>
    public override string MethodName => this._staticAction != null ? this._staticAction.GetMethodInfo().Name : this.Method.Name;

    /// <summary>
    /// Gets a value indicating whether the Action's owner is still alive, or if it was collected
    /// by the Garbage Collector already.
    /// </summary>
    public override bool IsAlive
    {
      get
      {
        if (this._staticAction == null && this.Reference == null)
          return false;
        if (this._staticAction == null)
          return this.Reference.IsAlive;
        return this.Reference == null || this.Reference.IsAlive;
      }
    }

    /// <summary>Initializes a new instance of the WeakAction class.</summary>
    /// <param name="action">The action that will be associated to this instance.</param>
    public WeakAction(Action<T> action)
      : this(action == null ? (object) null : action.Target, action)
    {
    }

    /// <summary>Initializes a new instance of the WeakAction class.</summary>
    /// <param name="target">The action's owner.</param>
    /// <param name="action">The action that will be associated to this instance.</param>
    public WeakAction(object target, Action<T> action)
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
    /// Executes the action. This only happens if the action's owner
    /// is still alive. The action's parameter is set to default(T).
    /// </summary>
    public new void Execute() => this.Execute(default (T));

    /// <summary>
    /// Executes the action. This only happens if the action's owner
    /// is still alive.
    /// </summary>
    /// <param name="parameter">A parameter to be passed to the action.</param>
    public void Execute(T parameter)
    {
      if (this._staticAction != null)
      {
        this._staticAction(parameter);
      }
      else
      {
        object actionTarget = this.ActionTarget;
        if (!this.IsAlive || this.Method == null || (this.ActionReference == null || actionTarget == null))
          return;
        this.Method.Invoke(actionTarget, new object[1]
        {
          (object) parameter
        });
      }
    }

    /// <summary>
    /// Executes the action with a parameter of type object. This parameter
    /// will be casted to T. This method implements <see cref="M:GalaSoft.MvvmLight.Helpers.IExecuteWithObject.ExecuteWithObject(System.Object)" />
    /// and can be useful if you store multiple WeakAction{T} instances but don't know in advance
    /// what type T represents.
    /// </summary>
    /// <param name="parameter">The parameter that will be passed to the action after
    /// being casted to T.</param>
    public void ExecuteWithObject(object parameter) => this.Execute((T) parameter);

    /// <summary>
    /// Sets all the actions that this WeakAction contains to null,
    /// which is a signal for containing objects that this WeakAction
    /// should be deleted.
    /// </summary>
    public new void MarkForDeletion()
    {
      this._staticAction = (Action<T>) null;
      base.MarkForDeletion();
    }
  }
}
