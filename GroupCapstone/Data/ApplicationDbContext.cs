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
		protected override void OnModelCreating(ModelBuilder builder) { base.OnModelCreating(builder); builder.Entity<IdentityRole>().HasData(
			new IdentityRole {Name = "Admin",NormalizedName = "ADMIN"},
			new	IdentityRole { Name = "Employee", NormalizedName = "EMPLOYEE" },
			new IdentityRole { Name = "Customer", NormalizedName = "CUSTOMER" });
		}
		public DbSet<GroupCapstone.Models.Customer> Customer { get; set; }
		public DbSet<GroupCapstone.Models.Employee> Employee { get; set; }
		public DbSet<GroupCapstone.Models.Admin> Admin { get; set; }
		public DbSet<GroupCapstone.Models.Order> Order { get; set; }
		public DbSet<GroupCapstone.Models.Product> Products { get; set; }
		public DbSet<GroupCapstone.Models.OrderDetails> OrderDetails { get; set; }
		public DbSet<GroupCapstone.Models.OrderOrderDetailProductVM> OrderOrderDetailProductVM { get; set; }
	}
}
