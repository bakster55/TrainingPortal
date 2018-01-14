using log4net;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TrainingPortal.Data.Interfaces;
using TrainingPortal.Data.Repositories;
using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Controllers
{
	public class CourseController : Controller
	{
		private ICourseRepository _courseRepository;
		private ICategoryRepository _categoryRepository;
		private ICertificateRepository _certificateRepository;
		private IAudienceRepository _audienceRepository;
		private ILog logger = LogManager.GetLogger("Logger");

		public CourseController(
			ICourseRepository courseRepository,
			ICategoryRepository categoryRepository,
			ICertificateRepository certificateRepository,
			IAudienceRepository audienceRepository)
		{
			logger.Error("Error");
			if (courseRepository == null)
			{
				throw new ArgumentNullException("courseRepository");
			}

			if (categoryRepository == null)
			{
				throw new ArgumentNullException("categoryRepository");
			}

			if (certificateRepository == null)
			{
				throw new ArgumentNullException("certificateRepository");
			}

			if (audienceRepository == null)
			{
				throw new ArgumentNullException("audienceRepository");
			}

			_courseRepository = courseRepository;
			_categoryRepository = categoryRepository;
			_audienceRepository = audienceRepository;
			_certificateRepository = certificateRepository;
		}

		public ActionResult Index(string categoryId)
		{
			List<Course> courses = _courseRepository.GetList()?.Select(course => (Course)course).ToList();

			if (!string.IsNullOrEmpty(categoryId) && courses != null)
			{
				courses = courses.Where(c => c.Category.Id == categoryId).ToList(); ;
			}

			List<Category> categories = _categoryRepository.GetList()?.Select(course => (Category)course).ToList();
			ViewBag.Categories = categories;

			List<Audience> audienceList = _audienceRepository.GetList()?.Select(audience => (Audience)audience).ToList();
			ViewBag.AudienceList = audienceList;

			return View(courses);
		}

		public PartialViewResult List(string categoryId, string audienceId, string courseName)
		{
			List<Course> courses = _courseRepository.GetList()?.Select(course => (Course)course).ToList();

			if (!string.IsNullOrEmpty(categoryId) && courses != null)
			{
				courses = courses.Where(c => c.Category == null ? false : c.Category.Id == categoryId).ToList();
			}

			if (!string.IsNullOrEmpty(audienceId) && courses != null)
			{
				courses = courses.Where(c => c.Audience == null ? false : c.Audience.Id == audienceId).ToList();
			}

			if (!string.IsNullOrEmpty(courseName) && courses != null)
			{
				courses = courses.Where(c => c.Name.ToLower().StartsWith(courseName.ToLower())).ToList();
			}

			return PartialView("Partials/Index", courses);
		}

		public ActionResult Details(string id)
		{
			Course course = _courseRepository.Get(id);

			if (User.Identity.IsAuthenticated)
			{
				Certificate certificate = _certificateRepository.Get(User.Identity.GetUserId(), id);
				if (certificate != null)
				{
					ViewBag.HasCertificate = true;
				}
			}

			return View(course);
		}

		[Authorize(Roles = "admin, editor")]
		public ActionResult Create()
		{
			CategoryRepository categoryRepository = new CategoryRepository();

			var categories = categoryRepository.GetList()?.Select(category => (Category)category);
			ViewBag.Categories = categories;

			List<Audience> audienceList = _audienceRepository.GetList()?.Select(audience => (Audience)audience).ToList();
			ViewBag.AudienceList = audienceList;

			return View();
		}

		[Authorize(Roles = "admin, editor")]
		[HttpPost]
		public ActionResult Create(Course course)
		{
			try
			{
				_courseRepository.Create(course);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(course);
			}
		}

		[Authorize(Roles = "admin, editor")]
		public ActionResult Edit(int id)
		{
			CategoryRepository categoryRepository = new CategoryRepository();

			var categories = categoryRepository.GetList()?.Select(category => (Category)category);
			ViewBag.Categories = categories;

			List<Audience> audienceList = _audienceRepository.GetList()?.Select(audience => (Audience)audience).ToList();
			ViewBag.AudienceList = audienceList;

			Course course = _courseRepository.Get(id.ToString());

			return View(course);
		}

		[Authorize(Roles = "admin, editor")]
		[HttpPost]
		public ActionResult Edit(int id, Course course)
		{
			try
			{
				_courseRepository.Update(course);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(course);
			}
		}

		[Authorize(Roles = "admin, editor")]
		public ActionResult Delete(int id)
		{
			Course course = _courseRepository.Get(id.ToString());

			return View(course);
		}

		[Authorize(Roles = "admin, editor")]
		[HttpPost]
		public ActionResult Delete(int id, Course course)
		{
			try
			{
				_courseRepository.Delete(id.ToString());

				return RedirectToAction("Index");
			}
			catch
			{
				return View(course);
			}
		}
	}
}
