using Repository.Entities;

namespace Repository
{
	public interface IRepository
	{
		Task<List<BookViewModel>> Get();

		Task<BookViewModel> GetById(Guid bookId);

		Task<bool> Insert(Book book);

		Task<bool> Update(Book book);

		Task<bool> Delete(Guid bookId);
	}
}
