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

		public CourseController()
		{
			courseRepository = new CourseRepository();
			categoryRepository = new CategoryRepository();
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

			return View(courses);
		}

		public ActionResult Details(int id)
		{
			Course course = courseRepository.Get(id.ToString());

			return View(course);
		}

		public ActionResult Create()
		{
			CategoryRepository categoryRepository = new CategoryRepository();

			var categories = categoryRepository.GetList().Select(category => (Category)category);
			ViewBag.Categories = categories;

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
