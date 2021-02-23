using CookbookAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookbookAPI.Repositories
{
    public interface IUsersRepository
    {
        public Task<User> GetUser(string username, string password);
        public Task<User> GetUser(string username);

        public Task AddUser(string username, string password, string email);
    }
}
