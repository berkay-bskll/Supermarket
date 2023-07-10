using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Süpermarke_Uygulama.BL;
using Süpermarke_Uygulama.UI;
namespace Süpermarke_Uygulama
{
    public partial class Ana_Form : Form
    {
        public Ana_Form()
        {
            InitializeComponent();
        }

        Müşteriler mf = new Müşteriler();
        Ürünler uf = new Ürünler();
      
        private void btnMüşteriler_Click(object sender, EventArgs e)
        {
            new Müşteriler().ShowDialog();
        }

        private void btnÜrünler_Click(object sender, EventArgs e)
        {
            uf.ShowDialog();

        }

        private void btnSatış_Click(object sender, EventArgs e)
        {
            FrmSatis frm = new FrmSatis()
            {
                Text = "Satış Yap",
                Satis = new Satis()
                {
                    ID = Guid.NewGuid()
                }
            };
           
            //tekrar:

                var sonuc = frm.ShowDialog();
                if (sonuc == DialogResult.OK)
                {
                    bool b = BLogic.SatisEkle(frm.Satis);
                    //if (b)
                    //{

                    //    DataSet ds = BLogic.MüşteriGetir("");
                      //  if (ds != null)
                        //    dataGridView1.DataSource = ds.Tables[0];

                    //}
                    //else
                      //  goto tekrar;
                }
        }

        private void Ana_Form_Load(object sender, EventArgs e)
        {
            DataSet ds1 = BLogic.SatisGetir();
            if (ds1 != null)
                dataGridView1.DataSource = ds1.Tables[0];
        }
    }
}
