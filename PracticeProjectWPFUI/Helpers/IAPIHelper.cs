﻿using PracticeProjectWPFUI.Models;
using System.Threading.Tasks;

namespace PracticeProjectWPFUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}