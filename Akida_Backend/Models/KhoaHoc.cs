using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Akida_Backend.Models
{
    public class KhoaHoc
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Category_ID { get; set; }
        public string Author { get; set; }
        public System.DateTime Created_Time { get; set; }
        public string Short_Description { get; set; }
        public int Number_Of_Participants { get; set; }
        public int Video_Info_ID { get; set; }
        public int Cost_Aki { get; set; }
        public int Enabled { get; set; }
    }
}