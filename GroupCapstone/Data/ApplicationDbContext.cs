using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GroupCapstone.Models;

namespace GroupCapstone.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
				: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<IdentityRole>()
				.HasData(
					new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
					new IdentityRole { Name = "Employee", NormalizedName = "EMPLOYEE" },
					new IdentityRole { Name = "Customer", NormalizedName = "CUSTOMER" });
			base.OnModelCreating(builder);
			builder.Entity<Customer>()
			  .HasData(
				 new Customer { Id = 1, FirstName = "Bob", LastName = "McBoberson", Email = "customer1@consume.com", PhoneNumber = "414-555-1234" },
					new Customer { Id = 2, FirstName = "Tom", LastName = "Tomson", Email = "customer1@consume.com", PhoneNumber = "123-456-7890" },
					new Customer { Id = 3, FirstName = "", LastName = "", Email = "", PhoneNumber = "" },
					new Customer { Id = 4, FirstName = "", LastName = "", Email = "", PhoneNumber = "" },
					new Customer { Id = 5, FirstName = "", LastName = "", Email = "", PhoneNumber = "" }
				 );
			builder.Entity<Product>()
			  .HasData(
					new Product { Id = 1, Name = "Cheese", Details = "Wisconsin cheese from Mexico.", Price = 2.10, ProductCategory = "Dairy", ImageUrl = "https://lovingitvegan.com/wp-content/uploads/2018/02/Cashew-Cheese-11.jpg" },
					new Product { Id = 2, Name = "Coffee", Details = "Harvested by blind monks.", Price = 20.19, ProductCategory = "Dry goods", ImageUrl = "https://www.qsi-q3.com/wp-content/uploads/sites/52/2017/02/Teaser_05.jpg" },
					new Product { Id = 3, Name = "Vegan Sausages", Details = "99% tofu the rest is a secrect.", Price = 9.50, ProductCategory = "Vegan", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/56/Smokey_tofu_sausages_%283084642875%29.jpg" },
					new Product { Id = 4, Name = "Dog food", Details = "No horses were harmed in the making of this product.", Price = 5.99, ProductCategory = "Pets", ImageUrl = "https://www.petflow.com/images/default/products/maximal/42303-1556549859.png" },
					new Product { Id = 5, Name = "Windex", Details = "Please do not drink this product", Price = 3.56, ProductCategory = "Cleaners", ImageUrl = "https://www.cvs.com/bizcontent/merchandising/productimages/large/1980020133.jpg" }
				 );
			builder.Entity<Order>()
			  .HasData(
					new Order { Id = 1, Date = new DateTime(2020, 10, 11), TotalPrice = 50, CustomerId = 1, IsPicked = true, IsCompleted = false },
					new Order { Id = 2, Date = new DateTime(2020, 10, 11), TotalPrice = 20, CustomerId = 2, IsPicked = false, IsCompleted = false },
					new Order { Id = 3, Date = new DateTime(2020, 9, 10), TotalPrice = 120, CustomerId = 1, IsPicked = false, IsCompleted = false },
					new Order { Id = 4, Date = new DateTime(2020, 10, 10), TotalPrice = 70, CustomerId = 2, IsPicked = false, IsCompleted = false },
					new Order { Id = 5, Date = new DateTime(2020, 10, 9), TotalPrice = 80, CustomerId = 1, IsPicked = false, IsCompleted = false },
					new Order { Id = 6, Date = new DateTime(2020, 8, 11), TotalPrice = 50, CustomerId = 2, IsPicked = true, IsCompleted = true }
				 );
			builder.Entity<OrderDetails>()
			  .HasData(
					new OrderDetails { Id = 1, ProductId = 2, OrderId = 1, Quantity = 5 },
					new OrderDetails { Id = 2, ProductId = 2, OrderId = 2, Quantity = 1 },
					new OrderDetails { Id = 3, ProductId = 3, OrderId = 2, Quantity = 8 },
					new OrderDetails { Id = 4, ProductId = 4, OrderId = 4, Quantity = 18 },
					new OrderDetails { Id = 5, ProductId = 5, OrderId = 4, Quantity = 14 },
					new OrderDetails { Id = 6, ProductId = 3, OrderId = 4, Quantity = 2 }
					);
			builder.Entity<StoreInfo>()
			  .HasData(
					new StoreInfo { Id = 1, Name = "Curb Hoppers", StreetAddress = "313 N Plankinton Ave", AddressCity = "Milwaukee", AddressState = "WI", AddressZip = "53203", StoreHours = "24/7", PhoneNumber = "867-5309" , Email = "ICU@curbhoppers.com", CompanyVision = "Our DNA is coded so that the customer comes first, well, right after all of our petty internal stuff.  Trust me, the customer is right up there in the top five…maybe ten, things we are focused on.", Logo="",Latitude= 43.0342198,Longitude= -87.9120726 });

					}
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Admin> Admins { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<OrderDetails> OrderDetails { get; set; }
		public DbSet<OrderOrderDetailProductVM> OrderOrderDetailProductVMs { get; set; }
		public DbSet<StoreInfo> StoreInfo { get; set; }

		public DbSet<ShoppingCart> ShoppingCarts { get; set; }

	}
}
