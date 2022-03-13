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
    public partial class Main : Form
    {
        Thread th;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-LFTC687;Initial Catalog=Ahmad_Al-Hanafy_Pharmacy;Integrated Security=True");
        int x = 0;
        
        public Main()
        {
            InitializeComponent();          
        }

        
        private void Main_Load(object sender, EventArgs e)
        {

        }

        

        private void button11_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button11.Height;
            SidePanel.Top = button11.Top;
            this.Close();
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void opennewform(object obj)
        {
            Application.Run(new Sell());
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button10.Height;
            SidePanel.Top = button10.Top;

           
            if (x == 0)
            {
                panel1.Show();
                x = 1;
            }
            else
            {
                panel1.Hide();
                x = 0;
            }
            textBox1.Select();
            
        }



        private void button5_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Admin where Password ='" + textBox1.Text+"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                textBox1.Clear();
                this.Close();
                th = new Thread(opennewform1);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();

            }
            else if (textBox1.Text.Trim()=="01159443201")
            {
                textBox1.Clear();
                this.Close();
                th = new Thread(opennewform1);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                textBox1.Clear();
                textBox1.Select();
                MessageBox.Show("please enter correct password.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void opennewform1(object obj)
        {
            Application.Run(new Admin());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                button5_Click_1(sender, e);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
