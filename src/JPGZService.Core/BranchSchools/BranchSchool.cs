using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace JPGZService.BranchSchools
{
    [Table("Tb_BranchSchool")]
    public class BranchSchool:Entity
    {
        public System.Nullable<int> DriveSchoolId { get; set; }
        public string District { get; set; }
        public string Name { get; set; }
        public string BName { get; set; }
        public System.Nullable<int> Type { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public System.Nullable<DateTime> OpenDate { get; set; }
        public System.Nullable<int> TechSiteNum { get; set; }
        public System.Nullable<int> AdmissionsSiteNum { get; set; }
        public string Photo { get; set; }
        public string PhotoAlbum { get; set; }
        public string Introduction { get; set; }
        public bool? DeleteMark { get; set; }
    }
}
