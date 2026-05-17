using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Runtime;
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
        private readonly EmailSettings _settings;

        public AdminService(UserRepo userrepo, CategoryRepo categoryRepo, EventRepo eventRepo, RoleRepo roleRepo, IOptions<EmailSettings> settings)
        {
            this.userrepo = userrepo;
            mapper = MapperConfig.GetMapper();
            this.categoryRepo = categoryRepo;
            this.eventRepo = eventRepo;
            this.roleRepo = roleRepo;
            _settings = settings.Value;
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

        public bool CreateCategory(CategoryTypeDTO data)
        {
            return categoryRepo.CreateCategory(mapper.Map<Category>(data));
        }

        public List<CategoryTypeDTO> ShowCategory()
        {
            return mapper.Map<List<CategoryTypeDTO>>(categoryRepo.ShowCategory());
        }

        public CategoryTypeDTO GetCategoryByID(int id)
        {
            return mapper.Map<CategoryTypeDTO>(categoryRepo.GetCategoryByID(id));
        }

        public bool UpdateCategory(CategoryTypeDTO data)
        {
            return categoryRepo.UpdateCategory(mapper.Map<Category>(data));
        }

        public bool SendEmail(string to, string subject, string body)
        {
            MailMessage message = new MailMessage();

            message.From = new MailAddress(_settings.Email);

            message.To.Add(to);

            message.Subject = subject;

            message.Body = body;

            message.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient(_settings.Host, _settings.Port);

            smtp.Credentials = new NetworkCredential(_settings.Email, _settings.Password);

            smtp.EnableSsl = _settings.EnableSSL;

            smtp.Send(message);

            return true;
        }


    }
}
