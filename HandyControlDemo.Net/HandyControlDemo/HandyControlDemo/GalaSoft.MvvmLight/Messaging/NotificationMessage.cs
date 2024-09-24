// Decompiled with JetBrains decompiler
// Type: GalaSoft.MvvmLight.Messaging.NotificationMessage
// Assembly: GalaSoft.MvvmLight, Version=5.1.1.35049, Culture=neutral, PublicKeyToken=e7570ab207bcb616
// MVID: 5BEDB485-56A9-4001-8E5C-95D46B1034CD
// Assembly location: C:\Users\Asus\OneDrive\Repos\MyDiary\packages\MvvmLightLibs.5.1.1.0\lib\net45\GalaSoft.MvvmLight.dll

namespace GalaSoft.MvvmLight.Messaging
{
  /// <summary>
  /// Passes a string message (Notification) to a recipient.
  /// <para>Typically, notifications are defined as unique strings in a static class. To define
  /// a unique string, you can use Guid.NewGuid().ToString() or any other unique
  /// identifier.</para>
  /// </summary>
  public class NotificationMessage : MessageBase
  {
    /// <summary>
    /// Initializes a new instance of the NotificationMessage class.
    /// </summary>
    /// <param name="notification">A string containing any arbitrary message to be
    /// passed to recipient(s)</param>
    public NotificationMessage(string notification) => this.Notification = notification;

    /// <summary>
    /// Initializes a new instance of the NotificationMessage class.
    /// </summary>
    /// <param name="sender">The message's sender.</param>
    /// <param name="notification">A string containing any arbitrary message to be
    /// passed to recipient(s)</param>
    public NotificationMessage(object sender, string notification)
      : base(sender)
      => this.Notification = notification;

    /// <summary>
    /// Initializes a new instance of the NotificationMessage class.
    /// </summary>
    /// <param name="sender">The message's sender.</param>
    /// <param name="target">The message's intended target. This parameter can be used
    /// to give an indication as to whom the message was intended for. Of course
    /// this is only an indication, amd may be null.</param>
    /// <param name="notification">A string containing any arbitrary message to be
    /// passed to recipient(s)</param>
    public NotificationMessage(object sender, object target, string notification)
      : base(sender, target)
      => this.Notification = notification;

    /// <summary>
    /// Gets a string containing any arbitrary message to be
    /// passed to recipient(s).
    /// </summary>
    public string Notification { get; private set; }
  }
}
