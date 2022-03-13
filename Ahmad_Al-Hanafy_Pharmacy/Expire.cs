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
    public partial class Expire : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-LFTC687;Initial Catalog=Ahmad_Al-Hanafy_Pharmacy;Integrated Security=True");
       
        public Expire()
        {
            InitializeComponent();
           
        }

        public void fn()
        {
            textBox1.Clear();
            dataGridView2.DataSource = null;
             con.Open();
            SqlCommand cmd = new SqlCommand("Show_Expire", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView2.DataSource = dt;
            con.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = Convert.ToString(dataGridView2.CurrentCell.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Product_Details where Product_Details_Id ='" + textBox1.Text.Trim() + "'", con);
                DataTable dt1 = new DataTable();
                sda.Fill(dt1);
                if (dt1.Rows[0][0].ToString() == "1")
                {
                    SqlCommand cmd1 = new SqlCommand("To_Sold", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@id", SqlDbType.VarChar).Value = textBox1.Text.Trim();
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("Delete_From_Details", con);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@id", SqlDbType.VarChar).Value = textBox1.Text.Trim();
                    cmd2.ExecuteNonQuery();
                    textBox1.Clear();

                    SqlCommand cmd = new SqlCommand("Show_Expire", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    dataGridView2.DataSource = dt;

                    MessageBox.Show("Product Sold", "Process Done");
                }
                else
                {
                    textBox1.Clear();
                    MessageBox.Show("Enter Right ID", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                textBox1.Clear();
                MessageBox.Show("Enter Right Values!", "Error");
            }
            con.Close();
        }
    }
}
