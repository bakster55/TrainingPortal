using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;
using TrainingPortal.Data.Interfaces;
using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Controllers
{
	[Authorize]
	public class CertificateController : Controller
	{
		private ICertificateRepository _certificateRepository;

		public CertificateController(ICertificateRepository certificateRepository)
		{
			if (certificateRepository == null)
			{
				throw new ArgumentNullException("certificateRepository");
			}

			_certificateRepository = certificateRepository;
		}

		public ActionResult Index(string courseId)
		{
			Certificate certificate = _certificateRepository.Get(User.Identity.GetUserId(), courseId);

			if (certificate != null)
			{
				return PartialView("Partials/Index", certificate);
			}
			else
			{
				return RedirectToAction("Details", "Course", new { Id = courseId });
			}
		}

		public ActionResult Details(string courseId)
		{
			Certificate certificate = _certificateRepository.Get(User.Identity.GetUserId(), courseId);

			if (certificate != null)
			{
				return View(certificate);
			}
			else
			{
				return RedirectToAction("Details", "Course", new { Id = courseId });
			}
		}

		public ActionResult Delete(string courseId)
		{
			Certificate certificate = _certificateRepository.Get(User.Identity.GetUserId(), courseId);

			if (certificate != null)
			{
				return View(certificate);
			}
			else
			{
				return RedirectToAction("Details", "Course", new { Id = courseId });
			}
		}

		[HttpPost]
		public ActionResult Delete(string courseId, Certificate certificate)
		{
			try
			{
				_certificateRepository.Delete(certificate.Id);

				return RedirectToAction("Details", "Course", new { Id = courseId });
			}
			catch
			{
				return View(certificate);
			}
		}
	}
}
