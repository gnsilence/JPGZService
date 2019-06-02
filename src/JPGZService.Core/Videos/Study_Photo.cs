using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JPGZService.Videos
{
    /// <summary>
    /// 图片model
    /// </summary>
    [Table("td_Study_Photo")]
    public  class Study_Photo : Entity
    {    
        // public int ID{ get; set; }
        public System.Nullable<int> GpsId{ get; set; }
        public DateTime PhotoTime{ get; set; }
        public string PhotoPathName{ get; set; }
        public DateTime UploadTime{ get; set; }
        public string PhotoId{ get; set; }
        public int PhotoSource{ get; set; }
        public int UploadStatus{ get; set; }
        public string ClassId{ get; set; }
        public string Stunum{ get; set; }
        public System.Nullable<int> EventType{ get; set; }
    }
}
