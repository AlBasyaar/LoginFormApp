using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using BCrypt.Net;

namespace AuthForm
{
    public partial class register : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Youtube;Integrated Security=True");

        public register()
        {
            InitializeComponent();
        }

        private void register_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 p = new Form1();
            p.Show();
            this.Hide();
        }

        private string getUsername(string username)
        {
            if (conn.State == ConnectionState.Open) conn.Close();

            string p = "SELECT username FROM Authform WHERE username=@username";
            string Authform = null;

            using (SqlCommand cmd = new SqlCommand(p, conn))
            {
                cmd.Parameters.AddWithValue("username", username);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        Authform = result.ToString();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database Error:" + ex.Message);
                }
                finally
                {
                    if (conn.State == ConnectionState.Open) conn.Close();
                }
            }
            return Authform;
        }

        private void button_register_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text.Trim();
            string password = txt_password.Text;
            string confirmPassword = txt_confirmpassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Semua kolom harus diisi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Kata sandi dan konfirmasi kata sandi tidak cocok!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (getUsername(username) != null)
            {
                MessageBox.Show("Username '" + username + "' sudah digunakan. Pilih username lain.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, 13);

            try
            {
                string query = "INSERT INTO Authform (username, password) VALUES (@Username, @Password)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);

                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Registrasi Berhasil! Anda sekarang dapat Login.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1 loginForm = new Form1();
                        loginForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Registrasi gagal. Coba lagi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                MessageBox.Show("Username '" + username + "' sudah digunakan. Pilih username lain.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txt_confirmpassword.Clear();
            txt_username.Focus();
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
                pictureBox1.Image= Properties.Resources.icon_show;
            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txt_confirmpassword.UseSystemPasswordChar == true)
            {
                txt_confirmpassword.UseSystemPasswordChar = false;
                pictureBox2.Image = Properties.Resources.icon_hide;
            }
            else
            {
                txt_confirmpassword.UseSystemPasswordChar = true;
                pictureBox2.Image = Properties.Resources.icon_show;
            }
        }
    }
}