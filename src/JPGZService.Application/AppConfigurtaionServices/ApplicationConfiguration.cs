using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.AppConfigurtaionServices
{
    public class ApplicationConfiguration
    {
        /// <summary>
        /// 照片上传路径
        /// </summary>
        public string SaveImageUrl { get; set; }
        /// <summary>
        /// 计划任务默认时长(分钟)
        /// </summary>
        public string defaultMinutes { get; set; }
    }
}
