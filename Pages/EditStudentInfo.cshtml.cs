using System;
using System.Data;
using System.Data.SqlClient;
using NewEasyPeasy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NewEasyPeasy.Pages
{
    public class EditStudentInfoModel : PageModel
    {
        public string Message = "Error Happened";

        [BindProperty(SupportsGet = true)]
        public UpdateInfo Parent { get; set; }
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string UserID { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public int Age { get; set; }


        public IActionResult OnPost()
        {
            string connectionString = "Data Source = TASNEEM; Initial Catalog = NewEasy; Integrated Security = True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string userUpdateSql = "UPDATE [User] SET Name = @Name, Email = @Email WHERE UserID = @UserID";
                    using (SqlCommand userCommand = new SqlCommand(userUpdateSql, connection))
                    {
                        userCommand.Parameters.AddWithValue("@Name", Parent.Name);
                        userCommand.Parameters.AddWithValue("@Email", Parent.Email);
                        userCommand.Parameters.AddWithValue("@UserID", Parent.UserID);

                        userCommand.ExecuteNonQuery();
                    }

                    //// Step 2: Update Student table
                    //string studentUpdateSql = "UPDATE [Student] SET Age = @Age WHERE UserID = @UserID";
                    //using (SqlCommand studentCommand = new SqlCommand(studentUpdateSql, connection))
                    //{
                    //    studentCommand.Parameters.AddWithValue("@Age", Age);
                    //    studentCommand.Parameters.AddWithValue("@UserID", Parent.UserID);

                    //    studentCommand.ExecuteNonQuery();
                    //}
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    Console.WriteLine(Message);
                }
            }

            return RedirectToPage("/StudentInfo");
        }
        [BindProperties(SupportsGet = true)]

        public class UpdateInfo
        {
            public string UserID { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }

        }


    }
}