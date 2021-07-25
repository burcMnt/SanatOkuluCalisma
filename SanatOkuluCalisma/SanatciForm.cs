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
    public partial class SanatciForm : Form
    {
        public event EventHandler SanatcilarDegisti;
        private readonly SanatOkuluContext db;
        public SanatciForm(SanatOkuluContext db)
        {
            this.db = db;
            InitializeComponent();
            Listele();
        }
        private void Listele()
        {
            lstSanatcilar.DataSource = db.Sanatcilar.OrderBy(x => x.Ad).ToList();
            lstSanatcilar.DisplayMember = "Ad";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.Trim();
            if (ad == "")
            {
                MessageBox.Show("Lütfen bir sanatçı adı belirtiniz..");
                return;
            }

            if (duzenlenen == null)
            {
                db.Sanatcilar.Add(new Sanatci() { Ad = ad });

            }
            else
            {
                duzenlenen.Ad = ad;
            }
            db.SaveChanges();
            Listele();
            SanatcilarDegistiginde(EventArgs.Empty);
            FormuResetle();
        }

        protected virtual void SanatcilarDegistiginde(EventArgs args)
        {
            if (SanatcilarDegisti != null)
            {
                SanatcilarDegisti(this, args);
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSİl_Click(object sender, EventArgs e)
        {
            if (lstSanatcilar.SelectedIndex == -1) return;

            Sanatci sanatci = (Sanatci)lstSanatcilar.SelectedItem;
            db.Sanatcilar.Remove(sanatci);
            db.SaveChanges();
            Listele();
            SanatcilarDegistiginde(EventArgs.Empty);

        }
        Sanatci duzenlenen;
        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (lstSanatcilar.SelectedIndex == -1) return;
            duzenlenen = (Sanatci)lstSanatcilar.SelectedItem;
            txtAd.Text = duzenlenen.Ad;
            btnEkle.Text = "KAYDET";
            btnIptal.Show();
            lstSanatcilar.Enabled = false;
            btnDuzenle.Enabled = false;
            btnSİl.Enabled = false;


        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            FormuResetle();
        }

        private void FormuResetle()
        {
            txtAd.Clear();
            duzenlenen = null;
            btnEkle.Text = "EKLE";
            btnIptal.Hide();
            lstSanatcilar.Enabled = btnDuzenle.Enabled = btnSİl.Enabled = true;
        }
    }
}
