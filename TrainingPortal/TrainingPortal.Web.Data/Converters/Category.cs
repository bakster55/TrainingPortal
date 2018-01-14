using TrainingPortal.Web.Data.CourseService;
using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Web.Data.Converters
{
	public static partial class Converter
	{
		//From CategoryService
		public static Category Convert(this TrainingPortal.Web.Data.CategoryService.CategoryDto category)
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

		public static TrainingPortal.Web.Data.CategoryService.CategoryDto Convert(this Category category)
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