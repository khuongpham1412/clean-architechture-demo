using StorageSystem.Application.Models.Customer.Outs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Models.Customer.Outs
{
    public class GetCustomerForView
    {
        public List<CustomerList> Customers = new List<CustomerList>();

        public int Total { get; set; }
    }

    public class CustomerList
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public DateTimeOffset DateCreated { get; set; }
    }
}
