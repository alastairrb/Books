namespace Repository.Entities
{
	public class BookViewModel
	{
		public Guid BookId { get; set; }

		public string Title { get; set; }

		public string Author { get; set; }

		public string PublicationYear { get; set; }

		public string Publisher { get; set; }

		public string Category { get; set; }

		public string Isbn { get; set; }
	}
}
