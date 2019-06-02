using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPGZService.Videos
{
    /// <summary>
    /// 视频评价
    /// </summary>
    [Table("tb_Video_Evaluation")]
    public class Video_EvaluationInfo : Entity
    {         
         /// <summary>
        /// 注册用户编号
        /// </summary>
         public System.Nullable<int> UserId{ get; set; }
         /// <summary>
        /// 视频编号
        /// </summary>
         public System.Nullable<int> VideoId{ get; set; }
         /// <summary>
        /// 总体满意度 1:一星 
        //2:二星 
        //3:三星 
        //4:四星 
        //5:五星（最满意）
        /// </summary>
         public System.Nullable<int> Overall{ get; set; }
         /// <summary>
        /// 评价时间
        /// </summary>
         public System.Nullable<DateTime> EvaluateTime{ get; set; }
         /// <summary>
        /// 评价用语列表;  评价用语信息表编号，“,”号各开（预留）
        /// </summary>
         public string Srvmanner{ get; set; }
         /// <summary>
        /// 个性化评价
        /// </summary>
         public string Teachlevel{ get; set; }        
    }
}
