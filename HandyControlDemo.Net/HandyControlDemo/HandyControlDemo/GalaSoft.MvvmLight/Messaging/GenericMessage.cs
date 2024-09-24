// Decompiled with JetBrains decompiler
// Type: GalaSoft.MvvmLight.Messaging.GenericMessage`1
// Assembly: GalaSoft.MvvmLight, Version=5.1.1.35049, Culture=neutral, PublicKeyToken=e7570ab207bcb616
// MVID: 5BEDB485-56A9-4001-8E5C-95D46B1034CD
// Assembly location: C:\Users\Asus\OneDrive\Repos\MyDiary\packages\MvvmLightLibs.5.1.1.0\lib\net45\GalaSoft.MvvmLight.dll

namespace GalaSoft.MvvmLight.Messaging
{
  /// <summary>Passes a generic value (Content) to a recipient.</summary>
  /// <typeparam name="T">The type of the Content property.</typeparam>
  public class GenericMessage<T> : MessageBase
  {
    /// <summary>
    /// Initializes a new instance of the GenericMessage class.
    /// </summary>
    /// <param name="content">The message content.</param>
    public GenericMessage(T content) => this.Content = content;

    /// <summary>
    /// Initializes a new instance of the GenericMessage class.
    /// </summary>
    /// <param name="sender">The message's sender.</param>
    /// <param name="content">The message content.</param>
    public GenericMessage(object sender, T content)
      : base(sender)
      => this.Content = content;

    /// <summary>
    /// Initializes a new instance of the GenericMessage class.
    /// </summary>
    /// <param name="sender">The message's sender.</param>
    /// <param name="target">The message's intended target. This parameter can be used
    /// to give an indication as to whom the message was intended for. Of course
    /// this is only an indication, amd may be null.</param>
    /// <param name="content">The message content.</param>
    public GenericMessage(object sender, object target, T content)
      : base(sender, target)
      => this.Content = content;

    /// <summary>Gets or sets the message's content.</summary>
    public T Content { get; protected set; }
  }
}
