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
    public partial class Add_Details : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-LFTC687;Initial Catalog=Ahmad_Al-Hanafy_Pharmacy;Integrated Security=True");
        public Add_Details()
        {
            InitializeComponent();
            comboBox2.Items.Add("1");
            comboBox2.Items.Add("2");
            comboBox2.Items.Add("3");
            comboBox2.Items.Add("4");
            comboBox2.Items.Add("5");
            comboBox2.Items.Add("6");
            comboBox2.Items.Add("7");
            comboBox2.Items.Add("8");
            comboBox2.Items.Add("9");
            comboBox2.Text = "1";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            textBox4.Text = textBox4.Text + "%";
            SqlCommand cmd = new SqlCommand("Show_To_Details", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = textBox4.Text.Trim();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            textBox4.Clear();
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Product where Product_Id ='" + textBox4.Text.Trim() + "'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    for (int i = 0; i < int.Parse(comboBox2.Text.Trim()); i++)
                    {
                        SqlCommand cmd = new SqlCommand("Add_details", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@product_id", SqlDbType.VarChar).Value = textBox4.Text.Trim();
                        DateTime t = DateTime.Parse(textBox5.Text);
                        cmd.Parameters.Add("@Exp_date", SqlDbType.VarChar).Value = t;
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Product Added", "Done");
                }
                else
                {
                    MessageBox.Show("Enter Right ID", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Enter right Values", "Error");
            }
            textBox4.Clear();
            textBox5.Clear();
            comboBox2.Text = "1";
            con.Close();
        }

        private void Add_Details_Load(object sender, EventArgs e)
        {

        }

        public void load()
        {
            textBox4.Clear();
            textBox5.Clear();
            comboBox2.Text = "1";
            dataGridView1.DataSource = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = Convert.ToString(dataGridView1.CurrentCell.Value);
        }
    }
}
