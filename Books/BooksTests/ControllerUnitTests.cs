using Books.Controllers;
using Books.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Repository;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BooksTests
{
	public class ControllerUnitTests
	{
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GetReturnsBook()
        {
            var mockService = new Mock<IBookService>();

            mockService.Setup(repo => repo.GetBooks())
				.ReturnsAsync(new List<BookViewModel>()
				{
					new BookViewModel(), new BookViewModel() 
                });

            var controller = new BookController(mockService.Object);

            var result = controller.Get();

            Assert.IsNotNull(result);
            Assert.That(result, Is.TypeOf<Task<IActionResult>>());
        }
    }
}
