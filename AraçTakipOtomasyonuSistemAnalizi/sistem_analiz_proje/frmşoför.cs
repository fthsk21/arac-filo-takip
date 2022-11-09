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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dboGarajOtomasyonDataSet.tbl_sofor' table. You can move, or remove it, as needed.
            

        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void temizle()
        {
            ad.Text = "";
            soyad.Text = "";
            txt_tc.Text = "";
            txt_dogum_tarihi.Text = "";
            dogum_yeri.Text = "";
            txt_tel.Text = "";
            e_mail.Text = "";
            adres.Text = "";
            ehliyet_sinifi.Text = "";
            txtsofor.Text = "";
        }

        void listele()
        {
            SqlCommand listele = new SqlCommand("select*from tbl_sofor", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(listele); //listeleme işlemlerini SqlDataAdapter'ı kullanırız.
            DataTable dt = new DataTable(); //Tablo oluşturmaya yarar.
            da.Fill(dt); //listeyi datatable içine atar.
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //  ("insert into tbl_garaj (marka,model,plaka,kasa_tipi,sigorta_tarihi,muayene_tarihi,yakit_tipi,yag_durumu,lastik_durumu) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti()); ad,soyad,tc_kimlik,dogum_tarihi,dogum_yeri,telefon,e_mail,adres,ehliyet_sinifi
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //KAYDETME İŞLEMİ YAPILIR.
            // ("insert into tbl_garaj (marka,model,plaka,kasa_tipi,sigorta_tarihi,muayene_tarihi,yakit_tipi,yag_durumu,lastik_durumu)

            SqlCommand kaydet = new SqlCommand
            ("insert into tbl_sofor (ad,soyad,tc_kimlik,dogum_tarihi,dogum_yeri,telefon,e_mail,adres,ehliyet_sinifi) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            kaydet.Parameters.AddWithValue("@p1", ad.Text);
            kaydet.Parameters.AddWithValue("@p2", soyad.Text);
            kaydet.Parameters.AddWithValue("@p3", txt_tc.Text);
            kaydet.Parameters.AddWithValue("@p4", txt_dogum_tarihi.Text);
            kaydet.Parameters.AddWithValue("@p5", dogum_yeri.Text);
            kaydet.Parameters.AddWithValue("@p6", txt_tel.Text);
            kaydet.Parameters.AddWithValue("@p7", e_mail.Text);
            kaydet.Parameters.AddWithValue("@p8", adres.Text);
            kaydet.Parameters.AddWithValue("@p9", ehliyet_sinifi.Text);
            kaydet.ExecuteNonQuery();//komutları çalıştırma işlemini yapar.
            MessageBox.Show("Kaydetme işlemi tamamlanmıştır.");
            listele();
        }
        // ("insert into tbl_garaj (ad,soyad,tc_kimlik,dogum_tarihi,dogum_yeri,telefon,e_mail,adres,ehliyet_sinifi) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
        private void button3_Click(object sender, EventArgs e)
        {
            //GÜNCELLEME İŞLEMİ YAPILARAK PARAMETRELERE AKTARILDI.
            SqlCommand guncelle = new SqlCommand 
            ("update tbl_sofor set ad=@p1,soyad=@p2,dogum_tarihi=@p4,dogum_yeri=@p5,telefon=@p6,e_mail=@p7,adres=@p8,ehliyet_sinifi=@p9 where tc_kimlik=@p3", bgl.baglanti());
            guncelle.Parameters.AddWithValue("@p1", ad.Text);
            guncelle.Parameters.AddWithValue("@p2", soyad.Text);
            guncelle.Parameters.AddWithValue("@p3", txt_tc.Text);
            guncelle.Parameters.AddWithValue("@p4", txt_dogum_tarihi.Text);
            guncelle.Parameters.AddWithValue("@p5", dogum_yeri.Text);
            guncelle.Parameters.AddWithValue("@p6", txt_tel.Text);
            guncelle.Parameters.AddWithValue("@p7", e_mail.Text);
            guncelle.Parameters.AddWithValue("@p8", adres.Text);
            guncelle.Parameters.AddWithValue("@p9", ehliyet_sinifi.Text);
            //MessageBox.Show(kaydet.CommandText.ToString());
            guncelle.ExecuteNonQuery();//Komutları çalıştırır.
            MessageBox.Show("Güncelleme işlemi tamamlanmıştır.");
            listele();
            temizle();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //SİLME İŞLEMİ YAPILIR.
            SqlCommand sil = new SqlCommand("delete from tbl_sofor where tc_kimlik=@p1", bgl.baglanti());
            sil.Parameters.AddWithValue("@p1", txt_tc.Text);
            sil.ExecuteNonQuery();
            MessageBox.Show("Silme işlemi tamamlanmıştır.");
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand ara = new SqlCommand("select*from tbl_sofor where ad like '%" + txtsofor.Text + "%'", bgl.baglanti());
            ara.Parameters.AddWithValue("@p1", txtsofor.Text);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //TEXTBOXLARA GİRİLEN VERİLER DATAGRİD SATIRLARINA YAZDIRILIR.
            ad.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            soyad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_tc.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_dogum_tarihi.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            dogum_yeri.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txt_tel.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            e_mail.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            adres.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            ehliyet_sinifi.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            listele();
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = item as TextBox;
                    txt.Clear();
                }
            }
        }

        private void txtsofor_TextChanged(object sender, EventArgs e)
        {
            SqlCommand ara = new SqlCommand("select*from tbl_sofor where ad like '%" + txtsofor.Text + "%'", bgl.baglanti());
            ara.Parameters.AddWithValue("@p1", txtsofor.Text);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btn_donus_Click(object sender, EventArgs e)
        {

            Form1 frm1 = new Form1();
            DialogResult sonuc = frm1.ShowDialog();
            this.Hide();
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
