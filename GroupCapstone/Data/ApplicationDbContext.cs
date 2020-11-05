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
					new IdentityRole { Name = "Admin",NormalizedName = "ADMIN"},
					new	IdentityRole { Name = "Employee", NormalizedName = "EMPLOYEE" },
					new IdentityRole { Name = "Customer", NormalizedName = "CUSTOMER" });
			base.OnModelCreating(builder);
			builder.Entity<Customer>()
			  .HasData(
				 new Customer { Id = 1, FirstName = "Bob", LastName = "McBoberson", Email = "customer1@consume.com", PhoneNumber ="414-555-1234" },
					new Customer { Id = 2, FirstName = "Tom", LastName = "Tomson", Email = "customer1@consume.com", PhoneNumber = "123-456-7890" },
					new Customer { Id = 3, FirstName = "", LastName = "", Email = "", PhoneNumber = "" },
					new Customer { Id = 4, FirstName = "", LastName = "", Email = "", PhoneNumber = "" },
					new Customer { Id = 5, FirstName = "", LastName = "", Email = "", PhoneNumber = "" }
				 );
			builder.Entity<Product>()
			  .HasData(
				    new Product { Id = 1, Name = "Cheese", Details = "Wisconsin cheese from Mexico.", Price = 2, ProductCategory = "Dairy",ImageUrl= "" },
					new Product { Id = 2, Name = "Coffee", Details = "Harvested by blind monks.", Price = 20, ProductCategory = "Dry goods", ImageUrl = "" },
					new Product { Id = 3, Name = "Vegan Sausages", Details = "99% tofu the rest is a secrect.", Price = 9, ProductCategory = "Vegan", ImageUrl = "" },
					new Product { Id = 4, Name = "Dog food", Details = "No horses were harmed in the making of this product.", Price = 5, ProductCategory = "Pets", ImageUrl = "" },
					new Product { Id = 5, Name = "Windex", Details = "Please do not drink this product", Price = 3, ProductCategory = "Cleaners", ImageUrl = "" }
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

		}
		public DbSet<GroupCapstone.Models.Customer> Customer { get; set; }
		public DbSet<GroupCapstone.Models.Employee> Employee { get; set; }
		public DbSet<GroupCapstone.Models.Admin> Admin { get; set; }
		public DbSet<GroupCapstone.Models.Order> Order { get; set; }
		public DbSet<GroupCapstone.Models.Product> Products { get; set; }
		public DbSet<GroupCapstone.Models.OrderDetails> OrderDetails { get; set; }

	}
}
