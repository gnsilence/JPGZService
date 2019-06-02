using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPGZService.PreRegistrations
{
    [Table("tb_PreRegistration")]
    public class PreRegistration : Entity
    {
        /// <summary>
        /// 报名人/学员名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Mobilephone { get; set; }
        /// <summary>
        /// 班型编号
        /// </summary>
        public System.Nullable<int> ClassInfoId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public System.Nullable<DateTime> CreateTime { get; set; }
        /// <summary>
        /// 0，未报名；1，已报名
        /// </summary>
        public System.Nullable<int> Status { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCardNo { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        public int? TeacherId { get; set; }
        public int? HouseholdType { get; set; }
    }
}
