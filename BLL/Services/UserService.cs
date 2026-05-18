using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class UserService
    {
        UserRepo repo; //repo obj
        Mapper mapper;

        public UserService(UserRepo repo)
        {
            this.repo = repo;
            mapper = MapperConfig.GetMapper();
        }
        public bool EmailExists(string email)
        {
            return repo.EmailExists(email);
        }
        public bool PhoneExists(string phone)
        {
            return repo.PhoneExists(phone);
        }
        public bool Create(UserDTO u)
        {
            var data = mapper.Map<UserDTO, User>(u);
            data.Role = "User";
            var result = repo.Create(data);
            return result;
        }

        public UserDTO Login(string email, string password)
        {
            var data = repo.Login(email, password);
            return mapper.Map<User, UserDTO>(data);
        }
        //public UserDTO Get(int id)
        //{
        //    var data = repo.Get(id);
        //    var result = mapper.Map<User, UserDTO>(data);

        //    //result.BloodGroup = data.BloodGroupInventory?.BloodGroup;
        //    result.BloodGroup = data.BloodGroupInventory != null? data.BloodGroupInventory.BloodGroup : null;
        //    return result;
        //}
        public UserDTO Get(int id)
        {
            var data = repo.Get(id);
            if (data == null) return null;

            var result = mapper.Map<User, UserDTO>(data);

            var bg = repo.GetBloodGroup(data.BloodGroupId);

            result.BloodGroup = bg?.BloodGroup;

            return result;
        }
        public bool Update(UserDTO u)
        {
            var data = mapper.Map<UserDTO, User>(u);
            var res = repo.Update(data);
            return res;
        }
    }
}
