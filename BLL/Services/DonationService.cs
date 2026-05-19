using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repos;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class DonationService
    {
        DonationRepo donationRepo;
        UserRepo userRepo;
        BloodGroupInventoryRepo bloodGroupInventoryRepo;
        Mapper mapper;

        public DonationService(DonationRepo donationRepo, UserRepo userRepo, BloodGroupInventoryRepo bloodGroupInventoryRepo)
        {
            this.donationRepo = donationRepo;
            this.userRepo = userRepo;
            this.bloodGroupInventoryRepo = bloodGroupInventoryRepo;
            mapper = MapperConfig.GetMapper();
        }

        public bool IsAdult(User user)
        {
            int age = DateTime.Now.Year - user.Dob.Year;
            return age >= 18;
        }

        bool IsEligible(User user, DateOnly donationDate)
        {
            if (user.LastDonationDate == null)
            {
                return true;
            }
            return donationDate.DayNumber - user.LastDonationDate.Value.DayNumber >= 90;
        }

        public void UpdateLastDonation(User user, DateOnly donationdate)
        {
            user.LastDonationDate = donationdate;
            userRepo.UpdateLastDonation(user);
        }

        private void UpdateStock(int bloodGroupId)
        {
            bloodGroupInventoryRepo.UpdateStock(bloodGroupId);
        }

        public bool CreateDonation(DonationDTO d)
        {
            var user = userRepo.Get(d.UserId);
            if (user == null)
            {
                return false;
            }
            if (!IsAdult(user))
            {
                return false;
            }
            if (!IsEligible(user, d.DonationDate))
            {
                return false;
            }
            var donation = mapper.Map<Donation>(d);
            bool isCreated = donationRepo.CreateDonation(donation);
            if (!isCreated)
            {
                return false;
            }
            UpdateStock(d.BloodGroupId);
            UpdateLastDonation(user, d.DonationDate);
            return true;
        }

        public List<DonationDTO> Get(int id)
        {
            var donation = donationRepo.Get(id);
            if (donation == null)
            {
                return new List<DonationDTO>();
            }
            return mapper.Map<List<DonationDTO>>(donation);
        }
        public List<DonationDTO> GetAll()
        {
            var donation = donationRepo.GetAll();
            //var user = userRepo.GetAll();
            //var bloodGroup = bloodGroupInventoryRepo.Get();
            
            List<DonationDTO> res = new List<DonationDTO>();
            foreach (var d in donation)
            {
                var user = userRepo.Get(d.UserId);
                var bg =   bloodGroupInventoryRepo.Get(d.BloodGroupId);
                res.Add(new DonationDTO
                {
                    Id = d.Id,
                    UserId = d.UserId,
                    DonationDate = d.DonationDate,
                    BloodGroupId = d.BloodGroupId,
                    UserName = user.Name,
                    BloodGroup = bg.BloodGroup
                });
            }
            return res;
        }
    }
}
