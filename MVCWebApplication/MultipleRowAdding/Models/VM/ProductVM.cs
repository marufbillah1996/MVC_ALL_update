using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MultipleRowAdding.Models.VM
{
    public class ProductVM
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3), Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string SearchButton { get; set; }

    }
}