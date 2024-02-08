﻿using Microsoft.EntityFrameworkCore;
using ShoppingSystem.Product.Application;
using ShoppingSystem.Product.Domain.Entities;
using ShoppingSystem.Shared.Response;
using System.Reflection;

namespace ShoppingSystem.Product.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Domain.Entities.Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
