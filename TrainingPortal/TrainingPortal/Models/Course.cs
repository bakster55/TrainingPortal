using TrainingPortal.Client.CourseService;

namespace TrainingPortal.Models
{
	public class Course
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Category Category { get; set; }

		public static implicit operator Course(CourseDto course)
		{
			if (course != null)
			{
				return new Course()
				{
					Id = course.Id,
					Name = course.Name,
					Description = course.Description,
					Category= course.Category
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
					Category = course.Category
				};
			}

			return null;
		}
	}
}