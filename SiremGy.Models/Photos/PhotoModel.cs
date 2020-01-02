using System;
using System.Collections.Generic;
using System.Text;

namespace SiremGy.BLL.Models.Photos
{
    public class PhotoModel : ModelBase
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public bool Visible { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
