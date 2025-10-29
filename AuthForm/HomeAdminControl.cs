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
    public partial class HomeAdminControl : UserControl
    {
        public HomeAdminControl()
        {
            InitializeComponent();
        }

        private void pictureCenter()
        {
            int y = (this.Height - pictureBox1.Height) / 2;
            int x = (this.Width - pictureBox1.Width) / 2;

            pictureBox1.Location = new Point(x, y);
        }

        private void HomeAdminControl_Resize(object sender, EventArgs e)
        {
            pictureCenter();
        }

        private void HomeAdminControl_Load(object sender, EventArgs e)
        {

        }
    }
}
