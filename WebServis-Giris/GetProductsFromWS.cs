using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebServis_Giris.ServiceReference1;

namespace WebServis_Giris
{
    public partial class GetProductsFromWS : Form
    {
        public GetProductsFromWS()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ProductListServiceSoapClient Service'in içindeki methodları barındırır.
            //PROXY talebi SOAP nesnelerine dönüştürür ve BUS'a iletir.
            //BUS talebi alır ve servise gider. Talep çalıştırılır ve dönen değer
            //BUS' a gelir. BUS, gelen değerden SOAP nesnesi üretir ve PROXY e iletir.
            ProductListServiceSoapClient client = new ProductListServiceSoapClient();
            
            
        }

        private void btnListProduct_Click(object sender, EventArgs e)
        {
            Identity idt = new Identity();
            idt.UserName = "admin";
            idt.Password = "123";

            ProductListServiceSoapClient client = new ProductListServiceSoapClient();
            dataGrid.DataSource = client.ProductList(idt);

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
