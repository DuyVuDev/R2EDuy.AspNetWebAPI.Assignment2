using People.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace People.Domain.Entities
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "first name cannot be empty!")]
        public required string FirstName { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "last name cannot be empty!")]
        public required string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public GenderType Gender { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "birth place cannot be empty!")]
        public required string BirthPlace { get; set; }
    }
}
