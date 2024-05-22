using CleanArch.Application.Interfaces;
using CleanArch.Application.Security;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    
        public CheckUser CheckUser(string userName, string email)
        {
            bool UserNameValid = _userRepository.IsExistUserName(userName.ToLower());
            bool EmailValid = _userRepository.IsExistEmail(email.Trim().ToLower());

            
               
            if (UserNameValid && EmailValid)
                return ViewModels.CheckUser.UserNameAndEmailNotValid;
            else if (EmailValid)
                return ViewModels.CheckUser.EmailNotValid;
            else if (UserNameValid)
                return ViewModels.CheckUser.UserNameNotValid;
            return ViewModels.CheckUser.Ok;
        }

        public bool IsExistUser(string email, string password)
        {
            return _userRepository.IsExistUser(email.Trim().ToLower(), PasswordHelper.EncodePasswordMD5(password));
        }

        public int RegisterUser(User user)
        {
            _userRepository.AddUser(user);
            _userRepository.Save();
            return user.UserId;
        }
    }
}
