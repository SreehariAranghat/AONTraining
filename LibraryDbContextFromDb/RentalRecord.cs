using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryDbContextFromDb;

[Index("BookId", Name = "IX_RentalRecords_BookId")]
[Index("UserId", Name = "IX_RentalRecords_UserId")]
public partial class RentalRecord
{
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    public int BookId { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? LastModifiedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    [ForeignKey("BookId")]
    [InverseProperty("RentalRecords")]
    public virtual Book Book { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("RentalRecords")]
    public virtual User User { get; set; } = null!;
}
