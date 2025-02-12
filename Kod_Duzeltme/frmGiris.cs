using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kod_Duzeltme
{
    public partial class frmGiris : Form
    {
        public frmGiris()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Reposito = cmbRepoAdı.Text;
            if (cmbRepoAdı.Text == "talhadrz.github.io")
            {
                frm.DosyaAdı = "talhadrz";
                frm.DosyaKonumu = $"C:\\Users\\LENOVO\\Desktop\\Github Repositories\\talhadrz";
            }
            else if (cmbRepoAdı.Text == "projeler")
            {
                frm.DosyaKonumu = $"C:\\Users\\LENOVO\\Desktop\\Github Repositories\\projeler";
                frm.DosyaAdı = "projeler";
            }

            frm.GithubAdı = cmbGithubAd.Text;
            frm.Token = txtToken.Text;
            if (frm.Token != null)
            {
                frm.Text = cmbRepoAdı.Text;
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen Repositorie Seç");
            }
        }
    }
}
