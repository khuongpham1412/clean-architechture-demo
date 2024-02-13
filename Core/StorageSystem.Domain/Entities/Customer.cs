using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Domain.Entities
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]

        public string Name { get; set; }

        [Required]

        public string Address { get; set; }

        [Required]

        public string Phone { get; set; }

        public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;

        public bool IsDeleted { get; set;} = false;

        public Guid? OrderId { get; set; }
    }
}
