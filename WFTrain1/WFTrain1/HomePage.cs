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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnKaryawan_Click(object sender, EventArgs e)
        {
            Karyawan karyawan = new Karyawan();
            karyawan.Show();
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            Transaksi transaksi = new Transaksi();
            transaksi.Show();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock();
            stock.Show();
        }
    }
}
