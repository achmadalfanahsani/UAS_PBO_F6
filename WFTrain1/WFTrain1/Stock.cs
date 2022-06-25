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
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
            refreash();
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
                cmd.CommandText = "Select * from stock";
                cmd.CommandType = CommandType.Text;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgStock.DataSource = dt;
                cmd.Dispose();
                koneksiPostgreSQL.Close();

                koneksiPostgreSQL.Open();
                NpgsqlCommand cmd4 = new NpgsqlCommand();
                cmd4.Connection = koneksiPostgreSQL;
                cmd4.CommandText = "Select * from pemilik";
                cmd4.CommandType = CommandType.Text;
                NpgsqlDataAdapter da4 = new NpgsqlDataAdapter(cmd4);
                DataTable dt4 = new DataTable();
                da4.Fill(dt4);
                dgPemilik2.DataSource = dt4;
                cmd.Dispose();
                koneksiPostgreSQL.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Koneksi Gagal " + ex.Message);
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {

            if (tbIDPemilik1.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data id pemilik");
            }
            else if (tbNama1.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data nama");
            }
            else if (tbJenis1.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data jenis");
            }
            else if (tbJumlah1.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data jumlah");
            }
            else
            {
                try
                {
                    string connstring = @"Server=localhost;Port=5432;Userid=postgres;Password=a1027013;Database=peternakan_ayam";
                    NpgsqlConnection koneksiPostgreSQL = new NpgsqlConnection(connstring);
                    {

                        koneksiPostgreSQL.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = koneksiPostgreSQL;
                        cmd.CommandText = "Insert into stock (pemilik_id, stock_name, stock_jenis, stock_kuantitas) values(@id,@nama,@jenis,@jumlah)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@id", Convert.ToInt32(tbIDPemilik1.Text)));
                        cmd.Parameters.Add(new NpgsqlParameter("@nama", tbNama1.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@jenis", tbJenis1.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@jumlah", Convert.ToInt32(tbJumlah1.Text)));
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
            tbIDPemilik1.Text = "";
            tbNama1.Text = "";
            tbJenis1.Text = "";
            tbJumlah1.Text = "";
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
        }

        private void tbnUbah_Click(object sender, EventArgs e)
        {
            if (tbIDStock.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data id stock");
            }
            else if (tbIDPemilik2.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data id pemilik");
            }
            else if (tbNama2.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data nama");
            }
            else if (tbJenis2.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data jenis");
            }
            else if (tbJumlah2.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data jumlah");
            }
            else
            {
                try
                {
                    string connstring = @"Server=localhost;Port=5432;Userid=postgres;Password=a1027013;Database=peternakan_ayam";
                    NpgsqlConnection koneksiPostgreSQL = new NpgsqlConnection(connstring);
                    {

                        koneksiPostgreSQL.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = koneksiPostgreSQL;
                        cmd.CommandText = "update stock set pemilik_id=@idp, stock_name=@nama, stock_jenis=@jenis, stock_kuantitas=@jumlah where stock_id=@id";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@idp", Convert.ToInt32(tbIDPemilik2.Text)));
                        cmd.Parameters.Add(new NpgsqlParameter("@nama", tbNama2.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@jenis", tbJenis2.Text));
                        cmd.Parameters.Add(new NpgsqlParameter("@jumlah", Convert.ToInt32(tbJumlah2.Text)));
                        cmd.Parameters.Add(new NpgsqlParameter("@id", Convert.ToInt32(tbIDStock.Text)));
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        koneksiPostgreSQL.Close();
                        MessageBox.Show("Berhasil mengubah data pada index ke : " + tbIDPemilik2.Text);
                        clearUpadate();
                        refreash();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void clearUpadate()
        {
            tbIDStock.Text = "";
            tbIDPemilik2.Text = "";
            tbNama2.Text = "";
            tbJenis2.Text = "";
            tbJumlah2.Text = "";
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (tbIDStock2.Text == "")
            {
                MessageBox.Show("Mohong lengkapi data index id transaksi");
            }
            else
            {
                try
                {
                    string connstring = @"Server=localhost;Port=5432;Userid=postgres;Password=a1027013;Database=peternakan_ayam";
                    NpgsqlConnection koneksiPostgreSQL = new NpgsqlConnection(connstring);
                    {
                        koneksiPostgreSQL.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = koneksiPostgreSQL;
                        cmd.CommandText = "Delete from stock where stock_id=@id";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@id", Convert.ToInt32(tbIDStock2.Text)));
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        koneksiPostgreSQL.Close();
                        MessageBox.Show("Berhasil menghapus data pada index ke : " + tbIDStock2.Text);
                        tbIDStock2.Text = "";
                        refreash();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
