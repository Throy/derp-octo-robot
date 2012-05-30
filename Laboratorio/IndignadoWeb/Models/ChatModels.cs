using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndignadoWeb.Models
{
    public class Message
    {
        public String s { get; set; }
        public String f { get; set; }
        public String m { get; set; }
    }

    public class ChatBox
    {
        public String username { get; set; }
        public List<Message> items { get; set; }
    }
}