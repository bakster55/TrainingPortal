using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TrainingPortal.Data.Repositories;
using TrainingPortal.Models;

namespace TrainingPortal.Controllers
{
	public class CourseController : Controller
	{
		private CourseRepository courseRepository;
		private CategoryRepository categoryRepository;
		private CertificateRepository certificateRepository;
		private AudienceRepository audienceRepository;

		public CourseController()
		{
			courseRepository = new CourseRepository();
			categoryRepository = new CategoryRepository();
			audienceRepository = new AudienceRepository();
			certificateRepository = new CertificateRepository();
		}

		public ActionResult Index(string categoryId)
		{
			List<Course> courses = courseRepository.GetList().Select(course => (Course)course).ToList();

			if (!string.IsNullOrEmpty(categoryId))
			{
				courses = courses.Where(c => c.Category.Id == categoryId).ToList(); ;
			}

			List<Category> categories = categoryRepository.GetList().Select(course => (Category)course).ToList();
			ViewBag.Categories = categories;

			List<Audience> audienceList = audienceRepository.GetList().Select(audience => (Audience)audience).ToList();
			ViewBag.AudienceList = audienceList;

			return View(courses);
		}

		public PartialViewResult List(string categoryId, string audienceId, string courseName)
		{
			List<Course> courses = courseRepository.GetList().Select(course => (Course)course).ToList();

			if (!string.IsNullOrEmpty(categoryId))
			{
				courses = courses.Where(c => c.Category == null ? false : c.Category.Id == categoryId).ToList(); ;
			}

			if (!string.IsNullOrEmpty(audienceId))
			{
				courses = courses.Where(c => c.Audience == null ? false : c.Audience.Id == audienceId).ToList(); ;
			}

			if (!string.IsNullOrEmpty(courseName))
			{
				courses = courses.Where(c => c.Name.ToLower().StartsWith(courseName.ToLower())).ToList(); ;
			}

			return PartialView("Partials/Index", courses);
		}

		public ActionResult Details(string id)
		{
			Course course = courseRepository.Get(id);

			if (User.Identity.IsAuthenticated)
			{
				Certificate certificate = certificateRepository.Get(User.Identity.GetUserId(), id);
				if (certificate != null)
				{
					ViewBag.HasCertificate = true;
				}
			}

			return View(course);
		}

		public ActionResult Create()
		{
			CategoryRepository categoryRepository = new CategoryRepository();

			var categories = categoryRepository.GetList().Select(category => (Category)category);
			ViewBag.Categories = categories;

			List<Audience> audienceList = audienceRepository.GetList().Select(audience => (Audience)audience).ToList();
			ViewBag.AudienceList = audienceList;

			return View();
		}

		[HttpPost]
		public ActionResult Create(Course course)
		{
			try
			{
				courseRepository.Create(course);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(course);
			}
		}

		public ActionResult Edit(int id)
		{
			CategoryRepository categoryRepository = new CategoryRepository();

			var categories = categoryRepository.GetList().Select(category => (Category)category);
			ViewBag.Categories = categories;

			List<Audience> audienceList = audienceRepository.GetList().Select(audience => (Audience)audience).ToList();
			ViewBag.AudienceList = audienceList;

			Course course = courseRepository.Get(id.ToString());

			return View(course);
		}

		[HttpPost]
		public ActionResult Edit(int id, Course course)
		{
			try
			{
				courseRepository.Update(course);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(course);
			}
		}

		public ActionResult Delete(int id)
		{
			Course course = courseRepository.Get(id.ToString());

			return View(course);
		}

		[HttpPost]
		public ActionResult Delete(int id, Course course)
		{
			try
			{
				courseRepository.Delete(id.ToString());

				return RedirectToAction("Index");
			}
			catch
			{
				return View(course);
			}
		}
	}
}
