using App.Business.ViewModels.BlogVms;
using App.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Blog,BlogCreateVm>();
            CreateMap<Blog,BlogCreateVm>().ReverseMap();
			CreateMap<Blog, BlogUpdateVm>();
			CreateMap<Blog, BlogUpdateVm>().ReverseMap();
		}
	}
}
