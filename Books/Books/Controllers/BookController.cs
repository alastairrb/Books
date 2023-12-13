using Books.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;

namespace Books.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class BookController : ControllerBase
	{
		private readonly IBookService _bookService;
		public BookController(IBookService bookService)
		{
			_bookService = bookService;
		}	

		[HttpGet("GetBooks"), Authorize(Roles = "Admin, User")]
		public async Task<IActionResult> Get()
		{			
			var bookList = await _bookService.GetBooks();

			if (bookList != null)
				return Ok(bookList);
			else
				return NotFound("No Books Found");
		}

		[HttpGet("GetBookByBookId"), Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetBookByBookId(Guid bookId)
		{
			var book = await _bookService.GetBookByBookId(bookId);

			if (book != null)
				return Ok(book);
			else
				return NotFound("Book Not Found");
		}		

		[HttpPost("InsertBook"), Authorize(Roles = "Admin")]
		public async Task<IActionResult> InsertBook(Book book)
		{
			var result = await _bookService.InsertBook(book);

			if (!result)
				return BadRequest(result);
			else
				return Ok();
		}

		[HttpPut("UpdateBook"), Authorize(Roles = "Admin")]
		public async Task<IActionResult> Update(Book book)
		{
			var result = await _bookService.UpdateBook(book);
			
			if (!result)
				return BadRequest(result);
			else
				return Ok();

		}	

		[HttpDelete("Delete"), Authorize(Roles = "Admin")]
		public async Task<IActionResult> DeleteBook(Guid bookId)
		{
			var result = await _bookService.DeleteBook(bookId);

			if (!result)
				return BadRequest(result);
			else
				return Ok();
		}
	}
}
