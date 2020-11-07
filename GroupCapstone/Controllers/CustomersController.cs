﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupCapstone.Data;
using GroupCapstone.Models;
using System.Security.Claims;

namespace GroupCapstone.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

       //GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers;
            var id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = customers.Where(c => c.IdentityUserId == id).SingleOrDefault();
           
            if (customer == null)
            {
                return RedirectToAction(nameof(Create));

            }
            CartSummary(customer.Id);

            return View(_context.Products.ToList());
        }

        // GET: /Customers/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            ShoppingCart cart = new ShoppingCart();
            var addProduct = _context.Products.Single(p => p.Id == id);
            var customerId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == customerId).SingleOrDefault();
            var shoppingCartDB = _context.ShoppingCarts.Where(s => s.ProductId == id && s.CustomerId == customer.Id).SingleOrDefault();
           //If shopping cart doesnt have this product for this customer add a new one else just add 1 to the qty
            if (shoppingCartDB == null)
            {
                cart.ProductId = id;
                cart.Name = addProduct.Name;
                cart.Price = addProduct.Price;
                cart.ImageUrl = addProduct.ImageUrl;
                cart.ProductCategory = addProduct.ProductCategory;
                cart.Qty = 1;
                cart.CustomerId = customer.Id;
                _context.Add(cart);
            }
            else
            {
                cart = shoppingCartDB;
                cart.Qty += 1;
                _context.Update(cart);
            }
            
         
            _context.SaveChanges();

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }
        public ActionResult Cart()
        {

            var id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == id).SingleOrDefault();

            var applicationDbContext = _context.ShoppingCarts.Where(s => s.CustomerId == customer.Id);

            return View(applicationDbContext.ToList());
        }



        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        // GET: Customers/Info/5
        public async Task<IActionResult> Info(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,IdentityUserId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,IdentityUserId")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       
        public ActionResult CartSummary(int id)
        {
            ViewData["CartCount"] = GetCount(id);
            ViewData["CartTotalCost"] = GetTotalCost(id);

            return PartialView("CartSummary");
        }
        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
        public int GetCount(int id)
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in _context.ShoppingCarts
                          where cartItems.CustomerId == id
                          select (int?)cartItems.Qty).Sum();

            // Return 0 if all entries are null
            return count ?? 0;
        }
        public int GetTotalCost(int id)
        {
            var product = _context.Products;
            // Get the count of each item in the cart and sum them up
            int? total = _context.ShoppingCarts.Where(s => s.CustomerId == id).Select(x=>x.Qty * x.Price).Sum();
            //@(((decimal)@ViewData["CartTotalCost"].ToString("C2"))


            // Return 0 if all entries are null
            return total ?? 0;
        }
    }
}
