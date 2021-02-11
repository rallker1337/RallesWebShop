using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using RasmusWebShop.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RasmusWebShop.Models;
using RasmusWebShop.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using RasmusWebShop.Data;
using Microsoft.AspNetCore.Identity;

namespace RasmusWebShop
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateHostBuilder(args).Build();
			using (var scope = host.Services.CreateScope())
			{
				var serviceProvider = scope.ServiceProvider;
				var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
				var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
				DataInitializer.SeedData(dbContext);
			}

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}