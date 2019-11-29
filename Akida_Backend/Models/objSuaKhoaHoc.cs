using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Akida_Backend.Models
{
    public class objSuaKhoaHoc
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Category_ID { get; set; }
        public string Short_Description { get; set; }
        public int Enabled { get; set; }
        public string Content { get; set; }
    }
}