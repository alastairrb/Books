using Microsoft.Extensions.Options;
using Repository.Entities;
using Repository.Settings;
using System.Data;
using System.Data.SqlClient;

namespace Repository
{
	public class BookRepository : IRepository
	{
		private readonly ConnectionSetting _connection;

		public BookRepository(IOptions<ConnectionSetting> connection)
		{
			_connection = connection.Value;
		}

		public async Task<List<BookViewModel>> Get()
		{
			var bookList = new List<BookViewModel>();
			
			using (var connect = new SqlConnection(_connection.SQLString))
			{					
				var cmd = new SqlCommand("dbo.GetBooks", connect);
				cmd.CommandType = CommandType.StoredProcedure;

				connect.Open();

				using (var reader = await cmd.ExecuteReaderAsync())
				{						
					while (await reader.ReadAsync())
					{
						bookList.Add(new BookViewModel()
						{
							BookId = (Guid)reader["BookId"],
							Title = reader["Title"].ToString(),
							Author = reader["Author"].ToString(),
							PublicationYear = reader["PublicationYear"].ToString(),
							Publisher = reader["Publisher"].ToString(),
							Category = reader["Category"].ToString(),
							Isbn = reader["BookId"].ToString()
						});
					}
				}
			}
				
			return bookList;
		}

		public async Task<BookViewModel> GetById(Guid bookId)
		{
			var book = new BookViewModel();
						
			using (var connect = new SqlConnection(_connection.SQLString))
			{
				var cmd = new SqlCommand("dbo.GetBookByBookId", connect);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@BookId", bookId);

				connect.Open();
				
				using (var reader = await cmd.ExecuteReaderAsync())
				{
					while (await reader.ReadAsync())
					{
						book.BookId = (Guid)reader["BookId"];
						book.Title = reader["Title"].ToString();
						book.Author = reader["Author"].ToString();
						book.PublicationYear = reader["PublicationYear"].ToString();
						book.Publisher = reader["Publisher"].ToString();
						book.Category = reader["Category"].ToString();
						book.Isbn = reader["BookId"].ToString();
					}
				}
			}			

			return book;
		}

		public async Task<bool> Insert(Book book)
		{
			var success = 0;
			using (var connect = new SqlConnection(_connection.SQLString))
			{
				var cmd = new SqlCommand("dbo.InsertBook", connect);
				cmd.CommandType = CommandType.StoredProcedure;			

				cmd.Parameters.AddWithValue("@BookId", book.BookId);
				cmd.Parameters.AddWithValue("@Title", book.Title);
				cmd.Parameters.AddWithValue("@AuthorId", book.AuthorId);
				cmd.Parameters.AddWithValue("@PublicationYear", book.PublicationYear);
				cmd.Parameters.AddWithValue("@PublisherId", book.PublisherId);
				cmd.Parameters.AddWithValue("@CategoryId", book.CategoryId);
				cmd.Parameters.AddWithValue("@ISBN", book.Isbn);

				connect.Open();

				success = await cmd.ExecuteNonQueryAsync();
			}

			return success < 0 ? true : false;
		}

		public async Task<bool> Update(Book book)
		{
			var success = 0;
			using (var connect = new SqlConnection(_connection.SQLString))
			{
				var cmd = new SqlCommand("dbo.UpdateBook", connect);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@BookId", book.BookId);
				cmd.Parameters.AddWithValue("@Title", book.Title);
				cmd.Parameters.AddWithValue("@AuthorId", book.AuthorId);
				cmd.Parameters.AddWithValue("@PublicationYear", book.PublicationYear);
				cmd.Parameters.AddWithValue("@PublisherId", book.PublisherId);
				cmd.Parameters.AddWithValue("@CategoryId", book.CategoryId);
				cmd.Parameters.AddWithValue("@ISBN", book.Isbn);

				connect.Open();

				success =  await cmd.ExecuteNonQueryAsync();
			}

			return success < 0 ? true : false;
		}

		public async Task<bool> Delete(Guid bookId)
		{
			var success = 0;
			using (var connect = new SqlConnection(_connection.SQLString))
			{
				var cmd = new SqlCommand("dbo.DeleteBook", connect);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@BookId", bookId);

				connect.Open();

				success = await cmd.ExecuteNonQueryAsync();				
			}

			return success < 0 ? true : false;
		}
	}
}
