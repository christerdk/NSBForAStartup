using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NSBForAStartup.AccountsService.Commands;

namespace NSBForAStartup.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Guid userId, string email)
        {
            MvcApplication.Bus.Send(new CreateNewUserCommand
                {
                    UserId = userId,
                    Email = email
                });
            return RedirectToAction("Index");
        }
    }
}
