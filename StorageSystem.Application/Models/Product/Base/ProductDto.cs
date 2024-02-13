using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Models.Product.Base
{
    public class ProductDto
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public DateTime DateCreated { set; get; }
        public string Description { set; get; }
        public string ThumbnailImage { get; set; }
        public List<string> Categories { get; set; }
    }
}
