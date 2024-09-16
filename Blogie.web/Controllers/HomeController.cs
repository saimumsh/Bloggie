using Blogie.core.BlogInfo;
using Blogie.data.Repositoty;
using Blogie.web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blogie.web.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
        private readonly IRepository<BlogData> _showAction;
        private readonly IWebHostEnvironment webHostEnvironment;
        public HomeController(IRepository<BlogData> showAction, IWebHostEnvironment webHostEnvironment)
        {
            _showAction = showAction;
            this.webHostEnvironment = webHostEnvironment;
        }

		public IActionResult Index()
		{
            List<BlogData> obj = _showAction.GetAll();
            return View(obj);
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
