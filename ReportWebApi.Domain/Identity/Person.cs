using Microsoft.AspNetCore.Identity;
using ReportWebApi.Domain.Entities;
using ReportWebApi.Domain.Enum;

namespace ReportWebApi.Domain.Identity
{
    public class Person : IdentityUser<Guid>
    {
        public string? FullName { get; set; }
        public Gender Gender { get; set; }
        public List<ProductPerson> ProductPersons { get; set; } = new List<ProductPerson>();
    }
}
