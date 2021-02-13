using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RasmusWebShop.ViewModels
{
	public class ProductEditViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "A title is requered")]
		[MaxLength(30, ErrorMessage = "Title maximum length is 30 characters")]
		[MinLength(2, ErrorMessage = "Title minimum length is 2 characters")]
		public string Title { get; set; }

		[MaxLength(250)]
		[MinLength(0)]
		public string Description { get; set; }


		[Range(0,9000,ErrorMessage = "Price range is (0 - 9000)")]
		public int Price { get; set; }

		public string Category { get; set; }

	}
}
