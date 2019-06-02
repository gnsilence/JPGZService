using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPGZService.DriveSchools
{
    [Table("tb_DriveSchool")]
    public  class DriveSchool:Entity 
    {
        public string DriveSchoolNo { get; set; }
        public string Name { get; set; }
        public string RegionNo { get; set; }
        public string TechType { get; set; }
        public string TechTypeName { get; set; }
        public string Description { get; set; }
        public string TrainUnitSigner { get; set; }
        public string BName { get; set; }
        public string Address { get; set; }
        public string BusinessNo { get; set; }
        public string LegalMan { get; set; }
        public string Mobilephone { get; set; }
        public string Landline { get; set; }
        public string Lesence { get; set; }
        public int Status { get; set; }
        public System.Nullable<DateTime> AddTime { get; set; }
        public System.Nullable<int> FirstHalfYear { get; set; }
        public System.Nullable<int> SecondHalfYear { get; set; }
        public System.Nullable<int> ICCardCount { get; set; }
        public System.Nullable<int> MinCarNum { get; set; }
        public System.Nullable<int> Gpsid { get; set; }
        public bool IsUpLoadStuPic { get; set; }
        public bool IsUpLoadTeacherPic { get; set; }
        public bool IsShowLegalManSeal { get; set; }
        public bool? DeleteMark { get; set; }
        public System.Nullable<int> AddUserId { get; set; }
        public int OrganizeID { get; set; }
        public int? ClassLevel { get; set; }
        public int? TrafficId { get; set; }

        /// <summary>
        /// 是否分析科目二区域
        /// </summary>
        public int IsSubjectTwo { get; set; }

        /// <summary>
        /// 是否分析科目三道路
        /// </summary>
        public int IsSubjectThree { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public decimal? Longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public decimal? Latitude { get; set; }
        /// <summary>
        /// 默认相册
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// 图片相册
        /// </summary>
        public string PhotoAlbum { get; set; }
        /// <summary>
        /// 资讯人数
        /// </summary>
        public int? ConsultNum { get; set; }

        #region    符合性审查新字段

        /// <summary>
        /// 培训机构全国平台编号
        /// </summary>
        public string Inscode { get; set; }

        /// <summary>
        /// 经营许可日期
        /// </summary>
        public System.Nullable<DateTime> Licetime { get; set; }

        /// <summary>
        /// 统一社会信用代码
        /// </summary>
        public string Creditcode { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string Postcode { get; set; }

        /// <summary>
        /// 教练员总数
        /// </summary>
        public int Coachnumber { get; set; }

        /// <summary>
        /// 考核员总数
        /// </summary>
        public int Grasupvnum { get; set; }

        /// <summary>
        /// 安全员总数
        /// </summary>
        public int Safmngnum { get; set; }

        /// <summary>
        /// 教练车总数
        /// </summary>
        public int Tracarnum { get; set; }

        /// <summary>
        /// 教室总面积
        /// </summary>
        public decimal Classroom { get; set; }

        /// <summary>
        /// 理论教室面积
        /// </summary>
        public decimal Thclassroom { get; set; }

        /// <summary>
        /// 教练场总面积
        /// </summary>
        public decimal Praticefield { get; set; }

        /// <summary>
        /// 上传状态：0-未提交、1-已提交全国、2-已提交省、3-省级更新
        /// </summary>
        public int UploadStatus { get; set; }

        /// <summary>
        /// 行政区划代码
        /// </summary>
        public string District { get; set; }

        #endregion

        public string UrbanCode { get; set; }
    }
}
