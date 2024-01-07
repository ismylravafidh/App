using App.Business.Services.Interfaces;
using App.Business.ViewModels.BlogVms;
using App.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.MVC.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class BlogController : Controller
    {
        IBlogService _service { get; set; }
        IWebHostEnvironment _environment;
		private readonly IMapper _mapper;

		public BlogController(IBlogService service , IWebHostEnvironment environment,IMapper mapper)
        {
            _service = service;
            _environment = environment;
			_mapper = mapper;
		}

        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _service.GetAllAsync();
            return View(blogs);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BlogCreateVm blog)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _service.Create(blog,_environment.WebRootPath);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
            Blog blog = await _service.GetByIdAsync(id);
            BlogUpdateVm blogVm = _mapper.Map<BlogUpdateVm>(blog);
            return View(blogVm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(BlogUpdateVm blog)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _service.Update(blog,_environment.WebRootPath);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _service.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
