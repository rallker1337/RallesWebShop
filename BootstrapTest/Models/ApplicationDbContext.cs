using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RasmusWebShop.ViewModels;

namespace RasmusWebShop.Models
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext()
		{
				
		}
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			:base(options)
		{

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("server=LocalHost;initial catalog=RasmusWebShop;integrated security=true");
			}
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<CategoryType> CategoryTypes { get; set; }
	}
}
