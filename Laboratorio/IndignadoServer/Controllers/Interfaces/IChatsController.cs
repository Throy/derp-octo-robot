using System.Collections.ObjectModel;
using IndignadoServer.LinqDataContext;
using System;
using System.Collections.Generic;
using IndignadoServer.Services;

namespace IndignadoServer.Controllers
{
    interface IChatsController
    {

        int initChat(int userinviting, int user);

        void leaveChat(int user, int room);

        void sendMesage(int user, int room,String message);

        List<DTChatMessage> checkMessages(int user);
    }
}
