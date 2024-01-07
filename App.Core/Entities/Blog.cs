using App.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Entities
{
    public class Blog : BaseEntity
    {
        public string BlogName { get; set; }
        public string BlogDescription { get; set;}
        public string ImgUrl { get; set; }
    }
}
