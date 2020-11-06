using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupCapstone.Data;
using GroupCapstone.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Cryptography.X509Certificates;
using GroupCapstone.Services.Messaging;

namespace GroupCapstone.Controllers
{
    //[Authorize (Roles = "Employee")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public IActionResult Index()
        {
            List<Order>? orders = new List<Order>();
            orders = _context.Orders.Where(o => o.IsCompleted == false).ToList();
            return View(orders);
        }


        public IActionResult OrderDetailsIndex(int? id)
        {
            List<OrderDetails> orderDetails = _context.OrderDetails.ToList();
            List<Product> product = _context.Products.ToList();
            List<Order> order = _context.Orders.ToList();
            var order_orderDetails_product = from od in orderDetails
                                             join p in product on od.ProductId equals p.Id into table1
                                             from p in table1.ToList()
                                             join o in order on od.OrderId equals o.Id into table2
                                             from o in table2.ToList()
                                             select new OrderOrderDetailProductVM
                                             {
                                                 OrderDetailsVM = od,
                                                 ProductVM = p,
                                                 OrderVM = o
                                             };
            var result = order_orderDetails_product.Where(o => o.OrderDetailsVM.OrderId == id).ToList();

            return View(result);
        }

        public ActionResult ConfirmOrderComplete(int id)
        {
            var order = _context.Orders.Where(o => o.Id == id).SingleOrDefault();
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmOrderComplete(Order order)
        {

            var orderToComplete = _context.Orders.Single(o => o.Id == order.Id);
            orderToComplete.IsCompleted = order.IsCompleted;

            _context.SaveChanges();
            return View("Index", orderToComplete);
        }
        public ActionResult ConfirmOrderPicked(int id)
        {

            var order = _context.Orders.Where(o => o.Id == id).SingleOrDefault();
            if (order == null)
            {
                return NotFound();
            }    
            return View (order);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ConfirmOrderPicked(Order order)
        {
            var orderToPick = _context.Orders.Single(o => o.Id == order.Id);
            var customer = _context.Customers.Where(c => c.Id == order.CustomerId).SingleOrDefault();
            orderToPick.IsPicked = order.IsPicked;
            await SendEmail(customer);

            _context.SaveChanges();
            return View("Index");
        }

        public async Task SendEmail(Customer customer)
        {
            MessageService service = new MessageService();

             await service.SendEmailAsync(
                    "BusinessName",
                    APIKEYS.emailId,
                    customer.FirstName,
                    customer.Email,
                    "Your order is ready for pickup",
                    "Thank you for ordering with us.");

        }
        
    }





}

