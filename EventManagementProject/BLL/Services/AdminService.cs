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
        RoleRepo roleRepo;

        public AdminService(UserRepo userrepo, CategoryRepo categoryRepo, EventRepo eventRepo, RoleRepo roleRepo)
        {
            this.userrepo = userrepo;
            mapper = MapperConfig.GetMapper();
            this.categoryRepo = categoryRepo;
            this.eventRepo = eventRepo;
            this.roleRepo = roleRepo;
        }

        public int GetID(string Email)
        {
            return userrepo.GetID(Email);
        }

        public bool DeleteUser(int id)
        {
            var data = eventRepo.GetOrganizerEvents(id);
            var events = mapper.Map<List<EventDTO>>(data);
            if (events != null)
            {
                foreach (var ev in events)
                {
                    eventRepo.DeleteEvent(ev.EventId);
                }
            }
            userrepo.DeleteUser(id);
            return true;
        }

        public bool DeleteCategory(int id)
        {
            var data = eventRepo.GetOrganizerEvents(id);
            var events = mapper.Map<List<EventDTO>>(data);
            if (events != null)
            {
                foreach (var ev in events)
                {
                    eventRepo.DeleteEvent(ev.EventId);
                }
            }
            categoryRepo.DeleteCategory(id);
            return true;
        }

        public bool DeleteRole(int id)
        {
            var data = userrepo.GetUsersForRole(id);

            var userData = mapper.Map<List<RegistrationDTO>>(data);
            if (userData != null)
            {
                foreach (var ev in userData)
                {
                    DeleteUser(ev.UserId);
                }
            }
            roleRepo.DeleteRole(id);
            return true;
        }
    }
}
