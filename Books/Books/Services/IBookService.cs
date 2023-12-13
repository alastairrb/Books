using Repository.Entities;

namespace Books.Services
{
	public interface IBookService
	{
		Task<List<BookViewModel>> GetBooks();

		Task<BookViewModel> GetBookByBookId(Guid bookId);

		Task<bool> InsertBook(Book book);

		Task<bool> UpdateBook(Book book);

		Task<bool> DeleteBook(Guid bookId);
	}
}
