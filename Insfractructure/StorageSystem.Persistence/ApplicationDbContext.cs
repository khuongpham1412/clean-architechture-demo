using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StorageSystem.Domain.Entities;
using StorageSystem.Persistence.Contracts;
using StorageSystem.Persistence.Models;

namespace StorageSystem.Persistence;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    //public DbSet<Product> Products => Set<Product>();
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get ; set ; }
    public DbSet<ProductImage> ProductImages { get ; set ; }
    public DbSet<Bill> Bills { get ; set ; }
    public DbSet<BillDetail> BillDetails { get ; set ; }
    public DbSet<Coupon> Coupons { get ; set ; }
    public DbSet<CouponDetail> CouponDetails { get ; set ; }
    public DbSet<Customer> Customers { get ; set ; }
    public DbSet<Supplier> Suppliers { get ; set ; }
    public DbSet<ProductSupplier> ProductSuppliers { get ; set ; }
    public DbSet<Unit> Units { get ; set ; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<ProductUnit> ProductUnits { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
        // tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
        // Đoạn mã sau chạy khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố đó
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var tableName = entityType.GetTableName();
            if (tableName!.StartsWith("AspNet"))
            {
                entityType.SetTableName(tableName.Substring(6));
            }
        }
        builder.Entity<Category>()
        .Property(f => f.Id)
        .ValueGeneratedOnAdd();

        builder.Entity<Product>()
        .Property(f => f.Id)
        .ValueGeneratedOnAdd();

        builder.Entity<ProductImage>()
        .Property(f => f.Id)
        .ValueGeneratedOnAdd();

        builder.Entity<Category>().HasData(
         new Category
         {
             Id = new Guid("9be53c65-521f-417a-b7de-13af7b0bdfc4"),
             Name = "Vật liệu xây dựng",
             DateCreated = DateTime.Now,
             IsDeleted = false
         },
         new Category
         {
             Id = new Guid("cf846c38-b43c-494d-bbbf-838a65ec3299"),
             Name = "Đồ điện",
             DateCreated = DateTime.Now,
             IsDeleted = false
         },
         new Category
         {
             Id = new Guid("de6b4a9e-1d88-48db-b21d-cfb3ee139df9"),
             Name = "Đồ gia dụng",
             DateCreated = DateTime.Now,
             IsDeleted = false
         },
         new Category
         {
             Id = new Guid("a4533b2f-1174-4587-8fe8-3333295cc0ac"),
             Name = "Vật phẩm trang trí",
             DateCreated = DateTime.Now,
             IsDeleted = false
         }
        );

        builder.Entity<Unit>().HasData(
         new Unit
         {
             Id = new Guid("4b703409-a32a-49cf-9943-d5a68dbedd6f"),
             Name = "Thùng",
             DateCreated = DateTime.Now,
             IsDeleted = false
         }
        );

        builder.Entity<Unit>().HasData(
         new Unit
         {
             Id = new Guid("bb7b0969-4383-446f-8ab9-6d766df08359"),
             Name = "Kg",
             DateCreated = DateTime.Now,
             IsDeleted = false
         }
        );

        builder.Entity<Unit>().HasData(
         new Unit
         {
             Id = new Guid("54cb56aa-a710-47e0-a386-4cc493d46747"),
             Name = "Hộp",
             DateCreated = DateTime.Now,
             IsDeleted = false
         }
        );

        builder.Entity<Product>().HasData(
            new Product
            {
                Id = new Guid("484c3f38-bfe0-42b9-8e9c-f30f1aa86fd3"),
                Name = "Tony Reichert",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/80",
                CategoryId = new Guid("9be53c65-521f-417a-b7de-13af7b0bdfc4"),
                OriginalPrice = 110000,
                Price = 405000
                
            },
            new Product
            {
                Id = new Guid("3238c0b8-d4a3-4cfb-9167-695ef4224b6b"),
                Name = "Zoey Lang",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/81",
                CategoryId = new Guid("9be53c65-521f-417a-b7de-13af7b0bdfc4"),
                OriginalPrice = 110000,
                Price = 406000
            },
            new Product
            {
                Id = new Guid("0de34a77-a035-4eac-8f1b-5f21ebef4569"),
                Name = "Jane Fisher",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/82",
                CategoryId = new Guid("cf846c38-b43c-494d-bbbf-838a65ec3299"),
                OriginalPrice = 110000,
                Price = 407000
            },
            new Product
            {
                Id = new Guid("163bd018-c22a-49e5-adb0-2ca2942bc420"),
                Name = "William Howard",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/83",
                CategoryId = new Guid("de6b4a9e-1d88-48db-b21d-cfb3ee139df9"),
                OriginalPrice = 110000,
                Price = 408000
            },
            new Product
            {
                Id = new Guid("1a1f7026-eb10-4632-ba16-c12bbea207b7"),
                Name = "Kristen Copper",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/84",
                CategoryId = new Guid("a4533b2f-1174-4587-8fe8-3333295cc0ac"),
                OriginalPrice = 110000,
                Price = 409000
            },
            new Product
            {
                Id = new Guid("c861791b-bce9-47a9-84c7-1abdb578d88b"),
                Name = "Brian Kim",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/85",
                CategoryId = new Guid("a4533b2f-1174-4587-8fe8-3333295cc0ac"),
                OriginalPrice = 110000,
                Price = 410000
            },
            new Product
            {
                Id = new Guid("d0d58f20-abe1-4f54-8e44-50e1d226ead4"),
                Name = "Michael Hunt",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/86",
                CategoryId = new Guid("9be53c65-521f-417a-b7de-13af7b0bdfc4"),
                OriginalPrice = 110000,
                Price = 411000
            },
            new Product
            {
                Id = new Guid("dcbeea7e-4675-4a01-b59a-a9e1f3e5f4b4"),
                Name = "Samantha Brooks",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/87",
                CategoryId = new Guid("9be53c65-521f-417a-b7de-13af7b0bdfc4"),
                OriginalPrice = 110000,
                Price = 412000 
            },
            new Product
            {
                Id = new Guid("97aac145-947d-4da4-8191-a2a3faa81fce"),
                Name = "Frank Harrison",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/88",
                CategoryId = new Guid("de6b4a9e-1d88-48db-b21d-cfb3ee139df9"),
                OriginalPrice = 110000,
                Price = 413000
            },
            new Product
            {
                Id = new Guid("0a5b4248-5d36-45aa-89fc-dd913824d34e"),
                Name = "Emma Adams",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/89",
                CategoryId = new Guid("de6b4a9e-1d88-48db-b21d-cfb3ee139df9"),
                OriginalPrice = 110000,
                Price = 414000
            },
            new Product
            {
                Id = new Guid("da3156b8-3324-4684-8789-9af51316865b"),
                Name = "Brandon Stevens",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/90",
                CategoryId = new Guid("de6b4a9e-1d88-48db-b21d-cfb3ee139df9"),
                OriginalPrice = 110000,
                Price = 415000
            },
            new Product
            {
                Id = new Guid("19400bf1-1da8-4a52-a515-4c36577bc98b"),
                Name = "Megan Richards",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/91",
                CategoryId = new Guid("cf846c38-b43c-494d-bbbf-838a65ec3299"),
                OriginalPrice = 110000,
                Price = 416000
            },
            new Product
            {
                Id = new Guid("5d01611b-e2ad-4abd-b40e-0450f50d2ec9"),
                Name = "Oliver Scott",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/92",
                CategoryId = new Guid("cf846c38-b43c-494d-bbbf-838a65ec3299"),
                OriginalPrice = 110000,
                Price = 305000
            },
            new Product
            {
                Id = new Guid("cff0eb9e-3b50-4ade-9f56-cb0e4ab4d617"),
                Name = "Grace Allen",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/93",
                CategoryId = new Guid("9be53c65-521f-417a-b7de-13af7b0bdfc4"),
                OriginalPrice = 110000,
                Price = 200000
            },
            new Product
            {
                Id = new Guid("9089f19c-473d-40b1-b7b3-e0f5f6c8f8df"),
                Name = "Noah Carter",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/94",
                CategoryId = new Guid("a4533b2f-1174-4587-8fe8-3333295cc0ac"),
                OriginalPrice = 110000,
                Price = 307000
            },
            new Product
            {
                Id= new Guid("f9ac3e9c-da9e-4aba-8a12-291a3655864b"),
                Name = "Ava Perez",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/95",
                CategoryId = new Guid("de6b4a9e-1d88-48db-b21d-cfb3ee139df9"),
                OriginalPrice = 110000,
                Price = 405000
            },
            new Product
            {
                Id = new Guid("6a9955a7-5c78-40fa-8020-174f1018f797"),
                Name = "Noah Carter",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/96",
                CategoryId = new Guid("a4533b2f-1174-4587-8fe8-3333295cc0ac"),
                OriginalPrice = 110000,
                Price = 406000
            },
            new Product
            {
                Id = new Guid("f35c176b-c70a-4fb5-b9b3-885eb8731901"),
                Name = "Ava Perez",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/97",
                CategoryId = new Guid("de6b4a9e-1d88-48db-b21d-cfb3ee139df9"),
                OriginalPrice = 110000,
                Price = 417000
            },
            new Product
            {
                Id = new Guid("e9416abf-ab8a-4b69-8bb5-3f3a8b7024ad"),
                Name = "Ava Perez",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/97",
                CategoryId = new Guid("a4533b2f-1174-4587-8fe8-3333295cc0ac"),
                OriginalPrice = 110000,
                Price = 405000
            },
            new Product
            {
                Id = new Guid("9244f89d-1b5d-44cd-8a7f-1922d464e336"),
                Name = "Ava Perez",
                DateCreated = DateTime.Now,
                IsDeleted = false,
                Description = "Description",
                ThumbnailImage = "https://placewaifu.com/image/97",
                CategoryId = new Guid("a4533b2f-1174-4587-8fe8-3333295cc0ac"),
                OriginalPrice = 110000,
                Price = 300000
            }
        );

        builder.Entity<ProductImage>().HasData(
            new ProductImage
            {
                ProductId = new Guid("484c3f38-bfe0-42b9-8e9c-f30f1aa86fd3"),
                ImagePath = "https://placewaifu.com/image/80",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
            {
                ProductId = new Guid("484c3f38-bfe0-42b9-8e9c-f30f1aa86fd3"),
                ImagePath = "https://placewaifu.com/image/91",
                IsImageFeature = false,
                Caption = "Caption"
            },
            new ProductImage
            {
                ProductId = new Guid("484c3f38-bfe0-42b9-8e9c-f30f1aa86fd3"),
                ImagePath = "https://placewaifu.com/image/92",
                IsImageFeature = false,
                Caption = "Caption"
            },
            new ProductImage
            {
                ProductId = new Guid("484c3f38-bfe0-42b9-8e9c-f30f1aa86fd3"),
                ImagePath = "https://placewaifu.com/image/93",
                IsImageFeature = false,
                Caption = "Caption"
            },

            new ProductImage
            {
                ProductId = new Guid("3238c0b8-d4a3-4cfb-9167-695ef4224b6b"),
                ImagePath = "https://placewaifu.com/image/81",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
                    {
                        ProductId = new Guid("3238c0b8-d4a3-4cfb-9167-695ef4224b6b"),
                        ImagePath = "https://placewaifu.com/image/91",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("3238c0b8-d4a3-4cfb-9167-695ef4224b6b"),
                        ImagePath = "https://placewaifu.com/image/92",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("3238c0b8-d4a3-4cfb-9167-695ef4224b6b"),
                        ImagePath = "https://placewaifu.com/image/93",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },

            new ProductImage
            {
                ProductId = new Guid("0de34a77-a035-4eac-8f1b-5f21ebef4569"),
                ImagePath = "https://placewaifu.com/image/82",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
                    {
                        ProductId = new Guid("0de34a77-a035-4eac-8f1b-5f21ebef4569"),
                        ImagePath = "https://placewaifu.com/image/91",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("0de34a77-a035-4eac-8f1b-5f21ebef4569"),
                        ImagePath = "https://placewaifu.com/image/92",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("0de34a77-a035-4eac-8f1b-5f21ebef4569"),
                        ImagePath = "https://placewaifu.com/image/93",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },

            new ProductImage
        {
            ProductId = new Guid("163bd018-c22a-49e5-adb0-2ca2942bc420"),
            ImagePath = "https://placewaifu.com/image/83",
            IsImageFeature = true,
            Caption = "Caption"
        },
            new ProductImage
                    {
                        ProductId = new Guid("163bd018-c22a-49e5-adb0-2ca2942bc420"),
                        ImagePath = "https://placewaifu.com/image/91",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("163bd018-c22a-49e5-adb0-2ca2942bc420"),
                        ImagePath = "https://placewaifu.com/image/92",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("163bd018-c22a-49e5-adb0-2ca2942bc420"),
                        ImagePath = "https://placewaifu.com/image/93",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },

            new ProductImage
            {
                ProductId = new Guid("1a1f7026-eb10-4632-ba16-c12bbea207b7"),
                ImagePath = "https://placewaifu.com/image/84",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
                    {
                        ProductId = new Guid("1a1f7026-eb10-4632-ba16-c12bbea207b7"),
                        ImagePath = "https://placewaifu.com/image/91",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("1a1f7026-eb10-4632-ba16-c12bbea207b7"),
                        ImagePath = "https://placewaifu.com/image/92",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("1a1f7026-eb10-4632-ba16-c12bbea207b7"),
                        ImagePath = "https://placewaifu.com/image/93",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },

            new ProductImage
            {
                ProductId = new Guid("c861791b-bce9-47a9-84c7-1abdb578d88b"),
                ImagePath = "https://placewaifu.com/image/85",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
                    {
                        ProductId = new Guid("c861791b-bce9-47a9-84c7-1abdb578d88b"),
                        ImagePath = "https://placewaifu.com/image/91",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("c861791b-bce9-47a9-84c7-1abdb578d88b"),
                        ImagePath = "https://placewaifu.com/image/92",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("c861791b-bce9-47a9-84c7-1abdb578d88b"),
                        ImagePath = "https://placewaifu.com/image/93",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },

            new ProductImage
            {
                ProductId = new Guid("d0d58f20-abe1-4f54-8e44-50e1d226ead4"),
                ImagePath = "https://placewaifu.com/image/86",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
                    {
                        ProductId = new Guid("d0d58f20-abe1-4f54-8e44-50e1d226ead4"),
                        ImagePath = "https://placewaifu.com/image/91",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("d0d58f20-abe1-4f54-8e44-50e1d226ead4"),
                        ImagePath = "https://placewaifu.com/image/92",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("d0d58f20-abe1-4f54-8e44-50e1d226ead4"),
                        ImagePath = "https://placewaifu.com/image/93",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },

            new ProductImage
            {
                ProductId = new Guid("dcbeea7e-4675-4a01-b59a-a9e1f3e5f4b4"),
                ImagePath = "https://placewaifu.com/image/87",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
                    {
                        ProductId = new Guid("dcbeea7e-4675-4a01-b59a-a9e1f3e5f4b4"),
                        ImagePath = "https://placewaifu.com/image/91",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("dcbeea7e-4675-4a01-b59a-a9e1f3e5f4b4"),
                        ImagePath = "https://placewaifu.com/image/92",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("dcbeea7e-4675-4a01-b59a-a9e1f3e5f4b4"),
                        ImagePath = "https://placewaifu.com/image/93",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },

            new ProductImage
            {
                ProductId = new Guid("97aac145-947d-4da4-8191-a2a3faa81fce"),
                ImagePath = "https://placewaifu.com/image/88",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
                    {
                        ProductId = new Guid("97aac145-947d-4da4-8191-a2a3faa81fce"),
                        ImagePath = "https://placewaifu.com/image/91",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("97aac145-947d-4da4-8191-a2a3faa81fce"),
                        ImagePath = "https://placewaifu.com/image/92",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("97aac145-947d-4da4-8191-a2a3faa81fce"),
                        ImagePath = "https://placewaifu.com/image/93",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },

            new ProductImage
            {
                ProductId = new Guid("0a5b4248-5d36-45aa-89fc-dd913824d34e"),
                ImagePath = "https://placewaifu.com/image/89",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
                    {
                        ProductId = new Guid("0a5b4248-5d36-45aa-89fc-dd913824d34e"),
                        ImagePath = "https://placewaifu.com/image/91",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("0a5b4248-5d36-45aa-89fc-dd913824d34e"),
                        ImagePath = "https://placewaifu.com/image/92",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("0a5b4248-5d36-45aa-89fc-dd913824d34e"),
                        ImagePath = "https://placewaifu.com/image/93",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },

            new ProductImage
            {
                ProductId = new Guid("da3156b8-3324-4684-8789-9af51316865b"),
                ImagePath = "https://placewaifu.com/image/90",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
                    {
                        ProductId = new Guid("da3156b8-3324-4684-8789-9af51316865b"),
                        ImagePath = "https://placewaifu.com/image/91",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("da3156b8-3324-4684-8789-9af51316865b"),
                        ImagePath = "https://placewaifu.com/image/92",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("da3156b8-3324-4684-8789-9af51316865b"),
                        ImagePath = "https://placewaifu.com/image/93",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },

            new ProductImage
            {
                ProductId = new Guid("19400bf1-1da8-4a52-a515-4c36577bc98b"),
                ImagePath = "https://placewaifu.com/image/91",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
                    {
                        ProductId = new Guid("19400bf1-1da8-4a52-a515-4c36577bc98b"),
                        ImagePath = "https://placewaifu.com/image/91",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("19400bf1-1da8-4a52-a515-4c36577bc98b"),
                        ImagePath = "https://placewaifu.com/image/92",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("19400bf1-1da8-4a52-a515-4c36577bc98b"),
                        ImagePath = "https://placewaifu.com/image/93",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },

            new ProductImage
            {
                ProductId = new Guid("5d01611b-e2ad-4abd-b40e-0450f50d2ec9"),
                ImagePath = "https://placewaifu.com/image/92",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
                    {
                        ProductId = new Guid("5d01611b-e2ad-4abd-b40e-0450f50d2ec9"),
                        ImagePath = "https://placewaifu.com/image/91",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("5d01611b-e2ad-4abd-b40e-0450f50d2ec9"),
                        ImagePath = "https://placewaifu.com/image/92",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("5d01611b-e2ad-4abd-b40e-0450f50d2ec9"),
                        ImagePath = "https://placewaifu.com/image/93",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },

            new ProductImage
            {
                ProductId = new Guid("cff0eb9e-3b50-4ade-9f56-cb0e4ab4d617"),
                ImagePath = "https://placewaifu.com/image/93",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
                    {
                        ProductId = new Guid("cff0eb9e-3b50-4ade-9f56-cb0e4ab4d617"),
                        ImagePath = "https://placewaifu.com/image/91",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("cff0eb9e-3b50-4ade-9f56-cb0e4ab4d617"),
                        ImagePath = "https://placewaifu.com/image/92",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("cff0eb9e-3b50-4ade-9f56-cb0e4ab4d617"),
                        ImagePath = "https://placewaifu.com/image/93",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },

            new ProductImage
            {
                ProductId = new Guid("9089f19c-473d-40b1-b7b3-e0f5f6c8f8df"),
                ImagePath = "https://placewaifu.com/image/94",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
                    {
                        ProductId = new Guid("9089f19c-473d-40b1-b7b3-e0f5f6c8f8df"),
                        ImagePath = "https://placewaifu.com/image/91",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("9089f19c-473d-40b1-b7b3-e0f5f6c8f8df"),
                        ImagePath = "https://placewaifu.com/image/92",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("9089f19c-473d-40b1-b7b3-e0f5f6c8f8df"),
                        ImagePath = "https://placewaifu.com/image/93",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },

            new ProductImage
            {
                ProductId = new Guid("f9ac3e9c-da9e-4aba-8a12-291a3655864b"),
                ImagePath = "https://placewaifu.com/image/95",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
                    {
                        ProductId = new Guid("f9ac3e9c-da9e-4aba-8a12-291a3655864b"),
                        ImagePath = "https://placewaifu.com/image/91",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("f9ac3e9c-da9e-4aba-8a12-291a3655864b"),
                        ImagePath = "https://placewaifu.com/image/92",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },
            new ProductImage
                    {
                        ProductId = new Guid("f9ac3e9c-da9e-4aba-8a12-291a3655864b"),
                        ImagePath = "https://placewaifu.com/image/93",
                        IsImageFeature = false,
                        Caption = "Caption"
                    },

            new ProductImage
            {
                ProductId = new Guid("6a9955a7-5c78-40fa-8020-174f1018f797"),
                ImagePath = "https://placewaifu.com/image/96",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
            {
                ProductId = new Guid("6a9955a7-5c78-40fa-8020-174f1018f797"),
                ImagePath = "https://placewaifu.com/image/91",
                IsImageFeature = false,
                Caption = "Caption"
            },
            new ProductImage
            {
                ProductId = new Guid("6a9955a7-5c78-40fa-8020-174f1018f797"),
                ImagePath = "https://placewaifu.com/image/92",
                IsImageFeature = false,
                Caption = "Caption"
            },
            new ProductImage
            {
                ProductId = new Guid("6a9955a7-5c78-40fa-8020-174f1018f797"),
                ImagePath = "https://placewaifu.com/image/93",
                IsImageFeature = false,
                Caption = "Caption"
            },

            new ProductImage
            {
                ProductId = new Guid("f35c176b-c70a-4fb5-b9b3-885eb8731901"),
                ImagePath = "https://placewaifu.com/image/97",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
            {
                ProductId = new Guid("f35c176b-c70a-4fb5-b9b3-885eb8731901"),
                ImagePath = "https://placewaifu.com/image/91",
                IsImageFeature = false,
                Caption = "Caption"
            },
            new ProductImage
            {
                ProductId = new Guid("f35c176b-c70a-4fb5-b9b3-885eb8731901"),
                ImagePath = "https://placewaifu.com/image/92",
                IsImageFeature = false,
                Caption = "Caption"
            },
            new ProductImage
            {
                ProductId = new Guid("f35c176b-c70a-4fb5-b9b3-885eb8731901"),
                ImagePath = "https://placewaifu.com/image/93",
                IsImageFeature = false,
                Caption = "Caption"
            },

            new ProductImage
            {
                ProductId = new Guid("e9416abf-ab8a-4b69-8bb5-3f3a8b7024ad"),
                ImagePath = "https://placewaifu.com/image/97",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
            {
                ProductId = new Guid("e9416abf-ab8a-4b69-8bb5-3f3a8b7024ad"),
                ImagePath = "https://placewaifu.com/image/91",
                IsImageFeature = false,
                Caption = "Caption"
            },
            new ProductImage
            {
                ProductId = new Guid("e9416abf-ab8a-4b69-8bb5-3f3a8b7024ad"),
                ImagePath = "https://placewaifu.com/image/92",
                IsImageFeature = false,
                Caption = "Caption"
            },
            new ProductImage
            {
                ProductId = new Guid("e9416abf-ab8a-4b69-8bb5-3f3a8b7024ad"),
                ImagePath = "https://placewaifu.com/image/93",
                IsImageFeature = false,
                Caption = "Caption"
            },

            new ProductImage
            {
                ProductId = new Guid("9244f89d-1b5d-44cd-8a7f-1922d464e336"),
                ImagePath = "https://placewaifu.com/image/97",
                IsImageFeature = true,
                Caption = "Caption"
            },
            new ProductImage
            {
                ProductId = new Guid("9244f89d-1b5d-44cd-8a7f-1922d464e336"),
                ImagePath = "https://placewaifu.com/image/91",
                IsImageFeature = false,
                Caption = "Caption"
            },
            new ProductImage
            {
                ProductId = new Guid("9244f89d-1b5d-44cd-8a7f-1922d464e336"),
                ImagePath = "https://placewaifu.com/image/92",
                IsImageFeature = false,
                Caption = "Caption"
            },
            new ProductImage
            {
                ProductId = new Guid("9244f89d-1b5d-44cd-8a7f-1922d464e336"),
                ImagePath = "https://placewaifu.com/image/93",
                IsImageFeature = false,
                Caption = "Caption"
            }
    );

             //Id = new Guid("4b703409-a32a-49cf-9943-d5a68dbedd6f"),
             //Name = "Thùng",
             //Id = new Guid("bb7b0969-4383-446f-8ab9-6d766df08359"),
             //Name = "Kg",
             //Id = new Guid("54cb56aa-a710-47e0-a386-4cc493d46747"),
             //Name = "Hộp",
           
        builder.Entity<ProductUnit>().HasData(
         new ProductUnit
         {
             ProductId = new Guid("5d01611b-e2ad-4abd-b40e-0450f50d2ec9"),
             UnitId = new Guid("4b703409-a32a-49cf-9943-d5a68dbedd6f"),
             Quantity = 100
         },
         new ProductUnit
         {
             ProductId = new Guid("5d01611b-e2ad-4abd-b40e-0450f50d2ec9"),
             UnitId = new Guid("54cb56aa-a710-47e0-a386-4cc493d46747"),
             Quantity = 100
         },
         new ProductUnit
         {
             ProductId = new Guid("c861791b-bce9-47a9-84c7-1abdb578d88b"),
             UnitId = new Guid("bb7b0969-4383-446f-8ab9-6d766df08359"),
             Quantity = 100
         }
        );
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseLazyLoadingProxies();
}
