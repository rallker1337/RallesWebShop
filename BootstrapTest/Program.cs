using System;
using System.Collections.Generic;
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

namespace RasmusWebShop
{
	public class Program
	{
		public static void Main(string[] args)
		{
			using (var context = new ApplicationDbContext())
			{
				context.Database.Migrate();
			}

			using (var context = new ApplicationDbContext())
			{

				context.CategoryTypes.Add(new CategoryType
				{
					Title = "Clothes"
				});
				context.CategoryTypes.Add(new CategoryType
				{
					Title = "Decor"
				});
				context.Categories.Add(new Category
				{
					Title = "Hats"
				});
				context.Categories.Add(new Category
				{
					Title = "Shirts",
				});
				context.Categories.Add(new Category
				{
					Title = "Furniture",
				});
				context.Categories.Add(new Category
				{
					Title = "Others",
				});
				context.Categories.Add(new Category
				{
					Title = "Brick",

				});
				context.Products.Add(new Product
				{
					Title = "White Tee",
					Description = "Cut of cloth from the gods",
					Price = 999.99m
				});

				context.SaveChanges();
			}
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
