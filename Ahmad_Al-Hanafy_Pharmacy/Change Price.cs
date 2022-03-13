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
    public partial class Change_Price : UserControl
    {
        string name;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-LFTC687;Initial Catalog=Ahmad_Al-Hanafy_Pharmacy;Integrated Security=True");
        public Change_Price()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text.Trim() + "%";
            textBox1.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand("Search_to_change", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("Change_Price", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = textBox2.Text.Trim();
                cmd.Parameters.Add("@Price", SqlDbType.VarChar).Value = textBox3.Text.Trim();
                cmd.ExecuteNonQuery();
                SqlCommand cmd1 = new SqlCommand("Search_to_change", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                DataTable dt = new DataTable();
                dt.Load(cmd1.ExecuteReader());
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Right Values!", "Error");
            }
            con.Close();
            textBox2.Clear();
            textBox3.Clear();
        }

        public void load()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dataGridView1.DataSource = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = Convert.ToString(dataGridView1.CurrentCell.Value);
        }
    }
}
