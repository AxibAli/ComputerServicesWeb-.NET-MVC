﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComputerServicesWeb.Models
{
    public class UsedMachineModels
    {
        public int id { get; set; }
        public string  PicturePath { get; set; }
        public string  Type { get; set; }
        public string  Brand { get; set; }
        public string  Ram { get; set; }
        public string  Harddisk { get; set; }
        public string  ScreenSize { get; set; }
        public string  ModelNo { get; set; }
        public string  Processor { get; set; }
        public string  OtherInformation { get; set; }
    }
}