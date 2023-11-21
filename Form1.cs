using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace andmebaas
{
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\AppData\Tooded_DB.mdf;Integrated Security=True");
        SqlDataAdapter adapter_toode, adapter_kategooria;
        SqlCommand command;
        public Form1()
        {
            InitializeComponent();
            NaitaAndmed();
        }
        //public void Lisa_Kategooriat(object sender, )
        //{

        //}
        public void NaitaKategooriad()
        {
            connect.Open();
            adapter_kategooria = new SqlDataAdapter("SELECT Kategooria_nimetus FROM KategooriaTabel", connect);
            DataTable dt_kat = new DataTable();
            adapter_kategooria.Fill(dt_kat);
            foreach(DataRow item in dt_kat.Rows)
            {
                comboBox2.Items.Add(item["Kategooria_nimetus"]);
            }
            connect.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            command = new SqlCommand("INSERT INTO KategooriaTabel (Kategooria_nimetus) VALUES (@kat) ", connect);
            connect.Open();
            command.Parameters.AddWithValue("@kat", comboBox2.Text);
            command.ExecuteNonQuery();
            connect.Close();
            comboBox2.Items.Clear();
            NaitaKategooriad();
        }

        public void NaitaAndmed()
        {
            connect.Open();
            DataTable dt_toode= new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT * FROM Tooded", connect);
            adapter_toode.Fill(dt_toode);
            dataGridView1.DataSource = dt_toode;
            connect.Close();
        }
    }
}
