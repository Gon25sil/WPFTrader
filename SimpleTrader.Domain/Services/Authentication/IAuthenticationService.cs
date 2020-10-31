using SimpleTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services.Authentication
{
    public enum RegistrationResult
    {
        Success,
        IncorrectPassword,
        EmailAlreadyExists,
        UsernameAlreadyExists
    }
    public interface IAuthenticationService
    {
        public Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);
        public Task<Account> Login(string username, string password);
    }
}
