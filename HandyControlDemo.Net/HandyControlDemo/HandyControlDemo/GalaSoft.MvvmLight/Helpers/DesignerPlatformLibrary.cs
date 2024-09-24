// Decompiled with JetBrains decompiler
// Type: GalaSoft.MvvmLight.Helpers.DesignerLibrary
// Assembly: GalaSoft.MvvmLight, Version=5.1.1.35049, Culture=neutral, PublicKeyToken=e7570ab207bcb616
// MVID: 5BEDB485-56A9-4001-8E5C-95D46B1034CD
// Assembly location: C:\Users\Asus\OneDrive\Repos\MyDiary\packages\MvvmLightLibs.5.1.1.0\lib\net45\GalaSoft.MvvmLight.dll

using System;

namespace GalaSoft.MvvmLight.Helpers
{
  /// <summary>Helper class for platform detection.</summary>
  internal static class DesignerLibrary
  {
    private static DesignerPlatformLibrary? _detectedDesignerPlatformLibrary;

    internal static DesignerPlatformLibrary DetectedDesignerLibrary
    {
      get
      {
        if (!DesignerLibrary._detectedDesignerPlatformLibrary.HasValue)
          DesignerLibrary._detectedDesignerPlatformLibrary = new DesignerPlatformLibrary?(DesignerLibrary.GetCurrentPlatform());
        return DesignerLibrary._detectedDesignerPlatformLibrary.Value;
      }
    }

    private static DesignerPlatformLibrary GetCurrentPlatform()
    {
      if (Type.GetType("System.ComponentModel.DesignerProperties, System.Windows, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e") != null)
        return DesignerPlatformLibrary.Silverlight;
      if (Type.GetType("System.ComponentModel.DesignerProperties, PresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35") != null)
        return DesignerPlatformLibrary.Net;
      return Type.GetType("Windows.ApplicationModel.DesignMode, Windows, ContentType=WindowsRuntime") != null ? DesignerPlatformLibrary.WinRt : DesignerPlatformLibrary.Unknown;
    }
  }
}
