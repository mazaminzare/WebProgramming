﻿using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface IUserRepository
    {

        bool IsExistUser(string email, string password);

        void AddUser(User user);
        bool IsExistUserName(string userName);
        bool IsExistEmail(string email);
        void Save();
    }
}
