﻿using Microsoft.AspNetCore.Mvc;
using ShoppingSystem.Product.Application;
using ShppingSystem.Product.Api.Dtos;
using System.Net.Mime;

namespace ShoppingSystem.Product.Api.Controllers.V1;
public class ProductsController : BaseController
{
    private readonly IProductService _productService;
    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProducts()
    {
        var products = _productService.GetProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetProduct(int id)
    {
        var product = _productService.GetProduct(id);
        return product == null ? NotFound() : Ok(product);
    }

    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult AddProduct(AddProductDto productDto)
    {
        if (string.IsNullOrEmpty(productDto.name) || string.IsNullOrEmpty(productDto.description) || productDto.price == 0)
            return BadRequest();

        Domain.Entities.Product product = new()
        {
            Name = productDto.name,
            Price = productDto.price,
            Description = productDto.description,
            IsDeleted = false
        };
        _productService.AddProduct(product);

        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }

}
