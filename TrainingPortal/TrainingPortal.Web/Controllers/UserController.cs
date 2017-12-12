using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrainingPortal.Models;

namespace TrainingPortal.Controllers
{
	[Authorize(Roles = "admin")]
	public class UserController : Controller
	{
		private ApplicationSignInManager _signInManager;
		private ApplicationUserManager _userManager;

		public UserController()
		{
		}

		public UserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
		{
			ApplicationUserManager = userManager;
			SignInManager = signInManager;
		}

		public ApplicationSignInManager SignInManager
		{
			get
			{
				return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
			}
			private set
			{
				_signInManager = value;
			}
		}

		public ApplicationUserManager ApplicationUserManager
		{
			get
			{
				return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			}
			private set
			{
				_userManager = value;
			}
		}

		public ActionResult Index()
		{
			List<ApplicationUser> users = ApplicationUserManager.Users.ToList();

			return View(users);
		}

		public async Task<ActionResult> Details(int id)
		{
			ApplicationUser user = await ApplicationUserManager.FindByIdAsync(id.ToString());

			return View(user);
		}

		public ActionResult ChangePassword(int id)
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> ChangePassword(int id, ChangePasswordAdminViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			ApplicationUser user = await ApplicationUserManager.FindByIdAsync(id.ToString());
			var userStore = new UserStore();
			string passwordHash = ApplicationUserManager.PasswordHasher.HashPassword(model.NewPassword);
			await userStore.SetPasswordHashAsync(user, passwordHash);

			var result = ApplicationUserManager.Update(user);
			if (result.Succeeded)
			{
				return RedirectToAction("Details", user);
			}

			AddErrors(result);
			return View(model);
		}

		public async Task<ActionResult> ChangeProfile(int id)
		{
			ApplicationUser applicationUser = await ApplicationUserManager.FindByIdAsync(id.ToString());

			return View(applicationUser);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> ChangeProfile(ApplicationUser user)
		{
			if (!ModelState.IsValid)
			{
				return View(user);
			}
			var result = await ApplicationUserManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				return RedirectToAction("Index");
			}
			AddErrors(result);
			return View(user);
		}

		public async Task<ActionResult> ChangeRole(int id)
		{
			ApplicationUser applicationUser = await ApplicationUserManager.FindByIdAsync(id.ToString());

			RoleManager<Role> roleManager = new RoleManager<Role>(new RoleStore());
			ViewBag.Roles  = roleManager.Roles.Select(r => r.Name).ToList();
			ViewBag.UserRoles = ApplicationUserManager.GetRoles(id.ToString());

			return View(applicationUser);
		}

		[HttpPost]
		public void AddToRole(int id, string roleName)
		{
			ApplicationUserManager.AddToRole(id.ToString(), roleName);
		}

		[HttpPost]
		public void RemoveFromRole(int id, string roleName)
		{
			ApplicationUserManager.RemoveFromRole(id.ToString(), roleName);
		}

		public async Task<ActionResult> Delete(int id)
		{
			ApplicationUser user = await ApplicationUserManager.FindByIdAsync(id.ToString());

			return View(user);
		}

		[HttpPost]
		public ActionResult Delete(ApplicationUser user)
		{
			try
			{
				ApplicationUserManager.Delete(user);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error);
			}
		}
	}
}
