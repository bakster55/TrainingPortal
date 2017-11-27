using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TrainingPortal.Data.Repositories;
using TrainingPortal.Models;

namespace TrainingPortal.Controllers
{
	public class TestController : Controller
	{
		private TestRepository testRepository;

		public TestController()
		{
			testRepository = new TestRepository();
		}

		public ActionResult Index(string courseId)
		{
			List<Test> tests = testRepository.GetList(courseId).Select(test => (Test)test).ToList();

			return View(tests);
		}

		public ActionResult Details(string id)
		{
			Test test = testRepository.Get(id);

			return View(test);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Test test, string courseId)
		{
			try
			{
				testRepository.Create(test, courseId);

				return RedirectToAction("Index", new { courseId = courseId });
			}
			catch
			{
				return View(test);
			}
		}

		public ActionResult Edit(string id)
		{
			Test test = testRepository.Get(id);

			return View(test);
		}

		[HttpPost]
		public ActionResult Edit(Test test, string courseId)
		{
			try
			{
				testRepository.Update(test);

				return RedirectToAction("Index", new { courseId = courseId });
			}
			catch
			{
				return View(test);
			}
		}

		public ActionResult Delete(string id)
		{
			Test test = testRepository.Get(id);

			return View(test);
		}

		[HttpPost]
		public ActionResult Delete(Test test, string courseId)
		{
			try
			{
				testRepository.Delete(test.Id);

				return RedirectToAction("Index", new { courseId = courseId });
			}
			catch
			{
				return View(test);
			}
		}
	}
}
