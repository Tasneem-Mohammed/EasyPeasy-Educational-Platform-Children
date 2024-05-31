//using NewEasyPeasy.Models;
//using NewEasyPeasy.Pages;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using System.ComponentModel.DataAnnotations;
//using System.Data;

//namespace NewEasyPeasy.Pages
//{
//    public class SignModel : PageModel
//    {

//        [BindProperty]
//        [EmailAddress]
//        public string Email { get; set; }

//        [BindProperty]
//        public string password { get; set; }


//        private readonly ILogger<SignModel> _logger;
//        private readonly DB db;
//        public bool IsValidCredentials { get; set; }
//        public SignModel(ILogger<SignModel> logger, DB db)
//        {
//            _logger = logger;
//            this.db = db;

//        }
//        public void OnGet()
//        {
//        }

//        public IActionResult OnPost()
//        {
//            if (ModelState.IsValid)
//            {
//                IsValidCredentials = db.CheckUserCredentials(Email, password);

//                if (IsValidCredentials)
//                {
//                    // Redirect to the Student page upon successful login
//                    return RedirectToAction("/Courses");
//                }
//                else
//                {
//                    return Page();
//                }
//            }

//            return Page();
//        }
//    }
//}
