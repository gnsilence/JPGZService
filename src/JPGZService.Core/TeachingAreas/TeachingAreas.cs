using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.TeachingAreas
{
    [Table("tb_TeachingArea")]
    public class TeachingArea : Entity
    {
       
        /// <summary>
        /// 驾校ID
        /// </summary>
        public System.Nullable<int> DriveSchoolId { get; set; }
        
        /// <summary>
        /// 场地名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 面积
        /// </summary>
        public decimal? Area { get; set; }

        /// <summary>
        /// 车型
        /// </summary>
        public string VehicleType { get; set; }
        /// <summary>
        /// 经纬度
        /// </summary>
        public string Polygon { get; set; }
        /// <summary>
        /// 可容纳车辆数
        /// </summary>
        public int? Totalvehnum { get; set; }
        /// <summary>
        /// 已投放车辆数
        /// </summary>
        public int? Curvehnum { get; set; }
        /// <summary>
        /// 上传状态  0:未备案 1:已省级备案
        /// </summary>
        public string UploadStatus { get; set; }
        /// <summary>
        /// 启用状态  0 待批 1启用 2 不启用
        /// </summary>
        public int Flag { get; set; }

        /// <summary>
        /// 原因
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// 驾校名称
        /// </summary>
        public string DriveSchoolName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? TAType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string seq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string polygonGuid { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public string Latitude { get; set; }

        /// <summary>
        /// GPS定位
        /// </summary>
        public string GpsCoordinates { get; set; }
       
    }
}
