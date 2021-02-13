using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RasmusWebShop.Models;


namespace RasmusWebShop.Data
{
	public class DataInitializer
	{
		public static void SeedData(ApplicationDbContext dbContext)
		{
			dbContext.Database.Migrate();

			SeedCategories(dbContext);
			SeedProducts(dbContext);
		}

		private static void SeedCategories(ApplicationDbContext dbContext)
		{
			var categories = dbContext.Categories.FirstOrDefault(r => r.Title == "T-Shirts");
			if (categories == null)
			{
				dbContext.Categories.Add(new Category { Title = "T-Shirts"});
			}
			categories = dbContext.Categories.FirstOrDefault(r => r.Title == "Hoodies");
			if (categories == null)
			{
				dbContext.Categories.Add(new Category { Title = "Hoodies" });
			}
			categories = dbContext.Categories.FirstOrDefault(r => r.Title == "Hats");
			if (categories == null)
			{
				dbContext.Categories.Add(new Category { Title = "Hats" });
			}

			dbContext.SaveChanges();
		}

		private static void SeedProducts(ApplicationDbContext dbContext)
		{
			var products = dbContext.Products.FirstOrDefault(r => r.Title == "White T-Shirt");
			if (products == null)
			{
				dbContext.Products.Add(new Product
				{
					Title = "White T-Shirt",
					Description = "Cut of cloth from the gods",
					Price = 99,
					Category = dbContext.Categories.FirstOrDefault(r=> r.Title == "T-Shirts")
				});
			}
			products = dbContext.Products.FirstOrDefault(r => r.Title == "Black T-Shirt");
			if (products == null)
			{
				dbContext.Products.Add(new Product
				{
					Title = "Black T-Shirt",
					Description = "",
					Price = 99,
					Category = dbContext.Categories.FirstOrDefault(r => r.Title == "T-Shirts")
				});
			}
			products = dbContext.Products.FirstOrDefault(r => r.Title == "Black Hoodie");
			if (products == null)
			{
				dbContext.Products.Add(new Product
				{
					Title = "Black Hoodie",
					Description = null,
					Price = 299,
					Category = dbContext.Categories.FirstOrDefault(r => r.Title == "Hoodies")
				});
			}
			products = dbContext.Products.FirstOrDefault(r => r.Title == "Grey Cap");
			if (products == null)
			{
				dbContext.Products.Add(new Product
				{
					Title = "Grey Cap",
					Description = "Cut of cloth from the gods",
					Price = 79,
					Category = dbContext.Categories.FirstOrDefault(r => r.Title == "Hats")
				});
			}
			products = dbContext.Products.FirstOrDefault(r => r.Title == "Black Cap");
			if (products == null)
			{
				dbContext.Products.Add(new Product
				{
					Title = "Black Cap",
					Description = "Cut of cloth from the gods",
					Price = 79,
					Category = dbContext.Categories.FirstOrDefault(r => r.Title == "Hats")
				});
			}
			products = dbContext.Products.FirstOrDefault(r => r.Title == "Grey Hoodie");
			if (products == null)
			{
				dbContext.Products.Add(new Product
				{
					Title = "Grey Hoodie",
					Description = "Cut of cloth from the gods",
					Price = 299,
					Category = dbContext.Categories.FirstOrDefault(r => r.Title == "Hoodies")
				});
			}
			products = dbContext.Products.FirstOrDefault(r => r.Title == "White Hoodie");
			if (products == null)
			{
				dbContext.Products.Add(new Product
				{
					Title = "White Hoodie",
					Description = "Cut of cloth from the gods",
					Price = 299,
					Category = dbContext.Categories.FirstOrDefault(r => r.Title == "Hoodies")
				});
			}

			dbContext.SaveChanges();
		}
	}
}
