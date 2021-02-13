using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OpenLoginAPI.Data;
using OpenLoginAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private AppDBContext _context;
        public LoginController(AppDBContext context)
        {
            this._context = context;
        }

       
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var rx = from x in _context.UserRegistration
                             where x.Username == model.UserName && x.Password == model.Password
                             select x;

                    //_context.UserRegistration.FirstOrDefault(model.UserName == "admin" && model.Password == "admin");
                    return Ok(new Response { Status = "Success", Message = "Login Successfully" });
                }
                catch (Exception ex)
                {
                    var exa = ex.Message;
                }
               
            }
            
            return Unauthorized();
        }
    }
}
