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
    public partial class Setting : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-LFTC687;Initial Catalog=Ahmad_Al-Hanafy_Pharmacy;Integrated Security=True");
        public Setting()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            change_Password1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            change_Password1.Hide();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("truncate table New", con);
            sda.SelectCommand.ExecuteNonQuery();

            SqlDataAdapter sda1 = new SqlDataAdapter
                ("insert into New select Product_Id,Product_Name,Price,Strips_Num,Category_Name,Expire_Date from Product_Details", con);
            sda1.SelectCommand.ExecuteNonQuery();

            SqlDataAdapter sda2 = new SqlDataAdapter("truncate table Product_Details", con);
            sda2.SelectCommand.ExecuteNonQuery();

            SqlDataAdapter sda3 = new SqlDataAdapter
                ("insert into Product_Details select Product_Id,Product_Name,Price,Strips_Num,Category_Name,Expire_Date from  New", con);
            sda3.SelectCommand.ExecuteNonQuery();

            SqlDataAdapter sda4 = new SqlDataAdapter("truncate table New", con);
            sda4.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("RESETTING IDs DONE", "PROCESS DONE", MessageBoxButtons.OK);
        }
    }
}
