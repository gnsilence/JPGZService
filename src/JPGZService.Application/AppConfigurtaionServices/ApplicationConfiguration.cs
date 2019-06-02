using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.AppConfigurtaionServices
{
    public class ApplicationConfiguration
    {
        /// <summary>
        /// 文件上传路径
        /// </summary>
        public string PassiveFilePath { get; set; }
        /// <summary>
        /// 是否提交省平台
        /// </summary>
        public bool IsSubmitProvince { get; set; }
        /// <summary>
        /// 是否提交省平台的市行政区号（多个以逗号隔开）
        /// </summary>
        public string IsUrbanCode { get; set; }
        /// <summary>
        /// 添加学员接口
        /// </summary>
        public string AddStudentApi { get; set; }
        /// <summary>
        /// 添加学员照片
        /// </summary>
        public string AddStudentPicApi { get; set; }

        /// redis写服务器连接
        /// </summary>
        public string WriteServerList { get; set; }

        /// <summary>
        /// 是否使用redis缓存
        /// </summary>
        public bool UseRedisCache { get; set; }

        public string SaveImageUrl { get; set; }
        /// <summary>
        /// 公告图片展示地址前缀
        /// </summary>
        public string NewImgPath { get; set; }

        /// <summary>
        /// 模拟考试学时配置
        /// </summary>
        public int MoniHours { get; set; }
        /// <summary>
        /// 视频学习系数
        /// </summary>
        public string VideoCoefficient { get; set; }
        /// <summary>
        /// 每天最大学时设置默认4小时（单位分钟）
        /// </summary>
        public int? DailyMaxHour { get; set; }

        /// <summary>
        /// 西安驾培管理系统地址
        /// </summary>
        public string XAJPManSystemAddress { get; set; }
        /// <summary>
        /// 西安驾培管理系统地址
        /// </summary>
        public string UserPhotoPath { get; set; }
        /// <summary>
        /// 微信appid
        /// </summary>
        public string appid { get; set; }
        /// <summary>
        /// 开发者密码
        /// </summary>
        public string secret { get; set; }

    }
}
