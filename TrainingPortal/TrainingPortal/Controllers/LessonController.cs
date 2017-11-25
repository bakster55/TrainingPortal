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

		public ActionResult Index(string courseId)
		{
			List<Lesson> lessons = lessonRepository.GetList(courseId).Select(lesson => (Lesson)lesson).ToList();

			return View(lessons);
		}

		public ActionResult Details(string id)
		{
			Lesson lesson = lessonRepository.Get(id);

			return View(lesson);
		}

		public ActionResult Create()
		{
			return View();
		}

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

		public ActionResult Edit(string id)
		{
			Lesson lesson = lessonRepository.Get(id);

			return View(lesson);
		}

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

		public ActionResult Delete(string id)
		{
			Lesson lesson = lessonRepository.Get(id);

			return View(lesson);
		}

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
