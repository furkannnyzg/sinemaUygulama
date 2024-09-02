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
    public partial class Form2 : Form
    {
        public Form2(List<Movie> _movies,Form1 _form1)
        {
            InitializeComponent();
            movies = _movies;
            form1= _form1;
            
        }

        List<Movie> movies;
        Form1 form1;
        Movie selectedMovie;
        Session SelectedSession;


        public void ListDetail(int movieIndex, string _time, string _date)
        {
            selectedMovie=movies[movieIndex];
            SelectedSession=selectedMovie.sessions.Find(s => s.date == _date && s.time==_time);//buradaki s sessionlar içerisinde döndüğümüzü söyler.
            //if kullanmak yani
            lblTime.Text = $"{_date} - {_time}";
            lblMinute.Text = selectedMovie.minute;
            lblPrice.Text= selectedMovie.price.ToString()+" TL";
            lblCategory.Text=selectedMovie.category.ToString();
            pbSelectedPicture.Image = Image.FromFile(selectedMovie.picture_path);

            checkChairStatus();


        }

        private void checkChairStatus()
        {

            foreach (Control item in grbChairs.Controls) {
            if(item is Button)
                {
                    string row = item.Tag.ToString();
                    string number = item.Text;
                    item.Enabled = true;

                    foreach  (chair chair in SelectedSession.chairs)
                    {
                        //buradaki olay burada seçilen buttonu chairsle eşleştirmektir.
                        if(chair.Row==row && chair.Number == number)
                        {
                            if (chair.Status)
                            {
                                item.BackColor = Color.DarkRed;//bu koltuk daha önce alınmıştır yap.
                                item.Enabled=false;
                            }
                            else {

                                item.BackColor = Color.LightGreen;
                            }
                            break;//chairs eşleşti artık burada durmanın bir manası yok
                        }
                    }

                }
            }
        }
        List<chair> chairs = new List<chair>();
        private void button18_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            string row=button.Tag.ToString();
            string number=button.Text;
            chair chair = SelectedSession.chairs.Find(c => c.Row == row && c.Number == number);
            if (button.BackColor.Name != "Blue") {
                chairs.Add(chair);
                button.BackColor = Color.Blue;
            }
            else {
                chairs.Remove(chair);
                button.BackColor = Color.LightGreen;
            }
         }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (chairs.Count==0)
            {
                MessageBox.Show("Lütfen en az 1 koltuk seçiniz.");
                return;
            }

            Sale sales=new Sale();
            sales.MovieName = selectedMovie.MovieName;
            sales.count=chairs.Count;
            sales.sessionTime = $"{SelectedSession.date}-{SelectedSession.time}";
            sales.totalPrice = CalculatePrice();

            foreach (chair chair in chairs)
            {
                chair.Status = true;
            }





            MessageBox.Show(sales.ToString());
            changePage();

        }
        private void changePage()
        {
            rbSmall.Checked = rbMedium.Checked = rbLarge.Checked = false;
            chairs.Clear();
            this.Hide();
            form1.Show();

        }
        private decimal CalculatePrice() {
        
        decimal price = selectedMovie.price * chairs.Count;
            if (rbSmall.Checked)
            {
                price += 3;
            }
            else if (rbMedium.Checked)
            {
                price += 6;
            }
            else if (rbLarge.Checked)
            {
                price += 9;
            }
            return price;
        
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            changePage();
        }
    }




}
