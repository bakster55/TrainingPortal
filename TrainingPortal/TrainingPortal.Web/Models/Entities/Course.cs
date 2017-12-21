using TrainingPortal.Web.Data.CourseService;

namespace TrainingPortal.Models
{
	public class Course
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Category Category { get; set; }
		public Audience Audience { get; set; }

		public static implicit operator Course(CourseDto course)
		{
			if (course != null)
			{
				return new Course()
				{
					Id = course.Id,
					Name = course.Name,
					Description = course.Description,
					Category= course.Category,
					Audience = course.Audience
				};
			}

			return null;
		}

		public static implicit operator CourseDto(Course course)
		{
			if (course != null)
			{
				return new CourseDto()
				{
					Id = course.Id,
					Name = course.Name,
					Description = course.Description,
					Category = course.Category,
					Audience = course.Audience
				};
			}

			return null;
		}
	}
}