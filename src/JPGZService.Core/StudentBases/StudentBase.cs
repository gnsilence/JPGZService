using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JPGZService.StudentBases
{
    [Table("tb_Student_Base")]
    public  class StudentBase: Entity
    {
        // public int? ID { get; set; }
        public string ICCardNo { get; set; }
        public string Name { get; set; }
        public System.Nullable<int> Sex { get; set; }
        public string Native { get; set; }
        public string Birthday { get; set; }
        public string IDCardNo { get; set; }
        public string FamilyAddress { get; set; }
        public string Company { get; set; }
        public string Mobilephone { get; set; }
        public string Landline { get; set; }
        public System.Nullable<DateTime> RegisterDate { get; set; }
        public System.Nullable<int> DriveType { get; set; }
        public System.Nullable<int> RegisterPlace { get; set; }
        public System.Nullable<int> AddUserId { get; set; }
        public string FingerPrint4 { get; set; }
        public System.Nullable<DateTime> AddTime { get; set; }
        public string Description { get; set; }
        public System.Nullable<int> Batch { get; set; }
        public string Pic { get; set; }
        public System.Nullable<int> PaType { get; set; }
        public System.Nullable<int> NativeType { get; set; }
        public System.Nullable<int> RegType { get; set; }
        public System.Nullable<int> Status { get; set; }
        public System.Nullable<int> MakeStatus { get; set; }
        public System.Nullable<DateTime> ActiveTime { get; set; }
        public System.Nullable<int> SeforeStudyVehicleType { get; set; }
        public string FingerPrint1 { get; set; }
        public string FingerPrint2 { get; set; }
        public string FingerPrint3 { get; set; }
        public System.Nullable<int> TheoryState { get; set; }
        public System.Nullable<int> OperationState { get; set; }
        public string OriginalDrivingLicenseNo { get; set; }
        public System.Nullable<DateTime> DrivingLicenseOfMaturity { get; set; }
        public string TemporaryRP { get; set; }
        public System.Nullable<DateTime> TemporaryRPDate { get; set; }
        public string TrainingContractScan { get; set; }
        public System.Nullable<int> PAIjInsurance { get; set; }
        public System.Nullable<DateTime> GeaduateDate { get; set; }
        public string GraduateNo { get; set; }
        public System.Nullable<int> DriveSchoolId { get; set; }
        public string StudentCardNo { get; set; }
        public System.Nullable<bool> DeleteMark { get; set; }
        public string S_PrintStuCard { get; set; }
        public string ApprovalOpinion { get; set; }
        public System.Nullable<int> DataOrganizeID { get; set; }
        public string DriveTypeName { get; set; }
        public System.Nullable<int> CheckResult { get; set; }
        public string Password { get; set; }
        public string Stunum { get; set; }
        public string Nationality { get; set; }
        public string PhotoId { get; set; }
        public string FingerprintId { get; set; }
        public System.Nullable<DateTime> Fstdrilicdate { get; set; }
        public System.Nullable<int> UploadStatus { get; set; }
        public System.Nullable<int> BusitType { get; set; }
        public System.Nullable<int> GpsId { get; set; }
        public System.Nullable<DateTime> Rowver { get; set; }
        public System.Nullable<int> ClassId { get; set; }
        public System.Nullable<int> Age { get; set; }
        public System.Nullable<int> BranchSchoolId { get; set; }
        public System.Nullable<int> SiteId { get; set; }
        public System.Nullable<int> TeacherId { get; set; }
        public System.Nullable<int> ChannelId { get; set; }
        public System.Nullable<int> ClassInfoId { get; set; }
        public System.Nullable<int> HouseholdType { get; set; }
        public string ContractAddress { get; set; }
        public string Gid { get; set; }
        public System.Nullable<int> RecordType { get; set; }
        public string UID { get; set; }
    }
}
