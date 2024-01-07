using App.Business.Exceptions.Blog;
using App.Business.Exceptions.Id;
using App.Business.Exceptions.Image;
using App.Business.Helpers;
using App.Business.Services.Interfaces;
using App.Business.ViewModels.BlogVms;
using App.Core.Entities;
using App.DAL.Repository.Implementations;
using App.DAL.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services.Implementations
{
    public class BlogService : IBlogService
    {
        IBlogRepository _repository;
        IMapper _mapper;
        public BlogService(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            List<Blog> blogs = await _repository.GetAllAsync();
            if (blogs is null)
            {
                throw new BlogNotFoundException();
            }
            return blogs;
        }
        public async Task<Blog> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new IdZeroAndNegativeException();
            }
            Blog blog = await _repository.GetByIdAsync(id);
            if (blog is null)
            {
                throw new BlogNotFoundException();
            }
            return blog;
        }
        public async Task Create(BlogCreateVm blogVm,string env)
        {
            if (blogVm == null)
            {
                throw new BlogNullException();
            }
            if (!blogVm.ImageFile.ContentType.Contains("image"))
            {
                throw new ImageNotFileException();
            }
            if (blogVm.ImageFile.Length > 2097152)
            {
                throw new ImageMaxLengthException();
            }
            blogVm.ImgUrl = blogVm.ImageFile.Upload(env, @"\Upload\Image\");
            Blog blog = _mapper.Map<Blog>(blogVm);
            await _repository.CreateAsync(blog);
            await _repository.SaveChangesAsync();
        }
        public async Task Update(BlogUpdateVm blogVm,string env)
        {
            if(blogVm.Id<=0)
            {
                throw new IdZeroAndNegativeException();
            }
            Blog oldBlog =await GetByIdAsync(blogVm.Id);
            if (blogVm.ImageFile != null)
            {
                FileManager.DeleteFile(oldBlog.ImgUrl, env, @"\Upload\Image\");
                if (!blogVm.ImageFile.ContentType.Contains("image"))
                {
                    throw new ImageNotFileException();
                }
                if (blogVm.ImageFile.Length > 2097152)
                {
                    throw new ImageMaxLengthException();
                }
                blogVm.ImgUrl = blogVm.ImageFile.Upload(env, @"\Upload\Image\");
            }

            _mapper.Map(blogVm, oldBlog);
            await _repository.UpdateAsync(oldBlog);
            await _repository.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            if (id <= 0)
            {
                throw new IdZeroAndNegativeException();
            }
            Blog blog = await GetByIdAsync(id);
            blog.IsDeleted = true;
            await _repository.DeleteAsync(blog);
            await _repository.SaveChangesAsync();
        }
    }
}