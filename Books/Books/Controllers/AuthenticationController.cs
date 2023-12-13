using Books.Models;
using Books.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly ICreateTokenService _createTokenService;
		public AuthenticationController(ICreateTokenService createTokenService)
		{
			_createTokenService = createTokenService;
		}
		

		[HttpPost("login")]
		public ActionResult Login(User user)
		{			
			var token = _createTokenService.CreateJwtToken(user);

			return Ok(token);
		}		
	}
}
