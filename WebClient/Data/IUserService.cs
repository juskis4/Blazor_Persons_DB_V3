﻿using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Authentication
{
    public interface IUserService
    {
        Task<User> ValidateUser(string username, string password);
    }
}