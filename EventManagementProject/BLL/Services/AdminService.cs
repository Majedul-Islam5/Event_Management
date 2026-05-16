using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
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

        public EventDTO GetEventByID(int id)
        {

            var data = eventRepo.GetEventByID(id);
            var ret = mapper.Map<EventDTO>(data);
            return ret;

        }

        public List<EventDTO> GetAllEvents()
        {
            var data = eventRepo.GetAllEvents();
            var ret = mapper.Map<List<EventDTO>>(data);

            return ret;
        }

        public bool UpdateEvent(EventDTO dto)
        {

            var data = mapper.Map<Event>(dto);
            var ret = eventRepo.UpdateEvent(data);

            return ret;
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

        public RegistrationDTO GetUserByID(int id)
        {
            var data = userrepo.GetUserByID(id);
            var ret = mapper.Map<RegistrationDTO>(data);

            return ret;
        }

        public List<RegistrationDTO> GetAllUsers()
        {
            var data = userrepo.GetAllUsers();
            var ret = mapper.Map<List<RegistrationDTO>>(data);
            return ret;
        }


    }
}
