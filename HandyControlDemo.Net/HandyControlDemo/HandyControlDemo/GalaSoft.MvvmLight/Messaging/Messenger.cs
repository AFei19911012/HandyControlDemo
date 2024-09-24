// Decompiled with JetBrains decompiler
// Type: GalaSoft.MvvmLight.Messaging.Messenger
// Assembly: GalaSoft.MvvmLight, Version=5.1.1.35049, Culture=neutral, PublicKeyToken=e7570ab207bcb616
// MVID: 5BEDB485-56A9-4001-8E5C-95D46B1034CD
// Assembly location: C:\Users\Asus\OneDrive\Repos\MyDiary\packages\MvvmLightLibs.5.1.1.0\lib\net45\GalaSoft.MvvmLight.dll

using GalaSoft.MvvmLight.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace GalaSoft.MvvmLight.Messaging
{
  /// <summary>
  /// The Messenger is a class allowing objects to exchange messages.
  /// </summary>
  public class Messenger : IMessenger
  {
    private static readonly object CreationLock = new object();
    private static IMessenger _defaultInstance;
    private readonly object _registerLock = new object();
    private Dictionary<Type, List<Messenger.WeakActionAndToken>> _recipientsOfSubclassesAction;
    private Dictionary<Type, List<Messenger.WeakActionAndToken>> _recipientsStrictAction;
    private readonly SynchronizationContext _context = SynchronizationContext.Current;
    private bool _isCleanupRegistered;

    /// <summary>
    /// Gets the Messenger's default instance, allowing
    /// to register and send messages in a static manner.
    /// </summary>
    public static IMessenger Default
    {
      get
      {
        if (Messenger._defaultInstance == null)
        {
          bool lockTaken = false;
          object creationLock = null;
          try
          {
            Monitor.Enter(creationLock = Messenger.CreationLock, ref lockTaken);
            if (Messenger._defaultInstance == null)
              Messenger._defaultInstance = (IMessenger) new Messenger();
          }
          finally
          {
            if (lockTaken)
              Monitor.Exit(creationLock);
          }
        }
        return Messenger._defaultInstance;
      }
    }

    /// <summary>
    /// Registers a recipient for a type of message TMessage. The action
    /// parameter will be executed when a corresponding message is sent.
    /// <para>Registering a recipient does not create a hard reference to it,
    /// so if this recipient is deleted, no memory leak is caused.</para>
    /// </summary>
    /// <typeparam name="TMessage">The type of message that the recipient registers
    /// for.</typeparam>
    /// <param name="recipient">The recipient that will receive the messages.</param>
    /// <param name="action">The action that will be executed when a message
    /// of type TMessage is sent.</param>
    public virtual void Register<TMessage>(object recipient, Action<TMessage> action) => this.Register<TMessage>(recipient, (object) null, false, action);

    /// <summary>
    /// Registers a recipient for a type of message TMessage.
    /// The action parameter will be executed when a corresponding
    /// message is sent. See the receiveDerivedMessagesToo parameter
    /// for details on how messages deriving from TMessage (or, if TMessage is an interface,
    /// messages implementing TMessage) can be received too.
    /// <para>Registering a recipient does not create a hard reference to it,
    /// so if this recipient is deleted, no memory leak is caused.</para>
    /// </summary>
    /// <typeparam name="TMessage">The type of message that the recipient registers
    /// for.</typeparam>
    /// <param name="recipient">The recipient that will receive the messages.</param>
    /// <param name="receiveDerivedMessagesToo">If true, message types deriving from
    /// TMessage will also be transmitted to the recipient. For example, if a SendOrderMessage
    /// and an ExecuteOrderMessage derive from OrderMessage, registering for OrderMessage
    /// and setting receiveDerivedMessagesToo to true will send SendOrderMessage
    /// and ExecuteOrderMessage to the recipient that registered.
    /// <para>Also, if TMessage is an interface, message types implementing TMessage will also be
    /// transmitted to the recipient. For example, if a SendOrderMessage
    /// and an ExecuteOrderMessage implement IOrderMessage, registering for IOrderMessage
    /// and setting receiveDerivedMessagesToo to true will send SendOrderMessage
    /// and ExecuteOrderMessage to the recipient that registered.</para>
    /// </param>
    /// <param name="action">The action that will be executed when a message
    /// of type TMessage is sent.</param>
    public virtual void Register<TMessage>(
      object recipient,
      bool receiveDerivedMessagesToo,
      Action<TMessage> action)
    {
      this.Register<TMessage>(recipient, (object) null, receiveDerivedMessagesToo, action);
    }

    /// <summary>
    /// Registers a recipient for a type of message TMessage.
    /// The action parameter will be executed when a corresponding
    /// message is sent.
    /// <para>Registering a recipient does not create a hard reference to it,
    /// so if this recipient is deleted, no memory leak is caused.</para>
    /// </summary>
    /// <typeparam name="TMessage">The type of message that the recipient registers
    /// for.</typeparam>
    /// <param name="recipient">The recipient that will receive the messages.</param>
    /// <param name="token">A token for a messaging channel. If a recipient registers
    /// using a token, and a sender sends a message using the same token, then this
    /// message will be delivered to the recipient. Other recipients who did not
    /// use a token when registering (or who used a different token) will not
    /// get the message. Similarly, messages sent without any token, or with a different
    /// token, will not be delivered to that recipient.</param>
    /// <param name="action">The action that will be executed when a message
    /// of type TMessage is sent.</param>
    public virtual void Register<TMessage>(object recipient, object token, Action<TMessage> action) => this.Register<TMessage>(recipient, token, false, action);

    /// <summary>
    /// Registers a recipient for a type of message TMessage.
    /// The action parameter will be executed when a corresponding
    /// message is sent. See the receiveDerivedMessagesToo parameter
    /// for details on how messages deriving from TMessage (or, if TMessage is an interface,
    /// messages implementing TMessage) can be received too.
    /// <para>Registering a recipient does not create a hard reference to it,
    /// so if this recipient is deleted, no memory leak is caused.</para>
    /// </summary>
    /// <typeparam name="TMessage">The type of message that the recipient registers
    /// for.</typeparam>
    /// <param name="recipient">The recipient that will receive the messages.</param>
    /// <param name="token">A token for a messaging channel. If a recipient registers
    /// using a token, and a sender sends a message using the same token, then this
    /// message will be delivered to the recipient. Other recipients who did not
    /// use a token when registering (or who used a different token) will not
    /// get the message. Similarly, messages sent without any token, or with a different
    /// token, will not be delivered to that recipient.</param>
    /// <param name="receiveDerivedMessagesToo">If true, message types deriving from
    /// TMessage will also be transmitted to the recipient. For example, if a SendOrderMessage
    /// and an ExecuteOrderMessage derive from OrderMessage, registering for OrderMessage
    /// and setting receiveDerivedMessagesToo to true will send SendOrderMessage
    /// and ExecuteOrderMessage to the recipient that registered.
    /// <para>Also, if TMessage is an interface, message types implementing TMessage will also be
    /// transmitted to the recipient. For example, if a SendOrderMessage
    /// and an ExecuteOrderMessage implement IOrderMessage, registering for IOrderMessage
    /// and setting receiveDerivedMessagesToo to true will send SendOrderMessage
    /// and ExecuteOrderMessage to the recipient that registered.</para>
    /// </param>
    /// <param name="action">The action that will be executed when a message
    /// of type TMessage is sent.</param>
    public virtual void Register<TMessage>(
      object recipient,
      object token,
      bool receiveDerivedMessagesToo,
      Action<TMessage> action)
    {
      bool lockTaken1 = false;
      object registerLock = null;
      try
      {
        Monitor.Enter(registerLock = this._registerLock, ref lockTaken1);
        Type key = typeof (TMessage);
        Dictionary<Type, List<Messenger.WeakActionAndToken>> dictionary1;
        if (receiveDerivedMessagesToo)
        {
          if (this._recipientsOfSubclassesAction == null)
            this._recipientsOfSubclassesAction = new Dictionary<Type, List<Messenger.WeakActionAndToken>>();
          dictionary1 = this._recipientsOfSubclassesAction;
        }
        else
        {
          if (this._recipientsStrictAction == null)
            this._recipientsStrictAction = new Dictionary<Type, List<Messenger.WeakActionAndToken>>();
          dictionary1 = this._recipientsStrictAction;
        }
        bool lockTaken2 = false;
        Dictionary<Type, List<Messenger.WeakActionAndToken>> dictionary2 = null;
        try
        {
          Monitor.Enter((object) (dictionary2 = dictionary1), ref lockTaken2);
          List<Messenger.WeakActionAndToken> weakActionAndTokenList;
          if (!dictionary1.ContainsKey(key))
          {
            weakActionAndTokenList = new List<Messenger.WeakActionAndToken>();
            dictionary1.Add(key, weakActionAndTokenList);
          }
          else
            weakActionAndTokenList = dictionary1[key];
          WeakAction<TMessage> weakAction = new WeakAction<TMessage>(recipient, action);
          Messenger.WeakActionAndToken weakActionAndToken = new Messenger.WeakActionAndToken()
          {
            Action = (WeakAction) weakAction,
            Token = token
          };
          weakActionAndTokenList.Add(weakActionAndToken);
        }
        finally
        {
          if (lockTaken2)
            Monitor.Exit((object) dictionary2);
        }
      }
      finally
      {
        if (lockTaken1)
          Monitor.Exit(registerLock);
      }
      this.RequestCleanup();
    }

    /// <summary>
    /// Sends a message to registered recipients. The message will
    /// reach all recipients that registered for this message type
    /// using one of the Register methods.
    /// </summary>
    /// <typeparam name="TMessage">The type of message that will be sent.</typeparam>
    /// <param name="message">The message to send to registered recipients.</param>
    public virtual void Send<TMessage>(TMessage message) => this.SendToTargetOrType<TMessage>(message, (Type) null, (object) null);

    /// <summary>
    /// Sends a message to registered recipients. The message will
    /// reach only recipients that registered for this message type
    /// using one of the Register methods, and that are
    /// of the targetType.
    /// </summary>
    /// <typeparam name="TMessage">The type of message that will be sent.</typeparam>
    /// <typeparam name="TTarget">The type of recipients that will receive
    /// the message. The message won't be sent to recipients of another type.</typeparam>
    /// <param name="message">The message to send to registered recipients.</param>
    public virtual void Send<TMessage, TTarget>(TMessage message) => this.SendToTargetOrType<TMessage>(message, typeof (TTarget), (object) null);

    /// <summary>
    /// Sends a message to registered recipients. The message will
    /// reach only recipients that registered for this message type
    /// using one of the Register methods, and that are
    /// of the targetType.
    /// </summary>
    /// <typeparam name="TMessage">The type of message that will be sent.</typeparam>
    /// <param name="message">The message to send to registered recipients.</param>
    /// <param name="token">A token for a messaging channel. If a recipient registers
    /// using a token, and a sender sends a message using the same token, then this
    /// message will be delivered to the recipient. Other recipients who did not
    /// use a token when registering (or who used a different token) will not
    /// get the message. Similarly, messages sent without any token, or with a different
    /// token, will not be delivered to that recipient.</param>
    public virtual void Send<TMessage>(TMessage message, object token) => this.SendToTargetOrType<TMessage>(message, (Type) null, token);

    /// <summary>
    /// Unregisters a messager recipient completely. After this method
    /// is executed, the recipient will not receive any messages anymore.
    /// </summary>
    /// <param name="recipient">The recipient that must be unregistered.</param>
    public virtual void Unregister(object recipient)
    {
      Messenger.UnregisterFromLists(recipient, this._recipientsOfSubclassesAction);
      Messenger.UnregisterFromLists(recipient, this._recipientsStrictAction);
    }

    /// <summary>
    /// Unregisters a message recipient for a given type of messages only.
    /// After this method is executed, the recipient will not receive messages
    /// of type TMessage anymore, but will still receive other message types (if it
    /// registered for them previously).
    /// </summary>
    /// <param name="recipient">The recipient that must be unregistered.</param>
    /// <typeparam name="TMessage">The type of messages that the recipient wants
    /// to unregister from.</typeparam>
    public virtual void Unregister<TMessage>(object recipient) => this.Unregister<TMessage>(recipient, (object) null, (Action<TMessage>) null);

    /// <summary>
    /// Unregisters a message recipient for a given type of messages only and for a given token.
    /// After this method is executed, the recipient will not receive messages
    /// of type TMessage anymore with the given token, but will still receive other message types
    /// or messages with other tokens (if it registered for them previously).
    /// </summary>
    /// <param name="recipient">The recipient that must be unregistered.</param>
    /// <param name="token">The token for which the recipient must be unregistered.</param>
    /// <typeparam name="TMessage">The type of messages that the recipient wants
    /// to unregister from.</typeparam>
    public virtual void Unregister<TMessage>(object recipient, object token) => this.Unregister<TMessage>(recipient, token, (Action<TMessage>) null);

    /// <summary>
    /// Unregisters a message recipient for a given type of messages and for
    /// a given action. Other message types will still be transmitted to the
    /// recipient (if it registered for them previously). Other actions that have
    /// been registered for the message type TMessage and for the given recipient (if
    /// available) will also remain available.
    /// </summary>
    /// <typeparam name="TMessage">The type of messages that the recipient wants
    /// to unregister from.</typeparam>
    /// <param name="recipient">The recipient that must be unregistered.</param>
    /// <param name="action">The action that must be unregistered for
    /// the recipient and for the message type TMessage.</param>
    public virtual void Unregister<TMessage>(object recipient, Action<TMessage> action) => this.Unregister<TMessage>(recipient, (object) null, action);

    /// <summary>
    /// Unregisters a message recipient for a given type of messages, for
    /// a given action and a given token. Other message types will still be transmitted to the
    /// recipient (if it registered for them previously). Other actions that have
    /// been registered for the message type TMessage, for the given recipient and other tokens (if
    /// available) will also remain available.
    /// </summary>
    /// <typeparam name="TMessage">The type of messages that the recipient wants
    /// to unregister from.</typeparam>
    /// <param name="recipient">The recipient that must be unregistered.</param>
    /// <param name="token">The token for which the recipient must be unregistered.</param>
    /// <param name="action">The action that must be unregistered for
    /// the recipient and for the message type TMessage.</param>
    public virtual void Unregister<TMessage>(
      object recipient,
      object token,
      Action<TMessage> action)
    {
      Messenger.UnregisterFromLists<TMessage>(recipient, token, action, this._recipientsStrictAction);
      Messenger.UnregisterFromLists<TMessage>(recipient, token, action, this._recipientsOfSubclassesAction);
      this.RequestCleanup();
    }

    /// <summary>
    /// Provides a way to override the Messenger.Default instance with
    /// a custom instance, for example for unit testing purposes.
    /// </summary>
    /// <param name="newMessenger">The instance that will be used as Messenger.Default.</param>
    public static void OverrideDefault(IMessenger newMessenger) => Messenger._defaultInstance = newMessenger;

    /// <summary>
    /// Sets the Messenger's default (static) instance to null.
    /// </summary>
    public static void Reset() => Messenger._defaultInstance = (IMessenger) null;

    /// <summary>
    /// Provides a non-static access to the static <see cref="M:GalaSoft.MvvmLight.Messaging.Messenger.Reset" /> method.
    /// Sets the Messenger's default (static) instance to null.
    /// </summary>
    public void ResetAll() => Messenger.Reset();

    private static void CleanupList(
      IDictionary<Type, List<Messenger.WeakActionAndToken>> lists)
    {
      if (lists == null)
        return;
      bool lockTaken = false;
      IDictionary<Type, List<Messenger.WeakActionAndToken>> dictionary = null;
      try
      {
        Monitor.Enter((object) (dictionary = lists), ref lockTaken);
        List<Type> typeList = new List<Type>();
        foreach (KeyValuePair<Type, List<Messenger.WeakActionAndToken>> list in (IEnumerable<KeyValuePair<Type, List<Messenger.WeakActionAndToken>>>) lists)
        {
          foreach (Messenger.WeakActionAndToken weakActionAndToken in list.Value.Where<Messenger.WeakActionAndToken>((Func<Messenger.WeakActionAndToken, bool>) (item => item.Action == null || !item.Action.IsAlive)).ToList<Messenger.WeakActionAndToken>())
            list.Value.Remove(weakActionAndToken);
          if (list.Value.Count == 0)
            typeList.Add(list.Key);
        }
        foreach (Type key in typeList)
          lists.Remove(key);
      }
      finally
      {
        if (lockTaken)
          Monitor.Exit((object) dictionary);
      }
    }

    private static void SendToList<TMessage>(
      TMessage message,
      IEnumerable<Messenger.WeakActionAndToken> weakActionsAndTokens,
      Type messageTargetType,
      object token)
    {
      if (weakActionsAndTokens == null)
        return;
      List<Messenger.WeakActionAndToken> list = weakActionsAndTokens.ToList<Messenger.WeakActionAndToken>();
      foreach (Messenger.WeakActionAndToken weakActionAndToken in list.Take<Messenger.WeakActionAndToken>(list.Count<Messenger.WeakActionAndToken>()).ToList<Messenger.WeakActionAndToken>())
      {
        if (weakActionAndToken.Action is IExecuteWithObject action && weakActionAndToken.Action.IsAlive && weakActionAndToken.Action.Target != null && (messageTargetType == null || weakActionAndToken.Action.Target.GetType() == messageTargetType || messageTargetType.GetTypeInfo().IsAssignableFrom(weakActionAndToken.Action.Target.GetType().GetTypeInfo())) && (weakActionAndToken.Token == null && token == null || weakActionAndToken.Token != null && weakActionAndToken.Token.Equals(token)))
          action.ExecuteWithObject((object) message);
      }
    }

    private static void UnregisterFromLists(
      object recipient,
      Dictionary<Type, List<Messenger.WeakActionAndToken>> lists)
    {
      if (recipient == null || lists == null || lists.Count == 0)
        return;
      bool lockTaken = false;
      Dictionary<Type, List<Messenger.WeakActionAndToken>> dictionary = null;
      try
      {
        Monitor.Enter((object) (dictionary = lists), ref lockTaken);
        foreach (Type key in lists.Keys)
        {
          foreach (Messenger.WeakActionAndToken weakActionAndToken in lists[key])
          {
            IExecuteWithObject action = (IExecuteWithObject) weakActionAndToken.Action;
            if (action != null && recipient == action.Target)
              action.MarkForDeletion();
          }
        }
      }
      finally
      {
        if (lockTaken)
          Monitor.Exit((object) dictionary);
      }
    }

    private static void UnregisterFromLists<TMessage>(
      object recipient,
      object token,
      Action<TMessage> action,
      Dictionary<Type, List<Messenger.WeakActionAndToken>> lists)
    {
      Type key = typeof (TMessage);
      if (recipient == null || lists == null || (lists.Count == 0 || !lists.ContainsKey(key)))
        return;
      bool lockTaken = false;
      Dictionary<Type, List<Messenger.WeakActionAndToken>> dictionary = null;
      try
      {
        Monitor.Enter((object) (dictionary = lists), ref lockTaken);
        foreach (Messenger.WeakActionAndToken weakActionAndToken in lists[key])
        {
          if (weakActionAndToken.Action is WeakAction<TMessage> action1 && recipient == action1.Target && (action == null || action.GetMethodInfo().Name == action1.MethodName) && (token == null || token.Equals(weakActionAndToken.Token)))
            weakActionAndToken.Action.MarkForDeletion();
        }
      }
      finally
      {
        if (lockTaken)
          Monitor.Exit((object) dictionary);
      }
    }

    /// <summary>
    /// Notifies the Messenger that the lists of recipients should
    /// be scanned and cleaned up.
    /// Since recipients are stored as <see cref="T:System.WeakReference" />,
    /// recipients can be garbage collected even though the Messenger keeps
    /// them in a list. During the cleanup operation, all "dead"
    /// recipients are removed from the lists. Since this operation
    /// can take a moment, it is only executed when the application is
    /// idle. For this reason, a user of the Messenger class should use
    /// <see cref="M:GalaSoft.MvvmLight.Messaging.Messenger.RequestCleanup" /> instead of forcing one with the
    /// <see cref="M:GalaSoft.MvvmLight.Messaging.Messenger.Cleanup" /> method.
    /// </summary>
    public void RequestCleanup()
    {
      if (this._isCleanupRegistered)
        return;
      Action cleanupAction = new Action(this.Cleanup);
      if (this._context != null)
        this._context.Post((SendOrPostCallback) (_ => cleanupAction()), (object) null);
      else
        cleanupAction();
      this._isCleanupRegistered = true;
    }

    /// <summary>
    /// Scans the recipients' lists for "dead" instances and removes them.
    /// Since recipients are stored as <see cref="T:System.WeakReference" />,
    /// recipients can be garbage collected even though the Messenger keeps
    /// them in a list. During the cleanup operation, all "dead"
    /// recipients are removed from the lists. Since this operation
    /// can take a moment, it is only executed when the application is
    /// idle. For this reason, a user of the Messenger class should use
    /// <see cref="M:GalaSoft.MvvmLight.Messaging.Messenger.RequestCleanup" /> instead of forcing one with the
    /// <see cref="M:GalaSoft.MvvmLight.Messaging.Messenger.Cleanup" /> method.
    /// </summary>
    public void Cleanup()
    {
      Messenger.CleanupList((IDictionary<Type, List<Messenger.WeakActionAndToken>>) this._recipientsOfSubclassesAction);
      Messenger.CleanupList((IDictionary<Type, List<Messenger.WeakActionAndToken>>) this._recipientsStrictAction);
      this._isCleanupRegistered = false;
    }

    private void SendToTargetOrType<TMessage>(
      TMessage message,
      Type messageTargetType,
      object token)
    {
      Type type1 = typeof (TMessage);
      if (this._recipientsOfSubclassesAction != null)
      {
        foreach (Type type2 in this._recipientsOfSubclassesAction.Keys.Take<Type>(this._recipientsOfSubclassesAction.Count<KeyValuePair<Type, List<Messenger.WeakActionAndToken>>>()).ToList<Type>())
        {
          List<Messenger.WeakActionAndToken> weakActionAndTokenList = (List<Messenger.WeakActionAndToken>) null;
          if (type1 == type2 || type1.GetTypeInfo().IsSubclassOf(type2) || type2.GetTypeInfo().IsAssignableFrom(type1.GetTypeInfo()))
          {
            bool lockTaken = false;
            Dictionary<Type, List<Messenger.WeakActionAndToken>> subclassesAction = null;
            try
            {
              Monitor.Enter((object) (subclassesAction = this._recipientsOfSubclassesAction), ref lockTaken);
              weakActionAndTokenList = this._recipientsOfSubclassesAction[type2].Take<Messenger.WeakActionAndToken>(this._recipientsOfSubclassesAction[type2].Count<Messenger.WeakActionAndToken>()).ToList<Messenger.WeakActionAndToken>();
            }
            finally
            {
              if (lockTaken)
                Monitor.Exit((object) subclassesAction);
            }
          }
          Messenger.SendToList<TMessage>(message, (IEnumerable<Messenger.WeakActionAndToken>) weakActionAndTokenList, messageTargetType, token);
        }
      }
      if (this._recipientsStrictAction != null)
      {
        List<Messenger.WeakActionAndToken> weakActionAndTokenList = (List<Messenger.WeakActionAndToken>) null;
        bool lockTaken = false;
        Dictionary<Type, List<Messenger.WeakActionAndToken>> recipientsStrictAction = null;
        try
        {
          Monitor.Enter((object) (recipientsStrictAction = this._recipientsStrictAction), ref lockTaken);
          if (this._recipientsStrictAction.ContainsKey(type1))
            weakActionAndTokenList = this._recipientsStrictAction[type1].Take<Messenger.WeakActionAndToken>(this._recipientsStrictAction[type1].Count<Messenger.WeakActionAndToken>()).ToList<Messenger.WeakActionAndToken>();
        }
        finally
        {
          if (lockTaken)
            Monitor.Exit((object) recipientsStrictAction);
        }
        if (weakActionAndTokenList != null)
          Messenger.SendToList<TMessage>(message, (IEnumerable<Messenger.WeakActionAndToken>) weakActionAndTokenList, messageTargetType, token);
      }
      this.RequestCleanup();
    }

    private struct WeakActionAndToken
    {
      public WeakAction Action;
      public object Token;
    }
  }
}
