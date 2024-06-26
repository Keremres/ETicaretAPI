﻿using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _productService.GetAll();
        if(result.Success)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.Message);
    }

    [HttpGet("getbycategory")]
    public IActionResult GetByCategory(int categoryId)
    {
        var result = _productService.GetAllByCategoryId(categoryId);
        if(result.Success)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.Message);
    }

    [HttpGet("getbyunitprice")]
    public IActionResult GetByUnitPrice(decimal min, decimal max)
    {
        var result = _productService.GetByUnitPrice(min, max);
        if(result.Success)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.Message);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        var result = _productService.GetById(id);
        if(result.Success)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.Message);
    }

    [HttpGet("getproductdetails")]
    public IActionResult GetProductDetails(int categoryId)
    {
        var result = _productService.GetProductDetails();
        if(result.Success)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.Message);
    }

    [HttpPost("add")]
    public IActionResult Add(Product product)
    {
        var result = _productService.Add(product);
        if(result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }

    [HttpPost("delete")]
    public IActionResult Delete(Product product)
    {
        var result = _productService.Delete(product);
        if(result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }

    [HttpPost("update")]
    public IActionResult Update(Product product)
    {
        var result = _productService.Update(product);
        if(result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }

    [HttpPost("transaction")]
    public IActionResult TransactionTest(Product product)
    {
        var result = _productService.AddTransactionalTest(product);
        if(result.Success)
        {
            return Ok(result.Message);
        }
        return BadRequest(result.Message);
    }
}
