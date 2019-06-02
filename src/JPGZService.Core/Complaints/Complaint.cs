using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.Complaints
{
    [Table("tb_Complaint")]
   public  class Complaint:Entity
    {
        /// <summary>
        /// 学员编号
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// 投诉对象类型 1:教练员 2:培训机构

        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 投诉对象编号 教练员编号Id或培训机构编号Id
        /// </summary>
        public int Objenum { get; set; }
        /// <summary>
        /// 投诉时间
        /// </summary>
        public System.Nullable<DateTime> Cdate { get; set; }
        /// <summary>
        /// 投诉内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 管理部门处理意见
        /// </summary>
        public string Depaopinion { get; set; }
        /// <summary>
        /// 培训机构处理意见
        /// </summary>
        public string Schopinion { get; set; }
        
        /// <summary>
        /// 处理人
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime? HandleDate { get; set; }
        /// <summary>
        /// 处理状态
        /// </summary>
        public int? HandleStatus { get; set; }

        public int? ReceptionUser { get; set; }
        public int? UploadStatus { get; set; }
    }
}
