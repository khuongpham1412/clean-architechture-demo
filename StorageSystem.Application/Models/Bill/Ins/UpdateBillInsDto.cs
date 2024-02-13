using StorageSystem.Application.Models.Bill.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Models.Bill.Ins
{
    public class UpdateBillInsDto : CreateOrUpdateBillDto
    {
        public List<UpdateBillInsItemDto> Items { get; set; }
    }

    public class UpdateBillInsItemDto
    {
        public Guid ProductId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal? DiscountAmount { get; set; }
    }
}
