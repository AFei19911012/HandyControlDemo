// Decompiled with JetBrains decompiler
// Type: GalaSoft.MvvmLight.Helpers.Empty
// Assembly: GalaSoft.MvvmLight, Version=5.1.1.35049, Culture=neutral, PublicKeyToken=e7570ab207bcb616
// MVID: 5BEDB485-56A9-4001-8E5C-95D46B1034CD
// Assembly location: C:\Users\Asus\OneDrive\Repos\MyDiary\packages\MvvmLightLibs.5.1.1.0\lib\net45\GalaSoft.MvvmLight.dll

using System;
using System.Threading.Tasks;

namespace GalaSoft.MvvmLight.Helpers
{
  /// <summary>
  /// Helper class used when an async method is required,
  /// but the context is synchronous.
  /// </summary>
  public static class Empty
  {
    private static readonly Task ConcreteTask = new Task((Action) (() => {}));

    /// <summary>Gets the empty task.</summary>
    public static Task Task => Empty.ConcreteTask;
  }
}
