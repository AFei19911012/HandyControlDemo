// Decompiled with JetBrains decompiler
// Type: GalaSoft.MvvmLight.Messaging.PropertyChangedMessageBase
// Assembly: GalaSoft.MvvmLight, Version=5.1.1.35049, Culture=neutral, PublicKeyToken=e7570ab207bcb616
// MVID: 5BEDB485-56A9-4001-8E5C-95D46B1034CD
// Assembly location: C:\Users\Asus\OneDrive\Repos\MyDiary\packages\MvvmLightLibs.5.1.1.0\lib\net45\GalaSoft.MvvmLight.dll

namespace GalaSoft.MvvmLight.Messaging
{
  /// <summary>
  /// Basis class for the <see cref="T:GalaSoft.MvvmLight.Messaging.PropertyChangedMessage`1" /> class. This
  /// class allows a recipient to register for all PropertyChangedMessages without
  /// having to specify the type T.
  /// </summary>
  public abstract class PropertyChangedMessageBase : MessageBase
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:GalaSoft.MvvmLight.Messaging.PropertyChangedMessageBase" /> class.
    /// </summary>
    /// <param name="sender">The message's sender.</param>
    /// <param name="propertyName">The name of the property that changed.</param>
    protected PropertyChangedMessageBase(object sender, string propertyName)
      : base(sender)
      => this.PropertyName = propertyName;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:GalaSoft.MvvmLight.Messaging.PropertyChangedMessageBase" /> class.
    /// </summary>
    /// <param name="sender">The message's sender.</param>
    /// <param name="target">The message's intended target. This parameter can be used
    /// to give an indication as to whom the message was intended for. Of course
    /// this is only an indication, amd may be null.</param>
    /// <param name="propertyName">The name of the property that changed.</param>
    protected PropertyChangedMessageBase(object sender, object target, string propertyName)
      : base(sender, target)
      => this.PropertyName = propertyName;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:GalaSoft.MvvmLight.Messaging.PropertyChangedMessageBase" /> class.
    /// </summary>
    /// <param name="propertyName">The name of the property that changed.</param>
    protected PropertyChangedMessageBase(string propertyName) => this.PropertyName = propertyName;

    /// <summary>Gets or sets the name of the property that changed.</summary>
    public string PropertyName { get; protected set; }
  }
}
