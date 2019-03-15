using Gaditas.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gaditas.Controllers
{
    public class BaseController : Controller
    {
        public void NotifyMessage(NotifyTypeEnum notifyTypeMessage, string mensagem)
        {
            ViewBag.NotifyMessage = "$.notify({message:'" + mensagem + "'},{type:'" + notifyTypeMessage + "', placement:{from: 'top',align: 'left'}});";
        }
    }
}
