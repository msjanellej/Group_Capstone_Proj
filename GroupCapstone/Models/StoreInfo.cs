using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroupCapstone.Models
{
	public class StoreInfo
	{
		[Key]
		public int Id { get; set; }

		[Display(Name = "Store Name")]
		public string Name { get; set; }

		[Display(Name="Street Address")]
		public string StreetAddress { get; set; }

		[Display(Name = "City")]
		public string AddressCity { get; set; }

		[Display(Name = "State")]
		public string AddressState { get; set; }

		[Display(Name = "Zip Code")]
		public int AddressZip { get; set; }

		[Display(Name = "Store Hours")]
		public string StoreHours { get; set; }

		[Display(Name = "Phone Number")]
		public string PhoneNumber { get; set; }

		[Display(Name = "Logo")]
		public string Logo { get; set; }

		[Display(Name = "Company Vision")]
		public string CompanyVision { get; set; }

		public string Email { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}
}
