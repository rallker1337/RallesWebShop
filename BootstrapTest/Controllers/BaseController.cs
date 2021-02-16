using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RasmusWebShop.Data;
using RasmusWebShop.Models;

namespace RasmusWebShop.Controllers
{
	public class BaseController : Controller
	{
		protected readonly ApplicationDbContext _dbContext;

		protected readonly UserManager<IdentityUser> _userManager;

		public BaseController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
		{
			_dbContext = dbContext;
			_userManager = userManager;
		}
	}
}