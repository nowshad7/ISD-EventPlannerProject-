using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventPlanner_.Models;
using System.Web.Security;

namespace EventPlanner_.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
		[HttpPost]
		public ActionResult Login(MemberShip model)
		{
			using (var context = new EventPlannerEntities())
			{
				bool isValid = context.Clients.Any(x => x.Email == model.Email && x.Password == model.Password);
				if (isValid)
				{
					FormsAuthentication.SetAuthCookie(model.Email, false);
					return RedirectToAction("Create", "EventOrders");
				}
				ModelState.AddModelError("", "Invalid Email or Password!");
				return View();
			}
				
		}
		public ActionResult Signup()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Signup(Clients model)
		{
			using (var context = new EventPlannerEntities())
			{
				context.Clients.Add(model);
				context.SaveChanges();
			}
			return RedirectToAction("Login");
		}

	}
}