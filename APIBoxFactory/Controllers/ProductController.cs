using Domain;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BoxFactory.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdcutController : ControllerBase
{
    private IProductService _productService;

    public ProdcutController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<List<Product>> GetAllProducts()
    {
        return _productService.GetAllProducts();
    }

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
}

