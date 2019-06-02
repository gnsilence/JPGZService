using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.Vehicles
{
    [Table("tb_Vehicle")]
   public  class Vehicle:Entity
    {
        public string VehicleNo { get; set; }
        public string FrameNo { get; set; }
        public System.Nullable<int> KindID { get; set; }
        public string DrivingLicenseNo { get; set; }
        public string OperatingLicensesNo { get; set; }
        public string EngineModel { get; set; }
        public int Manufactory { get; set; }       //符合性审查类型改为：int
        public System.Nullable<DateTime> FactoryDate { get; set; }
        public System.Nullable<DateTime> BuyDate { get; set; }
        public System.Nullable<double> BuyMoney { get; set; }
        public System.Nullable<DateTime> OperationsDate { get; set; }
        public System.Nullable<int> OperationsType { get; set; }
        public System.Nullable<int> WorkStatus { get; set; }
        public string Vpicture { get; set; }
        public System.Nullable<int> PlateColor { get; set; }
        public System.Nullable<int> ColorID { get; set; }
        public System.Nullable<int> Usage { get; set; }
        public System.Nullable<int> BandID { get; set; }
        public string EngineNo { get; set; }
        public System.Nullable<double> Vweight { get; set; }
        public System.Nullable<double> LoadingCapacity { get; set; }
        public System.Nullable<int> SeatCount { get; set; }
        public string RegAddress { get; set; }
        public System.Nullable<int> EnergyType { get; set; }
        public string QualificationNo { get; set; }
        public string BusinessScope { get; set; }
        public System.Nullable<int> Structure { get; set; }
        public System.Nullable<double> ExhaustEmissions { get; set; }
        public bool DeleteMark { get; set; }
        public System.Nullable<DateTime> AddTime { get; set; }
        public System.Nullable<int> AddUserId { get; set; }
        public string Description { get; set; }
        public System.Nullable<int> TrainSiteId { get; set; }
        public int Beian { get; set; }
        public System.Nullable<int> DriveSchoolId { get; set; }
        public int DataOrganizeID { get; set; }
        public int? GpsId { get; set; }
        public int? BranchSchoolId { get; set; }

        #region    符合性审查新字段

        /// <summary>
        /// 教练车全国平台编号
        /// </summary>
        public string Carnum { get; set; }

        /// <summary>
        /// 照片文件ID
        /// </summary>
        public string PhotoId { get; set; }

        /// <summary>
        /// 培训车型
        /// </summary>
        public string VehicleTiainType { get; set; }

        /// <summary>
        /// 上传状态：0-未提交、1-已提交全国、2-已提交省、3-省级更新
        /// </summary>
        public int UploadStatus { get; set; }

        #endregion
    }
}
