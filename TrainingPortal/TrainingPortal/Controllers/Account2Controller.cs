//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.Net.Http;
//using TrainingPortal.Models;
//using System.Security.Cryptography;
//using System.Text;
//using Microsoft.AspNet.Identity;

//namespace TrainingPortal.Controllers
//{
//	public class AccountController : Controller
//	{
//		private static readonly HttpClient client = new HttpClient();
//		private static readonly string url = "http://localhost:50902/";

//		// GET: Account
//		public ActionResult Index()
//		{
//			return View();
//		}

//		public ActionResult Register()
//		{
//			return View();
//		}

//		[HttpPost]
//		public ActionResult Register(RegisterViewModel registerViewModel)
//		{
//			if (ModelState.IsValid)
//			{
//				string passwordHash = MD5.Create().ComputeHash(Encoding.Unicode.GetBytes(registerViewModel.Password)).ToString();
//				var a = User;
//				var values = new Dictionary<string, string>	{
//					{ "name", registerViewModel.Name },
//					{ "email", registerViewModel.Email },
//					{ "passwordHash",  }
//				};

//				var content = new FormUrlEncodedContent(values);

//				var response = client.PostAsync(url + "api/User", content);
//				response.Wait();

//				var responseString = response.Result.Content.ReadAsStringAsync();
//			}

//			return View(registerViewModel);
//		}
//	}
//}