using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCapstone.Models
{
    public class ShoppingCart
    {

        [Key]
        public int Id { get; set; }
        public int Qty { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ProductCategory { get; set; }
        public string ImageUrl { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
