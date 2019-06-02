using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JPGZService.Account
{
    [Table("tb_StudentAccount")]
    public class UserAccount : Entity
    {
        /// <summary>
        /// 学员id
        /// </summary>
        public int? StudentId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? Createtime { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int? Sex { get; set; }

        /// <summary>
        /// 用户照片
        /// </summary>
        public string Pic { get; set; }

        /// <summary>
        /// 驾考车型
        /// </summary>
        public string DriveTypeName { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }


        /// <summary>
        /// 用户编号id
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCardNo { get; set; }
        /// <summary>
        /// 微信
        /// </summary>
        public string OpenId { get; set; }

    }
}
