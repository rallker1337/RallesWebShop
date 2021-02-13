using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RasmusWebShop.Data
{
	public class Product
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(30)]
		[MinLength(2)]
		public string Title { get; set; }

		[MaxLength(250)]
		[MinLength(0)]
		public string Description { get; set; }

		[Required]
		[DataType(DataType.Currency)]
		public int Price { get; set; }

		public Category Category { get; set; }
	}
}
