using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Category
    {
        [Key] //Birincil anahtar tanımlaması yaptım
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }

        //List ve ICollection arasındaki fark araştırılacak
        //onetoMany bir kategorinin birden fazla blogu olur
        public ICollection<Blog> Blogs { get; set; }

    }
}
