using TrainingPortal.Web.Data.LessonService;
using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Web.Data.Converters
{
	public static partial class Converter
	{
		public static Lesson Convert(this LessonDto lesson)
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

		public static LessonDto Convert(this Lesson lesson)
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