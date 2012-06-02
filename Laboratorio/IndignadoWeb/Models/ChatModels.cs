using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IndignadoWeb.ChatsServiceReference;

namespace IndignadoWeb.Models
{

    public class ChatModel
    {
        public String username { get; set; }
        public List<DTChatMessage> items { get; set; }
        public List<DTChatUser> usersOnline { get; set; }
        public int usersCount { get; set; }
    }

}