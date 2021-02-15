using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RasmusWebShop.ViewModels
{
	public class CategoryRemoveViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public List<ProductViewModel> ProductsInCategory { get; set; } = new List<ProductViewModel>();

		public bool ContainsProducts { get; set; }

	}
}
