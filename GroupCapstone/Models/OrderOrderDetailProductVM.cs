using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCapstone.Models
{
    public class OrderOrderDetailProductVM
    {   
    
        public Order OrderVM { get; set; }
        
        public OrderDetails OrderDetailsVM { get; set; }
        public Product ProductVM { get; set; }
    }
}
