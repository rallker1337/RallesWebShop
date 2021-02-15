using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RasmusWebShop.ViewModels
{
	public class CategoryNewViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "A title is required")]
		[MaxLength(30, ErrorMessage = "Title maximum length is 30 characters")]
		[MinLength(2, ErrorMessage = "Title minimum length is 2 characters")]
		public string Title { get; set; }


	}
}
