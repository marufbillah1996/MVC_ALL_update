using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MultipleRowAdding.Models
{
    public class OrderDetail
    {
		[Key, Column(Order = 0), ForeignKey("Order")]
		public int OrderId { get; set; }
		[Key, Column(Order = 1), ForeignKey("Product")]
		public int ProductId { get; set; }
		[Required]
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public decimal Amount { get; set; }
		public virtual Order Order { get; set; }
		public virtual Product Product { get; set; }
	}
}