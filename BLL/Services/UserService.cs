using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using BLL.Helpers;
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
            data.Password = PassHash.GetMd5(u.Password);
            data.Role = "User";
            var result = repo.Create(data);
            return result;
        }

        //public bool Create(UserDTO u)
        //{
        //    try
        //    {
        //        var data = mapper.Map<UserDTO, User>(u);

        //        data.Password = PassHash.GetMd5(u.Password);
        //        data.Role = "User";

        //        return repo.Create(data);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public UserDTO Login(string email, string password)
        {
            var data = repo.Login(email, PassHash.GetMd5(password));
            //var data = repo.Login(email, password);
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
            if (data == null)
            {
                return null;
            }

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
        public bool ChangePass(UserDTO u)
        {
            var user = repo.Get(u.Id);
            string currentPass = PassHash.GetMd5(u.Password);
            //string currentPass = u.Password;
            if(user.Password != currentPass)
            {
                return false;
            }
            user.Password = PassHash.GetMd5(u.NewPassword);
            return repo.ChangePass(user);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

    }
}
