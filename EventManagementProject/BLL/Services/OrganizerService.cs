using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class OrganizerService
    {
        UserRepo userrepo;
        Mapper mapper;
        CategoryRepo categoryRepo;
        EventRepo eventRepo;

        public OrganizerService(UserRepo userrepo, CategoryRepo categoryRepo, EventRepo eventRepo)
        {
            this.userrepo = userrepo;
            mapper = MapperConfig.GetMapper();
            this.categoryRepo = categoryRepo;
            this.eventRepo = eventRepo;
        }

        public List<CategoryTypeDTO> GetCategoryType()
        {
            var data = categoryRepo.GetCategoryType();
            var ret = mapper.Map<List<CategoryTypeDTO>>(data);

            return ret;
        }

        public int GetID(string Email)
        {
            return userrepo.GetID(Email);
        }

        public bool Create(EventDTO dto)
        {
            var data = mapper.Map<Event>(dto);

            return eventRepo.Create(data);
        }

        public List<EventDTO> GetOrganizerEvents(int id)
        {
            var data = eventRepo.GetOrganizerEvents(id);
            var ret = mapper.Map<List<EventDTO>>(data);

            return ret;
        }

        

        public EventDTO GetEventByID(int id)
        {

            var data = eventRepo.GetEventByID(id);
            var ret = mapper.Map<EventDTO>(data);
            return ret;

        }

        public bool DeleteEvent(int id) 
        {
            return eventRepo.DeleteEvent(id);
        }
    }
}
