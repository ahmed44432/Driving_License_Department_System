
using clsDataConnection;
using System;
using System.Data;
using Microsoft.Data.SqlClient;



namespace DataAccessLayer;

public class clsUserDataAccessLayer
{
    public static DataTable GetAllUsers()
    {
        
        SqlConnection connection = new SqlConnection(clsConnection.ConnectString);
        string textCommand = "select \r\n                                      UserID as [User ID]\r\n                                    , People.PersonID as [Person ID]\r\n                                    , LTRIM(RTRIM(\r\n                                            CONCAT(\r\n                                                People.FirstName, ' ',\r\n                                                People.SecondName, ' ',\r\n                                                People.ThirdName, ' ',\r\n                                                People.LastName\r\n                                            )\r\n                                        )) AS [Full Name]\r\n                                    ,UserName as [User Name]\r\n                                    ,IsActive \r\n                                    from Users\r\n                                    join People\r\n                                    on People.PersonID = Users.PersonID";
        SqlCommand command = new SqlCommand(textCommand, connection);
        DataTable table = new DataTable();
        try
        {

            
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                table.Load(reader);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            connection.Close();
        }
        return table;
    }

    public static DataTable GetAllUsersByUserID(int userid)
    {
        SqlConnection connection = new SqlConnection(clsConnection.ConnectString);
        string textCommand = "select \r\n                                      UserID as [User ID]\r\n                                    , People.PersonID as [Person ID]\r\n                                    , LTRIM(RTRIM(\r\n                                            CONCAT(\r\n                                                People.FirstName, ' ',\r\n                                                People.SecondName, ' ',\r\n                                                People.ThirdName, ' ',\r\n                                                People.LastName\r\n                                            )\r\n                                        )) AS [Full Name]\r\n                                    ,UserName as [User Name]\r\n                                    ,IsActive \r\n                                    from Users\r\n                                    join People\r\n                                    on People.PersonID = Users.PersonID\r\n                                    where UserID = @userid";
        SqlCommand command = new SqlCommand(textCommand, connection);
        command.Parameters.AddWithValue("@userid", userid);
        DataTable table = new DataTable();
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                table.Load(reader);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            connection.Close();
        }
        return table;
    }

    public static DataTable GetAllUsersByPersonID(int personid)
    {
        SqlConnection connection = new SqlConnection(clsConnection.ConnectString);
        string textCommand = "select \r\n                                      UserID as [User ID]\r\n                                    , People.PersonID as [Person ID]\r\n                                    , LTRIM(RTRIM(\r\n                                            CONCAT(\r\n                                                People.FirstName, ' ',\r\n                                                People.SecondName, ' ',\r\n                                                People.ThirdName, ' ',\r\n                                                People.LastName\r\n                                            )\r\n                                        )) AS [Full Name]\r\n                                    ,UserName as [User Name]\r\n                                    ,IsActive \r\n                                    from Users\r\n                                    join People\r\n                                    on People.PersonID = Users.PersonID\r\n                                    where People.PersonID = @personid";
        SqlCommand command = new SqlCommand(textCommand, connection);
        command.Parameters.AddWithValue("@personid", personid);
        DataTable table = new DataTable();
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                table.Load(reader);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            connection.Close();
        }
        return table;
    }

    public static DataTable GetAllUsersByUserName(string username)
    {
        SqlConnection connection = new SqlConnection(clsConnection.ConnectString);
        string textCommand = "select \r\n                                      UserID as [User ID]\r\n                                    , People.PersonID as [Person ID]\r\n                                    , LTRIM(RTRIM(\r\n                                            CONCAT(\r\n                                                People.FirstName, ' ',\r\n                                                People.SecondName, ' ',\r\n                                                People.ThirdName, ' ',\r\n                                                People.LastName\r\n                                            )\r\n                                        )) AS [Full Name]\r\n                                    ,UserName as [User Name]\r\n                                    ,IsActive \r\n                                    from Users\r\n                                    join People\r\n                                    on People.PersonID = Users.PersonID\r\n                                     where UserName like @username";
        SqlCommand command = new SqlCommand(textCommand, connection);
        command.Parameters.AddWithValue("@username", username + "%");
        DataTable table = new DataTable();
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                table.Load(reader);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            connection.Close();
        }
        return table;
    }

    public static DataTable GetAllUsersByFullName(string fullname)
    {
        SqlConnection connection = new SqlConnection(clsConnection.ConnectString);
        string textCommand = "select * from (select \r\n                                     UserID as [User ID]\r\n                                   , People.PersonID as [Person ID]\r\n                                   , LTRIM(RTRIM(\r\n                                           CONCAT(\r\n                                               People.FirstName, ' ',\r\n                                               People.SecondName, ' ',\r\n                                               People.ThirdName, ' ',\r\n                                               People.LastName\r\n                                           )\r\n                                       )) AS [Full Name]\r\n                                   ,UserName as [User Name]\r\n                                   ,IsActive \r\n                                   from Users\r\n                                   join People\r\n                                   on People.PersonID = Users.PersonID) as t\r\n                                   where t.[Full Name] like @fullname";
        SqlCommand command = new SqlCommand(textCommand, connection);
        command.Parameters.AddWithValue("@fullname", fullname + "%");
        DataTable table = new DataTable();
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                table.Load(reader);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            connection.Close();
        }
        return table;
    }

    public static DataTable GetUsersByActivationStatus(bool isactive)
    {
        SqlConnection connection = new SqlConnection(clsConnection.ConnectString);
        string textCommand = "select \r\n                                      UserID as [User ID]\r\n                                    , People.PersonID as [Person ID]\r\n                                    , LTRIM(RTRIM(\r\n                                            CONCAT(\r\n                                                People.FirstName, ' ',\r\n                                                People.SecondName, ' ',\r\n                                                People.ThirdName, ' ',\r\n                                                People.LastName\r\n                                            )\r\n                                        )) AS [Full Name]\r\n                                    ,UserName as [User Name]\r\n                                    ,IsActive \r\n                                    from Users\r\n                                    join People\r\n                                    on People.PersonID = Users.PersonID\r\n                                    where IsActive = @isactive";
        SqlCommand command = new SqlCommand(textCommand, connection);
        command.Parameters.AddWithValue("@isactive", isactive);
        DataTable table = new DataTable();
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                table.Load(reader);
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            connection.Close();
        }
        return table;
    }

    public static bool IsUserExist(string username, string password)
    {
        bool result = false;
        SqlConnection connection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = @"select * from Users   
            where  UserName = @username and Password = @password";
        SqlCommand command = new SqlCommand(cmdText, connection);
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@password", password);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            result = reader.HasRows;
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }
        return result;
    }

    public static bool IsUserExist(string username)
    {
        bool result = false;
        SqlConnection connection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from Users\r\n                             where  UserName = @username";
        SqlCommand command = new SqlCommand(cmdText, connection);
        command.Parameters.AddWithValue("@username", username);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            result = reader.HasRows;
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }
        return result;
    }

    public static bool IsUserExist(int personid)
    {
        bool result = false;
        SqlConnection connection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from Users\r\n                             where  PersonID = @personid";
        SqlCommand command = new SqlCommand(cmdText, connection);
        command.Parameters.AddWithValue("@personid", personid);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            result = reader.HasRows;
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }
        return result;
    }

    public static bool IsUserActive(string username)
    {
        bool result = false;
        SqlConnection connection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select 1 from Users\r\n                                where UserName  like @username and IsActive like 1";
        SqlCommand command = new SqlCommand(cmdText, connection);
        command.Parameters.AddWithValue("@username", username);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            result = reader.HasRows;
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }
        return result;
    }

    public static int AddNewUser(int personid, string username, string password, bool isactive)
    {
        SqlConnection connection = new SqlConnection(clsConnection.ConnectString);
        int userID = -1;
        string textCommand = "INSERT INTO [dbo].[Users]\r\n               ([PersonID]\r\n               ,[UserName]\r\n               ,[Password]\r\n               ,[IsActive])\r\n            VALUES\r\n               (@PersonID\r\n               ,@UserName\r\n               ,@Password\r\n               ,@IsActive)\r\n            SELECT SCOPE_IDENTITY();";
        SqlCommand command = new SqlCommand(textCommand, connection);
        command.Parameters.AddWithValue("@PersonID", personid);
        command.Parameters.AddWithValue("@UserName", username);
        command.Parameters.AddWithValue("@Password", password);
        command.Parameters.AddWithValue("@IsActive", isactive);
        try
        {
            connection.Open();
            object result = command.ExecuteScalar();
            if (result != null && int.TryParse(result.ToString(), out var personID))
            {
                userID = personID;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            connection.Close();
        }
        return userID;
    }

    public static bool UpdateUser(int userid, int personid, string username, string password, bool isactive)
    {
        SqlConnection connection = new SqlConnection(clsConnection.ConnectString);
        int rowEffected = 0;
        string textCommand = "UPDATE [dbo].[Users]\r\n               SET [PersonID] = @PersonID \r\n                  ,[UserName] = @UserName \r\n                  ,[Password] = @Password \r\n                  ,[IsActive] = @IsActive \r\n             WHERE UserID = @UserID";
        SqlCommand command = new SqlCommand(textCommand, connection);
        command.Parameters.AddWithValue("@UserID", userid);
        command.Parameters.AddWithValue("@PersonID", personid);
        command.Parameters.AddWithValue("@UserName", username);
        command.Parameters.AddWithValue("@Password", password);
        command.Parameters.AddWithValue("@IsActive", isactive);
        try
        {
            connection.Open();
            rowEffected = command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            connection.Close();
        }
        return rowEffected > 0;
    }

    public static bool GetUserByUserID(int userid, ref int personid, ref string username, ref string password, ref bool isactive)
    {
        bool result = false;
        SqlConnection connection = new SqlConnection(clsConnection.ConnectString);
        string textCommand = "select * from Users where UserID = @userid";
        SqlCommand command = new SqlCommand(textCommand, connection);
        command.Parameters.AddWithValue("@userid", userid);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                personid = (int)reader["PersonID"];
                username = (string)reader["UserName"];
                password = (string)reader["Password"];
                isactive = (bool)reader["IsActive"];
                result = true;
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            connection.Close();
        }
        return result;
    }

    public static bool GetUserByPersonID(ref int userid, int personid, ref string username, ref string password, ref bool isactive)
    {
        bool result = false;
        SqlConnection connection = new SqlConnection(clsConnection.ConnectString);
        string textCommand = "select * from Users where PersonID = @personid";
        SqlCommand command = new SqlCommand(textCommand, connection);
        command.Parameters.AddWithValue("@personid", personid);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                userid = (int)reader["UserID"];
                username = (string)reader["UserName"];
                password = (string)reader["Password"];
                isactive = (bool)reader["IsActive"];
                result = true;
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            connection.Close();
        }
        return result;
    }

    public static bool GetUserByUserName(ref int userid, ref int personid, ref string username, ref string password, ref bool isactive)
    {
        bool result = false;
        SqlConnection connection = new SqlConnection(clsConnection.ConnectString);
        string textCommand = "select * from Users where UserName like @username";
        SqlCommand command = new SqlCommand(textCommand, connection);
        command.Parameters.AddWithValue("@username", username);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                userid = (int)reader["UserID"];
                personid = (int)reader["PersonId"];
                username = (string)reader["UserName"];
                password = (string)reader["Password"];
                isactive = (bool)reader["IsActive"];
                result = true;
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            connection.Close();
        }
        return result;
    }

    public static bool DeleteUser(int userid)
    {
        int rowsAffected = 0;
        SqlConnection connection = new SqlConnection(clsConnection.ConnectString);
        string textCommand = "DELETE FROM Users WHERE UserID = @id";
        SqlCommand command = new SqlCommand(textCommand, connection);
        command.Parameters.AddWithValue("@id", userid);
        try
        {
            connection.Open();
            rowsAffected = command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            connection.Close();
        }
        return rowsAffected != 0;
    }

    public static bool IsUserLinked(int userid)
    {
        bool result = false;
        SqlConnection connection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "SELECT 1\r\n                WHERE \r\n                    EXISTS (SELECT 1 FROM Applications WHERE CreatedByUserID = @UserID)\r\n                 OR EXISTS (SELECT 1 FROM Licenses WHERE CreatedByUserID = @UserID)\r\n                 OR EXISTS (SELECT 1 FROM TestAppointments WHERE CreatedByUserID = @UserID);\r\n                ";
        SqlCommand command = new SqlCommand(cmdText, connection);
        command.Parameters.AddWithValue("@UserID", userid);
        try
        {
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            result = reader.HasRows;
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            connection.Close();
        }
        return result;
    }
}
