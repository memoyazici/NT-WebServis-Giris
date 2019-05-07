using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebServis_Giris.TCKNServiceReference;

namespace WebServis_Giris
{
    public partial class TCKNDogrulama : Form
    {
        public TCKNDogrulama()
        {
            InitializeComponent();
        }

        //private void TCKN_Dogrulama()
        //{
        //    KPSPublicSoapClient client = new KPSPublicSoapClient();
        //    client.TCKimlikNoDogrula();
        //}

        private void btnTCDogrula_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text.ToUpper();
            string soyad = txtSoyad.Text.ToUpper();
            long tckn = Convert.ToInt64(txtTCKN.Text);
            int dogumYili = Convert.ToInt32(txtDogumYılı.Text);

            KPSPublicSoapClient client = new KPSPublicSoapClient();
            bool tcknResult= client.TCKimlikNoDogrula(tckn,ad,soyad,dogumYili);

            if (tcknResult)
            {
                MessageBox.Show("Girilen TCKN Doğru");
            }
            else
            {
                MessageBox.Show("TCKN yanlış !");
            }
        }
    }
}
