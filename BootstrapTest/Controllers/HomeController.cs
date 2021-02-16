using System;
using System.Collections.Generic;
using System.Diagnostics;
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
	public class HomeController : BaseController
	{
		private readonly ILogger<HomeController> _logger;


		public HomeController(ApplicationDbContext dbContext, ILogger<HomeController> logger)
			: base(dbContext)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			var viewModel = new HomeIndexViewModel();
			Random random = new Random();
			int selected;
			int prodCount = 0;
			viewModel.Products = _dbContext.Products.Include(r => r.Category)
				.Select(dbProd => new ProductViewModel
				{
					Id = dbProd.Id,
					Title = dbProd.Title,
					Description = dbProd.Description,
					Price = dbProd.Price,
					Category = dbProd.Category.Title
				}).ToList();
			var randomProducts = new HomeIndexViewModel();
			var randomProdcut = new ProductViewModel();
			for (int i = 0; i < 3;  i++)
			{
				selected = random.Next(0, viewModel.Products.Count());
				randomProdcut = viewModel.Products[selected];
				viewModel.Products.Remove(viewModel.Products[selected]);

				randomProducts.Products.Add(randomProdcut);
			}
			viewModel = randomProducts;
			viewModel.Categories = _dbContext.Categories.Select(dbCat => new CategoryViewModel
			{
				Id = dbCat.Id,
				Title = dbCat.Title,
			}).ToList();


			
			return View(viewModel);
		}



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
