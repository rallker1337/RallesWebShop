using System.Collections.Generic;

namespace RasmusWebShop.ViewModels
{

	public class CategoriesIndexViewModel
	{
		public string q { get; set; }

		public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
	}
}