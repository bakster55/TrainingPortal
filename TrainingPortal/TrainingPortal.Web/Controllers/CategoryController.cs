using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TrainingPortal.Data.Repositories;
using TrainingPortal.Models;
using TrainingPortal.Web.Data.CategoryService;

namespace TrainingPortal.Controllers
{
	[Authorize(Roles = "admin, editor")]
	public class CategoryController : Controller
	{
		private ICategoryService _categoryRepository;

		public CategoryController(ICategoryService categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public ActionResult Index()
		{
			List<Category> categories = _categoryRepository.GetList().Select(category => (Category)category).ToList();

			return View(categories);
		}

		public ActionResult Details(int id)
		{
			Category category = _categoryRepository.Get(id.ToString());

			return View(category);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Category category)
		{
			try
			{
				_categoryRepository.Create(category);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(category);
			}
		}

		public ActionResult Edit(int id)
		{
			Category category = _categoryRepository.Get(id.ToString());

			return View(category);
		}

		[HttpPost]
		public ActionResult Edit(int id, Category category)
		{
			try
			{
				_categoryRepository.Update(category);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(category);
			}
		}

		public ActionResult Delete(int id)
		{
			Category category = _categoryRepository.Get(id.ToString());

			return View(category);
		}

		[HttpPost]
		public ActionResult Delete(int id, Category category)
		{
			try
			{
				_categoryRepository.Delete(id.ToString());

				return RedirectToAction("Index");
			}
			catch
			{
				return View(category);
			}
		}
	}
}
