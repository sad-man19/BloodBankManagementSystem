using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MapperConfig
    {
        public static MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            //entity to dto and dto to entity
            cfg.CreateMap<User, UserDTO>().ReverseMap();
            cfg.CreateMap<BloodGroupInventory, BloodGroupInventoryDTO>().ReverseMap();
            cfg.CreateMap<Donation, DonationDTO>().ReverseMap();
            cfg.CreateMap<Request, RequestDTO>().ReverseMap();
        });

        public static Mapper GetMapper()
        {
            return new Mapper(config);
        }
    }
}
