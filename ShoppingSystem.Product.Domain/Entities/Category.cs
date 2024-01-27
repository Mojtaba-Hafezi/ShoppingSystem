﻿using ShoppingSystem.Product.Domain.Contracts;

namespace ShoppingSystem.Product.Domain.Entities;

public class Category : IDeletableEntity, IAuditableEntity
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public long? ModifiedByUserId { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public long? DeletedByUserId { get; set; }
    public DateTime? DeletedAt { get; set; }
    public bool IsDeleted { get; set; }
    public long? CreatedByUserId { get; set; }
}
