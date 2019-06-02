using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JPGZService.QuestionsCollects
{
    [Table("tb_Questions_Collect")]
    public class QuestionsCollect : Entity
    {
        /// <summary>
        /// 题目id
        /// </summary>
        public int? QuestionId { get; set; }

        /// <summary>
        /// 收藏人id
        /// </summary>
        public int? CollectUer { get; set; }

        /// <summary>
        /// 收藏时间
        /// </summary>
        public DateTime? CollectTime { get; set; }

    }
}
