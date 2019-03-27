using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomerMvcApp.BLL;
using CustomerMvcApp.Models;

namespace CustomerMvcApp.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager = new CustomerManager();
        public string Add(Customer customer)
        {
            if (customerManager.IsSaved(customer))
            {
                return "Saved";
            }
            return "Not Saved";
        }

        public string Update(Customer customer)
        {
            if (customerManager.IsUpdate(customer))
            {
                return "Updated";
            }
            return "Not Updated";
        }

        public string Delete(string code)
        {
            if (customerManager.IsDelete(code))
            {
                return "Delete successfully";

            }
            return "Not Deleted NO Data Found";
        }

        public ViewResult Show(string name)
        {
            DataTable dt = customerManager.Show(name);
            return View(dt);
        }
	}
}