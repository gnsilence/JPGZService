using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JPGZService.testmysqldb.Dto
{
  public  class EmalSendDto
    {
        /// <summary>
        /// 发送地址
        /// </summary>
        [Required]
        [StringLength(120)]
        public string SendTo { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        [StringLength(120)]
        public string Subject { get; set; }
        /// <summary>
        /// 发送内容
        /// </summary>
        [Required]
        public string Content { get; set; }
    }
}
