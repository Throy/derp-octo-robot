using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using IndignadoServer.Controllers;

namespace IndignadoServer.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ChatsService" in both code and config file together.
    public class ChatsService : IChatsService
    {

        public DTChatRoom initChatWith(int user)
        {
            return ControllersHub.Instance.getIChatsController().initChatWith(user);
        }


        public void closeChat(int room){
            ControllersHub.Instance.getIChatsController().leaveChat(room);
        }

        public void sendMesage(int type, int room, String message){
            ControllersHub.Instance.getIChatsController().sendMesage(type, room, message);
        }

        public List<DTChatMessage> checkMessages(bool onlyUnConsumed)
        {
            List<DTChatMessage> result = ControllersHub.Instance.getIChatsController().checkMessages(onlyUnConsumed);
            return result;
        }

        public void HeartBeat()
        {
            ControllersHub.Instance.getIChatsController().HeartBeat();
        }

        public List<DTChatUser> GetUsersOnline(bool onlyUnConsumed)
        {
            return ControllersHub.Instance.getIChatsController().GetUsersOnline(onlyUnConsumed);
        }

        public int GetUsersOnlineCount()
        {
            return ControllersHub.Instance.getIChatsController().GetUsersOnlineCount();
        }
    }
}
