using TrainingPortal.Web.Data.CourseService;
using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Web.Data.Converters
{
	public static partial class Converter
	{
		public static Course Convert(this CourseDto course, Audience audience, Category category)
		{
			if (course != null)
			{
				return new Course()
				{
					Id = course.Id,
					Name = course.Name,
					Description = course.Description,
					Audience = audience,
					Category = category
				};
			}

			return null;
		}

		public static CourseDto Convert(this Course course)
		{
			if (course != null)
			{
				return new CourseDto()
				{
					Id = course.Id,
					Name = course.Name,
					Description = course.Description,
					CategoryId = course.Category.Id,
					AudienceId = course.Audience.Id
				};
			}

			return null;
		}
	}
}