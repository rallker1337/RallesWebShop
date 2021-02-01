using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RasmusWebShop.ViewModels
{

	public class Category
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public List<CategoryType> CategoryTypeId { get; set; } = new List<CategoryType>();
	}
}
