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
using GroupCapstone.Services.Messaging.Email;
using System.Security.Claims;
using IronBarCode;
using System.Drawing;

namespace GroupCapstone.Controllers
{
   [Authorize (Roles = "Employee")]
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
            var employeesOnList = _context.Employees.ToList();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (employee == null)
            {
                return RedirectToAction("Create");
            }
            List<Order> orders = new List<Order>();
            var order = _context.Orders.Where(o => o.IsCompleted == false);
            orders = order.OrderBy(o => o.Date).ToList();
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
            
            await SendEmail(customer, order);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task SendEmail(Customer customer, Order order)
        {

            string emailBody = "<div><h1>Thank you for placing your order with us!</h1></div><br>" +
            "<div>Your order has been pick by our talented warehouse ninjas. And is now ready to be pickup by you.</div>"+
            "<div>Please show the attached QR code to the employee when you arrive for your pick up.</div>";

            MessageService service = new MessageService();
            Email.GetQRCode(order);
            await service.SendEmailAsync(
                    "BusinessName",
                    APIKEYS.emailId,
                    customer.FirstName,
                    customer.Email,
                    "Your order is Ready to Pick Up",
                    emailBody,true);

        }
        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                _context.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index", "Employees");
            }
            catch
            {
                return View();
            }
        }
        //public GeneratedBarcode GetQRCode(Order order)
        //{
        //    var qrCode = QRCodeWriter.CreateQrCode(order.Id.ToString(), 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPng("MyQR.png");
        //    return qrCode;
        //}

    }





}

