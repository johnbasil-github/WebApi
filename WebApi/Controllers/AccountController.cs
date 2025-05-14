using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entity.Ḍto;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {   
        private readonly UserManager<IdentityUser> _userManager;
        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            
        }


        [HttpPost("Authenticate")]

        public async Task<IActionResult> Authenticate(UserInfoRequestDto request)
        {
            if(request == null)
            {
                return BadRequest("Invalid Credentials");
            }

            var user = await _userManager.FindByNameAsync(request.UserName);

            var result =await _userManager.CheckPasswordAsync(user, request.Password);

            if(result)
            {
                return Ok(user);
            }
            return BadRequest("Invalid Credentials");

        }
    }
}
