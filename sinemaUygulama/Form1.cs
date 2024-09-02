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
        DateTime currentDate=DateTime.Now;
        DateTime useDate;
        Form2 form2;
        private void Form1_Load(object sender, EventArgs e)
        {
            useDate=currentDate;
            lblDate.Text=useDate.ToShortDateString();
            movies = helper.CreateMovies();
            ListControls();
            form2=new Form2(movies,this);
            //formu gönderiyoruz
        }


        private void ListControls()
        {
            Size picturesSize = new Size(300, 180);
            Size buttonSize = new Size(90, 40);
            int x = 50;
            int y = 100;
            int xIncrement = 400;
            int yIncrement = 300;

            for (int i = 0; i < movies.Count; i++) {
            
                PictureBox picture = new PictureBox();
                picture.Location = new Point(x, y);
                picture.Size = picturesSize;
                picture.Image = Image.FromFile(movies[i].picture_path);
                picture.SizeMode = PictureBoxSizeMode.StretchImage;
                this.Controls.Add(picture);
                int buttonX = x;
                int buttonY = picture.Bottom + 10;
                for (int index=0;index<3;index++)
                {
                    Button button = new Button();
                    button.Text = movies[i].sessions[index].time;
                    button.Location= new Point(buttonX+2, buttonY);
                    button.Size = buttonSize;
                    button.Tag = i;//i movies index'i
                    button.Click += new EventHandler(button_Click);
                    this.Controls.Add(button);
                    buttonX += 100;
                }

                if (1200 > x + xIncrement + picture.Width)
                {
                    x += xIncrement;
                }
                else {
                    x = 50;
                    y += yIncrement;

                }


            }

        }

        private void button_Click(object sender,EventArgs e)
        {
            //sender'ın içerisinde hangi butona basıldığı bilindiği için cast işlemi gerçekleştirildi.

            Button button=sender as Button;
            int movieIndex=Convert.ToInt32(button.Tag);
            string sessionTime = button.Text;
            string sessionDate=lblDate.Text;
            if (DateTime.Parse($"{sessionDate} {sessionTime}") < DateTime.Now)
            {
                MessageBox.Show("Seçilen Seansı kaçırdınız.Başka seans seçiniz.");
                return;
            }
            this.Hide();
            form2.Show(); 
            form2.ListDetail(movieIndex, sessionTime, sessionDate);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            useDate=useDate.AddDays(1);
            lblDate.Text = useDate.ToShortDateString();
            btnPrevious.Enabled = true;
            if (currentDate.AddDays(2)==useDate)
            {
                btnNext.Enabled = false;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            useDate = useDate.AddDays(-1);
            lblDate.Text=useDate.ToShortDateString();
            btnNext.Enabled=true;
            if (currentDate==useDate)
            {
                btnPrevious.Enabled = false;
            }
        }
    }
}
