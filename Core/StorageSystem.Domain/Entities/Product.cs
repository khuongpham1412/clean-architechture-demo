using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.Domain.Entities;

public class Product
{
    [Key]
    public Guid Id { set; get; } = Guid.NewGuid();

    [Required]
    public string Name { set; get; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal Price { set; get; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal OriginalPrice { set; get; }

    public string? Description { set; get; }

    //Thiếu field nhập số lượng cho phép thông báo khi sắp hết hàng

    [ForeignKey("CategoryId")]
    public Guid CategoryId { set; get; }
    public virtual Category? Category { get; set; }

    public bool IsDeleted { get; set; } = false;

    public DateTimeOffset DateCreated { set; get; } = DateTimeOffset.Now;

    public string ThumbnailImage { get; set; }

    public virtual List<ProductImage> ProductImages { get; set; }

    public List<ProductSupplier>? ProductSuppliers { get; set; }

    public List<ProductUnit>? ProductUnits { get; set; }
}