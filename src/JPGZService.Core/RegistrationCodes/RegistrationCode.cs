using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace JPGZService.RegistrationCodes
{
    [Table("tb_RegistrationCode")]
    public class RegistrationCode:Entity
    {
        public string RegistrationNumber { get; set; }
        public System.Nullable<DateTime> ApplicationTime { get; set; }
        public System.Nullable<int> ApplicationRecordId { get; set; }
        public System.Nullable<int> BoundStudentId { get; set; }
        public System.Nullable<int> UseState { get; set; }
        public System.Nullable<DateTime> BoundTime { get; set; }
        public System.Nullable<int> BoundDrivingSchoolId { get; set; }
        public string CodeKey { get; set; }
    }
}
