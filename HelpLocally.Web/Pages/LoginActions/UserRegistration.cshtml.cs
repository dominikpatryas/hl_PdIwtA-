using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpLocally.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HelpLocally.Domain.FormInputs;
using HelpLocally.Domain;
using Microsoft.EntityFrameworkCore;

namespace HelpLocally.Web
{
    public class UserRegistrationModel : PageModel
    {
        private readonly HelpLocallyContext _context;

        public UserRegistrationModel(HelpLocallyContext context)
        {
            _context = context;
        }
        public void OnGet() { }

        public async Task<IActionResult> OnPost(UserRegistrationInput input)
        {
            if ((input.Login != null) && (input.Password != null))
            {
                var user = new User(input.Login);

                if (await UserExists(user.Login))
                    return BadRequest("Login exists");

                byte[] passwordHash, passwordSalt;
                CreatePasswordhash(input.Password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return Redirect("/Offers/offers");
            }

            return Redirect("/error");
        }

        public async Task<bool> UserExists(string login)
        {
            if (await _context.Users.AnyAsync(x => x.Login == login))
                return true;

            return false;
        }

        private void CreatePasswordhash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;                                                       
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)); 
            }
        }
    }
}