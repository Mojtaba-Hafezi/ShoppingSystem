﻿using AutoMapper;
using ShppingSystem.Product.Api.Dtos;

namespace ShoppingSystem.Product.Api.Profiles;

public class ProductProfile : Profile
{
    protected ProductProfile()
    {
        CreateMap<AddProductDto, Domain.Entities.Product>();
    }
}
