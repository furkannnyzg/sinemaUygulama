using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sinemaUygulama.Models
{
    public class Session
    {

        /*date,time,chair*/
        public  Session() {
        SetDefaultChairs();
        }
        public string date { get; set; }
        public string time { get; set; }
        public List<chair> chairs { get; set; }

        private void SetDefaultChairs(){
        
            chairs = new List<chair>();
            string[] rows = {"a","b","c","d"};
            string[] numbers = {"1","2","3","4","5","6"};

            foreach (string row in rows) {

                foreach (string number in numbers) {
               
                    chair chair = new chair(row,number);
                    chairs.Add(chair);
                }
            }
        
        }
    }
}
