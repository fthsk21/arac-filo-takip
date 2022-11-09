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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dboGarajOtomasyonDataSet.tbl_aciltel' table. You can move, or remove it, as needed.
           

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*SqlCommand ara = new SqlCommand("select*from tbl_aciltel where ad like '%" + txtsehir.Text + "%'", bgl.baglanti());
            ara.Parameters.AddWithValue("@p1", txtsehir.Text);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;*/
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        void temizle()
        {
            txtyolyardim.Text = "";
            txtcekici.Text = "";
            txtlastikci.Text = "";
            txtusta.Text = "";
            txtsigorta.Text = "";
            txtiller.Text = "";
        }
        void listele()
        {
            SqlCommand listele = new SqlCommand("select*from tbl_aciltel", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(listele); //listeleme işlemlerini SqlDataAdapter'ı kullanırız.
            DataTable dt = new DataTable(); //Tablo oluşturmaya yarar.
            da.Fill(dt); //listeyi datatable içine atar.
            dataGridView1.DataSource = dt;
        }

            private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            DialogResult sonuc = frm1.ShowDialog();
            this.Hide();
        }

        private void txtsehir_TextChanged(object sender, EventArgs e)
        {
            SqlCommand ara = new SqlCommand("select*from tbl_aciltel where iller like '%" + txtsehir.Text + "%'", bgl.baglanti());
            ara.Parameters.AddWithValue("@p1", txtsehir.Text);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlCommand kaydet = new SqlCommand
            ("insert into tbl_aciltel (yol_yardim,cekici,lastikci,usta,sigorta,iller) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            kaydet.Parameters.AddWithValue("@p1", txtyolyardim.Text);
            kaydet.Parameters.AddWithValue("@p2", txtcekici.Text);
            kaydet.Parameters.AddWithValue("@p3", txtlastikci.Text);
            kaydet.Parameters.AddWithValue("@p4", txtusta.Text);
            kaydet.Parameters.AddWithValue("@p5", txtsigorta.Text);
            kaydet.Parameters.AddWithValue("@p6", txtiller.Text);
            kaydet.ExecuteNonQuery();//komutları çalıştırma işlemini yapar.
            MessageBox.Show("Kaydetme işlemi tamamlanmıştır.");
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand sil = new SqlCommand("delete from tbl_aciltel where iller=@p1", bgl.baglanti());
            sil.Parameters.AddWithValue("@p1", txtiller.Text);
            sil.ExecuteNonQuery();
            MessageBox.Show("Silme işlemi tamamlanmıştır.");
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand guncelle = new SqlCommand
           ("update tbl_aciltel set yol_yardim=@p1,cekici=@p2,lastikci=@p3,usta=@p4,sigorta=@p5 where iller=@6", bgl.baglanti());
            guncelle.Parameters.AddWithValue("@p1", txtyolyardim.Text);
            guncelle.Parameters.AddWithValue("@p2", txtcekici.Text);
            guncelle.Parameters.AddWithValue("@p3", txtlastikci.Text);
            guncelle.Parameters.AddWithValue("@p4", txtusta.Text);
            guncelle.Parameters.AddWithValue("@p5", txtsigorta.Text);
            guncelle.Parameters.AddWithValue("@p6", txtiller.Text);
            guncelle.ExecuteNonQuery();//Komutları çalıştırır.
            MessageBox.Show("Güncelleme işlemi tamamlanmıştır.");
            listele();
            temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtyolyardim.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtcekici.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtlastikci.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtusta.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsigorta.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtiller.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
