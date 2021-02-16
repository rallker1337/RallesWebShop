using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RasmusWebShop.Data;
using RasmusWebShop.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace RasmusWebShop.Controllers
{
	public class ProductsController : BaseController
	{
		private readonly ILogger<HomeController> _logger;


		public ProductsController(ApplicationDbContext dbContext, ILogger<HomeController> logger, UserManager<IdentityUser> userManager)
			: base(dbContext, userManager)
		{
			_logger = logger;
		}
		public IActionResult Index(string q)
		{
			var viewModel = new ProductsIndexViewModel();
			viewModel.Products = _dbContext.Products.Include(r => r.Category)
				.Where(r => q == null || r.Title.Contains(q) || r.Description.Contains(q))
				.Select(dbProd => new ProductViewModel
				{
					Id = dbProd.Id,
					Title = dbProd.Title,
					Description = dbProd.Description,
					Price = dbProd.Price,
					Category = dbProd.Category.Title
				}).ToList();
			viewModel.q = q;
			return View(viewModel);
		}
		public IActionResult Category(int Id)
		{
			var viewModel = new ProductsCategoryViewModel();
			viewModel.Products = _dbContext.Products.Include(r => r.Category)
				.Where(r => r.Category.Id == Id)
				.Select(dbProd => new ProductViewModel
				{
					Id = dbProd.Id,
					Title = dbProd.Title,
					Description = dbProd.Description,
					Price = dbProd.Price,
					Category = dbProd.Category.Title
				}).ToList();

			return View(viewModel);
		}
		public IActionResult Product(int Id)
		{
			var viewModel = new ProductsProductViewModel();
			var dbProduct = _dbContext.Products.Include(p => p.Category).FirstOrDefault(r => r.Id == Id);

			viewModel.Id = dbProduct.Id;
			viewModel.Title = dbProduct.Title;
			viewModel.Description = dbProduct.Description;
			viewModel.Price = dbProduct.Price;
			viewModel.Category = dbProduct.Category.Title;
			viewModel.CategoryId = dbProduct.Category.Id;

			return View(viewModel);
		}

		[Authorize(Roles = "Admin, ProductManager")]
		public IActionResult Edit(int Id)
		{
			var viewModel = new ProductEditViewModel();

			var dbProduct = _dbContext.Products.Include(r => r.Category).First(r => r.Id == Id);

			viewModel.Id = dbProduct.Id;
			viewModel.Title = dbProduct.Title;
			viewModel.Description = dbProduct.Description;
			viewModel.Price = dbProduct.Price;
			viewModel.Category = dbProduct.Category.Id;
			viewModel.Categories = GetAllCategories();
			viewModel.CategortyTitle = dbProduct.Category.Title;

			return View(viewModel);
		}
		[HttpPost]
		public IActionResult Edit(ProductEditViewModel viewModel, int Id)
		{
			if (ModelState.IsValid)
			{
				var dbProduct = _dbContext.Products.Include(r => r.Category).First(r => r.Id == Id);

				dbProduct.Title = viewModel.Title;
				dbProduct.Description = viewModel.Description;
				dbProduct.Price = viewModel.Price;
				dbProduct.Category = _dbContext.Categories.First(r => r.Id == viewModel.Category);

				_dbContext.SaveChanges();

				return RedirectToAction("Product", viewModel);
			}

			viewModel.Categories = GetAllCategories();
			return View(viewModel);
		}

		[Authorize(Roles = "Admin, ProductManager")]
		public IActionResult New()
		{
			var viewModel = new ProductNewViewModel();
			viewModel.Categories = GetAllCategories();

			return View(viewModel);
		}
		[HttpPost]
		public IActionResult New(ProductNewViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var dbProduct = new Product();
				_dbContext.Products.Add(dbProduct);
				dbProduct.Id = viewModel.Id;
				dbProduct.Title = viewModel.Title;
				dbProduct.Description = viewModel.Description;
				dbProduct.Price = viewModel.Price;
				dbProduct.Category = _dbContext.Categories.First(r => r.Id == viewModel.Category);
				_dbContext.SaveChanges();

				return RedirectToAction("Index");
			}

			viewModel.Categories = GetAllCategories();
			return View(viewModel);
		}

		[Authorize(Roles="Admin, ProductManager")]
		public IActionResult Remove(int Id) 
		{
			var dbProduct = _dbContext.Products.Include(r=>r.Category).FirstOrDefault(r => r.Id == Id);
			var viewModel = new ProductRemoveViewModel();
			viewModel.Id = dbProduct.Id;
			viewModel.Title = dbProduct.Title;
			viewModel.Category = dbProduct.Category.Title;
			viewModel.CategoryId = dbProduct.Category.Id;

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult Remove(ProductRemoveViewModel viewModel, int Id) 
		{
			var dbProduct = _dbContext.Products.FirstOrDefault(r => r.Id == Id);
			if (ModelState.IsValid)
			{
				_dbContext.Products.Remove(dbProduct);
				_dbContext.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(viewModel);
		}
		private List<SelectListItem> GetAllCategories()
		{
			var list = new List<SelectListItem>();
			list.AddRange(_dbContext.Categories.Select(r => new SelectListItem
			{
				Value = r.Id.ToString(),
				Text = r.Title
			}));

			return list;
		}
	}
}
