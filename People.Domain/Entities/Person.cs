using People.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace People.Domain.Entities
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public required string FirstName { get; set; }
        [Required]

        public required string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [EnumDataType(typeof(GenderType))]
        public GenderType Gender { get; set; }
        [Required]
        public required string BirthPlace { get; set; }
    }
}
