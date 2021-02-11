using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RasmusWebShop.Data;
using RasmusWebShop.Models;
using RasmusWebShop.ViewModels;

namespace RasmusWebShop.Controllers
{
	public class ProductsController : BaseController
	{
		private readonly ILogger<HomeController> _logger;


		public ProductsController(ApplicationDbContext dbContext, ILogger<HomeController> logger)
			: base(dbContext)
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

			return View(viewModel);
		}
	}
}
