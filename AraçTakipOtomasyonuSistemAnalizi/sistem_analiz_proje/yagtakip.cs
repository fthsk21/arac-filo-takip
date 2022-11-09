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
    public partial class yagtakip : Form
    {
        public yagtakip()
        {
            InitializeComponent();
        }

        void temizle()
        {

        }
        void listele()
        {
            SqlCommand listele = new SqlCommand("select*from tbl_garaj1", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(listele); //listeleme işlemlerini SqlDataAdapter'ı kullanırız.
            DataTable dt = new DataTable(); //Tablo oluşturmaya yarar.
            da.Fill(dt); //listeyi datatable içine atar.
            dataGridView1.DataSource = dt;
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        sqlbaglantisi bgl =new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            int yag, mesafe, sonuc;
            mesafe = Convert.ToInt32(txtmesafe.Text);
            yag = Convert.ToInt32(txtyagmiktarı.Text);
            sonuc = Convert.ToInt32(mesafe / 50 - yag);
            txtyagson.Text = sonuc.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //GÜNCELLEME İŞLEMİ YAPILARAK PARAMETRELERE AKTARILDI.
            SqlCommand guncelle = new SqlCommand
            ("update tbl_garaj1 set yag_durumu=@p1 where plaka=@p2", bgl.baglanti());
            guncelle.Parameters.AddWithValue("@p1", txtyagson.Text);
            guncelle.Parameters.AddWithValue("@p2", dataGridView1.CurrentRow.Cells[2].Value.ToString());
            guncelle.ExecuteNonQuery();
            MessageBox.Show("GÜNCELLEME TAMAMLANDI");
            listele();





        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtyagmiktarı.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
