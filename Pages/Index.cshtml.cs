using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewEasyPeasy.Models;
using System.Data;
namespace NewEasyPeasy.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly DB db;
		public DataTable dt { get; set; } 
		public IndexModel(ILogger<IndexModel> logger, DB db)
		{
			_logger = logger;
			this.db = db;
		}

		public void OnGet()
		{
			//dt = db.ReadTable("Student");
		}
	}
}