using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.ChargeDatas
{
    [Table("tb_ChargeData")]
    public class ChargeData:Entity
    {
        /// <summary>
        /// 学员Id
        /// </summary>
        public System.Nullable<int> StudentId { get; set; }
        /// <summary>
        /// 收费类型 1，学费；2，补考费
        /// </summary>
        public System.Nullable<int> ChargeType { get; set; }
        
        /// <summary>
        /// 收费状态 0，未收费；1，已收费
        /// </summary>
        public System.Nullable<int> ChargeStatus { get; set; }
        /// <summary>
        /// 收费金额
        /// </summary>
        public System.Nullable<decimal> ChargeMoney { get; set; }
         
        /// <summary>
        /// 付款时间
        /// </summary>
        public System.Nullable<DateTime> PaymentDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        public System.Nullable<int> CreateUserId { get; set; } 
        public System.Nullable<DateTime> CreateTime { get; set; }
        public System.Nullable<int> ChargeUserId { get; set; } 
        public System.Nullable<DateTime> ChargeTime { get; set; }
        public System.Nullable<int> AuditUserId { get; set; } 
        public System.Nullable<DateTime> AuditTime { get; set; }
        public System.Nullable<int> AuditStatus { get; set; } 
    }
}
