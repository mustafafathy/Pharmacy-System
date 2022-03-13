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
    public partial class Change_Password : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-LFTC687;Initial Catalog=Ahmad_Al-Hanafy_Pharmacy;Integrated Security=True");
        public Change_Password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("change_Password", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = textBox1.Text.Trim();
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Clear();
            MessageBox.Show("Password Changed", "Process Done", MessageBoxButtons.OK);
        }
    }
}
