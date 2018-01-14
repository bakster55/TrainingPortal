using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TrainingPortal.Data.Interfaces;
using TrainingPortal.Web.Business.Models;
using TrainingPortal.Web.Models.Services;

namespace TrainingPortal.Controllers
{
	public class TestController : Controller
	{
		private ITestService _testService;
		private ITestRepository _testRepository;
		private ICertificateRepository _certificateRepository;

		public TestController(
			ITestService testService,
			ITestRepository testRepository,
			ICertificateRepository certificateRepository)
		{
			if (testService == null)
			{
				throw new ArgumentNullException("testService");
			}

			if (testRepository == null)
			{
				throw new ArgumentNullException("testRepository");
			}

			if (certificateRepository == null)
			{
				throw new ArgumentNullException("certificateRepository");
			}

			_testService = testService;
			_testRepository = testRepository;
			_certificateRepository = certificateRepository;
		}

		[Authorize(Roles = "admin, editor")]
		public ActionResult Index(string courseId)
		{
			List<Test> tests = _testRepository.GetList(courseId)?.Select(test => (Test)test).ToList();

			return View(tests);
		}

		[Authorize]
		public ActionResult WriteTest(string courseId)
		{
			List<Test> tests = _testRepository.GetList(courseId)?.Select(test =>
				{
					test?.Options?.ForEach((to) =>
					{
						to.IsChecked = false;
					});

					return test;
				}).ToList();

			return View(tests);
		}

		[Authorize]
		[HttpPost]
		public ActionResult WriteTest(List<Test> tests, string courseId)
		{
			Certificate certificate = _certificateRepository.Get(User.Identity.GetUserId(), courseId);

			if (certificate == null)
			{
				int count = _testService.GetTrueAnswersCount(tests, courseId);

				_certificateRepository.Create(new Certificate
				{
					Id = Guid.NewGuid().ToString(),
					Date = DateTime.Now.Date,
					UserId = User.Identity.GetUserId(),
					CourseId = courseId,
					Result = (int)Math.Floor((double)100 * count / tests.Count)
				});
			}

			return RedirectToAction("Details", "Course", new
			{
				id = courseId
			});
		}

		[Authorize(Roles = "admin, editor")]
		public ActionResult Details(string id)
		{
			Test test = _testRepository.Get(id);

			return View(test);
		}

		[Authorize(Roles = "admin, editor")]
		public ActionResult Create()
		{
			return View();
		}

		[Authorize(Roles = "admin, editor")]
		[HttpPost]
		public ActionResult Create(Test test, string courseId)
		{
			try
			{
				_testRepository.Create(test, courseId);

				return RedirectToAction("Index", new { courseId = courseId });
			}
			catch
			{
				return View(test);
			}
		}

		[Authorize(Roles = "admin, editor")]
		public ActionResult Edit(string id)
		{
			Test test = _testRepository.Get(id);

			return View(test);
		}

		[Authorize(Roles = "admin, editor")]
		[HttpPost]
		public ActionResult Edit(Test test, string courseId)
		{
			try
			{
				_testRepository.Update(test);

				return RedirectToAction("Index", new { courseId = courseId });
			}
			catch
			{
				return View(test);
			}
		}

		[Authorize(Roles = "admin, editor")]
		public ActionResult Delete(string id)
		{
			Test test = _testRepository.Get(id);

			return View(test);
		}

		[Authorize(Roles = "admin, editor")]
		[HttpPost]
		public ActionResult Delete(Test test, string courseId)
		{
			try
			{
				_testRepository.Delete(test.Id);

				return RedirectToAction("Index", new { courseId = courseId });
			}
			catch
			{
				return View(test);
			}
		}
	}
}
