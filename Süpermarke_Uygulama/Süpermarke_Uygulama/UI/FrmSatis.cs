using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Süpermarke_Uygulama.UI
{
    public partial class FrmSatis : Form
    {
        public FrmSatis()
        {
            InitializeComponent();
        }

       public Musteri Musteri { get; set; }
       public Urun Urun { get; set; }
       public Satis Satis { get; set; }
        public object Müşteri { get; private set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(nmFiyat.Value==0)
            {
                errorProvider1.SetError(nmFiyat, "Lütfen fiyat giriniz!");
                nmFiyat.Focus();
                return;
            }
            else
            {
                errorProvider1.SetError(nmFiyat, "");
            }
            Satis.Tarih = dtTarih.Value;
            Satis.Fiyat =(double) nmFiyat.Value;
            Satis.UrunID = Urun.ID;
            Satis.MusteriID = Musteri.ID;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FrmSatis_Load(object sender, EventArgs e)
        {
           txtId.Text = Satis.ID.ToString();
        }

        private void btnMüşteriSeç_Click(object sender, EventArgs e)
        {
            Müşteriler frm = new Müşteriler();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Musteri = frm.Musteri;
                txtMusteri.Text = Musteri.ToString();

            }
        }

        private void btnÜrünSeç_Click(object sender, EventArgs e)
        {
            Ürünler frm = new Ürünler();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Urun= frm.Urun;
                txtUrun.Text = Urun.ToString();

            }
        }

        
    }
}
