using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MultipleRowAdding.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3), Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        [StringLength(150, MinimumLength = 3), Display(Name = "Supplier Address")]
        public string SupplierAddress { get; set; }
        [StringLength(150, MinimumLength = 3), Display(Name = "Contact Name")]
        public string ContactName { get; set; }
        [StringLength(150, MinimumLength = 3), Display(Name = "Contact Email")]
        public string ContactEmail { get; set; }
        [StringLength(150, MinimumLength = 3), Display(Name = "Contact Phone")]
        public string ContactPhone { get; set; }
        [StringLength(150, MinimumLength = 3), Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        [ForeignKey("SupplierCategory")]
        public int SupplierCatagoryId { get; set; }

        public virtual SupplierCategory SupplierCategory { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}