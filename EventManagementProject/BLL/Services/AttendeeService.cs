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
        ReviewRepo reviewRepo;

        public AttendeeService(UserRepo userrepo, CategoryRepo categoryRepo, EventRepo eventRepo, BookingRepo bookingRepo, ReviewRepo reviewRepo)
        {
            this.userrepo = userrepo;
            mapper = MapperConfig.GetMapper();
            this.categoryRepo = categoryRepo;
            this.eventRepo = eventRepo;
            this.bookingRepo = bookingRepo;
            this.reviewRepo = reviewRepo;
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


        public List<BookingDTO> ConfBooking(int id)
        {
            var data = bookingRepo.ConfBooking(id);
            var ret = mapper.Map<List<BookingDTO>>(data);

            return ret;
        }

        public bool CreateReview(ReviewDTO dto)
        {
            var data = mapper.Map<Review>(dto);
            return reviewRepo.CreateReview(data);
        }

        public List<BookingDTO> ShowBooking(int id)
        {
            var data = bookingRepo.ShowBooking(id);
            var ret = mapper.Map<List<BookingDTO>>(data);

            return ret;
        }

        public BookingDTO GetBookingById(int id)
        {
            var data = bookingRepo.GetBookingById(id);
            var ret = mapper.Map<BookingDTO>(data);

            return ret;
        }

        public bool UpdateBooking(BookingDTO dto)
        {
            var data = mapper.Map<Booking>(dto);
            var ret = bookingRepo.UpdateBooking(data);

            return ret;
        }

        public bool CancelBooking(int id)
        {
            var ret = bookingRepo.CancelBooking(id);

            return ret;
        }
    }
}
