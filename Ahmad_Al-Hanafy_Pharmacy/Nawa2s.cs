using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ahmad_Al_Hanafy_Pharmacy
{
    public partial class Nawa2s : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-LFTC687;Initial Catalog=Ahmad_Al-Hanafy_Pharmacy;Integrated Security=True");
        public Nawa2s()
        {
            InitializeComponent();
            comboBox1.Items.Add("Tablets");
            comboBox1.Items.Add("Syrp");
            comboBox1.Items.Add("Vial");
            comboBox1.Items.Add("Cream");
            comboBox1.Items.Add("Orientment");
            comboBox1.Items.Add("Gel");
            comboBox1.Items.Add("Supp");
            comboBox1.Items.Add("Inf Supp");
            comboBox1.Items.Add("Eff");
            comboBox1.Items.Add("Sachets");
            comboBox1.Items.Add("Drops");
            comboBox1.Items.Add("Eye Drops");
            comboBox1.Items.Add("Ear Drops");
            comboBox1.Items.Add("Nasal Drops");
            comboBox1.Items.Add("Nasal Spray");
            comboBox1.Items.Add("Sol");
            comboBox1.Items.Add("Vaginal Douch");
            comboBox1.Items.Add("Vaginal Supp");
            comboBox1.Items.Add("Cosmetics");
            comboBox1.Items.Add("Multible");
            comboBox1.Items.Add(" ");
        }

        private void Nawa2s_Load(object sender, EventArgs e)
        {

        }

        public void load()
        {
            comboBox1.Text = null;
            dataGridView1.DataSource = null;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("nawa2s", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = comboBox1.Text.Trim();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
