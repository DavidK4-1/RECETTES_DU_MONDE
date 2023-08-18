using System.ComponentModel.DataAnnotations;
using System;
namespace French.Models.CatagoryModels
{
	public class CategoryCreate
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;
	}
}

