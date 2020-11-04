using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCapstone.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Display(Name ="Order Date")]
        public DateTime OrderDate {get; set;}

        [Display (Name = "Total Price")]
        public int TotalPrice { get; set; }

        [Display(Name = "Completed Status")]

        public bool IsCompleted { get; set; }

        [Display (Name = "Picked Status")]
        public bool IsPicked { get; set; }

        [ForeignKey("Customer")]
        [Display (Name = "Customer Id Number")]
        public int CustomerId { get; set; }
		public Customer Customer { get; set; }






    }
}
