using People.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace People.Application.DTO.Request
{
    public class PersonRequestDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "first name cannot be empty!")]
        public required string FirstName { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "last name cannot be empty!")]
        public required string LastName { get; set; }
        [Required]
        public required DateTime DateOfBirth { get; set; }
        [Required]
        [EnumDataType(typeof(GenderType))]
        public required GenderType Gender { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "birth place cannot be empty!")]
        public required string BirthPlace { get; set; }
    }
}
