using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFTrain1
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string connstring = @"Server=localhost;Port=5432;Userid=postgres;Password=a1027013;Database=peternakan_ayam";
                NpgsqlConnection koneksiPostgreSQL = new NpgsqlConnection(connstring);
                {
                    koneksiPostgreSQL.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand();
                    cmd.Connection = koneksiPostgreSQL;
                    cmd.CommandText = "Insert into pemilik(nama_pemilik) values(@Fname)";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new NpgsqlParameter("@Fname", tbFullNameRegister.Text));
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    koneksiPostgreSQL.Close();

                    koneksiPostgreSQL.Open();
                    NpgsqlCommand cmd2 = new NpgsqlCommand();
                    cmd2.Connection = koneksiPostgreSQL;
                    cmd2.CommandText = "Insert into login(login_email, login_password) values(@login_email, @login_password)";
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Parameters.Add(new NpgsqlParameter("@login_email", tbEmailRegister.Text));
                    cmd2.Parameters.Add(new NpgsqlParameter("@login_password", tbPasswordRegister.Text));
                    cmd2.ExecuteNonQuery();
                    cmd2.Dispose();
                    koneksiPostgreSQL.Close();

                    MessageBox.Show(" Data berhasil ditambahkan ");
                    HomePage hp = new HomePage();
                    hp.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
