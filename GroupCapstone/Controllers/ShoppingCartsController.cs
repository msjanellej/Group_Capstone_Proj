using System;
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
    public class ShoppingCartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShoppingCart
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ShoppingCart.Include(s => s.Product);
            return View(await applicationDbContext.ToListAsync());
        }

       


        // GET: ShoppingCarts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCart = await _context.ShoppingCart
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: ShoppingCarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Qty,ProductId")] ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoppingCart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", shoppingCart.ProductId);
            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCart = await _context.ShoppingCart.FindAsync(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", shoppingCart.ProductId);
            return View(shoppingCart);
        }

        // POST: ShoppingCarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Qty,ProductId")] ShoppingCart shoppingCart)
        {
            if (id != shoppingCart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoppingCart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingCartExists(shoppingCart.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", shoppingCart.ProductId);
            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCart = await _context.ShoppingCart
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
        }

        // POST: ShoppingCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingCart = await _context.ShoppingCart.FindAsync(id);
            _context.ShoppingCart.Remove(shoppingCart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingCartExists(int id)
        {
            return _context.ShoppingCart.Any(e => e.Id == id);
        }
    }
}
