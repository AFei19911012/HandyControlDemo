// Decompiled with JetBrains decompiler
// Type: GalaSoft.MvvmLight.ICleanup
// Assembly: GalaSoft.MvvmLight, Version=5.1.1.35049, Culture=neutral, PublicKeyToken=e7570ab207bcb616
// MVID: 5BEDB485-56A9-4001-8E5C-95D46B1034CD
// Assembly location: C:\Users\Asus\OneDrive\Repos\MyDiary\packages\MvvmLightLibs.5.1.1.0\lib\net45\GalaSoft.MvvmLight.dll

namespace GalaSoft.MvvmLight
{
  /// <summary>
  /// Defines a common interface for classes that should be cleaned up,
  /// but without the implications that IDisposable presupposes. An instance
  /// implementing ICleanup can be cleaned up without being
  /// disposed and garbage collected.
  /// </summary>
  public interface ICleanup
  {
    /// <summary>
    /// Cleans up the instance, for example by saving its state,
    /// removing resources, etc...
    /// </summary>
    void Cleanup();
  }
}
