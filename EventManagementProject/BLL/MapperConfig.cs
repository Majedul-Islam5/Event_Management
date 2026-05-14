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
        static MapperConfiguration config = new MapperConfiguration(cfg => {
            cfg.CreateMap<User, RegistrationDTO>().ReverseMap();
            cfg.CreateMap<User, LoginDTO>().ReverseMap();
            cfg.CreateMap<Role, RoleTypeDTO>().ReverseMap();
            cfg.CreateMap<Category, CategoryTypeDTO>().ReverseMap();
            cfg.CreateMap<Event, EventDTO>().ReverseMap();
            cfg.CreateMap<Booking, BookingDTO>().ReverseMap();
            cfg.CreateMap<Review, ReviewDTO>().ReverseMap();

            //
            //
            //
            //
        });
        public static Mapper GetMapper()
        {
            return new Mapper(config);
        }
    }
}
