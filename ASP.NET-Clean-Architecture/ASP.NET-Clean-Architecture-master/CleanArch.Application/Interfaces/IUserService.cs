using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface IUserService
    {
        bool IsExistUser(string email, string password);
        CheckUser CheckUser(string userName, string email);
        int RegisterUser(User user);
    }
}
