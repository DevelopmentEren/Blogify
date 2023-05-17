using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Blogify.Models;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Blogify.Controllers;

public class HomeController : Controller
{
    private readonly BlogifyContext context;
    public static User activeUser=new User();
    public static Blog activeBlog=new Blog();
    public static string secilikategori="";

    public HomeController(BlogifyContext context)
    {
        this.context=context;
        if(!this.context.Users.Any())
        {
            this.context.Users.Add(new User { Nickname="Kullanici1", Email="kullanici1@gmail.com" , Password="kullanici1" });
            this.context.Users.Add(new User { Nickname="Kullanici2", Email="kullanici2@gmail.com" , Password="kullanici2" });
            this.context.Users.Add(new User { Nickname="SakinElcicek", Email="sakinelcicek@gmail.com" , Password="Admin123." });
            this.context.Users.Add(new User { Nickname="MrEren11", Email="admin@gmail.com" , Password="Admin123." });
            this.context.SaveChanges();
        }

        if (!this.context.Blogs.Any())
        {
            this.context.Blogs.Add(new Blog { blogImage="/img/Yemekdefault.jpg",blogTitle="Köfte Ekmek: Lezzetli Bir Sokak Lezzeti" , blogCategory = "Yemek" , blogDescription = "Köfte ekmek, Türk mutfağının vazgeçilmez sokak lezzetlerinden biridir. Sıcacık bir ekmeğin içine yerleştirilen leziz köfteler, her bir ısırıkta damaklarda unutulmaz bir tat bırakır. Hem hızlı hem de doyurucu bir atıştırmalık olarak popülerlik kazanmış olan köfte ekmek, her yaştan insanın favorisi haline gelmiştir. Bu yazıda, köfte ekmek hakkında daha fazla bilgi edinecek ve bu lezzetli atıştırmalığı keşfedeceksiniz.Köfte ekmek, temel olarak iki ana bileşenden oluşur: köfte ve ekmek. Köftenin yapımında genellikle dana veya kuzu kıyması tercih edilir. Kıymaya soğan, sarımsak, baharatlar ve bazen de ekmek içi eklenerek yoğrulur. Köfte harcı hazırlandıktan sonra şekillendirilir ve ızgarada veya tavada pişirilir. Pişen köfteler, sıcak tutulması için genellikle yağda tutulur.Ekmek ise köfteyi sarmak için kullanılan önemli bir bileşendir. Köfte ekmek için tercih edilen ekmeğin yapısı, lezzeti üzerinde büyük etkiye sahiptir. Kabuğu çıtır, içi ise yumuşak ve hafif olmalıdır. Genellikle Türk pidesi veya lavaş gibi ekmeğin içi oyulur ve köfteler yerleştirilir. Ekmeğin üzerine, kişisel tercihlere göre maydanoz, taze soğan, marul, domates, salatalık gibi çeşitli yeşillikler eklenir. Ayrıca, acı soslar, yoğurt, hardal veya mayonez gibi çeşitli soslar da ekmeğin içine sürülerek ekstra tat ve lezzet katılır.Köfte ekmek, sokak satıcılarının tezgahlarında genellikle taze olarak hazırlanır ve sıcak servis edilir. İnsanlar genellikle günün her saatinde köfte ekmek yemek için bu tezgahların yanında sıraya girer. Sıcak ekmeğin içindeki sulu ve aromatik köfteler, her ısırıkta birleşerek enfes bir lezzet sunar. Ayrıca, köfte ekmek genellikle yanında servis edilen turşu, marul, soğan ve acı soslar ile de tamamlanır. Bu tür ekstralar, köftenin lezzetini daha da artırır ve atıştırmalığın doyuruculuğunu sağlar." , WriterId = 1 , WriterName = "Kullanici1" });

            this.context.Blogs.Add(new Blog { blogImage="/img/Seyahatdefault.jpg",blogTitle="Kız Kulesi: İstanbul'un Büyüleyici İkonu" , blogCategory = "Seyahat" , blogDescription = "İstanbul, tarihi ve kültürel zenginlikleriyle dünyanın en etkileyici şehirlerinden biridir. Bu büyülü şehirde, Boğaz'ın ortasında yer alan ve yüzyıllardır bir sembol haline gelen Kız Kulesi bulunmaktadır. Kız Kulesi, İstanbul'un en ikonik yapılarından biri olarak, ziyaretçilerini tarihin derinliklerine götürerek büyüleyici bir deneyim sunar.Kız Kulesi, Marmara Denizi'nde, Salacak açıklarında yer alan küçük bir adada konumlanmıştır. Yaklaşık 2500 yıllık geçmişiyle, bu yapı İstanbul'un en eski yapılarından biri olarak bilinir. Tarihi boyunca pek çok amaçla kullanılan Kız Kulesi, gözetleme kulesi, deniz feneri, karakol ve hatta karantina istasyonu olarak kullanılmıştır. Ayrıca, mitolojik hikayeler ve efsanelerle de çevrilidir.Kız Kulesi'nin adının kökeni üzerine pek çok efsane vardır. Bunlardan birine göre, kuleye hapsolmuş bir prenses nedeniyle 'Kız Kulesi' adı verilmiştir. Efsaneye göre, prensesin babası onu kuleden kurtarmak için bir kehanete dayanarak onu uzak bir yere gönderirken, bir yılan tarafından ısırılır ve kulede ölür. Bu romantik ve hüzünlü hikaye, Kız Kulesi'ne mistik bir hava katmaktadır.Kız Kulesi'nin mevcut yapısı, 18. yüzyılda Osmanlı İmparatorluğu döneminde inşa edilmiştir. Kare şeklindeki taş kulesi, yüksekliğiyle gökyüzüne yükselir ve İstanbul'un silüetine benzersiz bir dokunuş katar. Kule, beş katlı bir yapıya sahip olup, her kat farklı bir amaca hizmet etmektedir. En üst katta yer alan restoran, muhteşem bir manzara sunarak ziyaretçilere unutulmaz bir yemek deneyimi yaşatır." , WriterId = 1 , WriterName = "Kullanici1" });
            
            this.context.Blogs.Add(new Blog { blogImage="/img/Diğerdefault.jpg",blogTitle="Satranç: Zihin Oyunlarındaki Şah Tahtası" , blogCategory = "Diğer" , blogDescription = "Satranç, strateji ve zeka gerektiren bir zihin oyunudur ve binlerce yıldır dünya genelinde oynanmaktadır. Tahta üzerindeki farklı taşların hareketlerini kullanarak rakibi mat etmeye çalışırken, satranç oyuncuları düşünme yeteneklerini geliştirir, problem çözme becerilerini artırır ve stratejik düşünmeyi öğrenirler. Bu yazıda, satrancın tarihini, temel kurallarını ve sağladığı faydaları keşfedeceksiniz.Satranç, eski Hindistan'a kadar uzanan bir geçmişe sahiptir. İlk olarak 6. yüzyılda Hindistan'da ortaya çıkan bu oyun, zamanla Pers İmparatorluğu ve Arap dünyası üzerinden dünyaya yayıldı. Ortaçağ Avrupa'sında popülerlik kazanan satranç, zamanla farklı stratejiler, oyun tarzları ve kurallar geliştirdi. Günümüzde uluslararası olarak kabul edilen modern satranç, FIDE (Dünya Satranç Federasyonu) tarafından düzenlenen turnuvalarda ve şampiyonalarda oynanır.Satranç, iki oyuncu arasında oynanan bir strateji oyunudur. Genellikle bir satranç tahtası ve 32 taş kullanılarak oynanır. Tahta, 64 karelik bir şah tahtası olarak bilinir ve 8 sütun ve 8 sıradan oluşur. Her oyuncu, 16 taştan oluşan bir takım kullanır. Bunlar, vezir, şah, kale, fil, at ve piyon gibi farklı hareket yeteneklerine sahip taşlardır. Oyuncular, sıra ile taşlarını hareket ettirir ve rakip taşları yakalama, savunma veya avantaj elde etme amaçlı hamleler yapar.Satrancın temel amacı, rakip kralı tehdit ederek 'mat' etmektir. Rakibin kralını mat etmek, oyunu kazanmak anlamına gelir. Her hamlede, oyuncuların dikkatli düşünmesi, stratejilerini planlaması ve kararlarını vermesi gerekmektedir. Satranç, analitik düşünme becerilerini geliştirmenin yanı sıra, konsantrasyon, sabır, öngörü ve sezgi gibi zihinsel yetenekleri de gerektirir." , WriterId = 2 , WriterName = "Kullanici2" });
                
            this.context.Blogs.Add(new Blog { blogImage="/img/Teknolojidefault.jpg",blogTitle="3650 Ti Ekran Kartı: Performansıyla Sınırları Zorlayan Bir Güç Canavarı" , blogCategory = "Teknoloji" , blogDescription = "3650 Ti ekran kartı, oyun tutkunları ve grafik profesyonelleri için güçlü bir seçenek olan NVIDIA'nın bir ürünüdür. Bu ekran kartı, en yeni oyunları sorunsuz bir şekilde oynayabilme, karmaşık grafik işlemleri gerçekleştirme ve yaratıcı projelerde yüksek performans sunma konusunda sınırları zorlar. Bu yazıda, 3650 Ti ekran kartının özelliklerini, sağladığı avantajları ve performansı hakkında daha fazla bilgi edineceksiniz.3650 Ti, yüksek performanslı bir grafik işlem birimi olan GPU (Graphics Processing Unit) ile donatılmış bir ekran kartıdır. Bu kart, NVIDIA'nın gelişmiş teknolojilerini kullanarak üstün grafik işleme gücü sunar. 3650 Ti, oyun tutkunları için yüksek kare hızları ve ultra-yüksek çözünürlüklerde oynanabilirlik sağlar. Ayrıca, grafik profesyonelleri için yoğun veri işleme, 3D modelleme ve video düzenleme gibi görevleri hızlı bir şekilde yerine getirir.3650 Ti'nin en dikkat çekici özelliklerinden biri, yüksek bellek kapasitesidir. Bu ekran kartı genellikle 6 GB veya daha fazla GDDR6 bellek ile donatılmıştır. Bu, büyük veri kümesi işlemleri, çoklu uygulama çalıştırma ve yüksek çözünürlüklü grafiklerde daha akıcı bir deneyim sağlar. Ayrıca, 3650 Ti'nin geniş bellek bant genişliği, hızlı veri transferi ve akıcı görseller için önemli bir faktördür.3650 Ti ekran kartı, NVIDIA'nın güçlü Turing mimarisine dayanır. Bu mimari, gerçek zamanlı ışın izleme, yapay zeka destekli süper örnekleme ve daha fazlasını içeren bir dizi gelişmiş özelliği beraberinde getirir. Işın izleme teknolojisi, gerçekçi gölgeler, yansımalar ve aydınlatma efektleri sağlayarak oyunlarda daha etkileyici bir görsel deneyim sunar. Ayrıca, yapay zeka destekli süper örnekleme, düşük çözünürlüklü görüntüleri yüksek çözünürlüklü görüntülere dönüştürerek daha net ve keskin grafikler elde etmenizi sağlar." , WriterId = 2 , WriterName = "Kullanici2" });
            this.context.SaveChanges();
        }
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(User user)
    {   

        if (user.Nickname!=null&&user.Password!=null)
        {
            foreach (var User in context.Users)
            {
                if (user.Nickname==User.Nickname && user.Password==User.Password)
                {
                    activeUser=User;
                    return RedirectToAction("Index");
                }
            }

            return View();
        }
        
        else
        {
            return View();
        }
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        context.Add(user);
        context.SaveChanges();
        return RedirectToAction("login");
    }

    public IActionResult Index()
    {
        List<Blog> blogList=new List<Blog>();

        if (secilikategori==""||secilikategori==null||secilikategori=="Tümü")
        {
            blogList=context.Blogs.ToList();
        }

        if (secilikategori=="Seyahat")
        {
            blogList.Clear();

            foreach (var item in context.Blogs)
            {
                if (item.blogCategory=="Seyahat")
                {
                    blogList.Add(item);
                }
            }
        }

        if (secilikategori=="Spor")
        {
            blogList.Clear();

            foreach (var item in context.Blogs)
            {
                if (item.blogCategory=="Spor")
                {
                    blogList.Add(item);
                }
            }
        }

        if (secilikategori=="Teknoloji")
        {
            blogList.Clear();

            foreach (var item in context.Blogs)
            {
                if (item.blogCategory=="Teknoloji")
                {
                    blogList.Add(item);
                }
            }
        }

        if (secilikategori=="Yemek")
        {
            blogList.Clear();

            foreach (var item in context.Blogs)
            {
                if (item.blogCategory=="Yemek")
                {
                    blogList.Add(item);
                }
            }
        }

        if (secilikategori=="Dünya")
        {
            blogList.Clear();

            foreach (var item in context.Blogs)
            {
                if (item.blogCategory=="Dünya")
                {
                    blogList.Add(item);
                }
            }
        }

        if (secilikategori=="Türkiye")
        {
            blogList.Clear();

            foreach (var item in context.Blogs)
            {
                if (item.blogCategory=="Türkiye")
                {
                    blogList.Add(item);
                }
            }
        }

        if (secilikategori=="Güncel")
        {
            blogList.Clear();

            foreach (var item in context.Blogs)
            {
                if (item.blogCategory=="Güncel")
                {
                    blogList.Add(item);
                }
            }
        }

        if (secilikategori=="Diğer")
        {
            blogList.Clear();

            foreach (var item in context.Blogs)
            {
                if (item.blogCategory=="Diğer")
                {
                    blogList.Add(item);
                }
            }
        }
        
        return View(blogList);
    }

    public IActionResult AdminPanel()
    {
        if (activeUser.Nickname=="SakinElcicek"||activeUser.Nickname=="MrEren11")
        {
            return RedirectToAction("Index", "Admin");
        }

        return RedirectToAction("Index");
    }

    public IActionResult Katsec(string kat)
    {
        secilikategori=kat;
        return RedirectToAction("Index");
    }

    public IActionResult Routing(int id)
    {
        List<Blog> blogs= (from item in context.Blogs
                           where item.WriterId == id
                           select item).ToList();
        if (activeUser.Id==id)
        {
            return RedirectToAction("MyBlog");
        }

        else{
            return View("UserProfile",blogs);
        }
    }

    [HttpGet]
    public IActionResult Hakkimizda()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Hakkimizda(Bildiri bil)
    {
        bil.WriterId=activeUser.Id;
        bil.WriterName=activeUser.Nickname;
        context.Bildiris.Add(bil);
        context.SaveChanges();
        return View();
    }

    public IActionResult Exit()
    {
        activeUser=null;
        return RedirectToAction("Login");
    }

    public IActionResult BlogWatch(int id)
    {
        var blog=context.Blogs.FirstOrDefault(x=>x.Id==id);
        return View(blog);
    }

    public IActionResult UserProfile()
    {
        return View();
    }

    public IActionResult MyBlog()
    {
        List<Blog> MyBlogs=new List<Blog>();
        foreach (var item in context.Blogs)
        {
            if (item.WriterId==activeUser.Id)
            {
                MyBlogs.Add(item);
            }
        }
        return View(MyBlogs);
    }

    public IActionResult Remove(int id)
    {
        var removeBlog=context.Blogs.FirstOrDefault(x=>x.Id==id);
        context.Blogs.Remove(removeBlog);
        context.SaveChanges();
        return RedirectToAction("MyBlog");
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        var updateBlog=context.Blogs.FirstOrDefault(x=>x.Id==id);
        return View(updateBlog);
    }

    [HttpPost]
    public IActionResult Update(Blog blog)
    {
        context.Blogs.Update(blog);
        context.SaveChanges();
        return RedirectToAction("MyBlog");
    }

    [HttpGet]
    public IActionResult BlogAdd()
    {
        return View();
    }

    [HttpPost]
    public IActionResult BlogAdd(blogadd blog)
    {
        Blog newblog=new Blog();
        blog.WriterId=activeUser.Id;
        blog.WriterName=activeUser.Nickname;

        if(blog.blogImage==null){
            newblog.blogImage = "/img/"+blog.blogCategory+"default.jpg";
        }
        else{
            var extension = Path.GetExtension(blog.blogImage.FileName);
            var newimagename = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images/",newimagename);
            var stream = new FileStream(location, FileMode.Create);
            blog.blogImage.CopyTo(stream);
            newblog.blogImage = "/images/"+newimagename;
        }
        newblog.Id=blog.Id;
        newblog.blogTitle=blog.blogTitle;
        newblog.blogCategory=blog.blogCategory;
        newblog.blogDescription=blog.blogDescription;
        newblog.WriterId=blog.WriterId;
        newblog.WriterName=blog.WriterName;
        context.Blogs.Add(newblog);
        context.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
