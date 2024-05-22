using CleanArch.Data.Context;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UniversityDBContext _context;
        public UserRepository(UniversityDBContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public bool IsExistEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsExistUser(string email, string password)
        {
            return _context.Users.Any(u=>u.Email==email && u.Password==password);
        }

        public bool IsExistUserName(string userName)
        {
            return _context.Users.Any(u => u.UserName == userName);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
