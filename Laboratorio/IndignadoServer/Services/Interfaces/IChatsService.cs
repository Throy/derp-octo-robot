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
        int initChat(int userinviting, int user);

        [OperationContract]
        void closeChat(int user, int room);

        [OperationContract]
        void sendMesage(int user, int room , String message);

        [OperationContract]
        List<DTChatMessage> checkMessages(int user);
    }
}
