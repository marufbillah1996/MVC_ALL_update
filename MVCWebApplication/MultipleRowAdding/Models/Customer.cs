using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MultipleRowAdding.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3),Display(Name ="Customer Name")]
        public string CustomerName { get; set; }
        
        [StringLength(150, MinimumLength = 3), Display(Name = "Customer Address")]
        public string CustomerAddress { get; set; }
        [StringLength(50, MinimumLength = 3), Display(Name = "Customer Phone")]
        public string CustomerPhone { get; set; }
        [StringLength(150, MinimumLength = 3), Display(Name = "Customer Email")]
        public string CustomerEmail{ get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}