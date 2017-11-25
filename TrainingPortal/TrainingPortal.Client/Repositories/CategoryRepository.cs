using TrainingPortal.Client.CategoryService;

namespace TrainingPortal.Data.Repositories
{
	public class CategoryRepository : ICategoryService
	{
		private CategoryServiceClient categoryServiceClient;

		public CategoryRepository()
		{
			categoryServiceClient = new CategoryServiceClient();
			categoryServiceClient.Open();
		}

		~CategoryRepository()
		{
			categoryServiceClient.Close();
		}

		public void Create(CategoryDto category)
		{
			categoryServiceClient.Create(category);
		}

		public void Delete(string id)
		{
			categoryServiceClient.Delete(id);
		}

		public CategoryDto Get(string id)
		{
			CategoryDto category = categoryServiceClient.Get(id);

			return category;
		}

		public CategoryDto[] GetList()
		{
			CategoryDto[] categories = categoryServiceClient.GetList();

			return categories;
		}

		public void Update(CategoryDto category)
		{
			categoryServiceClient.Update(category);
		}
	}
}