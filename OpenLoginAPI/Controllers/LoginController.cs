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
        public async Task<JsonResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = from user in _context.UserRegistration
                             where user.Username == model.UserName && user.Password == model.Password
                             select user;

                    // return Ok(new Response { Status = "Success", Message = "Login Successfully" });
                    return new JsonResult("Login Successfully");
                }
                //catches any server error
                catch (Exception ex)
                {
                    var message = ex.Message;
                    //return message;
                }
               
            }
            //return Unauthorized();
            return new JsonResult("Login Failed");
        }
    }
}
