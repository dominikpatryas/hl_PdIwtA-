using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HelpLocally.Domain;
using HelpLocally.Domain.FormInputs;
using HelpLocally.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RestSharp;
using System.Web;
namespace HelpLocally.Web
{
    public class UserSigningModel : PageModel
    {
        private readonly HelpLocallyContext _context;
        private IConfiguration _config;
        public UserSigningModel(HelpLocallyContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost(UserSigninInput input)
        {
            if ((input.Login != null) && (input.Password != null))
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == input.Login);

                if (user == null)
                    return null;

                if (!VerifyPasswordHash(input.Password, user.PasswordHash, user.PasswordSalt))
                    return null;

                var claims = new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login)

                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(1),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

                Response.Cookies.Append("token", token);
                Response.Cookies.Append("userId", user.Id.ToString());

                return Redirect("/offers/offers");
            }

            return Redirect("/error");
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }
    }
}