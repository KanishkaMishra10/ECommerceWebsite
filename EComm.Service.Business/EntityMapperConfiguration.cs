using AutoMapper;
using Ecomm.Service.Domain.Models;
using EComm.Core.dto.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.Service.Business
{
    public static class EntityMapperConfiguration
    {
        public static void Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutomapperWebProfile>();
            });
        }
    }
    public class AutomapperWebProfile : Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<Product, ProductResponseModel>().ReverseMap();
        }
    }
}
