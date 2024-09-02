using sinemaUygulama.Enums;
using sinemaUygulama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sinemaUygulama.Helpers
{
    public class helper
    {

        public static List<Movie> CreateMovies()
        {
            string basepath = "C:\\Users\\eren_\\source\\repos\\sinemaUygulama\\sinemaUygulama\\pictures\\";
            return new List<Movie>() {
            
                new Movie(){ 
                MovieName="Ustura Kemal",
                minute="2 Saat",
                price=100,
                category=Category.gerilim,
                picture_path=basepath+"usturakemal.jpg"
                },
                new Movie(){
                MovieName="Hobbit",
                minute="2 Saat",
                price=100,
                category=Category.macera,
                picture_path=basepath+"hobbit.jpg"
                },
                new Movie(){
                MovieName="Keloglan",
                minute="2 Saat",
                price=100,
                category=Category.gerilim,
                picture_path=basepath+"keloglan.jpg"
                },
                new Movie(){
                MovieName="Kral",
                minute="2 Saat",
                price=100,
                category=Category.bilim_kurgu,
                picture_path=basepath+"kral.jpg"
                },
                new Movie(){
                MovieName="Mahşerin Dört Tatlısı",
                minute="2 Saat",
                price=100,
                category=Category.gerilim,
                picture_path=basepath+"mahserindorttatlisi.jpg"
                },
                new Movie(){
                MovieName="Sezercik",
                minute="2 Saat",
                price=100,
                category=Category.fantastik,
                picture_path=basepath+"sezercik.jpg"
                },

            };

        }

    }
}
