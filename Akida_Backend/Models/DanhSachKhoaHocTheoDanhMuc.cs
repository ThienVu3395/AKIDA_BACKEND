using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Akida_Backend.Models
{
    public class DanhSachKhoaHocTheoDanhMuc
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        public string Author { get; set; }
        public System.DateTime Created_Time { get; set; }
        public string Short_Description { get; set; }
        public int Number_Of_Participants { get; set; }
        public int Video_Info_ID { get; set; }
        public int Cost_Aki { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public int Count { get; set; }
    }
}