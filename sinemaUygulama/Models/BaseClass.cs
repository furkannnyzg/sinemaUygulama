using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sinemaUygulama.Models
{
    public abstract class BaseClass
    {
        //abstract yapma sebebim bu sınıftan belirli bir veri modeli oluşturulmayacağı için.
        public string MovieName { get; set; }
    }
}
