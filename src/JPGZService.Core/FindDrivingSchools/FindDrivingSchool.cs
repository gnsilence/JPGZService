using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.FindDrivingSchools
{
    [Table("V_FindDrivingSchool")]
    public class FindDrivingSchool:Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int? SNum { get; set; }
        public decimal? StandardPrice { get; set; }
        public int? Score { get; set; }
        public string Photo { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        public decimal? Longitude { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        public decimal? Latitude { get; set; }
        public string UrbanCode { get; set; }
    }
}
