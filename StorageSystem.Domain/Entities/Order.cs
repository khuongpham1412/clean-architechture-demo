using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageSystem.Domain.Enums;

namespace StorageSystem.Domain.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal? DiscountAmount { get; set; }

        public Guid OwnerId { get; set; }

        [ForeignKey("ProductId")]
        public Guid ProductId { set; get; }
        public virtual Product? Product { get; set; }

        [ForeignKey("UnitId")]
        public Guid UnitId { set; get; }
        public virtual Unit? Unit { get; set; }

        [ForeignKey("CustomerId")]
        public Guid CustomerId { set; get; }
        public virtual Customer? Customer { get; set; }

        public StatusOrder StatusOrder { get; set; }

        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;
    }
}
