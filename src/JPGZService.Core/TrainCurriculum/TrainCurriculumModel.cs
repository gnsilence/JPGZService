using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JPGZService.TrainCurriculum
{
    [Table("tb_TrainCurriculum")]
    public class TrainCurriculumModel: Entity
    {
        /// <summary>
		/// 主键id
        /// </summary>				        
        // public int Id { get; set; }
        /// <summary>
        /// 科目
        /// </summary>				        
        public int? Subject { get; set; }
        /// <summary>
        /// 培训车型
        /// </summary>				        
        public int? TrainType { get; set; }
        /// <summary>
        /// TrainTypeName
        /// </summary>				        
        public string TrainTypeName { get; set; }
        /// <summary>
        /// 课程编码
        /// </summary>				        
        public string SubjCode { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>				        
        public string Curriculum { get; set; }
        /// <summary>
        /// 课程计费类型(1：计费课程；2：免费课程)
        /// </summary>				        
        public int? CurriculumType { get; set; }
        /// <summary>
        /// 课程简介
        /// </summary>				        
        public string Intcurriculum { get; set; }
        /// <summary>
        /// 培训学时
        /// </summary>				        
        public double? Duration { get; set; }
        /// <summary>
        /// 学习有效期
        /// </summary>				        
        public DateTime? Learningper { get; set; }
        /// <summary>
        /// 访问权限(1：付费用户；2：所有用户开放)
        /// </summary>				        
        public int? Accessper { get; set; }
        /// <summary>
        /// 计费标准
        /// </summary>				        
        public double? Changing { get; set; }
        /// <summary>
        /// 删除状态(0未删除；1已删除)
        /// </summary>				        
        public int? IsDelete { get; set; }
        /// <summary>
        /// 添加人
        /// </summary>				        
        public string Author { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>				        
        public DateTime? AddTime { get; set; }
        /// <summary>
        /// 课程图片
        /// </summary>
        public string ImagePath { get; set; }
    }
}
