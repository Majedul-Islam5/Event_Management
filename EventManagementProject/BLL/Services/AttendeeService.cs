using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class AttendeeService
    {
        UserRepo userrepo;
        Mapper mapper;
        CategoryRepo categoryRepo;
        EventRepo eventRepo;
        BookingRepo bookingRepo;

        public AttendeeService(UserRepo userrepo, CategoryRepo categoryRepo, EventRepo eventRepo, BookingRepo bookingRepo)
        {
            this.userrepo = userrepo;
            mapper = MapperConfig.GetMapper();
            this.categoryRepo = categoryRepo;
            this.eventRepo = eventRepo;
            this.bookingRepo = bookingRepo;
        }

        public List<EventDTO> GetEvents(string Title, int CategoryId)
        {
            var data = eventRepo.GetEvents(Title, CategoryId);
            var ret = mapper.Map<List<EventDTO>>(data);
            return ret;
        }

        public List<CategoryTypeDTO> GetCategoryType()
        {
            var data = categoryRepo.GetCategoryType();
            var ret = mapper.Map<List<CategoryTypeDTO>>(data);

            return ret;
        }

        public EventDTO GetEventByID(int id)
        {

            var data = eventRepo.GetEventByID(id);
            var ret = mapper.Map<EventDTO>(data);
            return ret;

        }

        public int GetID(string Email)
        {
            return userrepo.GetID(Email);
        }

        public bool CreateTicket(BookingDTO dto)
        {
            var data = mapper.Map<Booking>(dto);

            return bookingRepo.Create(data);
        }
    }
}
