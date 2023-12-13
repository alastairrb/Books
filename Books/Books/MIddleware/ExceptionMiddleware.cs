namespace Books.MIddleware
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _nextMiddleware;
		private readonly ILogger<ExceptionMiddleware> _logger;

		public ExceptionMiddleware(RequestDelegate nextMiddleware, ILogger<ExceptionMiddleware> logger )
		{
			_nextMiddleware = nextMiddleware;
			_logger = logger;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _nextMiddleware(context);
			}
			catch(Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				await context.Response.WriteAsync(ex.Message);
			}
		}
	}
}
