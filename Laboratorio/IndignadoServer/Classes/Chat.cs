using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;

public class ChatUser : IEquatable<ChatUser>
{
    public int id { get; set; }
    public String nick { get; set; }

    public int activeCounter { get; set; }
    public bool active { get; set; }
    private List<int> _consumedBy;

    public ChatUser()
    {
        active = true;
        activeCounter = 0;
        _consumedBy = new List<int>();
    }

    public bool wasConsumedBy(int userId)
    {
        return _consumedBy.Contains(userId);
    }

    public int GetConsumedCount()
    {
        return _consumedBy.Count;
    }

    public void Consume(int userId)
    {
        if (!_consumedBy.Contains(userId))
            _consumedBy.Add(userId);
    }

    public void SetActive(bool active)
    {
        this.active = active;
        _consumedBy = new List<int>();
    }

    public override int GetHashCode()
    {
        return id;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as ChatUser);
    }

    public bool Equals(ChatUser obj)
    {
        return obj != null && obj.id == this.id;
    }
}

public class Chat
{
    private static int roomIDGenerator = 0;

    private int roomID;
    private Dictionary<int, ChatUser> chatters;
    private List<ChatMessage> messages;

    public Chat(ChatUser userInviting, ChatUser user)
    {
        roomID = roomIDGenerator++;
        chatters = new Dictionary<int, ChatUser>();
        chatters.Add(userInviting.id, userInviting);
        chatters.Add(user.id, user);
        messages = new List<ChatMessage>();
    }

    public int RoomID
    {
        get
        {
            return roomID;
        }
    }

    public void addMessage(int userId, String userNick, int type, String message)
    {
        messages.Add(new ChatMessage(userId, userNick, message, roomID, type));
    }

    public Boolean hasUsers(int userId1, int userId2)
    {
        return (chatters.ContainsKey(userId1) && chatters.ContainsKey(userId2));
    }

    public Boolean hasUser(int userId)
    {
        return (chatters.ContainsKey(userId));
    }

    public List<ChatMessage> Messages()
    {
        return messages;
    }

    public List<ChatMessage> getMesaggesFor(int user, bool onlyUnConsumed)
    {
        List<ChatMessage> result = new List<ChatMessage>();
        foreach (ChatMessage m in messages){
            // El mensaje se agrega localmente al chat cuando es enviado, no es necesario consumirlo, sino se ve doble
            //if (m.Sender == user && !m.wasConsumedBySender()){
            //    result.Add(m);
            //}
            //else 
            if (onlyUnConsumed && m.Sender != user && !m.wasConsumedByReceiver())
            {
                result.Add(m);
            }
            else if (!onlyUnConsumed && !m.wasClosedBy(user))
            {
                result.Add(m);
            }
            m.consumed(user);
        }
        return result;
    }

    // Ahora borra los mensajes que fueron cerrados por todos
    public void refresh()
    {
        List<ChatMessage> auxList = new List<ChatMessage>();

        foreach(ChatMessage aux in messages)
        {
            if (aux.GetClosedCount() == chatters.Count)
            {
                auxList.Add(aux);
            }
        }
        foreach (ChatMessage aux in auxList)
            messages.Remove(aux);
    }

    public String GetTitleFor(int userId)
    {
        String title = "";
        foreach (var pair in chatters)
        {
            if (pair.Key != userId)
                title += pair.Value.nick + " ";
        }

        return title;
    }

    public void Close(int userId)
    {
        foreach (ChatMessage message in messages)
        {
            message.Close(userId);
        }
    }

    public bool HasMessages()
    {
        return messages.Count > 0;
    }

}