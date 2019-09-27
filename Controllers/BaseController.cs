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
            ViewBag.NotifyMessage += "$.notify({message:'" + mensagem + "'},{type:'" + notifyTypeMessage + "', placement:{from: 'top',align: 'left'}});";
        }

        public void AddErrors()
        {
            foreach(var d in ViewData.ModelState.Values)
            {
                foreach (var error in d.Errors)
                {
                    NotifyMessage(NotifyTypeEnum.danger, error.ErrorMessage);
                }
            }
        }

    }
}
