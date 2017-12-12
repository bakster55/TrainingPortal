using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TrainingPortal.Data.Repositories;
using TrainingPortal.Models;

namespace TrainingPortal.Controllers
{
	[Authorize]
	public class CertificateController : Controller
	{
		private CertificateRepository certificateRepository;

		public CertificateController()
		{
			certificateRepository = new CertificateRepository();
		}

		public ActionResult Details(string courseId)
		{
			Certificate certificate = certificateRepository.Get(User.Identity.GetUserId(), courseId);

			return View(certificate);
		}

		public ActionResult Delete(string courseId)
		{
			Certificate certificate = certificateRepository.Get(User.Identity.GetUserId(), courseId);

			return View(certificate);
		}

		[HttpPost]
		public ActionResult Delete(string id, Certificate certificate)
		{
			try
			{
				certificateRepository.Delete(id);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(certificate);
			}
		}
	}
}
