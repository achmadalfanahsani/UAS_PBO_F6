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
    public partial class Transaksi : Form
    {
        public Transaksi()
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
                cmd.CommandText = "Select * from transaksi";
                cmd.CommandType = CommandType.Text;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgTransaksi.DataSource = dt;
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
                dgPemiliki1.DataSource = dt4;
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
            string tipeJenis;

            if (rbPemasukan1.Checked)
            {
                tipeJenis = "pemasukan";
            }
            else
            {
                tipeJenis = "pengeluaran";
            }

            if (tbIDPemilik1.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data id pemilik");
            }
            else if (tbKeterangan1.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data keterangan");
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
                        cmd.CommandText = "Insert into transaksi (pemilik_id, trs_keterangan, trs_pemasukan, trs_pengeluaran) values(@id,@keterangan,@pemasukan,@pengeluaran)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@id", Convert.ToInt32(tbIDPemilik1.Text)));
                        cmd.Parameters.Add(new NpgsqlParameter("@keterangan", tbKeterangan1.Text));

                        if (tipeJenis == "pemasukan")
                        {
                            cmd.Parameters.Add(new NpgsqlParameter("@pemasukan", Convert.ToInt32(tbJumlah1.Text)));
                            cmd.Parameters.Add(new NpgsqlParameter("@pengeluaran", Convert.ToInt32("0")));
                        }
                        else
                        {
                            cmd.Parameters.Add(new NpgsqlParameter("@pemasukan", Convert.ToInt32("0")));
                            cmd.Parameters.Add(new NpgsqlParameter("@pengeluaran", Convert.ToInt32(tbJumlah1.Text)));
                        }
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
            tbKeterangan1.Text = "";
            tbJumlah1.Text = "";
        }

        private void tbnUbah_Click(object sender, EventArgs e)
        {
            string tipeJenis;

            if (rbPemasukan2.Checked)
            {
                tipeJenis = "pemasukan";
            }
            else
            {
                tipeJenis = "pengeluaran";
            }

            if (tbIDPemilik2.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data id pemilik");
            }
            else if (tbKeterangan2.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data keterangan");
            }
            else if (tbJumlah2.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data jumlah");
            }
            else if (tbIndex2.Text == "")
            {
                MessageBox.Show("Mohon lengkapi data index pilihan");
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
                        cmd.CommandText = "update transaksi set pemilik_id=@idp, trs_keterangan=@keterangan, trs_pemasukan=@pemasukan, trs_pengeluaran=@pengeluaran where trs_id=@id";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@idp", Convert.ToInt32(tbIDPemilik2.Text)));
                        cmd.Parameters.Add(new NpgsqlParameter("@keterangan", tbKeterangan2.Text));
                        if (tipeJenis == "pemasukan")
                        {
                            cmd.Parameters.Add(new NpgsqlParameter("@pemasukan", Convert.ToInt32(tbJumlah2.Text)));
                            cmd.Parameters.Add(new NpgsqlParameter("@pengeluaran", Convert.ToInt32("0")));
                        }
                        else
                        {
                            cmd.Parameters.Add(new NpgsqlParameter("@pemasukan", Convert.ToInt32("0")));
                            cmd.Parameters.Add(new NpgsqlParameter("@pengeluaran", Convert.ToInt32(tbJumlah2.Text)));
                        }
                        cmd.Parameters.Add(new NpgsqlParameter("@id", Convert.ToInt32(tbIndex2.Text)));
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
            tbIDPemilik2.Text = "";
            tbKeterangan2.Text = "";
            tbJumlah2.Text = "";
            tbIndex2.Text = "";
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (tbIndex3.Text == "")
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
                        cmd.CommandText = "Delete from transaksi where trs_id=@id";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Add(new NpgsqlParameter("@id", Convert.ToInt32(tbIndex3.Text)));
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        koneksiPostgreSQL.Close();
                        MessageBox.Show("Berhasil menghapus data pada index ke : " + tbIndex3.Text);
                        tbIndex3.Text = "";
                        refreash();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            HomePage homePa= new HomePage();
            homePa.Show();
        }

        private void btnPengeluaran_Click(object sender, EventArgs e)
        {
            string connstring = @"Server=localhost;Port=5432;Userid=postgres;Password=a1027013;Database=peternakan_ayam";
            NpgsqlConnection koneksiPostgreSQL = new NpgsqlConnection(connstring);
            try
            {
                koneksiPostgreSQL.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = koneksiPostgreSQL;
                cmd.CommandText = "Select * from transaksi";
                cmd.CommandType = CommandType.Text;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgTransaksi.DataSource = dt;
                cmd.Dispose();
                koneksiPostgreSQL.Close();

                koneksiPostgreSQL.Open();
                NpgsqlCommand cmd2 = new NpgsqlCommand();
                cmd2.Connection = koneksiPostgreSQL;
                cmd2.CommandText = "SELECT  SUM(trs_pengeluaran) as trs_pengeluaran FROM transaksi";
                cmd2.CommandType = CommandType.Text;
                NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                da2.Fill(dt);
                koneksiPostgreSQL.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Koneksi Gagal " + ex.Message);
            }
        }

        private void btnPemasukan_Click(object sender, EventArgs e)
        {
            string connstring = @"Server=localhost;Port=5432;Userid=postgres;Password=a1027013;Database=peternakan_ayam";
            NpgsqlConnection koneksiPostgreSQL = new NpgsqlConnection(connstring);
            try
            {
                koneksiPostgreSQL.Open();
                NpgsqlCommand cmd = new NpgsqlCommand();
                cmd.Connection = koneksiPostgreSQL;
                cmd.CommandText = "Select * from transaksi";
                cmd.CommandType = CommandType.Text;
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgTransaksi.DataSource = dt;
                cmd.Dispose();
                koneksiPostgreSQL.Close();

                koneksiPostgreSQL.Open();
                NpgsqlCommand cmd2 = new NpgsqlCommand();
                cmd2.Connection = koneksiPostgreSQL;
                cmd2.CommandText = "SELECT  SUM(trs_pemasukan) as trs_pemasukan FROM transaksi";
                cmd2.CommandType = CommandType.Text;
                NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                da2.Fill(dt);
                koneksiPostgreSQL.Close();
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show("Koneksi Gagal " + ex.Message);
            }
        }
    }
}
