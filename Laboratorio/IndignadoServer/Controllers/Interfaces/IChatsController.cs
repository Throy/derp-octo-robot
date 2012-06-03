using System.Collections.ObjectModel;
using IndignadoServer.LinqDataContext;
using System;
using System.Collections.Generic;
using IndignadoServer.Services;

namespace IndignadoServer.Controllers
{
    interface IChatsController
    {

        DTChatRoom initChatWith(int user);

        void leaveChat(int room);

        void sendMesage(int type, int room, String message);

        List<DTChatMessage> checkMessages(bool onlyUnConsumed);

        void HeartBeat();

        List<DTChatUser> GetUsersOnline(bool onlyUnConsumed);

        int GetUsersOnlineCount();
    }
}
