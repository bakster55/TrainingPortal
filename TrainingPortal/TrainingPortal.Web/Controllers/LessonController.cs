using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TrainingPortal.Data.Repositories;
using TrainingPortal.Models;

namespace TrainingPortal.Controllers
{
	public class LessonController : Controller
	{
		private LessonRepository lessonRepository;

		public LessonController()
		{
			lessonRepository = new LessonRepository();
		}

		[Authorize(Roles = "admin, editor")]
		public ActionResult Index(string courseId)
		{
			List<Lesson> lessons = lessonRepository.GetList(courseId).Select(lesson => (Lesson)lesson).ToList();

			if (User.IsInRole("Admin"))
			{
				return View(lessons);
			}
			else
			{
				return View("TakeCourse", lessons);
			}
		}

		public ActionResult TakeCourse(string courseId, string lessonId = null)
		{
			List<Lesson> lessons = lessonRepository.GetList(courseId).Select(l => (Lesson)l).ToList();
			ViewBag.Lessons = lessons;

			try
			{
				Lesson lesson = lessons.Find(l => l.Id == lessonId);
				return View(lesson);
			}
			catch
			{
				return View();
			}
			
		}

		[Authorize(Roles = "admin, editor")]
		public ActionResult Details(string id)
		{
			Lesson lesson = lessonRepository.Get(id);

			return View(lesson);
		}

		[Authorize(Roles = "admin, editor")]
		public ActionResult Create()
		{
			return View();
		}

		[Authorize(Roles = "admin, editor")]
		[HttpPost]
		public ActionResult Create(Lesson lesson, string courseId)
		{
			try
			{
				lessonRepository.Create(lesson, courseId);

				return RedirectToAction("Index", new { courseId = courseId });
			}
			catch
			{
				return View(lesson);
			}
		}

		[Authorize(Roles = "admin, editor")]
		public ActionResult Edit(string id)
		{
			Lesson lesson = lessonRepository.Get(id);

			return View(lesson);
		}

		[Authorize(Roles = "admin, editor")]
		[HttpPost]
		public ActionResult Edit(Lesson lesson, string courseId)
		{
			try
			{
				lessonRepository.Update(lesson);

				return RedirectToAction("Index", new { courseId = courseId });
			}
			catch
			{
				return View(lesson);
			}
		}

		[Authorize(Roles = "admin, editor")]
		public ActionResult Delete(string id)
		{
			Lesson lesson = lessonRepository.Get(id);

			return View(lesson);
		}

		[Authorize(Roles = "admin, editor")]
		[HttpPost]
		public ActionResult Delete(Lesson lesson, string courseId)
		{
			try
			{
				lessonRepository.Delete(lesson.Id);

				return RedirectToAction("Index", new { courseId = courseId });
			}
			catch
			{
				return View(lesson);
			}
		}
	}
}
