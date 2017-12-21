using TrainingPortal.Web.Data.LessonService;

namespace TrainingPortal.Data.Repositories
{
	public class LessonRepository : ILessonService
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

		public void Create(LessonDto lesson, string courseId)
		{
			lessonServiceClient.Create(lesson, courseId);
		}

		public void Delete(string id)
		{
			lessonServiceClient.Delete(id);
		}

		public LessonDto Get(string id)
		{
			LessonDto lesson = lessonServiceClient.Get(id);

			return lesson;
		}

		public LessonDto[] GetList(string courseId)
		{
			LessonDto[] lessons = lessonServiceClient.GetList(courseId);

			return lessons;
		}

		public void Update(LessonDto lesson)
		{
			lessonServiceClient.Update(lesson);
		}
	}
}