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
using Stripe;
using System.Net;
using GroupCapstone.Services.Messaging;
using GroupCapstone.Services.Messaging.Email;

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
            CartSummary();

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
        // GET: /Customers/Cart
        public ActionResult Cart()
        {
            CartSummary();
            var id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(c => c.IdentityUserId == id).SingleOrDefault();

            var applicationDbContext = _context.ShoppingCarts.Where(s => s.CustomerId == customer.Id);
            ViewData["cusomerId"] = customer.Id;
            ViewBag.cart = applicationDbContext;
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
            CartSummary();
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
            CartSummary();
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id").ToList();
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,IdentityUserId")] Models.Customer customer)
        {
            if (ModelState.IsValid)
            {
                customer.IdentityUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var save = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["IdentityUserId"] = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CartSummary();
            var shoppingCart = await _context.ShoppingCarts.FindAsync(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }
            
            // ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", shppingCart.IdentityUserId);
            return View(shoppingCart);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ShoppingCart shoppingCart)
        {
           
            CartSummary();
            
                try
                {
                    var cart = _context.ShoppingCarts.Where(s => s.CustomerId == shoppingCart.CustomerId && s.ProductId == shoppingCart.ProductId).FirstOrDefault();
                       cart.Qty = shoppingCart.Qty;
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(shoppingCart.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Cart));
           
        
            
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            CartSummary();
            var shoppingCart = await _context.ShoppingCarts.FirstOrDefaultAsync(m => m.Id == id);
            if (shoppingCart == null)
            {
                return NotFound();
            }
            //var shoppingCart = await _context.ShoppingCarts.FindAsync(id);
            _context.ShoppingCarts.Remove(shoppingCart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Cart));
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var shoppingCart = await _context.ShoppingCarts.FindAsync(id);
            _context.ShoppingCarts.Remove(shoppingCart);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Cart));
        }
       
        public ActionResult CartSummary()
        {

            var customers = _context.Customers;
            var id = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = customers.Where(c => c.IdentityUserId == id).SingleOrDefault();
            if (GetCount(customer.Id) == 0)
            {
                return RedirectToAction("Index");
            }
            ViewData["CartCount"] = GetCount(customer.Id);
            ViewData["CartTotalCost"] = Math.Round(GetTotalCost(customer.Id), 2);
            ViewData["CartTotalCostString"] = Math.Round(GetTotalCost(customer.Id), 2).ToString("0.00");
            ViewData["CustomerEmail"] = customer.Email;
            ViewData["CustomerId"] = customer.Id;
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
        public double GetTotalCost(int id)
        {
            var product = _context.Products;
            // Get the count of each item in the cart and sum them up
            double? total = _context.ShoppingCarts.Where(s => s.CustomerId == id).Select(x=>x.Qty * x.Price).Sum();
            //@(((decimal)@ViewData["CartTotalCost"].ToString("C2"))


            // Return 0 if all entries are null
            return total ?? 0;
        }
         public async void OrderProccess(string reciept) 
        {
            CartSummary();
            var customerId = ViewData["CustomerId"];
            var totalCost = ViewData["CartTotalCost"];
            string htmlCode;
            //shoopingcart qty, price, productid customerid
            //order qty, price productid, orderId
            //order Date, Totalprice, customerID

            //add order to the database
            Models.Order order = new Models.Order();
            order.Date = DateTime.Now;
            order.CustomerId = (int)customerId;
            order.TotalPrice = (double)totalCost;
            
            _context.Orders.Add(order);
            _context.SaveChanges();
            int lastProductId = _context.Orders.Max(item => item.Id);

            //add orderDetails to the database one line at a time
            var shoppingCart = _context.ShoppingCarts.Where(s => s.CustomerId == (int)customerId).ToList();
            foreach (var item in shoppingCart)
            {
                OrderDetails orderDetails = new OrderDetails();
                orderDetails.OrderId = lastProductId;
                orderDetails.ProductId = item.ProductId;
                orderDetails.Price = item.Price * item.Qty;
                orderDetails.Quantity = item.Qty;
                
                _context.ShoppingCarts.Remove(item);
                _context.OrderDetails.Add(orderDetails);
                _context.SaveChanges();
            }

            Models.Customer customer = _context.Customers.Where(s => s.Id == (int)customerId).FirstOrDefault();

            
            //send eamil
            using (WebClient client = new WebClient()) // WebClient class inherits IDisposable
            {
                htmlCode = client.DownloadString(reciept);
            }
            await SendEmail(customer, htmlCode);
            
        }

        public async Task SendEmail(Models.Customer customer, string html)
        {
            string emailBody = html;

            MessageService service = new MessageService();
            //Email.GetQRCode(order);
            await service.SendEmailAsync(
                    "BusinessName",
                    APIKEYS.emailId,
                    customer.FirstName,
                    customer.Email,
                    "Your order has been recieved",
                    emailBody, false);
        }

        public IActionResult Checkout(int? id)
        {
            CartSummary();
            return View();
        }
        
        public async Task<IActionResult> StoreInfo()
        {
            CartSummary();
           

            var storeInfo = await _context.StoreInfo
                .FirstOrDefaultAsync(m => m.Id == 1);
            if (storeInfo == null)
            {
                return NotFound();
            }

            return View(storeInfo);
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout()
        { 
            CartSummary();
            var totalCost = ViewData["CartTotalCost"];
            var Email = ViewData["CustomerEmail"];
            int save = (int)((double)totalCost * 100);
            StripeConfiguration.ApiKey = APIKEYS.StripeApiKey;

            // `source` is obtained with Stripe.js; see https://stripe.com/docs/payments/accept-a-payment-charges#web-create-token
            var options = new ChargeCreateOptions
            {
                Amount = save,
                Currency = "usd",
                Source = "tok_visa",
                Description = "Order from app. Custom text could be brought in here",
                ReceiptEmail = (string)Email 
            };
            var service = new ChargeService();
            var payment = service.Create(options);
            if (payment.Status == "succeeded")
            {
                OrderProccess(payment.ReceiptUrl);
            }
            else
            {
                //place popup for error
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
