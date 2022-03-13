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
    public partial class Report : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-LFTC687;Initial Catalog=Ahmad_Al-Hanafy_Pharmacy;Integrated Security=True");
        public Report()
        {
            InitializeComponent();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Show_report", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@date", SqlDbType.VarChar).Value = dateTimePicker1.Text.Trim();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView3.DataSource = dt;
            con.Close();
        }

        private void Report_Load(object sender, EventArgs e)
        {

        }

        public void load ()
        {
            dataGridView3.DataSource = null;
            dateTimePicker1.Text = null;
        }
    }
}
