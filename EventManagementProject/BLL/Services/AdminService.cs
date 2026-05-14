using AutoMapper;
using BLL.DTOs;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class AdminService
    {
        UserRepo userrepo;
        Mapper mapper;
        CategoryRepo categoryRepo;
        EventRepo eventRepo;

        public AdminService(UserRepo userrepo, CategoryRepo categoryRepo, EventRepo eventRepo)
        {
            this.userrepo = userrepo;
            mapper = MapperConfig.GetMapper();
            this.categoryRepo = categoryRepo;
            this.eventRepo = eventRepo;
        }

        public int GetID(string Email)
        {
            return userrepo.GetID(Email);
        }
    }
}
