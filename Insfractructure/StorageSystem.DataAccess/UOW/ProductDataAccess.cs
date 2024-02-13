using MathNet.Numerics.Statistics.Mcmc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NPOI.SS.Formula.Functions;
using StorageSystem.Application.Contracts.DataAccess;
using StorageSystem.Application.Models.Bases;
using StorageSystem.Application.Models.Bill.Ins;
using StorageSystem.Application.Models.Product.Ins;
using StorageSystem.DataAccess.UOW.Base;
using StorageSystem.Domain.Entities;
using StorageSystem.Persistence;
using StorageSystem.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StorageSystem.DataAccess.UOW;

public class ProductDataAccess : GenericDataAccess<Product>, IProductDataAccess
{
    public ProductDataAccess(IApplicationDbContext context) : base(context)
    {
    }

    public async Task CreateProductAsync(Product product, CancellationToken cancellationToken = default)
    {
        await InsertAsync(product);
        //await _context.Products.AddAsync(product, cancellationToken);
    }

    public async Task CreateProductRangeAsync(List<Product> products, CancellationToken cancellationToken = default)
    {
        await _context.Products.AddRangeAsync(products, cancellationToken);
    }

    public async Task<Product> FindProductById(Guid Id)
    {
        return await FirstOrDefaultAsync(Id);
    }

    public async Task<Product> FirstAsync(Guid Id)
    {
        return await _context.Products.FirstAsync(x => x.Id == Id);
    }

    public async Task<Product> FirstOrDefaultAsync(Guid Id, CancellationToken cancellationToken = default)
    {
        return await _context.Products.Include(p => p.ProductImages).FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
    }

    public async Task<IEnumerable<Product>> GetAllProducts(FilterProduct filter, CancellationToken cancellationToken = default)
    {
        return await _context.Products
            .Where(p => string.IsNullOrEmpty(filter.Keyword) || p.Name.ToLower().Contains(filter.Keyword.ToLower()))
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Product>> GetAllProducts(FilterProduct filter, bool trackingReference, CancellationToken cancellationToken = default)
    {
        var list = await _context.Products.Include(p => p.ProductImages).Include(p => p.Category)
            .Where(p => (string.IsNullOrEmpty(filter.Keyword) || p.Name.ToLower().Contains(filter.Keyword.ToLower()))
                        && (filter.CategoryId == null || p.CategoryId == filter.CategoryId)
                        )
            .OrderBy(p => p.Price)
            .ToListAsync(cancellationToken);
        if (filter.IsSortDecrease)
        {
            list = list.OrderByDescending(p => p.Price).ToList();
        }
        return list.Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize).ToList();
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryId(Guid CategoryId, CancellationToken cancellationToken = default)
    {
        return await _context.Products.Include(p => p.ProductImages).Where(p => p.CategoryId == CategoryId).ToListAsync(cancellationToken);
    }

    public async void UpdateProduct(Product product, CancellationToken cancellationToken = default)
    {
        Update(product);
    }

    public void UpdateProductRange(List<Product> products, CancellationToken cancellationToken = default)
    {
        _context.Products.UpdateRange(products);
    }

    public async void DeleteProduct(Product product, CancellationToken cancellationToken = default)
    {
        //Delete(product);
        product.IsDeleted = true;
        Update(product);
    }

    public void DeleteProductRange(List<Product> products, CancellationToken cancellationToken = default)
    {
        foreach (var product in products)
        {
            product.IsDeleted = true;
        }
        UpdateProductRange(products);
        //_context.Products.RemoveRange(products);
    }

    public int GetTotalProducts(string keyword = null, Guid? categoryId = null)
    {
        return _context.Products
            .Where(p => (string.IsNullOrEmpty(keyword) || p.Name.ToLower().Contains(keyword.ToLower()))
                        && (categoryId == null || p.CategoryId == categoryId)) 
            .Count();
    }

    public async Task<IEnumerable<Product>> GetAllProductsFromIds(List<Guid> ids)
    {
        return await _context.Products.Where(p => ids.Contains(p.Id)).ToListAsync();
    }

    //public async Task<bool> UpdateQuantityProductsFromIds(List<UpdateQuantityProductDto> orders)
    //{
    //    try
    //    {
    //        //var updatedItemsDictionary = orders.ToDictionary(item => item.Id);
    //        //var p = _context.Products.Join(updatedItemsDictionary,
    //        //      item => item.Id,
    //        //      order => order.Key,
    //        //      (item, order) => new
    //        //      {
    //        //          test = item.Id,
    //        //          //Stock = orders.Value.Quantity
    //        //      })
    //        //.ToList();
    //        List<Product> products = await _context.Products
    //            .Where(p => orders.Select(o => o.ProductId).Contains(p.Id))
    //            .ToListAsync();

    //        //foreach (var product in products)
    //        //{
    //        //    foreach (var item in orders)
    //        //    {
    //        //        if (item.Id == product.Id)
    //        //        {
    //        //            product.Stock = product.Stock - item.Quantity;
    //        //            if (product.Stock < 0) return false;
    //        //        }
    //        //    }
    //        //}

    //        UpdateProductRange(products);
    //    }
    //    catch(Exception ex)
    //    {
    //        return false;
    //    }
    //    return true;
    //}
}
