using System.Collections.Generic;

namespace RasmusWebShop.ViewModels
{

	public class ProductsIndexViewModel
	{
		public string q { get; set; }

		public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
	}
}