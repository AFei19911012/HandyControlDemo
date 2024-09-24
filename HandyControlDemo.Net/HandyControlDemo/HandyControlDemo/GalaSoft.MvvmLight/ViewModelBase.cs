// Decompiled with JetBrains decompiler
// Type: GalaSoft.MvvmLight.ViewModelBase
// Assembly: GalaSoft.MvvmLight, Version=5.1.1.35049, Culture=neutral, PublicKeyToken=e7570ab207bcb616
// MVID: 5BEDB485-56A9-4001-8E5C-95D46B1034CD
// Assembly location: C:\Users\Asus\OneDrive\Repos\MyDiary\packages\MvvmLightLibs.5.1.1.0\lib\net45\GalaSoft.MvvmLight.dll

using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace GalaSoft.MvvmLight
{
  /// <summary>
  /// A base class for the ViewModel classes in the MVVM pattern.
  /// </summary>
  public abstract class ViewModelBase : ObservableObject, ICleanup
  {
    private static bool? _isInDesignMode;
    private IMessenger _messengerInstance;

    /// <summary>
    /// Initializes a new instance of the ViewModelBase class.
    /// </summary>
    public ViewModelBase()
      : this((IMessenger) null)
    {
    }

    /// <summary>
    /// Initializes a new instance of the ViewModelBase class.
    /// </summary>
    /// <param name="messenger">An instance of a <see cref="T:GalaSoft.MvvmLight.Messaging.Messenger" />
    /// used to broadcast messages to other objects. If null, this class
    /// will attempt to broadcast using the Messenger's default
    /// instance.</param>
    public ViewModelBase(IMessenger messenger) => this.MessengerInstance = messenger;

    /// <summary>
    /// Gets a value indicating whether the control is in design mode
    /// (running under Blend or Visual Studio).
    /// </summary>
    public bool IsInDesignMode => ViewModelBase.IsInDesignModeStatic;

    /// <summary>
    /// Gets a value indicating whether the control is in design mode
    /// (running in Blend or Visual Studio).
    /// </summary>
    public static bool IsInDesignModeStatic
    {
      get
      {
        if (!ViewModelBase._isInDesignMode.HasValue)
          ViewModelBase._isInDesignMode = new bool?(ViewModelBase.IsInDesignModePortable());
        return ViewModelBase._isInDesignMode.Value;
      }
    }

    private static bool IsInDesignModePortable()
    {
      switch (DesignerLibrary.DetectedDesignerLibrary)
      {
        case DesignerPlatformLibrary.Net:
          return ViewModelBase.IsInDesignModeNet();
        case DesignerPlatformLibrary.WinRt:
          return ViewModelBase.IsInDesignModeMetro();
        case DesignerPlatformLibrary.Silverlight:
          bool flag = ViewModelBase.IsInDesignModeSilverlight();
          if (!flag)
            flag = ViewModelBase.IsInDesignModeNet();
          return flag;
        default:
          return false;
      }
    }

    private static bool IsInDesignModeSilverlight()
    {
      try
      {
        Type type = Type.GetType("System.ComponentModel.DesignerProperties, System.Windows, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e");
        if (type == null)
          return false;
        PropertyInfo declaredProperty = type.GetTypeInfo().GetDeclaredProperty("IsInDesignTool");
        return declaredProperty != null && (bool) declaredProperty.GetValue((object) null, (object[]) null);
      }
      catch
      {
        return false;
      }
    }

    private static bool IsInDesignModeMetro()
    {
      try
      {
        return (bool) Type.GetType("Windows.ApplicationModel.DesignMode, Windows, ContentType=WindowsRuntime").GetTypeInfo().GetDeclaredProperty("DesignModeEnabled").GetValue((object) null, (object[]) null);
      }
      catch
      {
        return false;
      }
    }

    private static bool IsInDesignModeNet()
    {
      try
      {
        Type type1 = Type.GetType("System.ComponentModel.DesignerProperties, PresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
        if (type1 == null)
          return false;
        object obj1 = type1.GetTypeInfo().GetDeclaredField("IsInDesignModeProperty").GetValue((object) null);
        Type type2 = Type.GetType("System.ComponentModel.DependencyPropertyDescriptor, WindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
        Type type3 = Type.GetType("System.Windows.FrameworkElement, PresentationFramework, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
        if (type2 == null || type3 == null)
          return false;
        List<MethodInfo> list = type2.GetTypeInfo().GetDeclaredMethods("FromProperty").ToList<MethodInfo>();
        if (list == null || list.Count == 0)
          return false;
        MethodInfo methodInfo = list.FirstOrDefault<MethodInfo>((Func<MethodInfo, bool>) (mi => mi.IsPublic && mi.IsStatic && mi.GetParameters().Length == 2));
        if (methodInfo == null)
          return false;
        object obj2 = methodInfo.Invoke((object) null, new object[2]
        {
          obj1,
          (object) type3
        });
        if (obj2 == null)
          return false;
        PropertyInfo declaredProperty1 = type2.GetTypeInfo().GetDeclaredProperty("Metadata");
        if (declaredProperty1 == null)
          return false;
        object obj3 = declaredProperty1.GetValue(obj2, (object[]) null);
        Type type4 = Type.GetType("System.Windows.PropertyMetadata, WindowsBase, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35");
        if (obj3 == null || type4 == null)
          return false;
        PropertyInfo declaredProperty2 = type4.GetTypeInfo().GetDeclaredProperty("DefaultValue");
        return declaredProperty2 != null && (bool) declaredProperty2.GetValue(obj3, (object[]) null);
      }
      catch
      {
        return false;
      }
    }

    /// <summary>
    /// Gets or sets an instance of a <see cref="T:GalaSoft.MvvmLight.Messaging.IMessenger" /> used to
    /// broadcast messages to other objects. If null, this class will
    /// attempt to broadcast using the Messenger's default instance.
    /// </summary>
    protected IMessenger MessengerInstance
    {
      get => this._messengerInstance ?? Messenger.Default;
      set => this._messengerInstance = value;
    }

    /// <summary>
    /// Unregisters this instance from the Messenger class.
    /// <para>To cleanup additional resources, override this method, clean
    /// up and then call base.Cleanup().</para>
    /// </summary>
    public virtual void Cleanup() => this.MessengerInstance.Unregister((object) this);

    /// <summary>
    /// Broadcasts a PropertyChangedMessage using either the instance of
    /// the Messenger that was passed to this class (if available)
    /// or the Messenger's default instance.
    /// </summary>
    /// <typeparam name="T">The type of the property that
    /// changed.</typeparam>
    /// <param name="oldValue">The value of the property before it
    /// changed.</param>
    /// <param name="newValue">The value of the property after it
    /// changed.</param>
    /// <param name="propertyName">The name of the property that
    /// changed.</param>
    protected virtual void Broadcast<T>(T oldValue, T newValue, string propertyName) => this.MessengerInstance.Send<PropertyChangedMessage<T>>(new PropertyChangedMessage<T>((object) this, oldValue, newValue, propertyName));

    /// <summary>
    /// Raises the PropertyChanged event if needed, and broadcasts a
    /// PropertyChangedMessage using the Messenger instance (or the
    /// static default instance if no Messenger instance is available).
    /// </summary>
    /// <typeparam name="T">The type of the property that
    /// changed.</typeparam>
    /// <param name="propertyName">The name of the property that
    /// changed.</param>
    /// <param name="oldValue">The property's value before the change
    /// occurred.</param>
    /// <param name="newValue">The property's value after the change
    /// occurred.</param>
    /// <param name="broadcast">If true, a PropertyChangedMessage will
    /// be broadcasted. If false, only the event will be raised.</param>
    /// <remarks>If the propertyName parameter
    /// does not correspond to an existing property on the current class, an
    /// exception is thrown in DEBUG configuration only.</remarks>
    protected virtual void RaisePropertyChanged<T>(
      [CallerMemberName] string propertyName = null,
      T oldValue = default(T),
      T newValue = default(T),
      bool broadcast = false)
    {
      if (string.IsNullOrEmpty(propertyName))
        throw new ArgumentException("This method cannot be called with an empty string", nameof (propertyName));
      this.RaisePropertyChanged(propertyName);
      if (!broadcast)
        return;
      this.Broadcast<T>(oldValue, newValue, propertyName);
    }

    /// <summary>
    /// Raises the PropertyChanged event if needed, and broadcasts a
    /// PropertyChangedMessage using the Messenger instance (or the
    /// static default instance if no Messenger instance is available).
    /// </summary>
    /// <typeparam name="T">The type of the property that
    /// changed.</typeparam>
    /// <param name="propertyExpression">An expression identifying the property
    /// that changed.</param>
    /// <param name="oldValue">The property's value before the change
    /// occurred.</param>
    /// <param name="newValue">The property's value after the change
    /// occurred.</param>
    /// <param name="broadcast">If true, a PropertyChangedMessage will
    /// be broadcasted. If false, only the event will be raised.</param>
    protected virtual void RaisePropertyChanged<T>(
      Expression<Func<T>> propertyExpression,
      T oldValue,
      T newValue,
      bool broadcast)
    {
      PropertyChangedEventHandler propertyChangedHandler = this.PropertyChangedHandler;
      if (propertyChangedHandler == null && !broadcast)
        return;
      string propertyName = ObservableObject.GetPropertyName<T>(propertyExpression);
      if (propertyChangedHandler != null)
        propertyChangedHandler((object) this, new PropertyChangedEventArgs(propertyName));
      if (!broadcast)
        return;
      this.Broadcast<T>(oldValue, newValue, propertyName);
    }

    /// <summary>
    /// Assigns a new value to the property. Then, raises the
    /// PropertyChanged event if needed, and broadcasts a
    /// PropertyChangedMessage using the Messenger instance (or the
    /// static default instance if no Messenger instance is available).
    /// </summary>
    /// <typeparam name="T">The type of the property that
    /// changed.</typeparam>
    /// <param name="propertyExpression">An expression identifying the property
    /// that changed.</param>
    /// <param name="field">The field storing the property's value.</param>
    /// <param name="newValue">The property's value after the change
    /// occurred.</param>
    /// <param name="broadcast">If true, a PropertyChangedMessage will
    /// be broadcasted. If false, only the event will be raised.</param>
    /// <returns>True if the PropertyChanged event was raised, false otherwise.</returns>
    protected bool Set<T>(
      Expression<Func<T>> propertyExpression,
      ref T field,
      T newValue,
      bool broadcast)
    {
      if (EqualityComparer<T>.Default.Equals(field, newValue))
        return false;
      T oldValue = field;
      field = newValue;
      this.RaisePropertyChanged<T>(propertyExpression, oldValue, field, broadcast);
      return true;
    }

    /// <summary>
    /// Assigns a new value to the property. Then, raises the
    /// PropertyChanged event if needed, and broadcasts a
    /// PropertyChangedMessage using the Messenger instance (or the
    /// static default instance if no Messenger instance is available).
    /// </summary>
    /// <typeparam name="T">The type of the property that
    /// changed.</typeparam>
    /// <param name="propertyName">The name of the property that
    /// changed.</param>
    /// <param name="field">The field storing the property's value.</param>
    /// <param name="newValue">The property's value after the change
    /// occurred.</param>
    /// <param name="broadcast">If true, a PropertyChangedMessage will
    /// be broadcasted. If false, only the event will be raised.</param>
    /// <returns>True if the PropertyChanged event was raised, false otherwise.</returns>
    protected bool Set<T>(string propertyName, ref T field, T newValue = default(T), bool broadcast = false)
    {
      if (EqualityComparer<T>.Default.Equals(field, newValue))
        return false;
      T oldValue = field;
      field = newValue;
      this.RaisePropertyChanged<T>(propertyName, oldValue, field, broadcast);
      return true;
    }

    /// <summary>
    /// Assigns a new value to the property. Then, raises the
    /// PropertyChanged event if needed, and broadcasts a
    /// PropertyChangedMessage using the Messenger instance (or the
    /// static default instance if no Messenger instance is available).
    /// </summary>
    /// <typeparam name="T">The type of the property that
    /// changed.</typeparam>
    /// <param name="field">The field storing the property's value.</param>
    /// <param name="newValue">The property's value after the change
    /// occurred.</param>
    /// <param name="broadcast">If true, a PropertyChangedMessage will
    /// be broadcasted. If false, only the event will be raised.</param>
    /// <param name="propertyName">(optional) The name of the property that
    /// changed.</param>
    /// <returns>True if the PropertyChanged event was raised, false otherwise.</returns>
    protected bool Set<T>(ref T field, T newValue = default(T), bool broadcast = false, [CallerMemberName] string propertyName = null)
    {
      if (EqualityComparer<T>.Default.Equals(field, newValue))
        return false;
      T oldValue = field;
      field = newValue;
      this.RaisePropertyChanged<T>(propertyName, oldValue, field, broadcast);
      return true;
    }
  }
}
