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
    public partial class Admin : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-LFTC687;Initial Catalog=Ahmad_Al-Hanafy_Pharmacy;Integrated Security=True");
        Thread th;
        public Admin()
        {
            InitializeComponent();
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button12.Height;
            SidePanel.Top = button12.Top;
            add_Product1.load();
            add_Product1.Show();
            add_Details1.Hide();
            expire1.Hide();
            report1.Hide();
            nawa2s1.Hide();
            change_Price1.Hide();
            setting1.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button11.Height;
            SidePanel.Top = button11.Top;
            add_Details1.load();
            add_Details1.Show();
            add_Product1.Hide();
            expire1.Hide();
            report1.Hide();
            nawa2s1.Hide();
            change_Price1.Hide();
            setting1.Hide();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            SidePanel.Height = button10.Height;
            SidePanel.Top = button10.Top;
            expire1.Show();
            expire1.fn();
            add_Product1.Hide();
            add_Details1.Hide();
            report1.Hide();
            nawa2s1.Hide();
            change_Price1.Hide();
            setting1.Hide();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            SidePanel.Height = button9.Height;
            SidePanel.Top = button9.Top;
            report1.load();
            report1.Show();
            add_Product1.Hide();
            add_Details1.Hide();
            expire1.Hide();
            nawa2s1.Hide();
            change_Price1.Hide();
            setting1.Hide();
        }

        private void add_Product1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void add_Details1_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button8.Height;
            SidePanel.Top = button8.Top;
            nawa2s1.load();
            nawa2s1.Show();
            add_Product1.Hide();
            add_Details1.Hide();
            expire1.Hide();
            report1.Hide();
            change_Price1.Hide();
            setting1.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button6.Height;
            SidePanel.Top = button6.Top;
            change_Price1.load();
            change_Price1.Show();
            add_Product1.Hide();
            add_Details1.Hide();
            expire1.Hide();
            report1.Hide();
            nawa2s1.Hide();
            setting1.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button7.Height;
            SidePanel.Top = button7.Top;
            setting1.Show();
            add_Product1.Hide();
            add_Details1.Hide();
            expire1.Hide();
            report1.Hide();
            nawa2s1.Hide();
            change_Price1.Hide();
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
    }
}
