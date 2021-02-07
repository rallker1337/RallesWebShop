using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RasmusWebShop.Models;
using RasmusWebShop.ViewModels;

namespace RasmusWebShop.Controllers
{
	public class CategoriesController : BaseController
	{
		private readonly ILogger<HomeController> _logger;


		public CategoriesController(ApplicationDbContext dbContext, ILogger<HomeController> logger)
			: base(dbContext)
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
	}
}
