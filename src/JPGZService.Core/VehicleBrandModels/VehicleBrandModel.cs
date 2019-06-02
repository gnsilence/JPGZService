using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPGZService.VehicleBrandModels
{
    [Table("tb_VehicleBrandModel")]
    public class VehicleBrandModel : Entity
    {
        public System.Nullable<int> ParentId { get; set; }
        public string Name { get; set; }
        public string ManufacturerName { get; set; }
        public System.Nullable<int> JG_Id { get; set; }
    }
}

