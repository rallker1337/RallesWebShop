using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RasmusWebShop.ViewModels
{
	public class ProductRemoveViewModel
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public int CategoryId { get; set; }

		public string Category { get; set; }
	}
}
