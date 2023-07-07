using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MultipleRowAdding.Models
{
    public class SupplierCategory
    {
        [Key]
        public int SupplierCatagoryId { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 3), Display(Name = "Catagory Name")]
        public string CatagoryName { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

    }
}