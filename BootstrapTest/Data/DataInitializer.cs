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
		public static void SeedData(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
		{
			dbContext.Database.Migrate();

			SeedCategories(dbContext);
			SeedProducts(dbContext);
			SeedRoles(dbContext);
			SeedUsers(userManager);
		}

		private static void SeedRoles(ApplicationDbContext dbContext)
		{
			var role = dbContext.Roles.FirstOrDefault(r => r.Name == "Admin");
			if (role == null)
			{
				dbContext.Roles.Add(new IdentityRole
				{
					Name = "Admin",
					NormalizedName = "Admin"
				});
			}
			role = dbContext.Roles.FirstOrDefault(r => r.Name == "ProductManager");
			if (role == null)
			{
				dbContext.Roles.Add(new IdentityRole
				{
					Name = "ProductManager",
					NormalizedName = "ProductManager"
				});
			}
			dbContext.SaveChanges();
		}

		private static void SeedUsers(UserManager<IdentityUser> userManager)
		{
			AddUserIfNotExists(userManager, "stefan.holmberg@systementor.se", "Hejsan123#", new string[]{"Admin"});
			AddUserIfNotExists(userManager, "stefan.holmbergmanager@systementor.se", "Hejsan123#", new string[] { "ProductManager" });
			AddUserIfNotExists(userManager, "ras@mus.se", "Hejsan123#", new string[] { "Admin", "ProductManager" });
		}

		private static void AddUserIfNotExists(UserManager<IdentityUser> userManager, string userName, string password, string []roles)
		{
			if (userManager.FindByEmailAsync(userName).Result != null) return;
			var user = new IdentityUser
			{
				UserName = userName,
				Email = userName,
				EmailConfirmed = true
			};
			var result = userManager.CreateAsync(user, password).Result;
			var r = userManager.AddToRolesAsync(user, roles).Result;
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
