using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JPGZService.StudentBlackLists
{
    [Table("tb_StudentBlackList")]
    public  class StudentBlackList: Entity
    {
        /// <summary>
        /// 学员id
        /// </summary>
        public int? StudentId { get; set; }
        /// <summary>
        /// 拉黑原因
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 拉黑时间
        /// </summary>
        public DateTime? AddTime { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public int? IsDelete { get; set; }

        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime? DeleteTime { get; set; }

        /// <summary>
        /// 拉黑次数
        /// </summary>
        public int? AddCount { get; set; }
    }
}
