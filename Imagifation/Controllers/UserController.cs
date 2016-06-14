using Imagifation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Imagifation.Controllers
{
    [Authorize(Roles = "Администратор")]
    public class UserController : Controller
    {
        private ImagifationContext db = new ImagifationContext();

        // отображение списка пользователей
        [HttpGet]
        public ActionResult Index()
        {
            var users = db.Users.ToList();

            List<Role> roles = db.Roles.ToList();
            roles.Insert(0, new Role { Name = "Все", Id = 0 });
            ViewBag.Roles = new SelectList(roles, "Id", "Name");

            /*if (!HttpContext.User.IsInRole("Администратор"))
            {
                users.ForEach(x => { x.Login = null; x.Password = null; });
            }*/
            return View(users);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        public ActionResult Delete(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
