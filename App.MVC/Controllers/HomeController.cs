using App.Business.Services.Interfaces;
using App.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.MVC.Controllers
{
    public class HomeController : Controller
    {
        IBlogService _service;

        public HomeController(IBlogService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _service.GetAllAsync();
            return View(blogs);
        }
    }
}
