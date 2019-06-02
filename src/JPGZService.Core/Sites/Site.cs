using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.Sites
{
    [Table("tb_Site")]
    public class Site:Entity
    {
        /// <summary>
        /// 驾校编号
        /// </summary>
        public System.Nullable<int> DriveSchoolId { get; set; }
        /// <summary>
        /// 分校编号
        /// </summary>
        public System.Nullable<int> BranchSchoolId { get; set; }
        
        /// <summary>
        /// 场地名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// 场地类型:1，教练场；2，招生点
        /// </summary>
        public System.Nullable<int> SiteType { get; set; }
       
    }
}
