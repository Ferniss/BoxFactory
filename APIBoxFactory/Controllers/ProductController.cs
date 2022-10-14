using Application.DTOs;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<List<Product>> GetAllProducts()
    {
        return _productService.GetAllProducts();
    }

    [HttpGet]
    [Route("{id}")] //localhost:5001/product/42
    public ActionResult<Product> GetProductById(int id)
    {
        try
        {
            return _productService.GetProductById(id);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound("No product found at ID " + id);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }


    [HttpGet]
    [Route("RebuildDB")]
    public void RebuildDB()
    {
        _productService.RebuildDB();
    }
}