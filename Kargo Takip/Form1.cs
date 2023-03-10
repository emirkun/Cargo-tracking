using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kargo_Takip
{
    public partial class Form1 : Form
    {
        int sayi = 200000;
        OleDbCommand cmd;
        OleDbDataAdapter da;
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.accdb");
        DataSet ds;
        OleDbDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }
        private void sil()
        {
            
        }
        private void verigüncelle()
        {
            con.Close();
            listView1.Items.Clear();
            con.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = con;
            komut.CommandText = ("Select * From Tablo1");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["e_Plaka"].ToString();
                ekle.SubItems.Add(oku["e_Marka"].ToString());
                ekle.SubItems.Add(oku["e_Model"].ToString());
                ekle.SubItems.Add(oku["e_Vites"].ToString());
                ekle.SubItems.Add(oku["e_Fiyat"].ToString());

                listView1.Items.Add(ekle);
            }
            con.Close(); 
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "BMW")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("M5");
                comboBox2.Items.Add("E30");
                comboBox2.Items.Add("İ8");
                comboBox2.Items.Add("M3");
                comboBox2.Items.Add("İ5");
            }
            if (comboBox1.SelectedItem == "MERCEDES")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("CLA");
                comboBox2.Items.Add("S Maybach");
                comboBox2.Items.Add("GLC Coupe");
                comboBox2.Items.Add("Vito Tourer");
                comboBox2.Items.Add("A240");
            }
            if (comboBox1.SelectedItem == "HONDA")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Civic");
                comboBox2.Items.Add("CR-V.");
                comboBox2.Items.Add("Accord");
                comboBox2.Items.Add("CR-Z");
                comboBox2.Items.Add("CRX");
            }
            if (comboBox1.SelectedItem == "TOYOTA")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Supra");
                comboBox2.Items.Add("Corolla");
                comboBox2.Items.Add("HYBRID");
                comboBox2.Items.Add("Land Cruiser");
                comboBox2.Items.Add("Hilux");
            }
            if (comboBox1.SelectedItem == "FORD")
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Focus");
                comboBox2.Items.Add("Transit");
                comboBox2.Items.Add("Fiesta");
                comboBox2.Items.Add("Ranger");
                comboBox2.Items.Add("Stormtrak");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            string vites = null;
            if (radioButton1.Checked == true)
            {
                vites = "Manuel";
            }
            if (radioButton2.Checked == true)
            {
                vites = "Otomatik";
            }
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into Tablo1(e_Marka,e_Model,e_Vites,e_Plaka,e_Fiyat) values ('" + comboBox1.SelectedItem + "','" + comboBox2.SelectedItem + "','" + vites + "','" + maskedTextBox2.Text + "','" + bunifuTextbox1.text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("İşleminiz sıraya eklenmiştir. Bu işlem biraz vakit alabilir..!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            verigüncelle();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand verisil = new OleDbCommand("DELETE * FROM Tablo1 where Tablo1.e_Plaka=" + "'" + comboBox3.SelectedItem + "'", con);
            verisil.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("İşleminiz sıraya eklenmiştir. Bu işlem biraz vakit alabilir..!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            con.Close();
            OleDbCommand verisil = new OleDbCommand("DELETE * FROM Tablo1 where Tablo1.e_Fiyat<"+"'"+ sayi+"'",con);
            verigüncelle();
            con.Open();
            verisil.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("İşleminiz sıraya eklenmiştir. Bu işlem biraz vakit alabilir..!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
