using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.CoachRankingss
{
    [Table("V_CoachRankings")]
    public class CoachRankings:Entity
    {
        public string TeacherName { get; set; }
        public string TechPic { get; set; }
        public string TeachYear { get; set; }
        public int? TotalReview { get; set; }
        public int? PraiseTotal { get; set; }
        public int? BadTotal { get; set; }
        public int? Average { get; set; }
        public int? RegistrationTotal { get; set; }
        public int? MothRegistrationTotal { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Bname { get; set; }
        public string BAddress { get; set; }
        public string UrbanCode { get; set; }
        public string RegionNo { get; set; }
        public string Description { get; set; }
        public decimal? StandardPrice { get; set; }
        public int? DriveSchoolId { get; set; }
        public int? CoachRole { get; set; }
        public int? Employstatus { get; set; }
        public bool? DeleteMark { get; set; }
        public int? TrainingStatus { get; set; }
        public int? UploadStatus { get; set; }
    }
}
