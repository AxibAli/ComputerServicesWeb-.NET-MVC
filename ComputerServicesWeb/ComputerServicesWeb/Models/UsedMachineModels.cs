using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComputerServicesWeb.Models
{
    public class UsedMachineModels
    {
        public int id { get; set; }
        public long usedmachineId { get; set; }
        public string  PicturePath { get; set; }
        public string  Brand { get; set; }
        public string  Ram { get; set; }
        public string  Harddisk { get; set; }
        public string  ScreenSize { get; set; }
        public string  ModelNo { get; set; }
        public string  Processor { get; set; }
        public string  OtherInformation { get; set; }
        public string ArabicBrand { get; set; }
        public string ArabicRam { get; set; }
        public string ArabicHarddisk { get; set; }
        public string ArabicScreenSize { get; set; }
        public string ArabicModelNo { get; set; }
        public string ArabicProcessor { get; set; }
        public string ArabicOtherInformation { get; set; }
        public string Status { get; set; } 
        public string Price { get; set; } 

        [NotMapped]
        public string existingpicturepath { get; set; }
        [NotMapped]
        public SelectList Types { get; set; }
        [NotMapped]
        public SelectList ArabicTypes { get; set; }

        [ForeignKey("TypeModel")]
        public int Type { get; set; }
        public virtual TypeModel TypeModel { get; set; }

    }
}