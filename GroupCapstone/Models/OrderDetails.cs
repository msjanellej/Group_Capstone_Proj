using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCapstone.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }


        [ForeignKey("Product")]

        [Display(Name = "Product Id Number")]
        public int ProductId { get; set; }
        public Product Product { get; set; }


        [ForeignKey("Order")]
        [Display(Name = "Order ID Number")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
