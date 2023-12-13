using Books.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Books.Services
{
	public class CreateTokenService : ICreateTokenService
	{
		private IConfiguration _config;
		public CreateTokenService(IConfiguration config)
		{
			_config = config;
		}		

		public string CreateJwtToken(User user)
		{					
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(ClaimTypes.Role, user.Role)
			};

			var token = new JwtSecurityToken(
				_config["Jwt:Issuer"],
				_config["Jwt:Audience"],
				claims,
				expires: DateTime.Now.AddDays(1),
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(token);			
		}
	}
}
