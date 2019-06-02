using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JPGZService.Videos
{
    [Table("tb_Video")]
    public class Video:Entity
    {
        /// <summary>
        /// 所属课程
        /// </summary>
        public System.Nullable<int> CurriculumId { get; set; }
        /// <summary>
        /// 课件编号
        /// </summary>
        public string CoursewareCode { get; set; }
        /// <summary>
        /// 课件名称
        /// </summary>
        public string Courseware { get; set; }
        /// <summary>
        /// 课件计费类型(1：计费课件；2：免费课件；)
        /// </summary>
        public System.Nullable<int> CoursewareType { get; set; }
        /// <summary>
        /// 课件图片
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// 课件简介
        /// </summary>
        public string IntCourseware { get; set; }
        /// <summary>
        /// 课件时长
        /// </summary>
        public System.Nullable<double> Duration { get; set; }
        /// <summary>
        /// 课件路径
        /// </summary>
        public string CoursePath { get; set; }
        /// <summary>
        /// 访问权限(1：付费用户；2：所有用户开放;3：公开)
        /// </summary>
        public System.Nullable<int> Accessper { get; set; }
        /// <summary>
        /// 计费标准
        /// </summary>
        public System.Nullable<double> Changing { get; set; }
        /// <summary>
        /// 添加人
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public System.Nullable<DateTime> AddTime { get; set; }
        /// <summary>
        /// 删除状态(0：未删除；1：删除)
        /// </summary>
        public System.Nullable<int> IsDelete { get; set; }
    }
}
