using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingPortal.Models;

namespace TrainingPortal.Controllers
{
	public class CourseController : Controller
	{
		public ActionResult Index()
		{
			List<Course> courses = CourseRepository.GetCourses();

			return View(courses);
		}

		public ActionResult Details(int id)
		{
			Course course = CourseRepository.GetCourse(id);

			return View(course);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Course course)
		{
			try
			{
				CourseRepository.CreateCourse(course);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(course);
			}
		}

		public ActionResult Edit(int id)
		{
			Course course = CourseRepository.GetCourse(id);

			return View(course);
		}

		[HttpPost]
		public ActionResult Edit(int id, Course course)
		{
			try
			{
				CourseRepository.UpdateCourse(id, course);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(course);
			}
		}

		public ActionResult Delete(int id)
		{
			Course course = CourseRepository.GetCourse(id);

			return View(course);
		}

		[HttpPost]
		public ActionResult Delete(int id, Course course)
		{
			try
			{
				CourseRepository.DeleteCourse(id);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(course);
			}
		}
	}
}
