using StorageSystem.Application.Models.Order.Base;
using StorageSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Models.Order.Ins
{
    public class UpdateOrderInsDto : CreateOrUpdateOrderDto
    {
        public List<UpdateOrderItemInsDto> Orders { get; set; }
    }

    public class UpdateOrderItemInsDto
    {
        public Guid ProductId { get; set; }

        public Guid UnitId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal? DiscountAmount { get; set; }

        public Guid OwnerId { get; set; }

        public StatusOrder? StatusOrder { get; set; }

        public Guid? CustomerId { get; set; }
    }
}
