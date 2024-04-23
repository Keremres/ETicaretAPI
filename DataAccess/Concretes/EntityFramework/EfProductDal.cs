using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework;

public class EfProductDal : EfEntityRepositoryBase<Product,int,ETicaretAPIDbContext> , IProductDal
{
    public List<ProductDetailDto> GetProductDetails()
    {
        using (ETicaretAPIDbContext context = new ETicaretAPIDbContext())
        {
            var result = from p in context.Products
                         join c in context.Categories
                         on p.CategoryId equals c.Id
                         select new ProductDetailDto
                         {
                             ProductId = p.Id, ProductName = p.ProductName, CategoryName = c.CategoryName,
                             Description = p.Description, Price = p.Price, Stock = p.Stock
                         };
            return result.ToList();
        }
    } 
}
