using TrainingPortal.Client.CategoryService;

namespace TrainingPortal.Models
{
	public class Category
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public static implicit operator Category(CategoryDto category)
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

		public static implicit operator CategoryDto(Category category)
		{
			if (category != null)
			{
				return new CategoryDto()
				{
					Id = category.Id,
					Name = category.Name,
				};
			}

			return null;
		}
	}
}