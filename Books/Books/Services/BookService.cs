using Repository;
using Repository.Entities;

namespace Books.Services
{
	public class BookService : IBookService
	{
		private readonly IRepository _bookRepository;
		public BookService(IRepository bookRepository)
		{
			_bookRepository = bookRepository;
		}

		public Task<List<BookViewModel>> GetBooks()
		{
			return _bookRepository.Get();
		}

		public Task<BookViewModel> GetBookByBookId(Guid bookId)
		{
			return _bookRepository.GetById(bookId);
		}

		public async Task<bool> InsertBook(Book book)
		{
			return await _bookRepository.Insert(book);
		}

		public async Task<bool> UpdateBook(Book book)
		{
			return await _bookRepository.Update(book);
		}

		public async Task<bool> DeleteBook(Guid BookId)
		{
			return await _bookRepository.Delete(BookId);
		}
	}
}
