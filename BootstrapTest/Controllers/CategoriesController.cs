using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RasmusWebShop.Data;
using RasmusWebShop.Models;
using RasmusWebShop.ViewModels;

namespace RasmusWebShop.Controllers
{
	public class CategoriesController : BaseController
	{
		private readonly ILogger<HomeController> _logger;

		public CategoriesController(ApplicationDbContext dbContext, ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
			: base(dbContext, userManager)
		{
			_logger = logger;
		}
		public IActionResult Index(string q)
		{
			var viewModel = new CategoriesIndexViewModel();
			viewModel.Categories = _dbContext.Categories.Select(dbCat => new CategoryViewModel
				{
					Id = dbCat.Id,
					Title = dbCat.Title,
				}).ToList();

			return View(viewModel);
		}

		[Authorize(Roles = "Admin, ProductManager")]
		public IActionResult Edit(int Id)
		{
			var viewModel = new CategoryEditViewModel();

			var dbProduct = _dbContext.Categories.First(r => r.Id == Id);

			viewModel.Id = dbProduct.Id;
			viewModel.Title = dbProduct.Title;

			return View(viewModel);

		}
		[HttpPost]
		public IActionResult Edit(CategoryEditViewModel viewModel, int Id)
		{
			if (ModelState.IsValid)
			{
				var dbCategory = _dbContext.Categories.First(r => r.Id == Id);

				dbCategory.Id = viewModel.Id;
				dbCategory.Title = viewModel.Title;

				_dbContext.SaveChanges();

				return RedirectToAction("Index");
			}

			return View(viewModel);
		}

		[Authorize(Roles = "Admin, ProductManager")]
		public IActionResult New()
		{
			var viewModel = new CategoryNewViewModel();

			return View(viewModel);
		}
		[HttpPost]
		public IActionResult New(CategoryNewViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dbCategory = new Category();
				_dbContext.Categories.Add(dbCategory);
				dbCategory.Id = viewModel.Id;
				dbCategory.Title = viewModel.Title;
				_dbContext.SaveChanges();

				return RedirectToAction("Index");
			}

			return View(viewModel);
		}

		[Authorize(Roles = "Admin, ProductManager")]
		public IActionResult Remove(int Id)
		{
			var viewModel = new CategoryRemoveViewModel();
			var dbCategory = _dbContext.Categories.FirstOrDefault(r => r.Id == Id);
			var productsInCategory = _dbContext.Products.Include(r => r.Category)
				.Where(r => r.Category.Id == Id)
				.Select(dbProd => new ProductViewModel
			{
				Id = dbProd.Id,
				Title = dbProd.Title,
				Description = dbProd.Description,
				Price = dbProd.Price,
				Category = dbProd.Category.Title
			}).ToList();

			viewModel.Id = dbCategory.Id;
			viewModel.Title = dbCategory.Title;
			viewModel.ProductsInCategory = productsInCategory;
			if (viewModel.ProductsInCategory.Count == 0)
			{
				viewModel.ContainsProducts = false;
			}
			else
			{
				viewModel.ContainsProducts = true;
			}
			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Remove(CategoryRemoveViewModel viewModel, int Id, bool hasProducts, string ProductsInCategory) 
		{
			var dbCategory = _dbContext.Categories.FirstOrDefault(r => r.Id == Id);
			var errors = ModelState
				.Where(x => x.Value.Errors.Count > 0)
				.Select(x => new { x.Key, x.Value.Errors })
				.ToArray();
			if (ModelState.IsValid)
			{
				if (hasProducts == true)
				{
					var ids = ProductsInCategory.Split(':');

					foreach (var id in ids)
					{
						if (String.IsNullOrEmpty(id))
						{
							break;
						}
						int prodid = Convert.ToInt32(id);
						var dbProduct = _dbContext.Products.FirstOrDefault(r => r.Id == prodid);
						_dbContext.Products.Remove(dbProduct);
					}
				}
				_dbContext.Categories.Remove(dbCategory);
				_dbContext.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(viewModel);
		}
	}
}
