// Decompiled with JetBrains decompiler
// Type: GalaSoft.MvvmLight.Helpers.FeatureDetection
// Assembly: GalaSoft.MvvmLight, Version=5.1.1.35049, Culture=neutral, PublicKeyToken=e7570ab207bcb616
// MVID: 5BEDB485-56A9-4001-8E5C-95D46B1034CD
// Assembly location: C:\Users\Asus\OneDrive\Repos\MyDiary\packages\MvvmLightLibs.5.1.1.0\lib\net45\GalaSoft.MvvmLight.dll

using System.Reflection;

namespace GalaSoft.MvvmLight.Helpers
{
  /// <summary>Helper class for platform and feature detection.</summary>
  internal static class FeatureDetection
  {
    private static bool? _isPrivateReflectionSupported;

    public static bool IsPrivateReflectionSupported
    {
      get
      {
        if (!FeatureDetection._isPrivateReflectionSupported.HasValue)
          FeatureDetection._isPrivateReflectionSupported = new bool?(FeatureDetection.ResolveIsPrivateReflectionSupported());
        return FeatureDetection._isPrivateReflectionSupported.Value;
      }
    }

    private static bool ResolveIsPrivateReflectionSupported()
    {
      FeatureDetection.ReflectionDetectionClass reflectionDetectionClass = new FeatureDetection.ReflectionDetectionClass();
      try
      {
        typeof (FeatureDetection.ReflectionDetectionClass).GetTypeInfo().GetDeclaredMethod("Method").Invoke((object) reflectionDetectionClass, (object[]) null);
      }
      catch
      {
        return false;
      }
      return true;
    }

    private class ReflectionDetectionClass
    {
      private void Method()
      {
      }
    }
  }
}
