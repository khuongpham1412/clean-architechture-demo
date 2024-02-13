using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorageSystem.Application.Models.ProductImage.Bases;

namespace StorageSystem.Application.Models.ProductImage.Outs
{
    public class GetProductImageForViewOusDto
    {
        public ProductImageDto ProductImage { get; set; }

        public GetProductImageForViewOusDto() { }
    }
}
