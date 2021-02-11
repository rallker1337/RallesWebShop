using Microsoft.AspNetCore.Mvc;
using RasmusWebShop.Data;
using RasmusWebShop.Models;

namespace RasmusWebShop.Controllers
{
	public class BaseController : Controller
	{
		protected readonly ApplicationDbContext _dbContext;

		public BaseController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}
	}
}