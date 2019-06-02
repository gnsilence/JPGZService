using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPGZService.Teachers
{
    [Table("tb_Teacher")]
    public  class Teacher:Entity
    {
        public string ICCardNo { get; set; }
        public string TeacherCardNo { get; set; }
        public string TeacherName { get; set; }
        public System.Nullable<int> Sex { get; set; }
        public System.Nullable<DateTime> Birthday { get; set; }
        public string IDCardNo { get; set; }
        public string Mobilephone { get; set; }
        public string Address { get; set; }
        public string TechVehicleType { get; set; }
        public string DriveVehicleType { get; set; }
        public string DriveCardNo { get; set; }
        public string TeachYear { get; set; }
        public string DriveYear { get; set; }
        public System.Nullable<DateTime> BeginCardDate { get; set; }
        public System.Nullable<DateTime> BeginDate { get; set; }
        public System.Nullable<DateTime> EndDate { get; set; }
        public System.Nullable<int> TeacherType { get; set; }
        public string Description { get; set; }
        public System.Nullable<int> DriveSchoolId { get; set; }
        public System.Nullable<int> Status { get; set; }
        public System.Nullable<int> StatusUserId { get; set; }
        public string ContractNo { get; set; }
        public System.Nullable<DateTime> HireStartDate { get; set; }
        public System.Nullable<DateTime> HireEndDate { get; set; }
        public System.Nullable<DateTime> FireDate { get; set; }
        public string Beian { get; set; }
        public string PaType { get; set; }
        public string TeachPaNo { get; set; }
        public System.Nullable<int> EducationBg { get; set; }
        public System.Nullable<int> TechGrade { get; set; }
        public System.Nullable<int> CarType { get; set; }
        public string CarTypeName { get; set; }
        public System.Nullable<DateTime> AddTime { get; set; }
        public string TechPic { get; set; }
        public string FingerPrint1 { get; set; }
        public string FingerPrint2 { get; set; }
        public string FingerPrint3 { get; set; }
        public string FingerPrint4 { get; set; }
        public System.Nullable<int> Gpsid { get; set; }
        public System.Nullable<bool> DeleteMark { get; set; }
        public System.Nullable<int> AddUserId { get; set; }
        public System.Nullable<int> TeachCarType { get; set; }
        public string TecCardNo { get; set; }
        public System.Nullable<int> DataOrganizeID { get; set; }
        public System.Nullable<int> TheoryState { get; set; }
        public System.Nullable<int> OperationState { get; set; }
        public System.Nullable<int> ActionType { get; set; }
        public System.Nullable<int> BranchSchoolId { get; set; }

        public string UID { set; get; }
        /// <summary>
        /// 教练员密码，用作手机app端登录
        /// </summary>
        public string PassWord { get; set; }
        #region    符合性审查新字段

        /// <summary>
        /// 教练全国平台编号
        /// </summary>
        public string Coachnum { get; set; }

        /// <summary>
        /// 照片文件ID
        /// </summary>
        public string PhotoId { get; set; }

        /// <summary>
        /// 指纹图片ID
        /// </summary>
        public string FingerprintId { get; set; }

        /// <summary>
        /// 职业资格证号
        /// </summary>
        public string Occupationno { get; set; }

        /// <summary>
        /// 供职状态：0-在职、1-离职
        /// </summary>
        public int Employstatus { get; set; }

        /// <summary>
        /// 培训状态：1-禁培、0-正常
        /// </summary>
        public int TrainingStatus { get; set; }

        /// <summary>
        /// 教练角色：1-教练员、2-考核员、3-安全员
        /// </summary>
        public int CoachRole { get; set; }

        /// <summary>
        /// 上传状态：0-未提交、1-已提交全国、2-已提交省、3-省级更新
        /// </summary>
        public int UploadStatus { get; set; }

        #endregion
    }
}
