using StorageSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Models.Order.Ins
{
    public class CancelledOrderInsDto
    {
        public Guid CustomerId { get; set; }
    }
}
