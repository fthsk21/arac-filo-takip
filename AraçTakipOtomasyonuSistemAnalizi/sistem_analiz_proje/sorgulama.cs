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
    public partial class sorgulama : Form
    {
        public sorgulama()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        void listele()
        {
            SqlCommand listele = new SqlCommand("select*from tbl_garaj1", bgl.baglanti());
            SqlDataAdapter da = new SqlDataAdapter(listele); //listeleme işlemlerini SqlDataAdapter'ı kullanırız.
            DataTable dt = new DataTable(); //Tablo oluşturmaya yarar.
            da.Fill(dt); //listeyi datatable içine atar.
            dataGridView1.DataSource = dt;
        }

        private void sorgulama_Load(object sender, EventArgs e)
        {
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          //  txtsigorta.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
          //  txtmuayene.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
          //  txtlastik.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
        }

        private void btn_sıgorta_Click(object sender, EventArgs e)
        {
           

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TimeSpan fark;
            fark = DateTime.Parse(dateTimePicker2.Text) - DateTime.Parse(dateTimePicker1.Text);
            textBox1.Text = fark.TotalDays.ToString() + " GÜN KALDI";
            MessageBox.Show(textBox1.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TimeSpan fark;
            fark = DateTime.Parse(dateTimePicker6.Text) - DateTime.Parse(dateTimePicker5.Text);
            textBox3.Text = fark.TotalDays.ToString() + " GÜN KALDI";
            MessageBox.Show(textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            TimeSpan hesap;
            hesap = DateTime.Parse(dateTimePicker4.Text) - DateTime.Parse(dateTimePicker3.Text);
            textBox2.Text = hesap.TotalDays.ToString() + " GÜN KALDI";
            MessageBox.Show(textBox2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            DialogResult sonuc = frm5.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
