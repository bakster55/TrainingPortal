using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingPortal.Data.Repositories;
using TrainingPortal.Client.CategoryService;
using TrainingPortal.Models;

namespace TrainingPortal.Controllers
{
	public class CategoryController : Controller
	{
		private CategoryRepository categoryRepository;

		public CategoryController()
		{
			categoryRepository = new CategoryRepository();
		}

		public ActionResult Index()
		{
			List<Category> categories = categoryRepository.GetList().Select(category => new Category()
			{
				Id = category.Id,
				Name = category.Name,
			}).ToList();

			return View(categories);
		}

		public ActionResult Details(int id)
		{
			Category category = categoryRepository.Get(id.ToString());

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
				categoryRepository.Create(category);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(category);
			}
		}

		public ActionResult Edit(int id)
		{
			Category category = categoryRepository.Get(id.ToString());

			return View(category);
		}

		[HttpPost]
		public ActionResult Edit(int id, Category category)
		{
			try
			{
				categoryRepository.Update(category);

				return RedirectToAction("Index");
			}
			catch
			{
				return View(category);
			}
		}

		public ActionResult Delete(int id)
		{
			Category category = categoryRepository.Get(id.ToString());

			return View(category);
		}

		[HttpPost]
		public ActionResult Delete(int id, Category category)
		{
			try
			{
				categoryRepository.Delete(id.ToString());

				return RedirectToAction("Index");
			}
			catch
			{
				return View(category);
			}
		}
	}
}
