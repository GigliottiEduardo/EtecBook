using System.Net.Mail;
using EtecBookAPI.Data;
using EtecBookAPI.DataTransferObjects;
using EtecBookAPI.Helpers;
using EtecBookAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EtecBookAPI.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginDto login)
        {
            if (login == null)
            return BadRequest();

            if (!ModelState.IsValid)
            return BadRequest();

            AppUser user = new();
            if (IsEmail(login.Email))
            {
                user = await _context.Users.FirstOrDefaultAsync(
                  u => u.Email.Equals(login.Email)  
                );
            }
            else
            {
                user = await _context.Users.FirstOrDefaultAsync(
                  u => u.UserName.Equals(login.Email)  
                );
            }
            if (user == null)
                return NotFound(new { Message = "Usuário e/ou Senha Inválidos"});
            if (!PasswordHasher.VerifyPassword(login.Password, user.Password))
                return NotFound(new { Message = "Usuário e/ou senha Inválidos"});

            return Ok(new {Message = "Usuário Automaticado"});
            
            
        }

    private bool IsEmail(string email)
    {
        try
        {
            MailAddress mail = new(email);
            return true;
        }
        catch
        {
            return false;
        }
    }

}
