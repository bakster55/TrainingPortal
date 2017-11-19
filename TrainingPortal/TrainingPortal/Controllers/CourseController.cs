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
		// GET: Course
		public ActionResult Index()
		{
			List<Course> courses = CourseRepository.GetCourses();

			return View(courses);
		}

		// GET: Course/Details/5
		public ActionResult Details(int id)
		{
			Course course = CourseRepository.GetCourse(id);

			return View(course);
		}

		// GET: Course/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Course/Create
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

		// GET: Course/Edit/5
		public ActionResult Edit(int id)
		{
			Course course = CourseRepository.GetCourse(id);

			return View(course);
		}

		// POST: Course/Edit/5
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
				return View();
			}
		}

		// GET: Course/Delete/5
		public ActionResult Delete(int id)
		{
			Course course = CourseRepository.GetCourse(id);

			return View(course);
		}

		// POST: Course/Delete/5
		[HttpPost]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				CourseRepository.DeleteCourse(id);

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}
