using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebAPIJwtDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly JwtAuthenticationManager _jwtAuthenticationManager;

        public WeatherForecastController(JwtAuthenticationManager jwtAuthenticationManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }
        [AllowAnonymous]
        [HttpPost("Authorize")]
        public IActionResult AddUser([FromBody] User user)
        {
            var token = _jwtAuthenticationManager.Authenticate(user.username, user.password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok();
        }
    }
    
}