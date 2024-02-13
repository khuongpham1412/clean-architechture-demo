using StorageSystem.Application.Models.Product.Base;
using StorageSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Application.Models.Product.Outs
{
    public class GetProductForView
    {
        public List<ProductList> ProductLists = new List<ProductList>();

        public int Total { get; set; }
    }

    public class ProductList
    {
        public Guid Id { set; get; }

        public string Name { set; get; }

        public decimal Price { set; get; }

        public int Quantity { set; get; }

        public decimal OriginalPrice { set; get; }

        public int Stock { set; get; }

        public DateTimeOffset DateCreated { set; get; }

        public string? Description { set; get; }

        public string ThumbnailImage { get; set; }

        public Guid CategoryId { set; get; }

        public virtual List<ProductImageDto> ProductImages { get; set; }
        //public List<string> Categories { get; set; }
        //public ProductDto Product { get; set; }
    }

    public class ProductImageDto
    {
        public Guid Id { get; set; }

        public string ImagePath { get; set; }

        public string? Caption { get; set; }

        public Guid ProductId { get; set; }

        public bool IsImageFeature { get; set; }
    }
}
