using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TrainingPortal.Data.Repositories;
using TrainingPortal.Models;
using TrainingPortal.Web.Data.TestOptionService;


namespace TrainingPortal.Controllers
{
	[Authorize(Roles = "admin, editor")]
	public class TestOptionController : Controller
	{
		private ITestOptionService _testOptionRepository;

		public TestOptionController(ITestOptionService testOptionRepository)
		{
			if (testOptionRepository == null)
			{
				throw new ArgumentNullException("testOptionRepository");
			}

			_testOptionRepository = testOptionRepository;
		}

		public ActionResult Index(string testId)
		{
			List<TestOption> options = _testOptionRepository.GetList(testId)?.Select(to => (TestOption)to).ToList();

			return View(options);
		}

		public ActionResult Details(string id)
		{
			TestOption option = _testOptionRepository.Get(id);

			return View(option);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(TestOption option, string testId)
		{
			try
			{
				_testOptionRepository.Create(option, testId);

				return RedirectToAction("Index", new { testId = testId });
			}
			catch
			{
				return View(option);
			}
		}

		public ActionResult Edit(string id)
		{
			TestOption option = _testOptionRepository.Get(id);

			return View(option);
		}

		[HttpPost]
		public ActionResult Edit(TestOption option, string testId)
		{
			try
			{
				_testOptionRepository.Update(option);

				return RedirectToAction("Index", new { testId = testId });
			}
			catch
			{
				return View(option);
			}
		}

		public ActionResult Delete(string id)
		{
			TestOption option = _testOptionRepository.Get(id);

			return View(option);
		}

		[HttpPost]
		public ActionResult Delete(TestOption option, string testId)
		{
			try
			{
				_testOptionRepository.Delete(option.Id);

				return RedirectToAction("Index", new { testId = testId });
			}
			catch
			{
				return View(option);
			}
		}
	}
}
