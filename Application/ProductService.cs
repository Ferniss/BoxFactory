using System.ComponentModel.DataAnnotations;
using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using FluentValidation;
using static Application.DTOs.ProductDTOs;
using ValidationException = FluentValidation.ValidationException;

namespace Application;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IValidator<PostProductDTO> _postValidator;
    private readonly IValidator<Product> _productValidator;
    private readonly IMapper _mapper;


    public ProductService(
        IProductRepository repository,
        IValidator<PostProductDTO> postValidator,
        IValidator<Product> productValidator,
        IMapper mapper)
    {
        _mapper = mapper;
        _postValidator = postValidator;
        _productValidator = productValidator;
        _productRepository = repository;
    }

    public List<Product> GetAllProducts()
    {
        return _productRepository.GetAllProducts();
    }

    public Product GetProductById(int id)
    {
        return _productRepository.GetProductById(id);
    }

    public void RebuildDB()
    {
        _productRepository.RebuildDB();
    }

}