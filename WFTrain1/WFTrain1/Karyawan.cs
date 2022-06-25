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
    public partial class Karyawan : Form
    {
        private void Karyawan_Load(object sender, EventArgs e)
        {

        }
        public Karyawan()
        {
            InitializeComponent();
            refreash();
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (tbIDPemilik.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data id pemilik");
            }
            else if (tbNama.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data nama");
            }
            else if (tbUmur.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data umur");
            }
            else if (tbAlamat.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data alamat");
            }
            else if (tbNoHp.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data no handphone");
            }
            else if (tbGaji.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data gaji");
            }
            else
            {
                try
                {
                    /* Insertion After Validations*/
                    string connstring = @"Server=localhost;Port=5432;Userid=postgres;Password=a1027013;Database=peternakan_ayam";
                    NpgsqlConnection koneksiPostgreSQL = new NpgsqlConnection(connstring);
                    {
                        koneksiPostgreSQL.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = koneksiPostgreSQL;
                        cmd.CommandText = "Insert into karyawan(pemilik_id, karyawan_nama, karyawan_umur, karyawan_alamat, karyawan_no_hp, karyawan_gaji) values(@id,@nama,@umur,@alamat, @no_hp, @gaji)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@id", Convert.ToInt32(tbIDPemilik.Text)));
                        cmd.Parameters.Add(new NpgsqlParameter("@nama", tbNama.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("umur", tbUmur.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@alamat", tbAlamat.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@no_hp", tbNoHp.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@gaji", Convert.ToInt32(tbGaji.Text)));
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        koneksiPostgreSQL.Close();
                        MessageBox.Show("Berhasil menambahkan data baru");
                        clearInsert();
                        refreash();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void clearInsert()
        {
            tbIDPemilik.Text = "";
            tbNama.Text = "";
            tbUmur.Text = "";
            tbAlamat.Text = "";
            tbNoHp.Text = "";
            tbGaji.Text = "";
        }

        private void refreash()
        {
            string connstring = @"Server=localhost;Port=5432;Userid=postgres;Password=a1027013;Database=peternakan_ayam";
            NpgsqlConnection koneksiPostgreSQL = new NpgsqlConnection(connstring);
            try
            {
                koneksiPostgreSQL.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = koneksiPostgreSQL;
                cmd.CommandText = "Select * from karyawan";
                cmd.CommandType = CommandType.Text;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgKaryawan.DataSource = dt;
                cmd.Dispose();
                koneksiPostgreSQL.Close();

                koneksiPostgreSQL.Open();
                NpgsqlCommand cmd2 = new NpgsqlCommand();
                cmd2.Connection = koneksiPostgreSQL;
                cmd2.CommandText = "SELECT  SUM(karyawan_gaji) as karyawan_gaji FROM karyawan";
                cmd2.CommandType = CommandType.Text;
                NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                da2.Fill(dt);
                koneksiPostgreSQL.Close();

                koneksiPostgreSQL.Open();
                NpgsqlCommand cmd3 = new NpgsqlCommand();
                cmd3.Connection = koneksiPostgreSQL;
                cmd3.CommandText = "Select * from pemilik";
                cmd3.CommandType = CommandType.Text;
                NpgsqlDataAdapter da3 = new NpgsqlDataAdapter(cmd3);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                dgPemilik.DataSource = dt3;
                cmd.Dispose();
                koneksiPostgreSQL.Close();
            }

            catch (NpgsqlException ex)
            {
                MessageBox.Show("Koneksi Gagal " + ex.Message);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (tbIDKaryawan.Text == "")
            {
                MessageBox.Show("Mohong lengkapi data index id karyawan");
            }
            else
            {
                try /* Deletion After Validations*/
                {
                    string connstring = @"Server=localhost;Port=5432;Userid=postgres;Password=a1027013;Database=peternakan_ayam";
                    NpgsqlConnection koneksiPostgreSQL = new NpgsqlConnection(connstring);
                    {
                        koneksiPostgreSQL.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = koneksiPostgreSQL;
                        cmd.CommandText = "Delete from karyawan where karyawan_id=@id";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@id", Convert.ToInt32(tbIDKaryawan.Text)));
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        koneksiPostgreSQL.Close();
                        MessageBox.Show("Berhasil menghapus data pada index ke : " + tbIDKaryawan.Text);
                        tbIDKaryawan.Text = "";
                        refreash();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnUbah_Click(object sender, EventArgs e)
        {
            if (tbIDKaryawan1.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data id karyawan");
            }
            else if (tbIDPemilik1.Text == "")
            {
                MessageBox.Show("Mohon lengkapi id pemilik");
            }
            else if (tbNama2.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data nama");
            }
            else if (tbUmur2.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data umur");
            }
            else if (tbAlamat2.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data alamat");
            }
            else if (tbNoHp2.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data no handphone");
            }
            else if (tbGaji2.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data gaji");
            }
            else
            {
                try /* Updation After Validations*/
                {
                    string connstring = @"Server=localhost;Port=5432;Userid=postgres;Password=a1027013;Database=peternakan_ayam";
                    NpgsqlConnection koneksiPostgreSQL = new NpgsqlConnection(connstring);
                    {
                        koneksiPostgreSQL.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = koneksiPostgreSQL;
                        cmd.CommandText = "UPDATE karyawan SET pemilik_id=@idp, karyawan_nama=@nama, karyawan_umur=@umur, karyawan_alamat=@alamat, karyawan_no_hp=@no_hp, karyawan_gaji=@gaji WHERE karyawan_id=@id;";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@idp", Convert.ToInt32(tbIDPemilik1.Text)));
                        cmd.Parameters.Add(new NpgsqlParameter("@nama", tbNama2.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@umur", tbUmur2.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@alamat", tbAlamat2.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@no_hp", tbNoHp2.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@gaji", Convert.ToInt32(tbGaji2.Text)));
                        cmd.Parameters.Add(new NpgsqlParameter("@id", Convert.ToInt32(tbIDKaryawan1.Text)));
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        koneksiPostgreSQL.Close();
                        MessageBox.Show("Berhasil mengubah data pada index ke : " + tbIDKaryawan1.Text);
                        clear1();
                        refreash();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void clear1()
        {
            tbNama2.Text = "";
            tbUmur2.Text = "";
            tbIDPemilik1.Text="";
            tbAlamat2.Text = "";
            tbNoHp2.Text = "";
            tbGaji2.Text = "";
            tbIDKaryawan1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
        }
    }
}
