using StorageSystem.Application.Models.Bill.Base;
using StorageSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Models.Bill.Ins
{
    public class CreateBillInsDto : CreateOrUpdateBillDto
    {
        public string? CustomerName { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public Guid OwnerId { get; set; }

        public StatusOrder Status { get; set; }

        public List<CreateBillInsItemDto> Orders { get; set; }
    }

    public class CreateBillInsItemDto
    {
        public Guid ProductId { get; set; }

        public Guid UnitId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal? DiscountAmount { get; set; }
    }
}
