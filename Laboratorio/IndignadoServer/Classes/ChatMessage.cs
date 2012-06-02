using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;

public class ChatMessage
{
    private int _sender;
    private String _senderNick;
    private String _message;
    private int _room;
    private int _type; 

    private Boolean sentSender;
    private Boolean sentReceiver;

    // Los mensajes se cierra luego de cerrada la ventana del room
    private List<int> _closedBy;

    public ChatMessage(int sender, String senderNick, String message , int room, int type)
    {
        _sender = sender;
        _senderNick = senderNick;
        _message = message;
        _room = room;
        sentSender = false;
        sentReceiver = false;
        _type = type;
        _closedBy = new List<int>();
    }

    public int Sender
    {
        get
        {
            return _sender;
        }
        set
        {
            _sender = value;
        }
    }

    public String SenderNick
    {
        get
        {
            return _senderNick;
        }
        set
        {
            _senderNick = value;
        }
    }

    public int Type
    {
        get
        {
            return _type;
        }
        set
        {
            _type = value;
        }
    }

    public String Message
    {
        get
        {
            return _message;
        }
        set
        {
            _message = value;
        }
    }

    public int Room
    {
        get
        {
            return _room;
        }
        set
        {
            _room = value;
        }
    }

    // No usado en este momento
    public void consumed(int user)
    {
        if (user == _sender)
        {
            sentSender = true;
        }
        else
        {
            sentReceiver = true;
        }
    }

    // No usado en este momento
    public Boolean wasConsumedBySender(){
        return sentSender;
    }

    public Boolean wasConsumedByReceiver(){
        return sentReceiver;
    }

    public void Close(int userId)
    {
        if (!_closedBy.Contains(userId))
            _closedBy.Add(userId);
    }

    public Boolean wasClosedBy(int userId)
    {
        return _closedBy.Contains(userId);
    }

    public int GetClosedCount()
    {
        return _closedBy.Count;
    }

}