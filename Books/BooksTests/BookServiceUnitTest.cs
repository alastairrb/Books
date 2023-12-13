using Books.Services;
using Moq;
using Repository;
using Repository.Entities;

namespace BooksTests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		public void GetBooks_Success()
		{
			//Arrange
			var mockBookRepository = new Mock<IRepository>();

			var newBook = new BookViewModel
			{
				BookId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
				Title = "Trackers",
				Author = "Deon Meyer",
				PublicationYear = "2011",
				Publisher = "Penguin"
			};

			//Act
			mockBookRepository
				.Setup(x => x.Get())
				.ReturnsAsync(new List<BookViewModel>
				{
					newBook
				});

			//Assert
			var bookService = new BookService(mockBookRepository.Object);
			var result = bookService.GetBooks();

			Assert.That(result.Result.Count, Is.EqualTo(1));
		}

		[Test]
		public void GetBookByIdTestSuccess()
		{
			//Arrange
			var bookId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6");
			var mockBookRepository = new Mock<IRepository>();

			var newBook = new BookViewModel
			{
				BookId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
				Title = "Trackers",
				Author = "Deon Meyer",
				PublicationYear = "2011",
				Publisher = "Penguin"
			};

			//Act
			mockBookRepository
				.Setup(x => x.GetById(bookId))
				.ReturnsAsync(newBook);

			//Assert 			
			var bookService = new BookService(mockBookRepository.Object);
			var result = bookService.GetBookByBookId(bookId);

			Assert.That(result.Result.BookId, Is.EqualTo(bookId));			
		}

		[Test]
		public Task Service_Should_InsertAsync()
		{
			//Arrange			
			var mock = new Mock<IRepository>();
			var newBook = new Book
			{
				BookId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
				Title = "Trackers",
				AuthorId = Guid.Parse("469bd132-6fa2-4125-806c-e535729b7048"),
				PublicationYear = "2011",
				PublisherId = Guid.Parse("ccec53e5-a959-46ff-a20d-f02540314d16"),
				CategoryId = Guid.Parse("25e71ad1-ae3b-4247-94f1-23b9c1d8cb81")
			};

			mock.Setup(x => x.Insert(It.IsAny<Book>()));

			var service = new BookService(mock.Object);

			//Act
			_= service.InsertBook(newBook);

			//Assert
			//verify that the mock was invoked with the given model.
			mock.Verify(x => x.Insert(newBook));
			return Task.CompletedTask;
		}

		[Test]
		public Task Service_Should_UpdateAsync()
		{
			//Arrange			
			var mock = new Mock<IRepository>();
			var newBook = new Book
			{
				BookId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
				Title = "Trackers",
				AuthorId = Guid.Parse("469bd132-6fa2-4125-806c-e535729b7048"),
				PublicationYear = "2011",
				PublisherId = Guid.Parse("ccec53e5-a959-46ff-a20d-f02540314d16"),
				CategoryId = Guid.Parse("25e71ad1-ae3b-4247-94f1-23b9c1d8cb81")
			};

			mock.Setup(x => x.Insert(It.IsAny<Book>()));

			var service = new BookService(mock.Object);

			//Act
			var updateBook = new Book
			{
				BookId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
				Title = "Trackers Updated",
				AuthorId = Guid.Parse("469bd132-6fa2-4125-806c-e535729b7048"),
				PublicationYear = "2011",
				PublisherId = Guid.Parse("ccec53e5-a959-46ff-a20d-f02540314d16"),
				CategoryId = Guid.Parse("25e71ad1-ae3b-4247-94f1-23b9c1d8cb81")
			};

			_ = service.UpdateBook(updateBook);

			//Assert
			//verify that the mock was invoked with the given model.
			mock.Verify(x => x.Update(updateBook));
			return Task.CompletedTask;
		}

		[Test]
		public Task Service_Should_DeleteAsync()
		{
			//Arrange			
			var mock = new Mock<IRepository>();
			var newBook = new Book
			{
				BookId = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
				Title = "Trackers",
				AuthorId = Guid.Parse("469bd132-6fa2-4125-806c-e535729b7048"),
				PublicationYear = "2011",
				PublisherId = Guid.Parse("ccec53e5-a959-46ff-a20d-f02540314d16"),
				CategoryId = Guid.Parse("25e71ad1-ae3b-4247-94f1-23b9c1d8cb81")
			};

			mock.Setup(x => x.Insert(It.IsAny<Book>()));

			var service = new BookService(mock.Object);

			//Act
			_ = service.DeleteBook(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"));

			//Assert
			//verify that the mock was invoked with the given model.
			mock.Verify(x => x.Delete(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")));
			return Task.CompletedTask;
		}
	}
}