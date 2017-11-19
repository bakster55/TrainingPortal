using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingPortal.Models;

namespace WebApplication1.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILog log = LogManager.GetLogger("Logger");

		public HomeController()
		{
			
		}

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}