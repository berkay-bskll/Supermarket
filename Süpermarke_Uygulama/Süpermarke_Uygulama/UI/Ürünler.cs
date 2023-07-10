using Süpermarke_Uygulama.BL;
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
    public partial class Ürünler : Form
    {
        

        public Ürünler()
        {
            InitializeComponent();
        }

        private void Ürünler_Load(object sender, EventArgs e)
        {
            DataSet ds2 = BLogic.UrunGetir("");
            if (ds2 != null)
                dataGridView2.DataSource = ds2.Tables[0];
        }
        private void btnUrunEkle_Click(object sender, EventArgs e)
        {

            FrmUrun frm = new FrmUrun()
            {
                Text = "Ürün Ekle",
                Urun = new Urun() { ID = Guid.NewGuid() },
            };
        tekrar:

            var sonuc = frm.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                bool b = BLogic.UrunEkle(frm.Urun);
                if (b)
                {

                    DataSet ds = BLogic.UrunGetir("");
                    if (ds != null)
                        dataGridView2.DataSource = ds.Tables[0];

                }
                else
                    goto tekrar;
            }

        }

        private void btnUrunBul_Click(object sender, EventArgs e)
        {
            DataSet ds = BLogic.UrunGetir("");
            if (ds != null)
                dataGridView2.DataSource = ds.Tables[0];
        }
         public Urun Urun { get; set; }
        private void btnOk_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView2.SelectedRows[0];

            Urun = new Urun()
            {
                ID = Guid.Parse(row.Cells[0].Value.ToString()),
                Ad = row.Cells[1].Value.ToString(),
                Kategori = row.Cells[2].Value.ToString(),
                Fiyat =double.Parse (row.Cells[3].Value.ToString()),
                Stok= double.Parse(row.Cells[4].Value.ToString()),
                Birim = row.Cells[5].Value.ToString(),
                Detay = row.Cells[6].Value.ToString()

            };
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
