using AutoMapper;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class RequestService
    {
        RequestRepo repo;
        Mapper mapper;

        public RequestService(RequestRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }
    }
}
