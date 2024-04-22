using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LibraryDbContextFromDb;

[Table("Address")]
public partial class Address
{
    [Key]
    public int Id { get; set; }

    public string Address1 { get; set; } = null!;

    public string PinCode { get; set; } = null!;

    [InverseProperty("Address")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
