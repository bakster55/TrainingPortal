using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TrainingPortal.Data.Repositories;
using TrainingPortal.Models;
using TrainingPortal.Web.Data.CertificateService;

namespace TrainingPortal.Controllers
{
	[Authorize]
	public class CertificateController : Controller
	{
		private ICertificateService _certificateRepository;

		public CertificateController(ICertificateService certificateRepository)
		{
			_certificateRepository = certificateRepository;
		}

		public ActionResult Details(string courseId)
		{
			Certificate certificate = _certificateRepository.Get(User.Identity.GetUserId(), courseId);

			return View(certificate);
		}

		public ActionResult Delete(string courseId)
		{
			Certificate certificate = _certificateRepository.Get(User.Identity.GetUserId(), courseId);

			return View(certificate);
		}

		[HttpPost]
		public ActionResult Delete(string id, Certificate certificate)
		{
			try
			{
				_certificateRepository.Delete(id);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(certificate);
			}
		}
	}
}
