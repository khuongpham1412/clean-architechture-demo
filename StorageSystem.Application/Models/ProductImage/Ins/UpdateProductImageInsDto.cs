using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Models.ProductImage.Ins
{
    public class UpdateProductImageInsDto
    {
        public int ProductId { get; set; }
        public string ImagePath { get; set; }
        public bool IsImageFeature { get; set; }

    }
}
