using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JPGZService.Videos
{
    [Table("tb_Video_Record")]
    public class VideoRecord:Entity
    {
        /// <summary>
        /// 用户主键ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 视频主键ID
        /// </summary>
        public int VideoId { get; set; }
        /// <summary>
        /// 培训科目
        /// </summary>
        public int Subject { get; set; }
        /// <summary>
        /// 培训车型
        /// </summary>
        public string TrainType { get; set; }
        /// <summary>
        /// 播放时间
        /// </summary>
        public DateTime PlayTime { get; set; }   
        /// <summary>
        /// 学员id
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// 电子教学日志主键ID
        /// </summary>
        public int? StudyRecordResultId { get; set; }
    }
}
