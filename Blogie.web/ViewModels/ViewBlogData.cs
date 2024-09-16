using Blogie.core;

namespace Blogie.web.ViewModels
{
    public class ViewBlogData:BaseEntity 
    {
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public string? Thumnail { get; set; }
        public IFormFile? imageFile { get; set; }
        public string? Details { get; set; } 
    }
}
