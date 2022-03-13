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
using System.Threading;

namespace Ahmad_Al_Hanafy_Pharmacy
{
    public partial class Sell : Form
    {
        
        string s,s1;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-LFTC687;Initial Catalog=Ahmad_Al-Hanafy_Pharmacy;Integrated Security=True");
        Thread th;
        
        public Sell()
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

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                textBox1.Text = textBox1.Text + '%';
                s = textBox1.Text;
                s1 = comboBox1.Text;
                SqlCommand cmd = new SqlCommand("Show_To_Sell", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = textBox1.Text.Trim();
                cmd.Parameters.Add("@Cat", SqlDbType.VarChar).Value = comboBox1.Text.Trim();
                textBox1.Clear();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = dt;
            }
            catch (Exception)        
            {
                MessageBox.Show("Enter Product Name!");
            }
            
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
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

                    SqlCommand cmd = new SqlCommand("Show_To_Sell", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = s.Trim();
                    cmd.Parameters.Add("@Cat", SqlDbType.VarChar).Value = s1.Trim();

                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    dataGridView1.DataSource = dt;

                    MessageBox.Show("Product Sold", "Process Done");
                }
                else
                {
                    textBox1.Clear();
                    MessageBox.Show("Enter Right ID", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Enter right Values", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBox1.Clear();            
            }
            con.Close();
    
                
                

                
           
        }

        private void Sell_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(opennewform1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void opennewform1(object obj)
        {
            Application.Run(new Main());
        }

        private void button4_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = Convert.ToString(dataGridView1.CurrentCell.Value);      
        }
    }
}
