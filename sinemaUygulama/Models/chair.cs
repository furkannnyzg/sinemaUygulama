using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sinemaUygulama.Models
{
    public class chair
    {
         public chair() { }
        public chair(string row,string number) {
            this.Row = row;
            this.Number = number;
            
        }

        public string Row { get; set; }
        public string Number { get; set; }
        public bool Status { get; set; }
    }
}
