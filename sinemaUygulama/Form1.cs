using sinemaUygulama.Helpers;
using sinemaUygulama.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sinemaUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Movie> movies;

        private void Form1_Load(object sender, EventArgs e)
        {
            movies = helper.CreateMovies();
        }
    }
}
