using SanatOkuluCalisma.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanatOkuluCalisma
{
    public partial class Form1 : Form
    {
        SanatOkuluContext db = new SanatOkuluContext();
        public Form1()
        {
            InitializeComponent();
            SanatcilariYukle();
            EserleriListele();
        }

        private void SanatcilariYukle()
        {
            cboSanatci.DataSource = db.Sanatcilar.OrderBy(x => x.Ad).ToList();
            cboSanatci.ValueMember = "Id";
            cboSanatci.DisplayMember = "Ad";
        }

        private void pboYeniSanatci_Click(object sender, EventArgs e)
        {
            var frm = new SanatciForm(db);
            if (DialogResult.OK == frm.ShowDialog())
            {
                SanatcilariYukle();
            }

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

        }

        private void EserleriListele()
        {
            lvwEserler.Items.Clear();
            foreach (var item in db.Eserler.OrderBy(x=> x.Yil))
            {
                ListViewItem lvi = new ListViewItem(item.Ad);
                lvi.SubItems.Add(item.Sanatci.Ad);
                lvi.SubItems.Add(item.Yil.ToString());
                lvwEserler.Items.Add(lvi);
            }

            
        }

        private void FormuResetle()
        {
            txtAd.Focus();
            txtAd.Clear();
            cboSanatci.SelectedIndex = -1;
            mtbYil.Clear();
        }
    }
}
