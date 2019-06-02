using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.ExamRecords
{
    [Table("tb_Exam_Record")]
    public class ExamRecord:Entity
    {
        /// <summary>
        /// 注册用户编号
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public int? Score { get; set; }
        /// <summary>
        /// 答题时间
        /// </summary>
        public DateTime? ExamTime { get; set; }
        /// <summary>
        /// 科目1：科目一；2：科目二；3：科目三；4：科目四；
        /// </summary>
        public int? Subject { get; set; }
        /// <summary>
        /// 培训车型 A1
        /// </summary>
        public string TrainType { get; set; }
    }
}
