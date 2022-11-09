using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using sistem_analiz_proje.Models;
using System.Data.SqlClient;

namespace sistem_analiz_proje
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
        sqlbaglantisi bgl = new sqlbaglantisi();    
        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            DialogResult sonuc = frm1.ShowDialog();
            frm1.Show();
            this.Hide();

        }

        void temizle()
        {

        }
        void listele()
        {
            SqlCommand listele = new SqlCommand("select*from tbl_sofor", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(listele); //listeleme işlemlerini SqlDataAdapter'ı kullanırız.
            DataTable dt = new DataTable(); //Tablo oluşturmaya yarar.
            da.Fill(dt); //listeyi datatable içine atar.
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MailMessage mesajım = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("filotakipsistem@gmail.com", "FM*082952");
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            istemci.EnableSsl = true;
            mesajım.To.Add(txtmail.Text);
            mesajım.From = new MailAddress(txtmail.Text);
            mesajım.Subject="FİLO TAKİP SİSTEMLERİ İLETİŞİM";
            mesajım.Body = txtmesaj.Text;
            istemci.Send(mesajım);
            MessageBox.Show("MAİL GÖNDERİLDİ");


        }

        private void button3_Click(object sender, EventArgs e)
        {
            smsgonderme smsApi = new smsgonderme();
            smsApi.Smsgonderme(txttel.Text);
            MessageBox.Show("SMS GÖNDERİLDİ");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtad.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txttel.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtmail.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*SqlCommand listele = new SqlCommand("select e_mail from tbl_sofor ", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(listele);
            SqlDataReader dr = listele.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr[0]);
            }*/
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
