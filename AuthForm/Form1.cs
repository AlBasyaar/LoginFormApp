using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AuthForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Youtube;Integrated Security=True");

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            string rawPassword = txt_password.Text;
            string storedHash = null;

            try
            {
                string query = "SELECT password FROM Authform WHERE username = @Username";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Username", username);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        storedHash = result.ToString();
                    }
                }

                if (!string.IsNullOrEmpty(storedHash))
                {
                    if (BCrypt.Net.BCrypt.Verify(rawPassword, storedHash))
                    {
                        MessageBox.Show("Login berhasil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AdminDashboard menu = new AdminDashboard(username);
                        menu.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_username.Clear();
                        txt_password.Clear();
                        txt_username.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_username.Clear();
                    txt_password.Clear();
                    txt_username.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan koneksi/database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_username.Clear();
                txt_password.Clear();
                txt_username.Focus();
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_password.Clear();
            txt_username.Focus();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            register p = new register();
            p.Show();
            this.Hide();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txt_password.UseSystemPasswordChar == true)
            {
                txt_password.UseSystemPasswordChar = false;
                pictureBox1.Image = Properties.Resources.icon_hide;
            }
            else
            {
                txt_password.UseSystemPasswordChar = true;
                pictureBox1.Image = Properties.Resources.icon_show;
            }

        }
    }
}
