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
            var orders = _context.Order.Where(o => o.IsCompleted == false);
            List<Order> orderList = new List<Order>();
            foreach (var item in orders)
            {
                orderList.Add(item);
            }
            return View(orderList);
        }

        
        public  IActionResult OrderDetailsIndex(int? id)
        {
            var order = _context.OrderOrderDetailProductVM.Where(o => o.OrderVM.Id == id).ToList();
            
            return View(order);
        }
        public ActionResult ConfirmPickedOrder(Order order)
        {
            var orderPicked = _context.Order.Single(c => c.Id == order.Id);
            orderPicked.IsPicked = order.IsPicked;
            _context.SaveChanges();
            return View("OrderDetail", orderPicked);


        }
        public ActionResult ConfirmOrderComplete(Order order)
        {
            var orderCompleted = _context.Order.Single(c => c.Id == order.Id);
            orderCompleted.IsPicked = order.IsPicked;
            _context.SaveChanges();
            return View("OrderDetail", orderCompleted);


        }


       
    }
}
