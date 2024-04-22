using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryDbContextFromDb;

[Index("AddressId", Name = "IX_Users_AddressId")]
public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(100)]
    public string Password { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public string? Mobile { get; set; }

    public string? Phone { get; set; }

    public int? AddressId { get; set; }

    [ForeignKey("AddressId")]
    [InverseProperty("Users")]
    public virtual Address? Address { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<RentalRecord> RentalRecords { get; set; } = new List<RentalRecord>();
}
