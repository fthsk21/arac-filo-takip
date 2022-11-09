using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistem_analiz_proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            label2.Text = kullanici;

            if (label1.Text=="fatih")
            {
                label2.Text = "Fatih Işık";
            }

            else if (label1.Text == "muhammet")
            {
                label2.Text = "Muhammet Kizir";
            }

            else if (label1.Text == "servet")
            {
                label2.Text = "Servet Kılıç";
            }
        }

        public string kullanici; 
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iLETİŞİMToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void çIKIŞToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void çIKIŞToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmgaraj frm3 = new frmgaraj();
            DialogResult sonuc = frm3.ShowDialog();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            DialogResult sonuc = frm4.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            DialogResult sonuc = frm5.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            DialogResult sonuc = frm6.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            yagtakip yagtakip = new yagtakip();
            DialogResult sonuc = yagtakip.ShowDialog();
        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            sorgulama sorgulama = new sorgulama();
            DialogResult sonuc = sorgulama.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
