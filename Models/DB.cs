using System.Data;
using System.Data.SqlClient;



namespace NewEasyPeasy.Models
{ 
}


    public class DB
    {   
        public SqlConnection con { get; set; }
        public DB() 
        {
            string conStr = "Data Source=TASNEEM;Initial Catalog=NewEasy;Integrated Security=True";
            con= new SqlConnection(conStr);
        }
        //Read Specific Table
        public DataTable ReadTable() { 
            DataTable dt = new DataTable();
            string Q = @"Select * From [User ]";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(Q, con);
                dt.Load(cmd.ExecuteReader());
            }
            catch(SqlException ex)
            {

            }
            finally
            {
                con.Close();
            }
            return dt;
        }
    //// DB classes from Taasneem:
    public DataTable ReadStudentTable(string id)
    {
        DataTable dt = new DataTable();
        string query = @"SELECT
                        U.Name AS StudentName,
                        S.UserID AS StudentID,
                        S.Age AS StudentAge,
                        U.Email AS StudentEmail
                    FROM
                        Parent P
                    INNER JOIN
                        Student S ON P.childID = S.UserID
                    INNER JOIN
                        [User] U ON S.UserID = U.UserID
                    WHERE
                        P.UserID = @id";

        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            dt.Load(cmd.ExecuteReader());
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Error: " + ex.ToString());
        }
        finally
        {
            con.Close();
        }

        return dt;
    }
    public DataTable ReadStudentCourses(string studentId)
    {
        DataTable dt = new DataTable();
        string query = @"SELECT
                        C.CourseName,
                        C.CourseID,
                        C.Quiz,
                        U.Name AS TeacherName
                    FROM
                        Register R
                    INNER JOIN
                        Course C ON R.CourseID = C.CourseID
                    INNER JOIN
                        Teach T ON C.CourseID = T.CourseID
                    INNER JOIN
                        Teacher Te ON T.UserID = Te.UserID
                    INNER JOIN
                        [User] U ON Te.UserID = U.UserID
                    WHERE
                        R.UserID = @StudentID";

        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@StudentID", studentId);
            dt.Load(cmd.ExecuteReader());
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Error: " + ex.ToString());
        }
        finally
        {
            con.Close();
        }

        return dt;
    }
    public DataTable ReadTeacherCourses(string teacherId)
    {
        DataTable dt = new DataTable();
        string query = @"
        SELECT
            S.UserID AS StudentID,
            U.Name AS StudentName,
            C.CourseName,
            C.CourseID,
            S.Score,
            U_teacher.Name AS TeacherName
        FROM
            Teach T
        INNER JOIN
            Course C ON T.CourseID = C.CourseID
        INNER JOIN
            Register R ON C.CourseID = R.CourseID
        INNER JOIN
            Student S ON R.UserID = S.UserID
        INNER JOIN
            [User] U ON S.UserID = U.UserID
        INNER JOIN
            [User] U_teacher ON T.UserID = U_teacher.UserID
        WHERE
            T.UserID = @TeacherID";


        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@TeacherID", teacherId);
            dt.Load(cmd.ExecuteReader());
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Error: " + ex.ToString());
        }
        finally
        {
            con.Close();
        }

        return dt;
    }
    public string GetParentName(string userId)
    {
        string parentName = string.Empty;

        try
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            string query = "SELECT U.Name FROM Parent P JOIN [User] U ON P.UserID = U.UserID WHERE P.UserID = @ID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ID", userId);

            object result = cmd.ExecuteScalar();

            if (result != null)
            {
                parentName = result.ToString();
            }
            else
            {
                Console.WriteLine("No data found for the given user ID.");
            }
        }
        catch (SqlException ex)
        {
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        return parentName;
    }

    //public DataTable ReadTable(string tableName)
    //{
    //    DataTable dt = new DataTable();
    //    using (SqlConnection con = new SqlConnection(conStr))
    //    {
    //        string Query1 = $"SELECT * FROM {tableName}";

    //        try
    //        {
    //            con.Open(); // 1 - open the database!!!
    //            SqlCommand cmd = new SqlCommand(Query1, con);
    //            dt.Load(cmd.ExecuteReader());


    //        }
    //        catch (SqlException ex)
    //        {

    //        }
    //        finally
    //        {
    //            con.Close();
    //        }
    //    }
    //    return dt;
    //}
    //public DataTable ReadStudentTable(string id)
    //{
    //    DataTable dt = new DataTable();
    //    string query = $"SELECT\r\n    U.Name AS StudentName,\r\n    S.UserID AS StudentID,\r\n    S.Age AS StudentAge,\r\n    U.Email AS StudentEmail\r\nFROM\r\n    Parent P\r\nINNER JOIN\r\n    Student S ON P.childID = S.UserID\r\nINNER JOIN\r\n    [User] U ON S.UserID = U.UserID\r\nWHERE\r\n    P.UserID = @id";
    //    try
    //    {
    //        con.Open();
    //        SqlCommand cmd = new SqlCommand(query, con);
    //        cmd.Parameters.AddWithValue("@id", id);
    //        dt.Load(cmd.ExecuteReader());
    //    }
    //    catch (SqlException ex)
    //    {

    //        Console.WriteLine("eroooooooooooooooooor",ex.ToString());
    //    }
    //    finally { con.Close(); }
    //    return dt;
    //}
    ////
    ///
    // DB CLASS FROM AHMED contains new items:
    public DataTable ReadStudent(string id)
    {
        DataTable dt = new DataTable();
        string Q = $"SELECT \r\n    Course.CourseName,\r\n    (SELECT u.Name FROM [User] u WHERE u.UserId = t.UserId) AS TeacherName,\r\n    Course.Quiz,\r\n\tScore\r\nFROM \r\n    Course\r\nJOIN \r\n    Student t ON Course.CourseId = t.CourseId AND t.UserID = @id \r\n\r\nORDER BY \r\n    Course.CourseName;";
        try
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(Q, con);
            cmd.Parameters.AddWithValue("@id", id); // Assuming id is a string
            dt.Load(cmd.ExecuteReader());
        }
        catch (SqlException ex)
        {

        }
        finally { con.Close(); }
        return dt;
    }
    public void Insert(string email, string name, string password, string useri)
    {

        string Q = $"INSERT INTO [User] ([Email], [Name], [Password], [UserID])\r\nVALUES(@email, @name, @password, @useri)";
        try
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(Q, con))
            {
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar) { Value = email });
                cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar) { Value = name });
                cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar) { Value = password });


                cmd.Parameters.Add(new SqlParameter("@useri", SqlDbType.NVarChar) { Value = useri });


                cmd.ExecuteNonQuery();
            }
        }
        catch (SqlException ex)
        {

        }
        finally { con.Close(); }


    }

    public bool CheckUserCredentials(string email, string password)
    {
        bool userExists = false;
        string query = $"SELECT COUNT(*) FROM [User] WHERE [Email] = @email AND [Password] = @password";

        try
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar) { Value = email });
                cmd.Parameters.Add(new SqlParameter("@password", SqlDbType.NVarChar) { Value = password });

                // Use ExecuteScalar safely by handling DBNull
                object result = cmd.ExecuteScalar();
                int count = result != DBNull.Value ? Convert.ToInt32(result) : 0;

                userExists = count > 0;

                // int count = (int)cmd.ExecuteScalar();
                // userExists = count > 0;
            }
        }
        catch (SqlException ex)
        {
        }
        finally
        {
            con.Close();
        }

        return userExists;
    }

    public bool CheckId(string id)
    {
        bool userExists = false;
        string query = $"SELECT COUNT(*) FROM [User] WHERE [UserID] = @id";

        try
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.NVarChar) { Value = id });

                // Use ExecuteScalar safely by handling DBNull
                object result = cmd.ExecuteScalar();
                int count = result == DBNull.Value ? 0 : 1;

                userExists = count == 0;

                // int count = (int)cmd.ExecuteScalar();
                // userExists = count > 0;
            }
        }
        catch (SqlException ex)
        {
        }
        finally
        {
            con.Close();
        }

        return userExists;
    }

    public string GetId(string email)
    {
        string userid = null; // Initialize with a default value

        string query = "SELECT [USERID] FROM [User] WHERE Email = @email";

        try
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar) { Value = email });

                // Use ExecuteScalar safely by handling DBNull
                object result = cmd.ExecuteScalar();
                userid = result != DBNull.Value ? (string)result : null;
            }
        }
        catch (SqlException ex)
        {
            // Handle the exception, log, or throw if needed
        }
        finally
        {
            con.Close();
        }

        return userid;
    }
    public string GetName(string email)
    {
        string username = null; // Initialize with a default value

        string query = "SELECT [Name] FROM [User] WHERE Email = @email";

        try
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar) { Value = email });

                // Use ExecuteScalar safely by handling DBNull
                object result = cmd.ExecuteScalar();
                username = result != DBNull.Value ? (string)result : null;
            }
        }
        catch (SqlException ex)
        {
            // Handle the exception, log, or throw if needed
        }
        finally
        {
            con.Close();
        }

        return username;
    }

}

