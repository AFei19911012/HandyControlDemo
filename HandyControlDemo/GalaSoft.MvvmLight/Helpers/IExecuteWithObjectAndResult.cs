// Decompiled with JetBrains decompiler
// Type: GalaSoft.MvvmLight.Helpers.IExecuteWithObjectAndResult
// Assembly: GalaSoft.MvvmLight, Version=5.1.1.35049, Culture=neutral, PublicKeyToken=e7570ab207bcb616
// MVID: 5BEDB485-56A9-4001-8E5C-95D46B1034CD
// Assembly location: C:\Users\Asus\OneDrive\Repos\MyDiary\packages\MvvmLightLibs.5.1.1.0\lib\net45\GalaSoft.MvvmLight.dll

namespace GalaSoft.MvvmLight.Helpers
{
  /// <summary>
  /// This interface is meant for the <see cref="T:GalaSoft.MvvmLight.Helpers.WeakFunc`1" /> class and can be
  /// useful if you store multiple WeakFunc{T} instances but don't know in advance
  /// what type T represents.
  /// </summary>
  public interface IExecuteWithObjectAndResult
  {
    /// <summary>Executes a Func and returns the result.</summary>
    /// <param name="parameter">A parameter passed as an object,
    /// to be casted to the appropriate type.</param>
    /// <returns>The result of the operation.</returns>
    object ExecuteWithObject(object parameter);
  }
}
