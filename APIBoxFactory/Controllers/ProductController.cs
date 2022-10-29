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

    // get all product
    [HttpGet]
    public ActionResult<List<Product>> GetAllProducts()
    {
        return _productService.GetAllProducts();
    }

    // creating new product
    [HttpPost]
    [Route("")]
    public ActionResult<Product> CreateNewProduct(PostProductDTO dto)
    {
        try
        {
            var result = _productService.CreateNewProduct(dto);
            return Created("", result);
        }
        catch (ValidationException v)
        {
            return BadRequest(v.Message);
        }
        catch (System.Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("{id}")] //localhost:5001/product/42
    public ActionResult<Product> GetProductById(int id)
    {
        try
        {
            return _productService.GetProductById(id);
        } catch (KeyNotFoundException e) 
        {
            return NotFound("No product found at ID " + id);
        } catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }


    // rebuilding
    [HttpGet]
    [Route("RebuildDB")]
    public void RebuildDB()
    {
        _productService.RebuildDB();
    }

    // updating with id
    [HttpPut]
    [Route("{id}")] 
    public ActionResult<Product> PutProduct([FromRoute]int id, [FromBody]Product product)
    {
        try
        {
            return Ok(_productService.PutProduct(id, product));
        } catch (KeyNotFoundException e) 
        {
            return NotFound("No product found at ID " + id);
        } catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }

    // updating with id
    [HttpPatch]
    [Route("{id}")]
    public ActionResult<Product> PatchProduct([FromRoute] int id, [FromBody] Product product)
    {
        try
        {
            return Ok(_productService.PatchProduct(id, product));
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

    // deleting with id
    [HttpDelete]
    [Route("{id}")]
    public ActionResult<Product> DeleteProduct(int id)
    {
        try
        {
            return Ok(_productService.DeleteProduct(id));
        } catch (KeyNotFoundException e) 
        {
            return NotFound("No product found at ID " + id);
        } catch (Exception e)
        {
            return StatusCode(500, e.ToString());
        }
    }
}