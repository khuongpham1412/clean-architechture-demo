using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Domain.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTimeOffset DateCreated { set; get; } = DateTimeOffset.Now;

        public virtual List<Product>? Products { get; set; }

    }
}
