using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;


public class Chat
{
    private static int roomIDGenerator = 0;

    private int roomID;
    private List<int> chatters;
    private List<ChatMessage> messages;

    public Chat(int userInviting, int user){
        roomID = roomIDGenerator++;
        chatters = new List<int>();
        chatters.Add(userInviting);
        chatters.Add(user);
        messages = new List<ChatMessage>();
    }

    public int RoomID()
    {
        return roomID;
    }

    public void addMessage(int user, String message ){
        messages.Add(new ChatMessage(user, message,roomID));
    }

    public Boolean hasUsers(int user1, int user2)
    {
        return (chatters.Contains(user1) && chatters.Contains(user2));
    }

    public Boolean hasUser(int user)
    {
        return (chatters.Contains(user));
    }

    public List<ChatMessage> Messages()
    {
        return messages;
    }

    public List<ChatMessage> getMesaggesFor(int user)
    {
        List<ChatMessage> result = new List<ChatMessage>();
        foreach (ChatMessage m in messages){
            if (m.Sender == user && !m.wasConsumedBySender()){
                result.Add(m);
            }
            else if (!m.wasConsumedByReceiver())
            {
                result.Add(m);
            }
            m.consumed(user);
        }
        return result;
    }


    public void refresh()
    {
        List<ChatMessage> auxList = new List<ChatMessage>();

        foreach(ChatMessage aux in messages)
        {
            if (aux.wasConsumedByReceiver() && aux.wasConsumedBySender())
            {
                auxList.Add(aux);
            }
        }
        foreach (ChatMessage aux in auxList)
            messages.Remove(aux);
    }

    

}