using Books.Models;

namespace Books.Services
{
	public interface ICreateTokenService
	{
		string CreateJwtToken(User user);
	}
}
