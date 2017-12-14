﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TrainingPortal.Data.Repositories;
using TrainingPortal.Models;
using TrainingPortal.Web.Data.TestService;
using TrainingPortal.Web.Data.TestOptionService;
using TrainingPortal.Web.Data.CertificateService;

namespace TrainingPortal.Controllers
{
	public class TestController : Controller
	{
		private ITestService _testRepository;
		private ITestOptionService _testOptionRepository;
		private ICertificateService _certificateRepository;

		public TestController(
			ITestService testRepository,
			ITestOptionService testOptionRepository,
			ICertificateService certificateRepository)
		{
			_testRepository = testRepository;
			_testOptionRepository = testOptionRepository;
			_certificateRepository = certificateRepository;
		}

		[Authorize(Roles = "admin, editor")]
		public ActionResult Index(string courseId)
		{
			List<Test> tests = _testRepository.GetList(courseId).Select(test => (Test)test).ToList();

			return View(tests);
		}

		public ActionResult WriteTest(string courseId)
		{
			List<Test> tests = _testRepository.GetList(courseId).Select(test => (Test)test).ToList();

			for (int i = 0; i < tests.Count; i++)
			{
				Test test = tests[i];

				test.Options = _testOptionRepository.GetList(test.Id).Select(to =>
				{
					to.IsChecked = false;
					return (TestOption)to;
				}).ToList();
			}

			return View(tests);
		}

		[HttpPost]
		public ActionResult WriteTest(List<Test> tests, string courseId)
		{
			Certificate certificate = _certificateRepository.Get(User.Identity.GetUserId(), courseId);

			if (certificate == null)
			{
				List<Test> testsAnswers = _testRepository.GetList(courseId).Select(test => (Test)test).ToList();

				int count = 0;

				for (int i = 0; i < tests.Count; i++)
				{
					bool result = true;
					Test testAnswers = testsAnswers[i];
					testAnswers.Options = _testOptionRepository.GetList(testAnswers.Id).Select(to => (TestOption)to).ToList();
					Test test = tests[i];

					if (testAnswers.Options != null)
					{
						for (int j = 0; j < testAnswers.Options.Count; j++)
						{
							TestOption option = testAnswers.Options[j];

							if (testAnswers.Options[j].IsChecked != test.Options[j].IsChecked)
							{
								result = false;
								break;
							}
						}
					}

					if (result)
					{
						count++;
					}
				}

				_certificateRepository.Create(new Certificate
				{
					Id = Guid.NewGuid(),
					UserId = User.Identity.GetUserId(),
					CourseId = courseId,
					Result = (100 * count / tests.Count)
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
