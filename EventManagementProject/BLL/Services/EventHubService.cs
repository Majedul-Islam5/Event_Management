using AutoMapper;
using BLL.DTOs;
using DAL.EF.Tables;
using DAL.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Runtime;
using System.Security.Cryptography;
using System.Text;

namespace BLL.Services
{
    public class EventHubService
    {
        UserRepo userrepo;
        RoleRepo rolerepo;
        Mapper mapper;

        public EventHubService(UserRepo userrepo, RoleRepo rolerepo)
        {
            this.userrepo = userrepo;
            mapper = MapperConfig.GetMapper();
            this.rolerepo = rolerepo;
        }

        public bool EmailExists(string Email)
        {
            return userrepo.EmailExists(Email);
        }

        public List<RoleTypeDTO> GetUserType()
        {
            var data = rolerepo.GetUserTypes();
            var ret = mapper.Map<List<RoleTypeDTO>>(data);

            return ret;
        }


        public bool Create(RegistrationDTO dto)
        {
            dto.Password = GetMd5(dto.Password);
            var data = mapper.Map<User>(dto);

            return userrepo.Create(data);
        }


        //public bool UserExists(LoginDTO dto)
        //{
        //    dto.Password = GetMd5(dto.Password);
        //    var ret = mapper.Map<User>(login);
        //    return userrepo.UserExists(ret);
        //}

        static string GetMd5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // lowercase hex
                }

                return sb.ToString();
            }
        }
    }
}
