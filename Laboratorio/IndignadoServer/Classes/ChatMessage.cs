using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web;

public class ChatMessage
{
    private int _sender;
    private String _message;
    private int _room;

    private Boolean sentSender;
    private Boolean sentReceiver;

    public ChatMessage(int sender, String message , int room)
    {
        _sender = sender;
        _message = message;
        _room = room;
        sentSender = false;
        sentReceiver = false;
        
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

    public Boolean wasConsumedBySender(){
        return sentSender;
    }

    public Boolean wasConsumedByReceiver(){
        return sentReceiver;
    }

}