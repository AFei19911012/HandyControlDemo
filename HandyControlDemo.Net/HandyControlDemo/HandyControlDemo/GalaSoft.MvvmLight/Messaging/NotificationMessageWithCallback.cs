﻿// Decompiled with JetBrains decompiler
// Type: GalaSoft.MvvmLight.Messaging.NotificationMessageWithCallback
// Assembly: GalaSoft.MvvmLight, Version=5.1.1.35049, Culture=neutral, PublicKeyToken=e7570ab207bcb616
// MVID: 5BEDB485-56A9-4001-8E5C-95D46B1034CD
// Assembly location: C:\Users\Asus\OneDrive\Repos\MyDiary\packages\MvvmLightLibs.5.1.1.0\lib\net45\GalaSoft.MvvmLight.dll

using System;

namespace GalaSoft.MvvmLight.Messaging
{
  /// <summary>
  /// Provides a message class with a built-in callback. When the recipient
  /// is done processing the message, it can execute the callback to
  /// notify the sender that it is done. Use the <see cref="M:GalaSoft.MvvmLight.Messaging.NotificationMessageWithCallback.Execute(System.Object[])" />
  /// method to execute the callback. The callback method has one parameter.
  /// <seealso cref="T:GalaSoft.MvvmLight.Messaging.NotificationMessageAction" /> and
  /// <seealso cref="T:GalaSoft.MvvmLight.Messaging.NotificationMessageAction`1" />.
  /// </summary>
  public class NotificationMessageWithCallback : NotificationMessage
  {
    private readonly Delegate _callback;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:GalaSoft.MvvmLight.Messaging.NotificationMessageWithCallback" /> class.
    /// </summary>
    /// <param name="notification">An arbitrary string that will be
    /// carried by the message.</param>
    /// <param name="callback">The callback method that can be executed
    /// by the recipient to notify the sender that the message has been
    /// processed.</param>
    public NotificationMessageWithCallback(string notification, Delegate callback)
      : base(notification)
    {
      NotificationMessageWithCallback.CheckCallback(callback);
      this._callback = callback;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:GalaSoft.MvvmLight.Messaging.NotificationMessageWithCallback" /> class.
    /// </summary>
    /// <param name="sender">The message's sender.</param>
    /// <param name="notification">An arbitrary string that will be
    /// carried by the message.</param>
    /// <param name="callback">The callback method that can be executed
    /// by the recipient to notify the sender that the message has been
    /// processed.</param>
    public NotificationMessageWithCallback(object sender, string notification, Delegate callback)
      : base(sender, notification)
    {
      NotificationMessageWithCallback.CheckCallback(callback);
      this._callback = callback;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:GalaSoft.MvvmLight.Messaging.NotificationMessageWithCallback" /> class.
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
    public NotificationMessageWithCallback(
      object sender,
      object target,
      string notification,
      Delegate callback)
      : base(sender, target, notification)
    {
      NotificationMessageWithCallback.CheckCallback(callback);
      this._callback = callback;
    }

    /// <summary>
    /// Executes the callback that was provided with the message with an
    /// arbitrary number of parameters.
    /// </summary>
    /// <param name="arguments">A  number of parameters that will
    /// be passed to the callback method.</param>
    /// <returns>The object returned by the callback method.</returns>
    public virtual object Execute(params object[] arguments) => this._callback.DynamicInvoke(arguments);

    private static void CheckCallback(Delegate callback)
    {
      if ((object) callback == null)
        throw new ArgumentNullException(nameof (callback), "Callback may not be null");
    }
  }
}
