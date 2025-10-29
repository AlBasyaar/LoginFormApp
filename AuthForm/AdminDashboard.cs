using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuthForm
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard(string username)
        {
            InitializeComponent();
            txt_User.Text = username;

            SwitchControl(new HomeAdminControl());
        }

        public void SwitchControl(UserControl newControl)
        {
            pnlContent.Controls.Clear();
            newControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(newControl);
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void button_logout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 p = new Form1();
            p.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_home_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SwitchControl(new HomeAdminControl());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SwitchControl(new SiswaAdminControl()); 
        }
    }
}
