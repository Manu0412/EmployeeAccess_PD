using EmployeeAccess.Api.DTOs.Common;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAccess.Api.DTOs.Credentials
{
    public class AssignCredentialDTO
    {
        [NotEmptyGuid]
        public Guid EmployeeId { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 4)]
        public string Code { get; set; } = string.Empty;
    }
}
