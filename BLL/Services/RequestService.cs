using AutoMapper;
using BLL.DTOs;
using BLL.Helpers;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class RequestService
    {
        RequestRepo requestRepo;
        DonationRepo donationRepo;
        UserRepo userRepo;
        BloodGroupInventoryRepo bloodGroupInventoryRepo;
        Mapper mapper;

        public RequestService(RequestRepo requestRepo, DonationRepo donationRepo, UserRepo userRepo, BloodGroupInventoryRepo bloodGroupInventoryRepo)
        {
            this.requestRepo = requestRepo;
            this.donationRepo = donationRepo;
            this.userRepo = userRepo;
            this.bloodGroupInventoryRepo = bloodGroupInventoryRepo;
            mapper = MapperConfig.GetMapper();
        }
        public bool CreateRequest(RequestDTO r)
        {
            //var data = mapper.Map<UserDTO, User>(u);
            //data.Role = "User";
            //var result = repo.Create(data);
            //return result;
            var data = mapper.Map<Request>(r);
            data.Status = "Pending";
            var result = requestRepo.CreateRequest(data);
            return result;
        }
        public List<RequestDTO> GetAll()
        {
            var req = requestRepo.GetAll();
            //var result = mapper.Map<List<Request>, List<RequestDTO>>(data);
            //return result;
            List<RequestDTO> res = new List<RequestDTO>();
            foreach (var r in req)
            {
                var user = userRepo.Get(r.UserId);
                var bg = bloodGroupInventoryRepo.Get(r.BloodGroupId);
                res.Add(new RequestDTO
                {
                    Id = r.Id,
                    UserId = r.UserId,
                    BloodGroupId = r.BloodGroupId,
                    Quantity = r.Quantity,
                    ReqDate = r.ReqDate,
                    Status = r.Status,
                    UserName = user.Name,
                    BloodGroup = bg.BloodGroup
                });
            }
            return res;
        }

        public bool DeleteRequest(int id)
        {
            var result = requestRepo.DeleteRequest(id);
            return result;
        }
    }
}
