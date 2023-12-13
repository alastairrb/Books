Books Instructions
------------------
1) The project is created in such a way that you should be able to open the solution, rebuild and run the project without.
1.1) Database - restore the database

2) How to use the swagger editor to test your endpoints:
   2.1) /api/Authentication/login -> this endpoint is very basic and creates a jwt token that allows you to authenticate to run the other api endpoints. I kept this very simple and you can
                                     enter any username and password(it doesnt authenticate this against anything). It is important for you to include a role. Either Admin or User to determine
                                     what endpoints you are able to access,
    2.2) Copy the token that is generated and click on the lock to authorize. you enter bearer *token* and hit authorize. You will then be able to access the endpints depending on your role.
    2.2) /Book/GetBooks - Gets a list of all the books (Admin/User role)
         /Book/GetBookByBookId - Get a book by it's id (Admin) -> can test with the bookId from the query that returns a list of books
         /Book/InsertBook - inserts a book (Admin) 
         /Book/UpdateBook - updates a book (Admin)
         /Book/Delete - deletes a book (Admin)
         For the add/Update/Delete you can test with the following data:
         {
          "bookId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "title": "Trackers",
          "authorId": "469bd132-6fa2-4125-806c-e535729b7048",
          "publicationYear": "2011",
          "publisherId": "ccec53e5-a959-46ff-a20d-f02540314d16",
          "categoryId": "25e71ad1-ae3b-4247-94f1-23b9c1d8cb81",
          "isbn": "9781234567897"
        }
3) Design
   3.1) I used a very simple implementation of the repository pattern without implementing the unit of work as I didnt feel it was necessary for this design. The repository is implemented in
        a seperate project and therefore can be switched out if needed without affecting the main project.
   3.2) I have implemented a service layer where I would usually implement any business logic related to the program but as this is very simple it functions more like an adapter between the
        controller and repository,
   3.3) Controller is lightweight and has the authenticated api endpoints
   3.4) For simplicity's sake I have only implented CRUD for the book table and I have two models, one for returning the data from the Get queries and one for Inserting and Updating.

4) Error Handling - I implemented a some custom middleware which should handle all erorrs without polluting the codebase with try/catches everywhere. I am not sure if thia is exaclty what you
   were looking for but I like this approach as it is neat and easy to implement.

5) I use the IOptions pattern to get the connectionstring but use configure to get the data for the generation of the jwt token

6) I use dependancy injection to inject what is needed into the various classes. this ensures that the code is loosely coupled and helps with the unit testing.

7) Which brings me to unit test. I wrote some basic service layer test to see if the service was working as expected. Unfortunately I ran out of time so I was only able to
   include one controller test. I only tested the positives for these as I usually test both positives an dnegatives when it is more a specifiv business unit of work to be 
   tested ie. Calculations etc
   We generally write more integration test on this side although we are trying to change that but I ran out of time to implement integration tests.
   Unit tests are something that I know needs a bit of work from my side and I am definitely looking forward to having an opportunity to do that.
   



    

