using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.ClassInfos
{
    [Table("Tb_ClassInfo")]
   public class ClassInfo:Entity
    {
        public string ClassName { get; set; }
        public string Propagslogan { get; set; }
        public System.Nullable<int> CarType { get; set; }
        public string CarTypeName { get; set; }
        public string ClassLable { get; set; }
        public string ServiceExplain { get; set; }
        public string Applicatnotes { get; set; }
        public string ClassAlbum { get; set; }
        public System.Nullable<int> ActiveStatus { get; set; }
        public System.Nullable<int> IsDelete { get; set; }
        public System.Nullable<DateTime> CreateTime { get; set; }
        public System.Nullable<DateTime> ActiveTime { get; set; }
        public string CreateUserName { get; set; }
        public string CancelActiveUser { get; set; }
        public System.Nullable<DateTime> CancelTime { get; set; }
        public string ClassIntro { get; set; }
        public int DriveSchoolId { get; set; }
        public int BranchSchoolId { get; set; }
        public string seq { get; set; }
        public int? UploadStatus { get; set; }
        public System.Nullable<DateTime> uptime { get; set; }
    }
}
