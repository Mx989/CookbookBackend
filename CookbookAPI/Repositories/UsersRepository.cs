using CookbookAPI.Data;
using CookbookAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookbookAPI.Repositories
{
    public class UsersRepository: IUsersRepository
    {
        private CookbookDbContext cookbookDbContext;

        public UsersRepository(CookbookDbContext _context)
        {
            cookbookDbContext = _context;
        }

        public async Task<User> GetUser(string username, string password)
        {
            return await cookbookDbContext.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

        public async Task<User> GetUser(string username)
        {
            var user = await cookbookDbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
            user.Password = null;

            if (user != null)
            {
                return user;
            }
            else return null;
        }

        public async Task AddUser(string username, string password, string email)
        {
            await cookbookDbContext.Users.AddAsync(new User() { Username = username, Password = password, EmailAddress = email });
            await cookbookDbContext.SaveChangesAsync();
        }
    }
}
