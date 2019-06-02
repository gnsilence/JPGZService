using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.ClassAddtions
{
    [Table("Tb_ClassAddtion")]
    public class ClassAddtion:Entity
    {
        public int ClassId { get; set; }
        public System.Nullable<decimal> StandardPrice { get; set; }
        public System.Nullable<int> TrainPattern { get; set; }
        public System.Nullable<int> ChargePattern { get; set; }
        public System.Nullable<int> PayMentPattern { get; set; }
        public System.Nullable<double> Part1Hours { get; set; }
        public System.Nullable<double> Part2Hours { get; set; }
        public System.Nullable<double> Part3Hours { get; set; }
        public System.Nullable<double> Part4Hours { get; set; }
        public System.Nullable<decimal> Part1PreMoney { get; set; }
        public System.Nullable<decimal> Part2PreMoney { get; set; }
        public System.Nullable<decimal> Part3PreMoney { get; set; }
        public System.Nullable<decimal> Part4PreMoney { get; set; }
        public string ChargeDescribe { get; set; }
    }
}
