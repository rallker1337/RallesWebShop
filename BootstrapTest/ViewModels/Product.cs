using System.Collections.Generic;

namespace RasmusWebShop.ViewModels
{
	public class Product
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public decimal Price { get; set; }

		public List<Category>  CategoryId { get; set; } = new List<Category>();
	}
}