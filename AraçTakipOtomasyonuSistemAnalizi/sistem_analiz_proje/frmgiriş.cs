using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sistem_analiz_proje
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string[] bharf = { "A", "B", "C", "D" };
            string[] kharf = { "a", "b", "c", "d" };
            string[] sembol = { "*", "?", "#", "%" };
            Random rnd = new Random();
            int sayi1 = rnd.Next(1, 5);
            int sayi2 = rnd.Next(0, bharf.Length);
            int sayi3 = rnd.Next(0, kharf.Length);
            int sayi4 = rnd.Next(0, sembol.Length);
            label5.Text = sayi1.ToString();
            label6.Text = bharf[sayi2];
            label7.Text = kharf[sayi3];
            label8.Text = sembol[sayi4];


        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }



        private void label2_Click(object sender, EventArgs e)
        {

        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbl_giris where kullanici_adi=@p1 and sifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", kullanici_adi.Text);
            komut.Parameters.AddWithValue("@p2", sifre.Text);
            SqlDataReader dr = komut.ExecuteReader();//Çalıştırır.

            if (dr.Read())
            {
                Form1 frm = new Form1();
                frm.kullanici = kullanici_adi.Text;
                frm.Show();
                this.Hide();
                //MessageBox.Show("GİRİŞ BAŞARILI");
            }
            else
            {
                MessageBox.Show("Kullanıcı veya şifre hatalı.");
            }
          
         
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

    

