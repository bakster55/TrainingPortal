using TrainingPortal.Web.Data.CourseService;

namespace TrainingPortal.Models
{
	public class Category
	{
		public string Id { get; set; }

		public string Name { get; set; }

		//From CourseService
		public static implicit operator Category(TrainingPortal.Web.Data.CourseService.CategoryDto category)
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

		public static implicit operator TrainingPortal.Web.Data.CourseService.CategoryDto(Category category)
		{
			if (category != null)
			{
				return new TrainingPortal.Web.Data.CourseService.CategoryDto()
				{
					Id = category.Id,
					Name = category.Name,
				};
			}

			return null;
		}

		//From CategoryService
		public static implicit operator Category(TrainingPortal.Web.Data.CategoryService.CategoryDto category)
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

		public static implicit operator TrainingPortal.Web.Data.CategoryService.CategoryDto(Category category)
		{
			if (category != null)
			{
				return new TrainingPortal.Web.Data.CategoryService.CategoryDto()
				{
					Id = category.Id,
					Name = category.Name,
				};
			}

			return null;
		}
	}
}