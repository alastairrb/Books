namespace Repository.Entities
{
	public class Book
	{
		public Guid BookId { get; set; }

		public string Title { get; set; }

		public Guid AuthorId { get; set; }

		public string PublicationYear { get; set; }

		public Guid PublisherId { get; set; }

		public Guid CategoryId { get; set; }

		public string Isbn { get; set; }
	}
}
