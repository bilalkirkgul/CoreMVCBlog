using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string AboutDetailsOne { get; set; }
        public string AboutDetailsTwo { get; set; }
        public string AboutImgOne { get; set; }
        public string AboutImgTwo { get; set; }
        public bool Status { get; set; }
        public string AboutLocation { get; set; }
    }
}
