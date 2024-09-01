using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sinemaUygulama.Models
{
    public  class Sale:BaseClass
    {

        public string creationDate { get; set; }
        public decimal totalPrice { get; set; }
        public int count { get; set; }
        public string sessionTime { get; set; }
    }
}
