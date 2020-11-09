using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCapstone.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        [DisplayFormat(DataFormatString = "{0:c2,us}", ApplyFormatInEditMode = true)]
        public double Price { get; set; }

        public string ProductCategory { get; set; }
        public string ImageUrl { get; set; }

    }
}
