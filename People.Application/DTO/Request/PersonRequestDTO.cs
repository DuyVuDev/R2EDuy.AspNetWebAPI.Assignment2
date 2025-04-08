using People.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace People.Application.DTO.Request
{
    public class PersonRequestDTO
    {
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required DateTime DateOfBirth { get; set; }
        [Required]
        [EnumDataType(typeof(GenderType))]
        public required GenderType Gender { get; set; }
        [Required]
        public required string BirthPlace { get; set; }
    }
}
