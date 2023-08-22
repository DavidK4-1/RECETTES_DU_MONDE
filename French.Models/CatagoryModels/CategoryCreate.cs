using System.ComponentModel.DataAnnotations;
using System;
namespace French.Models.CatagoryModels
{
	public class CategoryCreate
	{
		[Required]
		public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}

