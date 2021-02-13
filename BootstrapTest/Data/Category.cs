using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RasmusWebShop.Data
{
	public class Category
	{

		public int Id { get; set; }

		[Required]
		[MaxLength(30)]
		[MinLength(2)]
		public string Title { get; set; }
	}
}
