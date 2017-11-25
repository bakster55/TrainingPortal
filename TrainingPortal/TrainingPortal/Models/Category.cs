using TrainingPortal.Client.CourseService;

namespace TrainingPortal.Models
{
	public class Category
	{
		public string Id { get; set; }

		public string Name { get; set; }

		//From CourseService
		public static implicit operator Category(TrainingPortal.Client.CourseService.CategoryDto category)
		{
			if (category != null)
			{
				return new Category()
				{
					Id = category.Id,
					Name = category.Name,
				};
			}

			return null;
		}

		public static implicit operator TrainingPortal.Client.CourseService.CategoryDto(Category category)
		{
			if (category != null)
			{
				return new TrainingPortal.Client.CourseService.CategoryDto()
				{
					Id = category.Id,
					Name = category.Name,
				};
			}

			return null;
		}

		//From CategoryService
		public static implicit operator Category(TrainingPortal.Client.CategoryService.CategoryDto category)
		{
			if (category != null)
			{
				return new Category()
				{
					Id = category.Id,
					Name = category.Name,
				};
			}

			return null;
		}

		public static implicit operator TrainingPortal.Client.CategoryService.CategoryDto(Category category)
		{
			if (category != null)
			{
				return new TrainingPortal.Client.CategoryService.CategoryDto()
				{
					Id = category.Id,
					Name = category.Name,
				};
			}

			return null;
		}
	}
}