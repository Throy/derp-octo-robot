using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using IndignadoServer.LinqDataContext;
using IndignadoServer.Services;

namespace IndignadoServer.Controllers
{
    class ChatManager
    {
        private static Dictionary<int, Dictionary<int,Chat>> chats;
        

        public ChatManager()
        {
            chats = new Dictionary<int, Dictionary<int, Chat>>();
        }

        public Chat getChat(int IdMovement , int roomID)
        {
            return chats[IdMovement][roomID];
        }

        public int newChat(int IdMovement, int userInviting, int user)
        {
            if (chats[IdMovement] == null ){
                chats.Add(IdMovement,new Dictionary<int,Chat>() );
            }
            foreach(Chat chataux in chats[IdMovement].Values){
                if (chataux.hasUsers(userInviting,user)){
                    return chataux.RoomID();
                }
            }
            Chat chat = new Chat(userInviting, user);
            chats[IdMovement].Add(chat.RoomID(), chat);
            return chat.RoomID();
        }

        public void closeChat(int IdMovement, int roomID)
        {
            try
            {
                chats[IdMovement].Remove(roomID);
            }
            catch
            {
            }           
        }

        public Boolean cointainsChat(int IdMovement , int roomID)
        {
            return chats[IdMovement][roomID] != null;
        }

        public List<Chat> getUserChats(int IdMovement, int user)
        {
            List<Chat> aux = new List<Chat>();
            foreach(Chat chataux in chats[IdMovement].Values){
                if (chataux.hasUser(user)){
                        aux.Add(chataux);
                }
            }
            return aux;
        }
    }


    class ChatsController: IndignadoController, IChatsController
    {
        private ChatManager manager;

        public ChatsController()
        {
            manager = new ChatManager();
        }

        public int initChat(int userinviting, int user)
        {
            return manager.newChat(IdMovement,userinviting, user);;
        }


        public void leaveChat(int user, int roomID)
        {
            manager.closeChat(IdMovement,roomID);   
        }

        public void sendMesage(int user, int roomID, String message)
        {
            Chat chat = manager.getChat(IdMovement, roomID);
            if (chat != null)
            {
                chat.addMessage(user, message);
            }
        }

        public List<DTChatMessage> checkMessages(int user)
        {
            List<Chat> chats = manager.getUserChats(IdMovement, user);
            List<DTChatMessage> resultM = new List<DTChatMessage>();
            foreach (Chat chat in chats)
            {
               List<ChatMessage> unconsumed = chat.getMesaggesFor(user);
               foreach (ChatMessage m in unconsumed)
               {
                   resultM.Add(ClassToDT.MessageToDT(m));
               }
               chat.refresh();
            }

            return resultM;
        }
    }
}
