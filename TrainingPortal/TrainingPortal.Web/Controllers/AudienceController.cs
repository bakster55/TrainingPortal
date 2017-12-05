using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TrainingPortal.Data.Repositories;
using TrainingPortal.Models;

namespace TrainingPortal.Controllers
{
	public class AudienceController : Controller
	{
		private AudienceRepository audienceRepository;

		public AudienceController()
		{
			audienceRepository = new AudienceRepository();
		}

		public ActionResult Index()
		{
			List<Audience> audienceList = audienceRepository.GetList().Select(audience => (Audience)audience).ToList();

			return View(audienceList);
		}

		public ActionResult Details(string id)
		{
			Audience audience = audienceRepository.Get(id);

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
				audienceRepository.Create(audience);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(audience);
			}
		}

		public ActionResult Edit(int id)
		{
			Audience audience = audienceRepository.Get(id.ToString());

			return View(audience);
		}

		[HttpPost]
		public ActionResult Edit(int id, Audience audience)
		{
			try
			{
				audienceRepository.Update(audience);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(audience);
			}
		}

		public ActionResult Delete(int id)
		{
			Audience audience = audienceRepository.Get(id.ToString());

			return View(audience);
		}

		[HttpPost]
		public ActionResult Delete(int id, Audience audience)
		{
			try
			{
				audienceRepository.Delete(id.ToString());

				return RedirectToAction("Index");
			}
			catch
			{
				return View(audience);
			}
		}
	}
}
