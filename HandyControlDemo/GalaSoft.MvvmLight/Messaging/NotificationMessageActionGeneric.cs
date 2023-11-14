// Decompiled with JetBrains decompiler
// Type: GalaSoft.MvvmLight.Messaging.NotificationMessageAction`1
// Assembly: GalaSoft.MvvmLight, Version=5.1.1.35049, Culture=neutral, PublicKeyToken=e7570ab207bcb616
// MVID: 5BEDB485-56A9-4001-8E5C-95D46B1034CD
// Assembly location: C:\Users\Asus\OneDrive\Repos\MyDiary\packages\MvvmLightLibs.5.1.1.0\lib\net45\GalaSoft.MvvmLight.dll

using System;

namespace GalaSoft.MvvmLight.Messaging
{
  /// <summary>
  /// Provides a message class with a built-in callback. When the recipient
  /// is done processing the message, it can execute the callback to
  /// notify the sender that it is done. Use the <see cref="M:GalaSoft.MvvmLight.Messaging.NotificationMessageAction`1.Execute(`0)" />
  /// method to execute the callback. The callback method has one parameter.
  /// <seealso cref="T:GalaSoft.MvvmLight.Messaging.NotificationMessageAction" />.
  /// </summary>
  /// <typeparam name="TCallbackParameter">The type of the callback method's
  /// only parameter.</typeparam>
  public class NotificationMessageAction<TCallbackParameter> : NotificationMessageWithCallback
  {
    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="T:GalaSoft.MvvmLight.Messaging.NotificationMessageAction`1" /> class.
    /// </summary>
    /// <param name="notification">An arbitrary string that will be
    /// carried by the message.</param>
    /// <param name="callback">The callback method that can be executed
    /// by the recipient to notify the sender that the message has been
    /// processed.</param>
    public NotificationMessageAction(string notification, Action<TCallbackParameter> callback)
      : base(notification, (Delegate) callback)
    {
    }

    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="T:GalaSoft.MvvmLight.Messaging.NotificationMessageAction`1" /> class.
    /// </summary>
    /// <param name="sender">The message's sender.</param>
    /// <param name="notification">An arbitrary string that will be
    /// carried by the message.</param>
    /// <param name="callback">The callback method that can be executed
    /// by the recipient to notify the sender that the message has been
    /// processed.</param>
    public NotificationMessageAction(
      object sender,
      string notification,
      Action<TCallbackParameter> callback)
      : base(sender, notification, (Delegate) callback)
    {
    }

    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="T:GalaSoft.MvvmLight.Messaging.NotificationMessageAction`1" /> class.
    /// </summary>
    /// <param name="sender">The message's sender.</param>
    /// <param name="target">The message's intended target. This parameter can be used
    /// to give an indication as to whom the message was intended for. Of course
    /// this is only an indication, amd may be null.</param>
    /// <param name="notification">An arbitrary string that will be
    /// carried by the message.</param>
    /// <param name="callback">The callback method that can be executed
    /// by the recipient to notify the sender that the message has been
    /// processed.</param>
    public NotificationMessageAction(
      object sender,
      object target,
      string notification,
      Action<TCallbackParameter> callback)
      : base(sender, target, notification, (Delegate) callback)
    {
    }

    /// <summary>
    /// Executes the callback that was provided with the message.
    /// </summary>
    /// <param name="parameter">A parameter requested by the message's
    /// sender and providing additional information on the recipient's
    /// state.</param>
    public void Execute(TCallbackParameter parameter) => this.Execute((object) parameter);
  }
}
