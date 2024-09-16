using Blogie.core;
using Blogie.core.BlogInfo;
using Blogie.web.ViewModels;
using Blogie.data.Repositoty;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Blogie.web.Controllers
{
    //[Authorize]
	public class BloggieController : Controller
	{
        private readonly IRepository<BlogData> _blogAction;
        private readonly IWebHostEnvironment webHostEnvironment;
        public BloggieController(IRepository<BlogData> blogAction, IWebHostEnvironment webHostEnvironment)
        {
            _blogAction = blogAction;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
		{
			List<BlogData> obj = _blogAction.GetAll();

			return View(obj);
		}
        public IActionResult Create()
        {
			return View();
        }
		[HttpPost]
        public IActionResult Create( ViewBlogData obj)
		{
            if(ModelState.IsValid)
            {
                var path = webHostEnvironment.WebRootPath;
                var filePath = "image/" + obj.imageFile.FileName;
                var fullPath = Path.Combine(path, filePath);
                FileUpload(obj.imageFile, fullPath);


                BlogData blogData = new BlogData()
                {
                    Thumnail = filePath,
                    Title=obj.Title,
                    Summary=obj.Summary,
                    Details=obj.Details,
               
                };
                _blogAction.Add(blogData);
                //return RedirectToAction("index", "Bloggie");
            }
            else
            {
                return View(obj);
            }
			return RedirectToAction("Index","Bloggie");
            //_blogAction.Add(obj);
		}
        public void FileUpload(IFormFile file ,string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Create);
            file.CopyTo(fileStream);
        }
		public IActionResult Update(int id)
		{
			if (id == null)
			{
				return NotFound();
			}
            BlogData obj = _blogAction.GetById(id);
			return View(obj);
		}
		[HttpPost]
        public IActionResult Update(BlogData obj)
        {
            
            _blogAction.Update(obj);
            return RedirectToAction("Index","Bloggie");
        }
        public IActionResult Delete(int id)
		{
            if (id == null)
            {
                return NotFound();
            }
            BlogData obj = _blogAction.GetById(id);
            return View(obj);
		}
        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(BlogData obj)
        {
            _blogAction.Delete(obj);
            return RedirectToAction("Index","Bloggie");
        }
        public IActionResult ShowDetails(int id)
        {
            BlogData obj = _blogAction.GetById(id);
            return View(obj);
        }

    }
}
