using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventPlanner_.Models;
using EventPlanner_.Controllers;
using EventPlanner_;


namespace EventPlanner_.Controllers
{

	public class HomeController : Controller
	{
		Client client = null;


		public HomeController()
		{
			client = new Client();

		}
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "About page.";

			return View();
		}


		public ActionResult Service()
		{
			ViewBag.Message = "service page.";

			return View();
		}
		public ActionResult ClientRegister()
		{
			ViewBag.Message = "Register page.";

			return View();
		}

		



		public ActionResult Contact()
		{

			return View();
		}









		
			
		}

	}
