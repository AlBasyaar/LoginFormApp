using AuthForm.Repositories;
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
    public partial class SiswaAdminControl : UserControl
    {
        public SiswaAdminControl()
        {
            InitializeComponent();
            ReadUserData();

            this.tableUser.Columns["Username"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.tableUser.Columns["Password"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.tableUser.Columns["Username"].DefaultCellStyle.ForeColor = Color.DodgerBlue;
            this.tableUser.Columns["Username"].DefaultCellStyle.Font = new Font(this.tableUser.Font, FontStyle.Bold);
            this.tableUser.Columns["Username"].ReadOnly = true;
            this.tableUser.Columns["Password"].ReadOnly = true;
            this.tableUser.Columns["Edit"].DisplayIndex = tableUser.Columns.Count - 1;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ReadUserData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Username");
            dt.Columns.Add("Password");

            var repo = new UserRepository();
            var userList = repo.GetUserList();

            foreach (var user in userList)
            {
                var row = dt.NewRow();
                row["Id"] = user.id;
                row["Username"] = user.username;
                row["Password"] = user.password;

                dt.Rows.Add(row);

                this.tableUser.DataSource = dt;
            }
        }

        private void tableUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tableUser.Columns[e.ColumnIndex].Name == "Edit" && e.RowIndex >= 0)
            {

            }
        }

        private void tableUser_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
