using System;
using System.Collections.Generic;
using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JPGZService.Feedback
{
    [Table("tb_Feedback")]
    public class Feedback: Entity
    {
        public string Title { get; set; }
        public string FContent { get; set; }
        public string Contact { get; set; }
        public System.Nullable<DateTime> CreateTime { get; set; }
        public System.Nullable<DateTime> HandleTime { get; set; }
        public string HandleIdea { get; set; }
        public System.Nullable<int> UserId { get; set; }
        public System.Nullable<int> DataType { get; set; }
        public System.Nullable<int> DriverId { get; set; }
        public System.Nullable<int> StuId { get; set; }
        public System.Nullable<int> HandleState { get; set; }
        public System.Nullable<int> RegisteredID { get; set; }
        /// <summary>
        /// 评分
        /// </summary>
        public int Overall { get; set; }
    }
}
