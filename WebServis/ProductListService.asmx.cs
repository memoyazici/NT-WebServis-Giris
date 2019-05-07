using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace WebServis
{
    /// <summary>
    /// Summary description for ProductListService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    /*Web servisleri Servis Oriented Architecture (SOA) olarak adlandırılır. Servisleri
     * kullanabilmek içşn bşr arayüze ihtiyaç duyulur. Servisler, arka planda çalışan
     * uygulamalardır. Bu arka plan uygulamalarının, kullanıcılar ile direkt bir bağlantısı yoktur.
     * Kullanıcının servis ile iletişime geçebilmesi için bir araç yada arayüz tanımlanması gerekir.
     * (Services/SqlServer servisleri -- Arayüz SQL server Management Studio)
     * 
     * Farklı servis mimarileri
     * 1- Windows Services
     * 2- .Net Remoting
     * 3- MSMQ : Bilgisayarlar arası mesaj alma/gönderme protokollerini sağlayan servis mimarisi
     * 4- Web Servis : Bir web sitesi gibi çalışan, domain ve IP ardesi olan
     * bu örnekte IIS üzerinden çalıştırılan, web de çalışan servislerdir.
     * 5- WCF (Windows Cmmunication Foundation) : Hem winform hem web de çalışabilen
     * en gelişmiş servis mimarilerinden biridir.
     *
     * Servis mimarisinin ortaya çıkış sebebi "Distributed ARchitecture" yani dağıtık mimaridir.
     * YAzılan bir masaüstü uygulamasının birden çok clientta çalışması gerektiğinde, clientların
     * merkez DB erişimi için web server'da host edilen web servislerinden yararlanılabilir.
     * Birden çok client (şubeler vs.) yaptığı işlemlerin, Merkez şube tarafından incelenmesi
     * ve raporlanabilmesi için web servslere ihtiyaç duyarız.
     * Bu yapı dağıtık uygulama yapılır
     * mrekezin haberleşmesi web servisleri ile sağlanır
     *
     *Servisin bir domain ve IP adresi ile web te çalışan bir yapısı olması gerekir. Bunun için
     * bir web server ına yüklenerek publish edilmeli ve bu şekilde o web serverında aktif hale
     * getirilmelidir. Aynı masaüstü uygulamasını kullanan farklı yerlerdeki clientlarımız,
     * bu servisler üzerinden veritabanına ulaşacaklardır.
     * 
     * Masaüstü uygulamamıza bir web servisi eklediğimiz zaman, clint tarafında PROXY isimli
     * yapılar oluşur. PROXY ler içerisinde, projenize dahil ettiğiniz web servisin içindeki yapıyı
     * temsil eden DLL lerdir. Servis içerisinde hangi metodların olduğu, methodların parametre
     * sayısı, tipi vb., methodların return tipleri, PROXY içerisinde bulunur.
     * Yani client ta yüklü uygulamamız PROXY i web servismiş gibi kullanır. Client ta oluşan
     * talep, Proxy tarafından yapılanır ve web servise iletilir. Web servis, gelen talebi
     * BUS aracılığı ile alır, çalıştırır, gerekiyorsa DB ile iletişime geçer ve sonucu BUS
     * aracılığı ile client ın Proxy sine iletir. PROXY sonucu alır ve client üzerinde gösterir.
     * Web servisleri web uygulamasıdır, IIS serverda çalışır.
     * Web servis içerisinde tanımladğımız method lara header tanımlayabiliyoruz. Header tanımı
     * bu web servisin çalışabilmesi için gerekli koşulların tanımlandığı yerdir. Mesela header
     * içerisinde kullanıcı adı ve parola belirleyebiliriz ve servisin çalışabilmesi için
     * gelen kullanıcı adı parolanın header ile uyumlu olmasını kontrol edebilir ve gelen veri
     * doğru ise servisi çalıştırabilirsiniz.
     * Kriptolama : Kriptolama algoritmaları gelen/giden veri kriptolanarak yazılırsa, koruma
     * düzeyi yükselir. Çünkü gidip/ gelen veri her zaman değişken olacaktır.
     * 
     * Web servis hazırlanıp yayına açıldığında, hem client tarafında, hem de server tarafında
     * endpoint denilen ayarlaroluşur. Endpoint ayarları, client uygulamamızın hangi protokol
     * (http,tcp,icp vb - default olarak basic http binding yöntemi kullanılır)
     * üzerinden web servis uygulaması ile iletişime geçeceğini belirler
     *
     * Bir diğer endpoint olarak gidip/ gelen verinin tipinin belirlenmesini sağlar.
     * Bu ayarlar otomatik olarak set edilir. İhtiyaç durumunda client uygulamasının app.config
     * ayarlarından değiştirilir.
     * 
     * Client ile servis arasında gidip/gelen nesne SOAP nesnesidir.
     * SOAP : Simple Object Access Protocol - Basit NEsne Erişim Protokolü
     * SAOP nesnesi XML formatındadır. dolaysıs ile servis ve client arasında gidip gelen
     * verinin XML formatına dönüştürülebilmesi için serileştirilebilir [Serializable]
     * olması gerekir
     */

    public class ProductListService : System.Web.Services.WebService
    {

        [WebMethod]
        //Bu servisin sunduğu bu metot, web'te çalışabilir demek
        //http://localhost:54177/ProductListService.asmx?wsdl
        //ProductListService uygulamamızı windows form uygulamamıza ekleyebilmemiz için
        /* bu web servisi, client uygulamamıza tanıtan dil WSDL dir
         * WSDL Web servis definiton language, web servisinin ad, metotları, return tipleri,
         * ,parametreleri ve tipleri vb. bütün servis özelliklerini client uygulamamıza
         * tanıtan bir dildir.
         
             */
        public string HelloWorld()
        {
            return "Hello World Hello Istanbul norefresh";
        }

        public Identity IdentityInfo { get; set; }


        [WebMethod]
        [SoapHeader("IdentityInfo")]
        public List<ProductDTO> ProductList()
        {

            if (IdentityInfo.UserName == "admin" && IdentityInfo.Password == "123")
            {
                
                NorthwindEntities db = new NorthwindEntities();
                return db.Products.Select(x => new ProductDTO
                {
                    ProductID = x.ProductID,
                    ProductName = x.ProductName,
                    SupplierID = x.SupplierID,
                    CategoryID = x.CategoryID,
                    QuantityPerUnit = x.QuantityPerUnit,
                    UnitPrice = x.UnitPrice,
                    UnitsInStock = x.UnitsInStock,
                    UnitsOnOrder = x.UnitsOnOrder,
                    ReorderLevel = x.ReorderLevel,
                    Discontinued = x.Discontinued

                }).ToList();
            }
            else
                return null;

        }

      


        }
}
