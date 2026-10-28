using EmployeeAccess.Api.DTOs.Common;
using EmployeeAccess.Domain.Entities.AccessControl;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAccess.Api.DTOs.AccessRecords
{
    public class RegisterAccessDTO
    {
        [Required]
        [StringLength(64)]
        public string CredentialCode { get; set; } = string.Empty;

        [NotEmptyGuid]
        public Guid AccessPointId { get; set; }

        [EnumDataType(typeof(MovementType))]
        public MovementType Movement { get; set; }
    }
}
