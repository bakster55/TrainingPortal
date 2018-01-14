using TrainingPortal.Web.Data.LessonService;
using TrainingPortal.Data.Interfaces;
using System.Linq;
using TrainingPortal.Web.Data.Converters;
using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Data.Repositories
{
	public class LessonRepository : ILessonRepository
	{
		private LessonServiceClient lessonServiceClient;

		public LessonRepository()
		{
			lessonServiceClient = new LessonServiceClient();
			lessonServiceClient.Open();
		}

		~LessonRepository()
		{
			if (lessonServiceClient != null)
			{
				lessonServiceClient.Close();
			}
		}

		public void Create(Lesson lesson, string courseId)
		{
			lessonServiceClient.Create(lesson.Convert(), courseId);
		}

		public void Delete(string id)
		{
			lessonServiceClient.Delete(id);
		}

		public Lesson Get(string id)
		{
			LessonDto lesson = lessonServiceClient.Get(id);

			return lesson.Convert();
		}

		public Lesson[] GetList(string courseId)
		{
			LessonDto[] lessons = lessonServiceClient.GetList(courseId);

			return lessons.Select((l) => l.Convert()).ToArray();
		}

		public void Update(Lesson lesson)
		{
			lessonServiceClient.Update(lesson.Convert());
		}
	}
}