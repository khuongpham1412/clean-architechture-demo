using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Domain.Entities
{
    public class ProductUnit
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey("UnitId")]
        public Guid UnitId { set; get; }
        public virtual Unit? Unit { get; set; }

        [ForeignKey("ProductId")]
        public Guid ProductId { set; get; }
        public virtual Product? Product { get; set; }

        public int Quantity { get; set; }
    }
}
