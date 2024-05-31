using NewEasyPeasy.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace NewEasyPeasy.Pages
{
    public class EnrolledCoursesModel : PageModel
    {
        private readonly DB _db;

        public EnrolledCoursesModel(DB db)
        {
            _db = db;
        }

        public DataTable dt { get; set; }

        public void OnGet(string studentId)
        {
            dt = _db.ReadStudentCourses("s-2");
        }
    }
}
