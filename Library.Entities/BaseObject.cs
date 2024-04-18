using System.ComponentModel.DataAnnotations;

namespace Library.Entities
{
    public abstract class BaseObject
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public DateTime? DeletedDate { get; set; }
    }
}
