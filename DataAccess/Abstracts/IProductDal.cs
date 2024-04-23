using Core.DataAccess;
using Core.Entities;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstracts;

public interface IProductDal : IEntityRepository<Product,int>
{
    List<ProductDetailDto> GetProductDetails();
}
