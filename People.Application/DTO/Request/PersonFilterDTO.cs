using People.Domain.Enums;

namespace People.Application.DTO.Request
{
    public class PersonFilterDTO
    {
        public string? Name { get; set; }
        public GenderType? Gender { get; set; }
        public string? BirthPlace { get; set; }
    }
}
