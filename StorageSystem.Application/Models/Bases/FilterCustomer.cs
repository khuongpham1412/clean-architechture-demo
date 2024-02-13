using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Models.Bases
{
    public class FilterCustomer : Paging
    {
        public string? Keyword { get; set; }
    }
}
