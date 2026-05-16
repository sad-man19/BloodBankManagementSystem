using AutoMapper;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class BloodGroupInventoryService
    {
        BloodGroupInventoryRepo repo; //repo obj
        Mapper mapper;

        public BloodGroupInventoryService(BloodGroupInventoryRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }
    }
}
