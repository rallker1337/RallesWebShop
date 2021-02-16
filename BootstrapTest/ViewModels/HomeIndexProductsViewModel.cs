using System.Collections.Generic;

namespace RasmusWebShop.ViewModels
{

	public class HomeIndexViewModel
	{
		public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();

		public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
	}
}