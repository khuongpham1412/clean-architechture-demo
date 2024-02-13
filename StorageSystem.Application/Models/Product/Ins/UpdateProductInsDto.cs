using StorageSystem.Application.Models.Products.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Models.Product.Ins
{
    public class UpdateProductInsDto : CreateOrUpdateProductDto
    {
        public string Name { set; get; }

        public decimal Price { set; get; }

        public string Description { set; get; }

        public Guid CategoryId { get; set; }

        public string ThumbnailImage { get; set; }

        public virtual List<Domain.Entities.ProductImage> ProductImages { get; set; }
    }
}
