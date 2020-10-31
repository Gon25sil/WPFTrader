using Microsoft.AspNet.Identity;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService accountService;
        private readonly IPasswordHasher passwordHasher;

        public AuthenticationService(IAccountService accountService, IPasswordHasher passwordHasher)
        {
            this.accountService = accountService;
            this.passwordHasher = passwordHasher;
        }

        public async Task<Account> Login(string username, string password)
        {
            Account account = await accountService.GetByUsername(username);

            PasswordVerificationResult passwordVerificationResult = passwordHasher.VerifyHashedPassword(account.AccountHolder.PasswordHash, password);

            if (passwordVerificationResult == PasswordVerificationResult.Success)
                return account;
            else
                throw new InvalidPasswordException(username, password);
        }

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            if (password != confirmPassword)
                return RegistrationResult.IncorrectPassword;

            var emailAccount = await accountService.GetByEmail(email);

            if (emailAccount != null)
                return RegistrationResult.EmailAlreadyExists;

            var usernameAccount = await accountService.GetByUsername(username);
            if (usernameAccount != null)
                return RegistrationResult.UsernameAlreadyExists;

            var hashedPass = passwordHasher.HashPassword(password);

            Account account = new Account()
            {
                AccountHolder = new User()
                {
                    DateJoined = DateTime.Now,
                    Email = email,
                    Username = username,
                    PasswordHash = hashedPass
                },
                Balance = 500
            };

            await accountService.Create(account);

            return RegistrationResult.Success;

        }
    }
}
