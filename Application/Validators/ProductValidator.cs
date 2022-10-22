using System.Data;
using Application.DTOs;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class PostProductValidator : AbstractValidator<PostProductDTO>
{
    public PostProductValidator()
    {
        RuleFor(p => p.Price).GreaterThan(0);
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Description).NotEmpty();
    }
}

public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(p => p.Price).GreaterThan(0);
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Id).GreaterThan(0);
        RuleFor(p => p.Description).NotEmpty();
    }
}

public class PutProductValidator : AbstractValidator<PutProductDTO>
{
    public PutProductValidator()
    {
        RuleFor(p => p.Price).GreaterThan(0);
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Description).NotEmpty();
        RuleFor(p => p.Id).GreaterThan(0);
    }
}