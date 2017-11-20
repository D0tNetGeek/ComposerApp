using System.Linq;
using System.Web.Mvc;
using ANW.ComposerApp.Models;
using ANW.ComposerService;

namespace ANW.ComposerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IComposerService _composerService;

        public HomeController(IComposerService composerService)
        {
            _composerService = composerService;
        }

        public HomeController()
        {
            _composerService = new ComposerService.ComposerService();
        }

        public ViewResult Index()
        {
            var composers = _composerService.GetAllComposers();

            var model = composers.Select(x => new Composer
            {
                    Id = x.Id,
                    Title = x.Title,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Awards = x.Awards
            }).ToList();

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ViewResult Details(int id)
        {
            var composer = _composerService.GetComposerById(id);

            var model = new Composer
            {
                Title = composer.Title,
                FirstName = composer.FirstName,
                LastName = composer.LastName,
                FullName = composer.FullName,
                Awards = composer.Awards
            };
            return View(model);
        }
    }
}