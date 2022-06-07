using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace employee_management.Domain.Common;

public abstract class BaseDomainEntity
{
    public string? Id { get; set; }
    public string CreatedBy { get; set; } = default!;
    public DateTime LastModifiedDate { get; set; }
    public string LastModifiedBy { get; set; } = default!;
}