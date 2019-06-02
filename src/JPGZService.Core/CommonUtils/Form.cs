using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.CommonUtils
{
    public class Form
    {
        /// <summary>
        /// 表单提交地址
        /// </summary>
        public string CommitUrl { get; set; }
        /// <summary>
        /// 表单提交方式
        /// </summary>
        public string CommitMethod { get; set; }
        /// <summary>
        /// 表单数据
        /// </summary>
        public string CommitData { get; set; }

        /// <summary>
        /// 表单数据
        /// </summary>
        public byte[] CommitDataBytes { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string SignData { get; set; }
    }
}
