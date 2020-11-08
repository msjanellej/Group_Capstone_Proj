using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GroupCapstone.ActionFilters
{
	public class GlobalRouting :IActionFilter
	{
			private readonly ClaimsPrincipal _claimsPrincipal;
			public GlobalRouting(ClaimsPrincipal claimsPrincipal)   // Injecting ClaimsPrincipal class into our filter
			{
				_claimsPrincipal = claimsPrincipal;
			}
			public void OnActionExecuting(ActionExecutingContext context)   // Runs before action method executed
			{
					var controller = context.RouteData.Values["controller"];
					if (controller.Equals("Home"))
					{
							if (_claimsPrincipal.IsInRole("Admin"))
							{
								context.Result = new RedirectToActionResult("Index", "Admin", null);
							}
							else if (_claimsPrincipal.IsInRole("Customer"))    // If user role is customer, redirect to home/index belonging to customer view
							{
								context.Result = new RedirectToActionResult("Index", "Customers", null);
							}
							else if (_claimsPrincipal.IsInRole("Employee"))   // If user role is employee, redirect to home/index belonging to employee view
							{
								context.Result = new RedirectToActionResult("Index", "Employees", null);
							}

					}
			}
			public void OnActionExecuted(ActionExecutedContext context)
			{

			}
	}

}


