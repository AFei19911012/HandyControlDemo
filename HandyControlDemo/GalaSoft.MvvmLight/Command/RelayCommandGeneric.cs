// Decompiled with JetBrains decompiler
// Type: GalaSoft.MvvmLight.Command.RelayCommand`1
// Assembly: GalaSoft.MvvmLight, Version=5.1.1.35049, Culture=neutral, PublicKeyToken=e7570ab207bcb616
// MVID: 5BEDB485-56A9-4001-8E5C-95D46B1034CD
// Assembly location: C:\Users\Asus\OneDrive\Repos\MyDiary\packages\MvvmLightLibs.5.1.1.0\lib\net45\GalaSoft.MvvmLight.dll

using GalaSoft.MvvmLight.Helpers;
using System;
using System.Reflection;
using System.Windows.Input;

namespace GalaSoft.MvvmLight.Command
{
  /// <summary>
  /// A generic command whose sole purpose is to relay its functionality to other
  /// objects by invoking delegates. The default return value for the CanExecute
  /// method is 'true'. This class allows you to accept command parameters in the
  /// Execute and CanExecute callback methods.
  /// </summary>
  /// <typeparam name="T">The type of the command parameter.</typeparam>
  /// <remarks>If you are using this class in WPF4.5 or above, you need to use the
  /// GalaSoft.MvvmLight.CommandWpf namespace (instead of GalaSoft.MvvmLight.Command).
  /// This will enable (or restore) the CommandManager class which handles
  /// automatic enabling/disabling of controls based on the CanExecute delegate.</remarks>
  public class RelayCommand<T> : ICommand
  {
    private readonly WeakAction<T> _execute;
    private readonly WeakFunc<T, bool> _canExecute;

    /// <summary>
    /// Initializes a new instance of the RelayCommand class that
    /// can always execute.
    /// </summary>
    /// <param name="execute">The execution logic.</param>
    /// <exception cref="T:System.ArgumentNullException">If the execute argument is null.</exception>
    public RelayCommand(Action<T> execute)
      : this(execute, (Func<T, bool>) null)
    {
    }

    /// <summary>Initializes a new instance of the RelayCommand class.</summary>
    /// <param name="execute">The execution logic.</param>
    /// <param name="canExecute">The execution status logic.</param>
    /// <exception cref="T:System.ArgumentNullException">If the execute argument is null.</exception>
    public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
    {
      this._execute = execute != null ? new WeakAction<T>(execute) : throw new ArgumentNullException(nameof (execute));
      if (canExecute == null)
        return;
      this._canExecute = new WeakFunc<T, bool>(canExecute);
    }

    /// <summary>
    /// Occurs when changes occur that affect whether the command should execute.
    /// </summary>
    public event EventHandler CanExecuteChanged;

    /// <summary>
    /// Raises the <see cref="E:GalaSoft.MvvmLight.Command.RelayCommand`1.CanExecuteChanged" /> event.
    /// </summary>
    public void RaiseCanExecuteChanged()
    {
      EventHandler canExecuteChanged = this.CanExecuteChanged;
      if (canExecuteChanged == null)
        return;
      canExecuteChanged((object) this, EventArgs.Empty);
    }

    /// <summary>
    /// Defines the method that determines whether the command can execute in its current state.
    /// </summary>
    /// <param name="parameter">Data used by the command. If the command does not require data
    /// to be passed, this object can be set to a null reference</param>
    /// <returns>true if this command can be executed; otherwise, false.</returns>
    public bool CanExecute(object parameter)
    {
      if (this._canExecute == null)
        return true;
      if (this._canExecute.IsStatic || this._canExecute.IsAlive)
      {
        if (parameter == null && typeof (T).GetTypeInfo().IsValueType)
          return this._canExecute.Execute(default (T));
        if (parameter == null || parameter is T)
          return this._canExecute.Execute((T) parameter);
      }
      return false;
    }

    /// <summary>
    /// Defines the method to be called when the command is invoked.
    /// </summary>
    /// <param name="parameter">Data used by the command. If the command does not require data
    /// to be passed, this object can be set to a null reference</param>
    public virtual void Execute(object parameter)
    {
      object parameter1 = parameter;
      if (!this.CanExecute(parameter1) || this._execute == null || !this._execute.IsStatic && !this._execute.IsAlive)
        return;
      if (parameter1 == null)
      {
        if (typeof (T).GetTypeInfo().IsValueType)
          this._execute.Execute(default (T));
        else
          this._execute.Execute((T) parameter1);
      }
      else
        this._execute.Execute((T) parameter1);
    }
  }
}
