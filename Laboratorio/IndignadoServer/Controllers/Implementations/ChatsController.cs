using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using IndignadoServer.LinqDataContext;
using IndignadoServer.Services;
using System.ServiceModel;
using System.Threading;

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

        public Chat newChat(int IdMovement, int userInviting, int user)
        {
            if (!chats.ContainsKey(IdMovement))
            {
                chats.Add(IdMovement, new Dictionary<int,Chat>());
            }
            foreach(Chat chataux in chats[IdMovement].Values)
            {
                if (chataux.hasUsers(userInviting, user))
                {
                    return chataux;
                }
            }
            Chat chat = new Chat(GetChatUser(userInviting), GetChatUser(user));
            chats[IdMovement].Add(chat.RoomID, chat);
            return chat;
        }

        public void closeChat(int IdMovement, int roomID, int userId)
        {
            if (chats.ContainsKey(IdMovement) && chats[IdMovement].ContainsKey(roomID))
            {
                chats[IdMovement][roomID].Close(userId);

                if (!chats[IdMovement][roomID].HasMessages())
                    chats[IdMovement].Remove(roomID);
            }       
        }

        public Boolean cointainsChat(int IdMovement, int roomID)
        {
            return chats.ContainsKey(IdMovement) && chats[IdMovement].ContainsKey(roomID);
        }

        public List<Chat> getUserChats(int IdMovement, int user)
        {
            List<Chat> aux = new List<Chat>();
            if (chats.ContainsKey(IdMovement))
            {
                foreach (Chat chataux in chats[IdMovement].Values)
                {
                    if (chataux.hasUser(user))
                    {
                        aux.Add(chataux);
                    }
                }
            }
            return aux;
        }

        private ChatUser GetChatUser(int userId)
        {
            var db = new IndignadoDBDataContext();
            var user = db.Usuarios.SingleOrDefault(u => (u.id == userId));

            if (user == null)
                throw new FaultException("Ese usuario no existe!");

            ChatUser chatUser = new ChatUser();
            chatUser.id = user.id;
            chatUser.nick = user.nombre;

            return chatUser;
        }
    }


    class ChatsController: IndignadoController, IChatsController
    {
        private ChatManager manager;
        private Timer _timer;
        private Dictionary<int, Dictionary<int, ChatUser>> _usersActive;

        public ChatsController()
        {
            manager = new ChatManager();
            _usersActive = new Dictionary<int, Dictionary<int, ChatUser>>();
            _timer = new Timer(new TimerCallback(RefreshUsersActive), _usersActive, 1000, 1000);
        }

        ~ ChatsController()
        {
            _timer.Dispose();
        }

        public DTChatRoom initChatWith(int user)
        {
            DTChatRoom room = new DTChatRoom();
            Chat chat = manager.newChat(IdMovement, UserInfo.Id, user);
            room.id = chat.RoomID;
            room.title = chat.GetTitleFor(UserInfo.Id);

            return room;
        }

        public void leaveChat(int roomID)
        {
            manager.closeChat(IdMovement, roomID, UserInfo.Id);
            manager.getChat(IdMovement, roomID).refresh();
        }

        public void sendMesage(int type, int roomID, String message)
        {
            Chat chat = manager.getChat(IdMovement, roomID);
            if (chat != null)
            {
                chat.addMessage(UserInfo.Id, UserInfo.Apodo, type, message);
            }
        }

        public List<DTChatMessage> checkMessages(bool onlyUnConsumed)
        {
            List<Chat> chats = manager.getUserChats(IdMovement, UserInfo.Id);
            List<DTChatMessage> resultM = new List<DTChatMessage>();
            foreach (Chat chat in chats)
            {
                List<ChatMessage> messages = chat.getMesaggesFor(UserInfo.Id, onlyUnConsumed);
                String roomTitle = chat.GetTitleFor(UserInfo.Id);
                foreach (ChatMessage m in messages)
                {
                    resultM.Add(ClassToDT.MessageToDT(m, roomTitle));
                }
                // Por ahora no quiero que se quiten para que cuando el usuario haga
                // reload vuelva a tener los mensajes de los chats que tenga abiertos
                // chat.refresh();
            }

            return resultM;
        }

        public void HeartBeat()
        {
            ChatUser user = new ChatUser();
            user.id = UserInfo.Id;
            user.nick = UserInfo.Apodo;

            if (!_usersActive.ContainsKey(IdMovement))
                _usersActive.Add(IdMovement, new Dictionary<int,ChatUser>());

            if (!_usersActive[IdMovement].ContainsKey(user.id))
            {
                _usersActive[IdMovement].Add(user.id, user);
            }
            else
            {
                if (!_usersActive[IdMovement][user.id].active)
                {
                    _usersActive[IdMovement][user.id].SetActive(true);
                }
                _usersActive[IdMovement][user.id].activeCounter = 0;
            }
        }

        public static void RefreshUsersActive(object o)
        {
            var _usersActive = o as Dictionary<int, Dictionary<int, ChatUser>>;

            foreach (var usersActive in _usersActive)
            {
                List<int> keys = new List<int>(usersActive.Value.Keys);
                foreach (int key in keys)
                {
                    usersActive.Value[key].activeCounter++;
                    if (usersActive.Value[key].activeCounter > 40 && usersActive.Value[key].active)
                    {
                        usersActive.Value[key].SetActive(false);
                    }
                    else if (!usersActive.Value[key].active)
                    {
                        int count = 0;
                        foreach (var pair in usersActive.Value)
                        {
                            if (pair.Value.active)
                                count++;
                        }

                        if (usersActive.Value[key].GetConsumedCount() == count)
                            usersActive.Value.Remove(key);
                    }
                }
            }
        }

        public List<DTChatUser> GetUsersOnline(bool onlyUnConsumed)
        {
            List<DTChatUser> dtList = new List<DTChatUser>();
            foreach (var pair in _usersActive[IdMovement])
            {
                if (pair.Key != UserInfo.Id && (!pair.Value.wasConsumedBy(UserInfo.Id) || !onlyUnConsumed))
                {
                    dtList.Add(ClassToDT.ChatUserToDT(pair.Value));
                    pair.Value.Consume(UserInfo.Id);
                }
            }

            return dtList;
        }

        public int GetUsersOnlineCount()
        {
            int count = 0;
            foreach (var pair in _usersActive[IdMovement])
            {
                if (pair.Value.active)
                    count++;
            }

            return count;
        }
    }
}
