using ChamCong2.API.Models;
using ChamCong2.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static ChamCong2.API.Models.Response;

namespace ChamCong2.API.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class LogginController : ControllerBase
    {
        private readonly ChamCongDbContext chamCongDbContext;
        private readonly AppSettings appSettings;

        public LogginController(ChamCongDbContext chamCongDbContext, IOptionsMonitor<AppSettings> optionsMonitor)
        {
            this.chamCongDbContext = chamCongDbContext;
            this.appSettings = optionsMonitor.CurrentValue;
        }
        [HttpPost("login")]
        public async Task<IActionResult> DangNhap(UserCred model)
        {
            try
            {
                var checkuser = chamCongDbContext.im_Users.SingleOrDefault(p => p.Username == model.Username && model.Password == p.Passwword);
                if (checkuser == null) //không đúng
                {
                    return Ok(new APIReponsitory(false, "Invalid username/password"));
                }
                else
                {
                   
                    return Ok(new APIReponsitory(true, "Authenticate success", GenerateToken(checkuser)));
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi không lấy ra được token");
            }
        }
        private string GenerateToken(im_User nguoiDung)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(appSettings.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, nguoiDung.Username)                   
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescription);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
