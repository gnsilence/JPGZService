using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPGZService.Videos
{
    [Table("tb_Video_PlayCount")]
    public class Video_PlayCountInfo: Entity
    {
         /// <summary>
        /// 主键id
        /// </summary>
         // public int Id{ get; set; }
         /// <summary>
        /// 视频编号
        /// </summary>
         public System.Nullable<int> VideoId{ get; set; }
         /// <summary>
        /// 播放量
        /// </summary>
         public System.Nullable<int> PlayCount{ get; set; }
    }
}
