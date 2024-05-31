using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Azure.Core;
using Azure;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;



namespace NewEasyPeasy.Pages
{
    public class AdminModel : PageModel { }
//    {
//        public string Message = "Error Happened";

    //        [BindProperty(SupportsGet = true)]
    //        public UpdateInfo Admin { get; set; }
    //        [BindProperty]
    //        public string Name { get; set; }

    //        [BindProperty]
    //        public string UserID { get; set; }

    //        [BindProperty]
    //        public string Email { get; set; }

    //        [BindProperty]
    //        public int Score { get; set; }

    //        [BindProperty]
    //        public int Age { get; set; }





    //        public IActionResult OnPost()
    //        {
    //            string connectionString = "Data Source=DESKTOP-BG4GFP5;Initial Catalog=NewEasy;Integrated Security=True";

    //            using (SqlConnection connection = new SqlConnection(connectionString))
    //            {
    //                try
    //                {
    //                    connection.Open();

    //                    // Step 1: Update User table
    //                    string userUpdateSql = "UPDATE [User] SET Name = @Name, Email = @Email WHERE UserID = @UserID";
    //                    using (SqlCommand userCommand = new SqlCommand(userUpdateSql, connection))
    //                    {
    //                        userCommand.Parameters.AddWithValue("@Name", Admin.Name);
    //                        userCommand.Parameters.AddWithValue("@Email", Admin.Email);
    //                        userCommand.Parameters.AddWithValue("@UserID", Admin.UserID);

    //                        userCommand.ExecuteNonQuery();
    //                    }

    //                    // Step 2: Update Student table
    //                    string studentUpdateSql = "UPDATE [Student] SET Score = @Score, Age = @Age WHERE UserID = @UserID";
    //                    using (SqlCommand studentCommand = new SqlCommand(studentUpdateSql, connection))
    //                    {
    //                        studentCommand.Parameters.AddWithValue("@Score", Score);
    //                        studentCommand.Parameters.AddWithValue("@Age", Age);
    //                        studentCommand.Parameters.AddWithValue("@UserID", Admin.UserID);

    //                        studentCommand.ExecuteNonQuery();
    //                    }
    //                }
    //                catch (Exception ex)
    //                {
    //                    Message = ex.Message;
    //                    Console.WriteLine(Message);
    //                }
    //            }

    //            return RedirectToPage("/Admin");
    //        }
    //        [BindProperties(SupportsGet = true)]
    //        public class UpdateInfo
    //        {
    //            public string UserID { get; set; }
    //            public string Name { get; set; }
    //            public string Email { get; set; }
    //            public int Age { get; set; }

    //            public int Score { get; set; }
    //        }


    //    }
}



//namespace NewEasyPeasy.Pages
//{
//    public class AdminModel : PageModel
//    {
//        public string Message = "Error Happened";

//        [BindProperty(SupportsGet = true)]
//        public UpdateInfo Admin { get; set; }
//        [BindProperty]
//        public string Name { get; set; }

//        [BindProperty]
//        public string UserID { get; set; }

//        [BindProperty]
//        public string Email { get; set; }

//        [BindProperty]
//        public int Score { get; set; }

//        [BindProperty]
//        public int Age { get; set; }





//        public IActionResult OnPost()
//        {
//            string connectionString = "Data Source=DESKTOP-BG4GFP5;Initial Catalog=NewEasy;Integrated Security=True";

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();

//                    // Step 1: Update User table
//                    string userUpdateSql = "UPDATE [User] SET Name = @Name, Email = @Email WHERE UserID = @UserID";
//                    using (SqlCommand userCommand = new SqlCommand(userUpdateSql, connection))
//                    {
//                        userCommand.Parameters.AddWithValue("@Name", Admin.Name);
//                        userCommand.Parameters.AddWithValue("@Email", Admin.Email);
//                        userCommand.Parameters.AddWithValue("@UserID", Admin.UserID);

//                        userCommand.ExecuteNonQuery();
//                    }

//                    // Step 2: Update Student table
//                    string studentUpdateSql = "UPDATE [Student] SET Score = @Score, Age = @Age WHERE UserID = @UserID";
//                    using (SqlCommand studentCommand = new SqlCommand(studentUpdateSql, connection))
//                    {
//                        studentCommand.Parameters.AddWithValue("@Score", Score);
//                        studentCommand.Parameters.AddWithValue("@Age", Age);
//                        studentCommand.Parameters.AddWithValue("@UserID", Admin.UserID);

//                        studentCommand.ExecuteNonQuery();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Message = ex.Message;
//                    Console.WriteLine(Message);
//                }
//            }

//            return RedirectToPage("/Admin");
//        }
//        [BindProperties(SupportsGet = true)]
//        public class UpdateInfo
//        {
//            public string UserID { get; set; }
//            public string Name { get; set; }
//            public string Email { get; set; }
//            public int Age { get; set; }

//            public int Score { get; set; }
//        }





//public IActionResult OnPostDelete()
//        {
//            string connectionString = "Data Source=DESKTOP-BG4GFP5;Initial Catalog=NewEasy;Integrated Security=True";

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();

//                    // Delete record from User table
//                    string userDeleteSql = "DELETE FROM [User] WHERE UserID = @UserID";
//                    using (SqlCommand userCommand = new SqlCommand(userDeleteSql, connection))
//                    {
//                        userCommand.Parameters.AddWithValue("@UserID", Admin.UserID);

//                        userCommand.ExecuteNonQuery();
//                    }

//                    // Delete record from Student table
//                    string studentDeleteSql = "DELETE FROM [Student] WHERE UserID = @UserID";
//                    using (SqlCommand studentCommand = new SqlCommand(studentDeleteSql, connection))
//                    {
//                        studentCommand.Parameters.AddWithValue("@UserID", Admin.UserID);

//                        studentCommand.ExecuteNonQuery();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Message = ex.Message;
//                    Console.WriteLine(Message);
//                }
//            }

//            return RedirectToPage("/Admin");
//        }

//        public class UpdateInfo
//        {
//            public string UserID { get; set; }
//            public string Name { get; set; }
//            public string Email { get; set; }
//            public int Score { get; set; }
//            public int Age { get; set; }
//        }
//    }
//}

//namespace NewEasyPeasy.Pages
//{
//    public class AdminModel : PageModel
//    {
//        public string Message = "Error Happened";

//        [BindProperty(SupportsGet = true)]
//        public UpdateInfo Admin { get; set; }

//        public IActionResult OnPost()
//        {
//            string connectionString = "Data Source=DESKTOP-BG4GFP5;Initial Catalog=NewEasy;Integrated Security=True";

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();

//                    // Step 1: Update User table
//                    string userUpdateSql = "UPDATE [User] SET Name = @Name, Email = @Email WHERE UserID = @UserID";
//                    using (SqlCommand userCommand = new SqlCommand(userUpdateSql, connection))
//                    {
//                        userCommand.Parameters.AddWithValue("@Name", Admin.Name);
//                        userCommand.Parameters.AddWithValue("@Email", Admin.Email);
//                        userCommand.Parameters.AddWithValue("@UserID", Admin.UserID);

//                        userCommand.ExecuteNonQuery();
//                    }

//                    // Step 2: Update Student table
//                    string studentUpdateSql = "UPDATE [Student] SET Score = @Score, Age = @Age WHERE UserID = @UserID";
//                    using (SqlCommand studentCommand = new SqlCommand(studentUpdateSql, connection))
//                    {
//                        studentCommand.Parameters.AddWithValue("@Score", Admin.Score);
//                        studentCommand.Parameters.AddWithValue("@Age", Admin.Age);
//                        studentCommand.Parameters.AddWithValue("@UserID", Admin.UserID);

//                        studentCommand.ExecuteNonQuery();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Message = ex.Message;
//                    Console.WriteLine(Message);
//                    return Page();
//                }
//            }

//            return RedirectToPage("/Admin");
//        }

//        public IActionResult OnPostDelete()
//        {
//            string connectionString = "Data Source=DESKTOP-BG4GFP5;Initial Catalog=NewEasy;Integrated Security=True";

//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                try
//                {
//                    connection.Open();

//                    // Delete record from User table
//                    string userDeleteSql = "DELETE FROM [User] WHERE UserID = @UserID";
//                    using (SqlCommand userCommand = new SqlCommand(userDeleteSql, connection))
//                    {
//                        userCommand.Parameters.AddWithValue("@UserID", Admin.UserID);

//                        userCommand.ExecuteNonQuery();
//                    }

//                    // Delete record from Student table
//                    string studentDeleteSql = "DELETE FROM [Student] WHERE UserID = @UserID";
//                    using (SqlCommand studentCommand = new SqlCommand(studentDeleteSql, connection))
//                    {
//                        studentCommand.Parameters.AddWithValue("@UserID", Admin.UserID);

//                        studentCommand.ExecuteNonQuery();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Message = ex.Message;
//                    Console.WriteLine(Message);
//                    return Page();
//                }
//            }

//            return RedirectToPage("/Admin");
//        }

//        public class UpdateInfo
//        {
//            public string UserID { get; set; }
//            public string Name { get; set; }
//            public string Email { get; set; }
//            public int Score { get; set; }
//            public int Age { get; set; }
//        }
//    }
//}







