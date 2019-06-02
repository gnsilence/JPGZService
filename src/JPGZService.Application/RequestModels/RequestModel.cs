using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.RequestModels
{
    public class BaseReturnMsg
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public string errorcode { get; set; }
        /// <summary>
        /// 提示信息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 附加信息
        /// </summary>
        public object data { get; set; }

    }

    public class BaseReturnMsg<T>
    {
        /// <summary>
        /// 返回码
        /// </summary>
        public string errorcode { get; set; }
        /// <summary>
        /// 提示信息
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 分页总数
        /// </summary>
        public int? totalCount { get; set; }
        /// <summary>
        /// 附加信息
        /// </summary>
        public T data { get; set; }

    }

}


