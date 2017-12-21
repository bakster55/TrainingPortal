using TrainingPortal.Web.Data.LessonService;

namespace TrainingPortal.Models
{
	public class Lesson
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Content { get; set; }

		public static implicit operator Lesson(LessonDto lesson)
		{
			if (lesson != null)
			{
				return new Lesson()
				{
					Id = lesson.Id,
					Name = lesson.Name,
					Content = lesson.Content,
				};
			}

			return null;
		}

		public static implicit operator LessonDto(Lesson lesson)
		{
			if (lesson != null)
			{
				return new LessonDto()
				{
					Id = lesson.Id,
					Name = lesson.Name,
					Content = lesson.Content,
				};
			}

			return null;
		}
	}
}