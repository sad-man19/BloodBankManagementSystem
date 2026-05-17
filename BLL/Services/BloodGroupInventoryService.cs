using AutoMapper;
using BLL.DTOs;
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
        public List<BloodGroupInventoryDTO> Get()
        {
            var data = repo.Get();
            var result = mapper.Map<List<BloodGroupInventoryDTO>>(data);
            return result;
        }
    }
}
