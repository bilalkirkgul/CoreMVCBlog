using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class MessageTwo
    {
        [Key]
        public int MessageID { get; set; }
        public string MessageSubject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime MessageDate { get; set; }
        public bool MessageStatus { get; set; }
        //Gönderici              
        public int? SenderID { get; set; }
        public Writer SenderUser { get; set; }
        //Alıcı      
        public int? ReceiverID { get; set; }
        public Writer ReceiverUser { get; set; }

    }
}
