using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Domain.Entities
{
    public class CouponDetail
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("CouponId")]
        public Guid CouponId { set; get; }
        public virtual Coupon? Coupon { get; set; }

        [ForeignKey("ProductId")]
        public Guid ProductId { set; get; }
        public virtual Product? Product { get; set; }
    }
}
