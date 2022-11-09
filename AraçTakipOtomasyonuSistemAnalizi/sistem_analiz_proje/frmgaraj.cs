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
    public partial class frmgaraj : Form
    {
        public frmgaraj()
        {
            InitializeComponent();
        }
        
        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dboGarajOtomasyonDataSet.tbl_garaj' table. You can move, or remove it, as needed.
            
            frmgaraj frm3 = new frmgaraj();
            listele();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        sqlbaglantisi bgl = new sqlbaglantisi();


        private void button2_Click(object sender, EventArgs e)
        {

        }
        void temizle()
        {
            marka.Text = "";
            model.Text = "";
            plaka.Text = "";
            kasa_tipi.Text = "";
            sigorta_tarihi.Text = "";
            muayene_tarihi.Text = "";
            yakit_tipi.Text = "";
            maskedTextBox1.Text = "";
            lastik_durumu.Text = "";
            bul_txt.Text = "";
            e_mail.Text = "";
            if (maskedTextBox1.Text=="")
            {
                progressBar1.Value = 0;
            }
        }

        void listele()
        {
            SqlCommand listele = new SqlCommand("select*from tbl_garaj1", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(listele); //listeleme işlemlerini SqlDataAdapter'ı kullanırız.
            DataTable dt = new DataTable(); //Tablo oluşturmaya yarar.
            da.Fill(dt); //listeyi datatable içine atar.
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //SİLME İŞLEMİ YAPILIR.
            SqlCommand sil = new SqlCommand("delete from tbl_garaj1 where marka=@p1", bgl.baglanti());
            sil.Parameters.AddWithValue("@p1", marka.Text);
            sil.ExecuteNonQuery();
            MessageBox.Show("Silme işlemi tamamlanmıştır.");
            listele();
        }
        int poz;
        private void button2_Click_1(object sender, EventArgs e)
        {
            poz = progressBar1.Value;
            //KAYDETME İŞLEMİ YAPILIR.
            SqlCommand kaydet = new SqlCommand
            ("insert into tbl_garaj1 (marka,model,plaka,kasa_tipi,sigorta_tarihi,muayene_tarihi,yakit_tipi,yag_durumu,lastik_durumu,e_mail) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.baglanti());
            kaydet.Parameters.AddWithValue("@p1", marka.Text);
            kaydet.Parameters.AddWithValue("@p2", model.Text);
            kaydet.Parameters.AddWithValue("@p3", plaka.Text);
            kaydet.Parameters.AddWithValue("@p4", kasa_tipi.Text);
            kaydet.Parameters.AddWithValue("@p5", sigorta_tarihi.Text);
            kaydet.Parameters.AddWithValue("@p6", muayene_tarihi.Text);
            kaydet.Parameters.AddWithValue("@p7", yakit_tipi.Text);
            kaydet.Parameters.AddWithValue("@p8", maskedTextBox1.Text);
            kaydet.Parameters.AddWithValue("@p9", lastik_durumu.Text);
            kaydet.Parameters.AddWithValue("@p10", e_mail.Text);
            kaydet.ExecuteNonQuery();//komutları çalıştırma işlemini yapar.
            MessageBox.Show("Kaydetme işlemi tamamlanmıştır.");
            listele();
            temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //GÜNCELLEME İŞLEMİ YAPILARAK PARAMETRELERE AKTARILDI.
            SqlCommand guncelle = new SqlCommand
            ("update tbl_garaj1 set marka=@p1,model=@p2,kasa_tipi=@p4,sigorta_tarihi=@p5,muayene_tarihi=@p6,yakit_tipi=@p7,yag_durumu=@p8,lastik_durumu=@p9,e_mail=@p10 where plaka=@p3", bgl.baglanti());
            guncelle.Parameters.AddWithValue("@p1", marka.Text);
            guncelle.Parameters.AddWithValue("@p2", model.Text);
            guncelle.Parameters.AddWithValue("@p3", plaka.Text);
            guncelle.Parameters.AddWithValue("@p4", kasa_tipi.Text);
            guncelle.Parameters.AddWithValue("@p5", sigorta_tarihi.Text);
            guncelle.Parameters.AddWithValue("@p6", muayene_tarihi.Text);
            guncelle.Parameters.AddWithValue("@p7", yakit_tipi.Text);
            guncelle.Parameters.AddWithValue("@p8", maskedTextBox1.Text);
            guncelle.Parameters.AddWithValue("@p9", lastik_durumu.Text);
            guncelle.Parameters.AddWithValue("@p10", e_mail.Text);
            guncelle.ExecuteNonQuery();//Komutları çalıştırır.
            MessageBox.Show("Güncelleme işlemi tamamlanmıştır.");
            listele();
            temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //TEXTBOXLARA GİRİLEN VERİLER DATAGRİD SATIRLARINA YAZDIRILIR.
            marka.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            model.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            plaka.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            kasa_tipi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            sigorta_tarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            muayene_tarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            yakit_tipi.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            lastik_durumu.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            e_mail.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            progressBar1.Value = int.Parse(maskedTextBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand ara = new SqlCommand("select*from tbl_garaj1 where plaka like '%" + bul_txt.Text + "%'", bgl.baglanti());
            ara.Parameters.AddWithValue("@p1", bul_txt.Text);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void txtarac_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
        private void button6_Click(object sender, EventArgs e)
        {
             
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bul_txt_TextChanged(object sender, EventArgs e)
        {
            SqlCommand ara = new SqlCommand("select*from tbl_garaj1 where plaka like '%" + bul_txt.Text + "%'", bgl.baglanti());
            ara.Parameters.AddWithValue("@p1", bul_txt.Text);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
