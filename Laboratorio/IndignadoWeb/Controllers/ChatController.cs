using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndignadoWeb.Common;
using IndignadoWeb.Models;
using IndignadoWeb.SessionServiceReference;

namespace IndignadoWeb.Controllers
{
    [MultiTenanActionFilter]
    public class ChatController : Controller
    {
        //
        // GET: /Chat/

        public JsonResult StartSession()
        {
            ChatBox chatBox = new ChatBox();

            DTLoginInfo loginInfo = HttpContext.Session["loginInfo"] as DTLoginInfo;
            if (loginInfo != null)
                chatBox.username = loginInfo.name;
            else
                chatBox.username = "DonNadie";

            Message m = new Message();
            m.f = "Pancho";
            m.s = "1";
            m.m = "Test chat hardcoded";

            chatBox.items = new List<Message>();
            chatBox.items.Add(m);

            return Json(chatBox, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Heartbeat()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Close()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send()
        {
            return View();
        }

    }
}
