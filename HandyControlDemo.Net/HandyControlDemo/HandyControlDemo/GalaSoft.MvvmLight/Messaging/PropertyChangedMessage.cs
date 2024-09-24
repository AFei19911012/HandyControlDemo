// Decompiled with JetBrains decompiler
// Type: GalaSoft.MvvmLight.Messaging.PropertyChangedMessage`1
// Assembly: GalaSoft.MvvmLight, Version=5.1.1.35049, Culture=neutral, PublicKeyToken=e7570ab207bcb616
// MVID: 5BEDB485-56A9-4001-8E5C-95D46B1034CD
// Assembly location: C:\Users\Asus\OneDrive\Repos\MyDiary\packages\MvvmLightLibs.5.1.1.0\lib\net45\GalaSoft.MvvmLight.dll

namespace GalaSoft.MvvmLight.Messaging
{
  /// <summary>
  /// Passes a string property name (PropertyName) and a generic value
  /// (<see cref="P:GalaSoft.MvvmLight.Messaging.PropertyChangedMessage`1.OldValue" /> and <see cref="P:GalaSoft.MvvmLight.Messaging.PropertyChangedMessage`1.NewValue" />) to a recipient.
  /// This message type can be used to propagate a PropertyChanged event to
  /// a recipient using the messenging system.
  /// </summary>
  /// <typeparam name="T">The type of the OldValue and NewValue property.</typeparam>
  public class PropertyChangedMessage<T> : PropertyChangedMessageBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:GalaSoft.MvvmLight.Messaging.PropertyChangedMessage`1" /> class.
    /// </summary>
    /// <param name="sender">The message's sender.</param>
    /// <param name="oldValue">The property's value before the change occurred.</param>
    /// <param name="newValue">The property's value after the change occurred.</param>
    /// <param name="propertyName">The name of the property that changed.</param>
    public PropertyChangedMessage(object sender, T oldValue, T newValue, string propertyName)
      : base(sender, propertyName)
    {
      this.OldValue = oldValue;
      this.NewValue = newValue;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:GalaSoft.MvvmLight.Messaging.PropertyChangedMessage`1" /> class.
    /// </summary>
    /// <param name="oldValue">The property's value before the change occurred.</param>
    /// <param name="newValue">The property's value after the change occurred.</param>
    /// <param name="propertyName">The name of the property that changed.</param>
    public PropertyChangedMessage(T oldValue, T newValue, string propertyName)
      : base(propertyName)
    {
      this.OldValue = oldValue;
      this.NewValue = newValue;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:GalaSoft.MvvmLight.Messaging.PropertyChangedMessage`1" /> class.
    /// </summary>
    /// <param name="sender">The message's sender.</param>
    /// <param name="target">The message's intended target. This parameter can be used
    /// to give an indication as to whom the message was intended for. Of course
    /// this is only an indication, amd may be null.</param>
    /// <param name="oldValue">The property's value before the change occurred.</param>
    /// <param name="newValue">The property's value after the change occurred.</param>
    /// <param name="propertyName">The name of the property that changed.</param>
    public PropertyChangedMessage(
      object sender,
      object target,
      T oldValue,
      T newValue,
      string propertyName)
      : base(sender, target, propertyName)
    {
      this.OldValue = oldValue;
      this.NewValue = newValue;
    }

    /// <summary>
    /// Gets the value that the property has after the change.
    /// </summary>
    public T NewValue { get; private set; }

    /// <summary>
    /// Gets the value that the property had before the change.
    /// </summary>
    public T OldValue { get; private set; }
  }
}
