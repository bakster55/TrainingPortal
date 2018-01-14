using TrainingPortal.Web.Data.CategoryService;
using TrainingPortal.Data.Interfaces;
using TrainingPortal.Web.Business.Models;
using System.Linq;
using TrainingPortal.Web.Data.Converters;

namespace TrainingPortal.Data.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private CategoryServiceClient categoryServiceClient;

		public CategoryRepository()
		{
			categoryServiceClient = new CategoryServiceClient();
			categoryServiceClient.Open();
		}

		~CategoryRepository()
		{
			if (categoryServiceClient != null)
			{
				categoryServiceClient.Close();
			}
		}

		public void Create(Category category)
		{
			categoryServiceClient.Create(category.Convert());
		}

		public void Delete(string id)
		{
			categoryServiceClient.Delete(id);
		}

		public Category Get(string id)
		{
			CategoryDto category = categoryServiceClient.Get(id);

			return category.Convert();
		}

		public Category[] GetList()
		{
			CategoryDto[] categories = categoryServiceClient.GetList();

			return categories.Select((c) => c.Convert()).ToArray();
		}

		public void Update(Category category)
		{
			categoryServiceClient.Update(category.Convert());
		}
	}
}