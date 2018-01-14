using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TrainingPortal.Data.Interfaces;
using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Controllers
{
	[Authorize(Roles = "admin, editor")]
	public class AudienceController : Controller
	{
		private IAudienceRepository _audienceRepository;

		public AudienceController(IAudienceRepository audienceRepository)
		{
			if (audienceRepository == null)
			{
				throw new ArgumentNullException("audienceRepository");
			}

			_audienceRepository = audienceRepository;
		}

		public ActionResult Index()
		{
			List<Audience> audienceList = _audienceRepository.GetList()?.Select(audience => (Audience)audience).ToList();

			return View(audienceList);
		}

		public ActionResult Details(string id)
		{
			Audience audience = _audienceRepository.Get(id);

			return View(audience);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Audience audience)
		{
			try
			{
				_audienceRepository.Create(audience);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(audience);
			}
		}

		public ActionResult Edit(int id)
		{
			Audience audience = _audienceRepository.Get(id.ToString());

			return View(audience);
		}

		[HttpPost]
		public ActionResult Edit(int id, Audience audience)
		{
			try
			{
				_audienceRepository.Update(audience);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(audience);
			}
		}

		public ActionResult Delete(int id)
		{
			Audience audience = _audienceRepository.Get(id.ToString());

			return View(audience);
		}

		[HttpPost]
		public ActionResult Delete(int id, Audience audience)
		{
			try
			{
				_audienceRepository.Delete(id.ToString());

				return RedirectToAction("Index");
			}
			catch
			{
				return View(audience);
			}
		}
	}
}
