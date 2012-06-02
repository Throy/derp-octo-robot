using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignadoWeb.Common;
using IndignadoWeb.Models;
using IndignadoWeb.SessionServiceReference;
using IndignadoWeb.ChatsServiceReference;
using System.ServiceModel;

namespace IndignadoWeb.Controllers
{
    [MultiTenanActionFilter]
    public class ChatController : Controller
    {
        private T GetService<T>(String url)
        {
            var binding = new WSHttpBinding();
            binding.Security.Mode = SecurityMode.Message;
            binding.Security.Message.ClientCredentialType = MessageCredentialType.UserName;

            ChannelFactory<T> scf;
            scf = new ChannelFactory<T>(
                        binding,
                        url);

            DTTenantInfo tenantInfo = HttpContext.Session["tenantInfo"] as DTTenantInfo;

            scf.Credentials.UserName.UserName = tenantInfo.id.ToString(); // idMovimiento
            scf.Credentials.UserName.Password = (HttpContext.Session["token"] == null) ? "Guest" : HttpContext.Session["token"].ToString();

            return scf.CreateChannel();
        }

        //
        // GET: /Chat/
        
        public JsonResult StartSession()
        {
            IChatsService serv = GetService<IChatsService>("http://localhost:8730/IndignadoServer/ChatsService/");

            ChatModel chatModel = new ChatModel();

            DTLoginInfo loginInfo = HttpContext.Session["loginInfo"] as DTLoginInfo;
            if (loginInfo != null)
            {
                serv.HeartBeat();
                chatModel.username = loginInfo.name;
                chatModel.items = serv.checkMessages(false);
                chatModel.usersOnline = serv.GetUsersOnline(false);
                // Yo no cuento como otro usario online por eso el -1
                chatModel.usersCount = serv.GetUsersOnlineCount() - 1;
            }
            else
            {
                chatModel.username = "DonNadie";
                chatModel.items = new List<DTChatMessage>();
            }

            /*DTChatMessage message = new DTChatMessage();
            message.from = "Pancho";
            message.type = 0;
            message.message = "Hardcoded message!";

            chatModel.items.Add(message);*/

            (serv as ICommunicationObject).Close();

            return Json(chatModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InitChatBox(int userId)
        {
            IChatsService serv = GetService<IChatsService>("http://localhost:8730/IndignadoServer/ChatsService/");

            DTLoginInfo loginInfo = HttpContext.Session["loginInfo"] as DTLoginInfo;

            DTChatRoom room = new DTChatRoom();
            if (loginInfo != null)
            {
                room = serv.initChatWith(userId);
            }

            (serv as ICommunicationObject).Close();

            return Json(room, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Heartbeat()
        {
            IChatsService serv = GetService<IChatsService>("http://localhost:8730/IndignadoServer/ChatsService/");

            ChatModel chatModel = new ChatModel();

            DTLoginInfo loginInfo = HttpContext.Session["loginInfo"] as DTLoginInfo;
            if (loginInfo != null)
            {
                serv.HeartBeat();
                chatModel.username = loginInfo.name;
                chatModel.items = serv.checkMessages(true);
                chatModel.usersOnline = serv.GetUsersOnline(true);
                chatModel.usersCount = serv.GetUsersOnlineCount();
                // Yo no cuento como otro usario online por eso el -1
                chatModel.usersCount = serv.GetUsersOnlineCount() - 1;
            }

            (serv as ICommunicationObject).Close();

            return Json(chatModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Close(int roomId)
        {
            IChatsService serv = GetService<IChatsService>("http://localhost:8730/IndignadoServer/ChatsService/");

            DTLoginInfo loginInfo = HttpContext.Session["loginInfo"] as DTLoginInfo;
            if (loginInfo != null)
            {
                serv.closeChat(roomId);
            }

            (serv as ICommunicationObject).Close();

            return Content("1");
        }

        [HttpPost]
        public ActionResult Send(int roomId, String message)
        {
            IChatsService serv = GetService<IChatsService>("http://localhost:8730/IndignadoServer/ChatsService/");

            DTLoginInfo loginInfo = HttpContext.Session["loginInfo"] as DTLoginInfo;
            if (loginInfo != null)
            {
                serv.sendMesage(0, roomId, message);
            }

            (serv as ICommunicationObject).Close();

            return Content("1");
        }

    }
}
