using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Models.Customer.Base
{
    public class CreateOrUpdateCustomerDto
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
