using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CustomerMvcApp.DLL;
using CustomerMvcApp.Models;

namespace CustomerMvcApp.BLL
{
    public class CustomerManager
    {
        CustomerRepository customerRepository = new CustomerRepository();

        public bool IsSaved(Customer customer)
        {
            bool isSaved = customerRepository.Saved(customer);
            return isSaved;

        }

        public bool IsUpdate(Customer customer)
        {
            bool isUpdate = customerRepository.Updated(customer);
            return isUpdate;
        }

        public DataTable Show(string name)
        {
            return customerRepository.Show(name);
        }

        public bool IsDelete(string code)
        {
            return customerRepository.Delete(code);
        }
    }
}