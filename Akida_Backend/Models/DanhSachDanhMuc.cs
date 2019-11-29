using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Akida_Backend.Models
{
    public class DanhSachDanhMuc
    {
        public int ID_Category { get; set; }
        public string Name { get; set; }
        public System.DateTime Created_Time { get; set; }
        public string Description { get; set; }
    }
}