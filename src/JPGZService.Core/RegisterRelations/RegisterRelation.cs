using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace JPGZService.RegisterRelations
{
    [Table("tb_RegisterRelation")]
    public class RegisterRelation:Entity
    {
        public System.Nullable<int> ApplicationQuantity { get; set; }
        public System.Nullable<DateTime> ApplicationTime { get; set; }
        public System.Nullable<int> Applicant { get; set; }
        public System.Nullable<int> ApplicationState { get; set; }
        public System.Nullable<DateTime> ApprovalTime { get; set; }
        public System.Nullable<int> Approver { get; set; }
        public System.Nullable<int> ApplicationDrivingSchoolId { get; set; }
        public string OrderCode { get; set; }
    }
}
