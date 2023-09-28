using KadirBeskardes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KadirBeskardes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context=new ApplicationDbContext("Data Source=DESKTOP-7C95RJS;Initial Catalog=MyWebSite(KadirBeskardes);Integrated Security=True;");
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult ProjectDetail(int id)
        {
            Project project = _context.Projects.ToList().FirstOrDefault(p => p.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        public IActionResult Projects()
        {
            List<Project> projects = _context.Projects.ToList();
            return View(projects);
        }
        /*
        private List<Project> GetSampleProjects()
        {
            List<Project> projects = new List<Project>
            {
            new Project
            {
                Id=1,
                Title = "Proje 1",
                Description = "Bu bir örnek proje açıklamasıdır.",
                Technologies = "ASP.NET Core, C#, HTML, CSS",
                ImageUrl = "/proje1.jpg" // Resimleri "wwwroot/images" klasörü altında depolayın
            },
            new Project
            {
                Id=2,
                Title = "Proje 2",
                Description = "Bu bir başka örnek proje açıklamasıdır.",
                Technologies = "ASP.NET Core, C#, JavaScript, Bootstrap",
                ImageUrl = "/proje2.jpg"
            },
            new Project
            {
                Id=3,
                Title = "Proje 1",
                Description = "Bu bir örnek proje açıklamasıdır.",
                Technologies = "ASP.NET Core, C#, HTML, CSS",
                ImageUrl = "/proje3.jpg" 
            },
            new Project
            {
                Id=4,
                Title = "Proje 2",
                Description = "Bu bir başka örnek proje açıklamasıdır.",
                Technologies = "ASP.NET Core, C#, JavaScript, Bootstrap",
                ImageUrl = "/proje1.jpg"
            },
            new Project
            {
                Id=5,
                Title = "Proje 1",
                Description = "Bu bir örnek proje açıklamasıdır.",
                Technologies = "ASP.NET Core, C#, HTML, CSS",
                ImageUrl = "/proje2.jpg" 
            },
            new Project
            {
                Id=6,
                Title = "Proje 2",
                Description = "Bu bir başka örnek proje açıklamasıdır.",
                Technologies = "ASP.NET Core, C#, JavaScript, Bootstrap",
                ImageUrl = "/proje3.jpg"
            }
            // Burada diğer projelerinizi ekleyebilirsiniz.
            };

            return projects;
        }*/
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Contact(IletisimFormModel model)
        {
            if (model!=null)
            {
                _context.IletisimFormModels.Add(model);
                _context.SaveChanges();
                // Burada gelen form verilerini işleyebilirsiniz
                // Örneğin, e-posta gönderme işlemi, veritabanına kaydetme gibi

                // İşlemler tamamlandıktan sonra başka bir sayfaya yönlendirilebilir
                return RedirectToAction("Index");
            }

            return View(model);
        }
        public IActionResult Intro()
        {
            return View(); // Burada "Intro" sayfasının görüntüleneceğini belirtiyoruz.
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}