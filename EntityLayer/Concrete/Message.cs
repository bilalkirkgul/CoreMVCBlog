using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Message
    {
        [Key]
        public int MessageID { get; set; }
        //Gönderici
        public string Sender { get; set; }
        //Alıcı
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public string Details { get; set; }
        public DateTime Date { get; set; }
        public bool MessageStatus { get; set; }

    }
}
