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
    public partial class Add_Product : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-LFTC687;Initial Catalog=Ahmad_Al-Hanafy_Pharmacy;Integrated Security=True");
        public Add_Product()
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

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("Add_Product", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@product_name", SqlDbType.VarChar).Value = textBox1.Text.Trim();
                cmd.Parameters.Add("@strips_num", SqlDbType.VarChar).Value = textBox2.Text.Trim();
                cmd.Parameters.Add("@price", SqlDbType.VarChar).Value = textBox3.Text.Trim();
                cmd.Parameters.Add("@category_name", SqlDbType.VarChar).Value = comboBox1.Text.Trim();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Added", "Process Done");
            }
            catch (Exception)
            {
                MessageBox.Show("Enter Right Values!", "Error");
            }
            con.Close();
        }

        private void Add_Product_Load(object sender, EventArgs e)
        {

        }
        public void load ()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = null;
        }
    }
}
