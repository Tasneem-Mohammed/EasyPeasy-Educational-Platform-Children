using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using NewEasyPeasy.Models;
using Microsoft.Extensions.Logging;
using System.Data;

namespace NewEasyPeasy.Pages
{
    public class ParentDashboardModel : PageModel
    {
        private readonly ILogger<ParentDashboardModel> _logger;
        private readonly DB _db;

        public ParentDashboardModel(ILogger<ParentDashboardModel> logger, DB db)
        {
            _logger = logger;
            _db = db;
        }

        public string ParentName { get; set; }

        public void OnGet()
        {
            string userId = "p-2";
            ParentName = _db.GetParentName(userId);
        }
    }
}



