using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPGZService.GetQuestion
{
    [Table("tb_Questions")]
    public class QuestionInfo : Entity
    {
         /// <summary>
        /// 主键id
        /// </summary>
         // public int Id{ get; set; }
         /// <summary>
        /// 所属课程
        /// </summary>
         public System.Nullable<int> CurriculumId{ get; set; }
         /// <summary>
        /// 试题标题
        /// </summary>
         public string QuesTitle{ get; set; }
         /// <summary>
        /// 试题类型(1.单选题；2.多选题；３.判断题；)
        /// </summary>
         public System.Nullable<int> QuesType{ get; set; }
         /// <summary>
        /// 试题素材路径(多素材用“|”分割)
        /// </summary>
         public string FilePath{ get; set; }
         /// <summary>
        /// 试题素材类型(1.文字题；2.图片题；３.动画题)
        /// </summary>
         public System.Nullable<int> FileType{ get; set; }
         /// <summary>
        /// 添加人
        /// </summary>
         public string Author{ get; set; }
         /// <summary>
        /// 添加时间
        /// </summary>
         public System.Nullable<DateTime> AddTime{ get; set; }
         /// <summary>
        /// 删除状态(0未删除；1已删除)
        /// </summary>
         public System.Nullable<int> IsDelete{ get; set; }
         /// <summary>
        /// 知识点类型
        /// </summary>
         public System.Nullable<int> KnowledgeType{ get; set; }
    }
}
