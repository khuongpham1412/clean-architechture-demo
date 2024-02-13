using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Models.Bill.Ins
{
    public class ReplacementBillInsDto
    {
        public int BillId { get; set; }

        public List<ReplacementBillInsItemDto> Items { get; set;}
    }

    public class ReplacementBillInsItemDto
    {
        public Guid ProductId { get; set; }

        public Guid UnitId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal? DiscountAmount { get; set; }
    }
}
