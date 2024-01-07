using App.Business.ViewModels.BlogVms;
using App.Core.Entities;
using App.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Services.Interfaces
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllAsync();
        Task<Blog> GetByIdAsync(int id);
        Task Create(BlogCreateVm blogVm,string env);
        Task Update(BlogUpdateVm blogVm,string env);
        Task Delete(int id);
    }
}
