using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IndignadoServer.Services
{
    [ServiceContract]
    public interface IChatsService
    {
        [OperationContract]
        DTChatRoom initChatWith(int user);

        [OperationContract]
        void closeChat(int room);

        [OperationContract]
        void sendMesage(int type, int room, String message);

        [OperationContract]
        List<DTChatMessage> checkMessages(bool onlyUnConsumed);

        [OperationContract]
        void HeartBeat();

        [OperationContract]
        List<DTChatUser> GetUsersOnline(bool onlyUnConsumed);

        [OperationContract]
        int GetUsersOnlineCount();
    }
}
