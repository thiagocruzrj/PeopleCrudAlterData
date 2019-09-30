using AutoMapper;
using People.Api.ViewModels;
using People.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Api.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Person, PersonViewModel>().ReverseMap();
        }
    }
}
