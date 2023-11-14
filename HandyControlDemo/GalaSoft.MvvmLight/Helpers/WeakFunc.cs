// Decompiled with JetBrains decompiler
// Type: GalaSoft.MvvmLight.Helpers.WeakFunc`1
// Assembly: GalaSoft.MvvmLight, Version=5.1.1.35049, Culture=neutral, PublicKeyToken=e7570ab207bcb616
// MVID: 5BEDB485-56A9-4001-8E5C-95D46B1034CD
// Assembly location: C:\Users\Asus\OneDrive\Repos\MyDiary\packages\MvvmLightLibs.5.1.1.0\lib\net45\GalaSoft.MvvmLight.dll

using System;
using System.Reflection;

namespace GalaSoft.MvvmLight.Helpers
{
  /// <summary>
  /// Stores a Func&lt;T&gt; without causing a hard reference
  /// to be created to the Func's owner. The owner can be garbage collected at any time.
  /// </summary>
  /// <typeparam name="TResult">The type of the result of the Func that will be stored
  /// by this weak reference.</typeparam>
  public class WeakFunc<TResult>
  {
    private Func<TResult> _staticFunc;

    /// <summary>
    /// Gets or sets the <see cref="T:System.Reflection.MethodInfo" /> corresponding to this WeakFunc's
    /// method passed in the constructor.
    /// </summary>
    protected MethodInfo Method { get; set; }

    /// <summary>
    /// Get a value indicating whether the WeakFunc is static or not.
    /// </summary>
    public bool IsStatic => this._staticFunc != null;

    /// <summary>
    /// Gets the name of the method that this WeakFunc represents.
    /// </summary>
    public virtual string MethodName => this._staticFunc != null ? this._staticFunc.GetMethodInfo().Name : this.Method.Name;

    /// <summary>
    /// Gets or sets a WeakReference to this WeakFunc's action's target.
    /// This is not necessarily the same as
    /// <see cref="P:GalaSoft.MvvmLight.Helpers.WeakFunc`1.Reference" />, for example if the
    /// method is anonymous.
    /// </summary>
    protected WeakReference FuncReference { get; set; }

    /// <summary>
    /// Gets or sets a WeakReference to the target passed when constructing
    /// the WeakFunc. This is not necessarily the same as
    /// <see cref="P:GalaSoft.MvvmLight.Helpers.WeakFunc`1.FuncReference" />, for example if the
    /// method is anonymous.
    /// </summary>
    protected WeakReference Reference { get; set; }

    /// <summary>Initializes an empty instance of the WeakFunc class.</summary>
    protected WeakFunc()
    {
    }

    /// <summary>Initializes a new instance of the WeakFunc class.</summary>
    /// <param name="func">The Func that will be associated to this instance.</param>
    public WeakFunc(Func<TResult> func)
      : this(func == null ? (object) null : func.Target, func)
    {
    }

    /// <summary>Initializes a new instance of the WeakFunc class.</summary>
    /// <param name="target">The Func's owner.</param>
    /// <param name="func">The Func that will be associated to this instance.</param>
    public WeakFunc(object target, Func<TResult> func)
    {
      if (func.GetMethodInfo().IsStatic)
      {
        this._staticFunc = func;
        if (target == null)
          return;
        this.Reference = new WeakReference(target);
      }
      else
      {
        this.Method = func.GetMethodInfo();
        this.FuncReference = new WeakReference(func.Target);
        this.Reference = new WeakReference(target);
      }
    }

    /// <summary>
    /// Gets a value indicating whether the Func's owner is still alive, or if it was collected
    /// by the Garbage Collector already.
    /// </summary>
    public virtual bool IsAlive
    {
      get
      {
        if (this._staticFunc == null && this.Reference == null)
          return false;
        return this._staticFunc != null && this.Reference == null || this.Reference.IsAlive;
      }
    }

    /// <summary>
    /// Gets the Func's owner. This object is stored as a
    /// <see cref="T:System.WeakReference" />.
    /// </summary>
    public object Target => this.Reference == null ? (object) null : this.Reference.Target;

    /// <summary>
    /// Gets the owner of the Func that was passed as parameter.
    /// This is not necessarily the same as
    /// <see cref="P:GalaSoft.MvvmLight.Helpers.WeakFunc`1.Target" />, for example if the
    /// method is anonymous.
    /// </summary>
    protected object FuncTarget => this.FuncReference == null ? (object) null : this.FuncReference.Target;

    /// <summary>
    /// Executes the action. This only happens if the Func's owner
    /// is still alive.
    /// </summary>
    /// <returns>The result of the Func stored as reference.</returns>
    public TResult Execute()
    {
      if (this._staticFunc != null)
        return this._staticFunc();
      object funcTarget = this.FuncTarget;
      return this.IsAlive && this.Method != null && (this.FuncReference != null && funcTarget != null) ? (TResult) this.Method.Invoke(funcTarget, (object[]) null) : default (TResult);
    }

    /// <summary>Sets the reference that this instance stores to null.</summary>
    public void MarkForDeletion()
    {
      this.Reference = (WeakReference) null;
      this.FuncReference = (WeakReference) null;
      this.Method = (MethodInfo) null;
      this._staticFunc = (Func<TResult>) null;
    }
  }
}
