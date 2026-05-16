using AutoMapper;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class DonationService
    {
        DonationRepo repo;
        Mapper mapper;

        public DonationService(DonationRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }
    }
}
