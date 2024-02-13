using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Domain.Entities
{
    public class ProductSupplier
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey("SupplierId")]
        public Guid SupplierId { set; get; }
        public virtual Supplier? Supplier { get; set; }

        [ForeignKey("ProductId")]
        public Guid ProductId { set; get; }
        public virtual Product? Product { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { set; get; }
    }
}
