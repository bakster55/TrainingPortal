using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TrainingPortal.Data.Interfaces;
using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Controllers
{
	public class LessonController : Controller
	{
		private ILessonRepository _lessonRepository;

		public LessonController(ILessonRepository lessonRepository)
		{
			if (lessonRepository == null)
			{
				throw new ArgumentNullException("lessonRepository");
			}

			_lessonRepository = lessonRepository;
		}

		[Authorize(Roles = "admin, editor")]
		public ActionResult Index(string courseId)
		{
			List<Lesson> lessons = _lessonRepository.GetList(courseId)?.Select(lesson => (Lesson)lesson).ToList();

			return View(lessons);
		}

		public ActionResult TakeCourse(string courseId, string lessonId)
		{
			List<Lesson> lessons = _lessonRepository.GetList(courseId)?.Select(l => (Lesson)l).ToList();
			ViewBag.Lessons = lessons;

			try
			{
				Lesson lesson = null;

				if (lessons != null && lessons.Count > 0)
				{
					if (!String.IsNullOrEmpty(lessonId))
					{
						lesson = lessons.Find(l => l.Id == lessonId);
					}

					if (lesson == null)
					{
						lesson = lessons[0];
					}
				}

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
			Lesson lesson = _lessonRepository.Get(id);

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
				_lessonRepository.Create(lesson, courseId);

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
			Lesson lesson = _lessonRepository.Get(id);

			return View(lesson);
		}

		[Authorize(Roles = "admin, editor")]
		[HttpPost]
		public ActionResult Edit(Lesson lesson, string courseId)
		{
			try
			{
				_lessonRepository.Update(lesson);

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
			Lesson lesson = _lessonRepository.Get(id);

			return View(lesson);
		}

		[Authorize(Roles = "admin, editor")]
		[HttpPost]
		public ActionResult Delete(Lesson lesson, string courseId)
		{
			try
			{
				_lessonRepository.Delete(lesson.Id);

				return RedirectToAction("Index", new { courseId = courseId });
			}
			catch
			{
				return View(lesson);
			}
		}
	}
}
