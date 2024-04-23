using Entities.Concretes;
using Business.Abstracts;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Transaction;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Business;
using Business.Constants;

namespace Business.Concretes;

public class ProductManager : IProductService
{
    IProductDal _productDal;
    ICategoryService _categoryService;
    public ProductManager(IProductDal productDal, ICategoryService categoryService)
    {
        _productDal = productDal;
        _categoryService = categoryService;
    }

    [SecuredOperation("product.add,admin")]
    [ValidationAspect(typeof(ProductValidator))]
    [CacheRemoveAspect("IProductService.Get")]
    public IResult Add(Product product)
    {
        IResult result = BusinessRules.Run(CheckIfProductName(product.ProductName));

        if (result != null)
        {
            return result;
        }
        _productDal.Add(product);

        return new SuccessResult("ürün eklendi");
    }

    [CacheAspect]
    public IDataResult<List<Product>> GetAll()
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(), "ürün listelendi");
    }

    [CacheAspect]
    public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId));
    }

    [CacheAspect]
    public IDataResult<Product> GetById(int productId)
    {
        return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
    }

    public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
    {
        return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.Price >= min && p.Price <= max));
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {

        return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
    }

    [SecuredOperation("product.add,admin")]
    [ValidationAspect(typeof(ProductValidator))]
    [CacheRemoveAspect("IProductService.Get")]
    public IResult Update(Product product)
    {
        IResult result = BusinessRules.Run(CheckIfProductName(product.ProductName));

        if (result != null)
        {
            return result;
        }
        _productDal.Update(product);

        return new SuccessResult("ürün güncellendi");
    }

    [SecuredOperation("product.add,admin")]
    [CacheRemoveAspect("IProductService.Get")]
    public IResult Delete(Product product)
    {
        _productDal.Delete(product);
        return new SuccessResult("ürün silindi!");
    }


    private IResult CheckIfProductName(string productName)
    {
        var result = _productDal.GetAll(p => p.ProductName == productName).Any();
        if (result)
        {
            return new ErrorResult("Aynı isim zaten var. Başka bir isim deneyin.");
        }
        return new SuccessResult();
    }

    [TransactionScopeAspect]
    public IResult AddTransactionalTest(Product product)
    {
        _productDal.Update(product);
        _productDal.Add(product);

        return new SuccessResult("güncellendi! TransactionScopeAspect ile güncellendi!");
    }

}
