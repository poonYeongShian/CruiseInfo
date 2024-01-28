using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo2.Dtos;
using ToDo2.Models;
using ToDo2.Services;
using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;


namespace ToDo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        /*
         * Demo sign in, sign out, not sign in yet
         * **/
        private readonly TodoContext _todoContext;

        // Get the constant value(JWT token) from the appsettings.json file
        private readonly IConfiguration _configuration;

        public LoginController(TodoContext todoContext, IConfiguration configuration)
        {
            _todoContext = todoContext;
            _configuration = configuration;
        }

        [HttpPost]
        public string login(LoginPost value)
        {
            // Get user from DB
            var user = (from a in _todoContext.Employees
                        where a.Account == value.Account
                        && a.Password == value.Password
                        select a).SingleOrDefault();

            if (user == null)
            {
                return "帳號密碼錯誤";
            }
            else
            {
                //Store user login info
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Account),
                    new Claim("FullName", user.Name),
                    // new Claim(ClaimTypes.Role, "select")

                    new Claim("EmployeeId", user.EmployeeId.ToString())
                };

                //Get role from user
                var role = from a in _todoContext.Roles
                           where a.EmployeeId == user.EmployeeId
                           select a;

                //Each User can have more than 1 role
                foreach (var temp in role)
                {
                    claims.Add(new Claim(ClaimTypes.Role, temp.Name));
                }

                

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return "Sign in Success";
            }
        }

        [HttpPost("jwtLogin")]
        public string jwtLogin(LoginPost value)
        {
            // Get user from DB
            var user = (from a in _todoContext.Employees
                        where a.Account == value.Account
                        && a.Password == value.Password
                        select a).SingleOrDefault();

            if (user == null)
            {
                return "帳號密碼錯誤";
            }
            else
            {
                //Store user login info
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Email, user.Account),
                    new Claim("FullName", user.Name),
                    // new Claim(ClaimTypes.Role, "select")

                    new Claim(JwtRegisteredClaimNames.NameId, user.EmployeeId.ToString())
                };

                //取出appsettings.json裡的KEY處理
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:KEY"]));

                //設定jwt相關資訊(initialize setting)
                var jwt = new JwtSecurityToken
                (
                    issuer: _configuration["JWT:Issuer"],    // Issuer from appsetting.json
                    audience: _configuration["JWT:Audience"], // Audience from appsetting.json
                    claims: claims,                           // above claim
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );

                //Get role from user
                var role = from a in _todoContext.Roles
                           where a.EmployeeId == user.EmployeeId
                           select a;

                //Each User can have more than 1 role
                foreach (var temp in role)
                {
                    claims.Add(new Claim(ClaimTypes.Role, temp.Name));
                }

                //產生JWT Token
                var token = new JwtSecurityTokenHandler().WriteToken(jwt);

                //回傳JWT Token給認證通過的使用者
                return token;
            }
        }

        [HttpDelete]
        public void logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        [HttpGet("NoLogin")]
        public string noLogin()
        {
            return "未登入";
        }

        [HttpGet("NoAccess")]
        public string noAccess()
        {
            return "沒有權限(no permission)";
        }
    }
}
