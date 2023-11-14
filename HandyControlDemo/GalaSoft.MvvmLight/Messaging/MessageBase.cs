// Decompiled with JetBrains decompiler
// Type: GalaSoft.MvvmLight.Messaging.MessageBase
// Assembly: GalaSoft.MvvmLight, Version=5.1.1.35049, Culture=neutral, PublicKeyToken=e7570ab207bcb616
// MVID: 5BEDB485-56A9-4001-8E5C-95D46B1034CD
// Assembly location: C:\Users\Asus\OneDrive\Repos\MyDiary\packages\MvvmLightLibs.5.1.1.0\lib\net45\GalaSoft.MvvmLight.dll

namespace GalaSoft.MvvmLight.Messaging
{
  /// <summary>
  /// Base class for all messages broadcasted by the Messenger.
  /// You can create your own message types by extending this class.
  /// </summary>
  public class MessageBase
  {
    /// <summary>Initializes a new instance of the MessageBase class.</summary>
    public MessageBase()
    {
    }

    /// <summary>Initializes a new instance of the MessageBase class.</summary>
    /// <param name="sender">The message's original sender.</param>
    public MessageBase(object sender) => this.Sender = sender;

    /// <summary>Initializes a new instance of the MessageBase class.</summary>
    /// <param name="sender">The message's original sender.</param>
    /// <param name="target">The message's intended target. This parameter can be used
    /// to give an indication as to whom the message was intended for. Of course
    /// this is only an indication, amd may be null.</param>
    public MessageBase(object sender, object target)
      : this(sender)
      => this.Target = target;

    /// <summary>Gets or sets the message's sender.</summary>
    public object Sender { get; protected set; }

    /// <summary>
    /// Gets or sets the message's intended target. This property can be used
    /// to give an indication as to whom the message was intended for. Of course
    /// this is only an indication, amd may be null.
    /// </summary>
    public object Target { get; protected set; }
  }
}
