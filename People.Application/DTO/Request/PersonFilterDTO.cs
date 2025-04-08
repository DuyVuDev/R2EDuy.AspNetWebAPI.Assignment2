using People.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace People.Application.DTO.Request
{
    public class PersonFilterDTO
    {
        public string? Name { get; set; }

        [EnumDataType(typeof(GenderType))]
        public GenderType? Gender { get; set; }

        public string? BirthPlace { get; set; }
    }
}
