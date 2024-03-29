﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RasmusWebShop.ViewModels
{
	public class ProductNewViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "A title is required")]
		[MaxLength(30, ErrorMessage = "Title maximum length is 30 characters")]
		[MinLength(2, ErrorMessage = "Title minimum length is 2 characters")]
		public string Title { get; set; }

		[MaxLength(250)]
		[MinLength(0)]
		public string Description { get; set; }


		[Range(0,9000,ErrorMessage = "Price range is (0 - 9000)")]
		public int Price { get; set; }

		[Required(ErrorMessage = "A category is required")]
		public int Category { get; set; }

		public List<SelectListItem> Categories { get; set; }

		public int SelectedCategoryId { get; set; }

	}
}
