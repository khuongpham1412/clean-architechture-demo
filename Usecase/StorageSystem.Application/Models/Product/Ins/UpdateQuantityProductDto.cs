using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Models.Product.Ins
{
    public class UpdateQuantityProductDto
    {
        public Guid ProductId { get; set;}

        public Guid UnitId { get; set; }

        public int Quantity { get; set;}
    }
}
