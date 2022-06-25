using Npgsql;
using System.Data;

namespace WFTrain1
{
    public partial class FLogin : Form
    {
        HomePage homePage = new HomePage();
        DataTable dt;
        public FLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connstring = @"Server=localhost;Port=5432;Userid=postgres;Password=a1027013;Database=peternakan_ayam";
            NpgsqlConnection koneksiPostgreSQL = new NpgsqlConnection(connstring);

            try
            {
                if (tbEmailLogin.Text == "")
                {
                    MessageBox.Show(" Mohon isi email anda" );
                }
                else if (tbPasswordLogin.Text == "")
                {
                    MessageBox.Show(" Mohon isi password anda ");
                }
                else
                {
                    koneksiPostgreSQL.Open();
                    NpgsqlCommand cmd = new NpgsqlCommand($"select * from login where login_email='"+tbEmailLogin.Text+"' and login_password='"+tbPasswordLogin.Text+"'", koneksiPostgreSQL);
                    NpgsqlDataAdapter adpt = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adpt.Fill(dt);

                    if (dt.Rows[0][2].ToString()==tbEmailLogin.Text && dt.Rows[0][3].ToString() == tbPasswordLogin.Text)
                    {
                        MessageBox.Show(" Anda berhasil login ");
                        koneksiPostgreSQL.Close();
                        homePage.Show();
                    }
                    else
                    {
                        MessageBox.Show(" Email dan Password tidak valid ");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
            
        }

        private void llRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new Register();
            register.Show();
        }
    }
}