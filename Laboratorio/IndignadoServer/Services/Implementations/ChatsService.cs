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


        public int initChat(int userinviting, int user)
        {
            return ControllersHub.Instance.getIChatsController().initChat(userinviting,user);
        }


        public void closeChat(int user, int room){
            ControllersHub.Instance.getIChatsController().leaveChat(user,room);
        }

        public void sendMesage(int user, int room, String message){
            ControllersHub.Instance.getIChatsController().sendMesage(user,room,message);
        }

        public List<DTChatMessage> checkMessages(int user)
        {
            List<DTChatMessage> result = ControllersHub.Instance.getIChatsController().checkMessages(user);
            return result;
        }

    }
}
