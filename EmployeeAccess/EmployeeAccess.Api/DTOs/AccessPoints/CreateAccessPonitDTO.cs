using System.ComponentModel.DataAnnotations;

namespace EmployeeAccess.Api.DTOs.AccessPoints
{
    public class CreateAccessPointDTO
    {
        [Required]
        [StringLength(64, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [StringLength(512)]
        public string? Description { get; set; }
    }
}
