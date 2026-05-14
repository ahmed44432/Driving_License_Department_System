
using clsDataConnection;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public class clsLocalLicenseApplicationDataAccessLayer
{
    public static DataTable GetLocalLicenseApplication()
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "SELECT [LocalDrivingLicenseApplicationID]\r\n                      as [L.D.L.ApplicationID]\r\n                      ,[ClassName]\r\n                      ,[NationalNo]\r\n                      ,[FullName]\r\n                      ,[ApplicationDate]\r\n                      ,[PassedTestCount]\r\n                      ,[Status]\r\n                  FROM [dbo].[LocalDrivingLicenseApplications_View]";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        DataTable dataTable = new DataTable();
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                dataTable.Load(sqlDataReader);
            }

            sqlDataReader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            sqlConnection.Close();
        }

        return dataTable;
    }

    public static DataTable GetAllLocalLicenseApplicationsByAppID(int appid)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "SELECT [LocalDrivingLicenseApplicationID]\r\n                      as [L.D.L.ApplicationID]\r\n                      ,[ClassName]\r\n                      ,[NationalNo]\r\n                      ,[FullName]\r\n                      ,[ApplicationDate]\r\n                      ,[PassedTestCount]\r\n                      ,[Status]\r\n                  FROM [dbo].[LocalDrivingLicenseApplications_View]\r\n                  where LocalDrivingLicenseApplicationID like @appid";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        DataTable dataTable = new DataTable();
        sqlCommand.Parameters.AddWithValue("@appid", appid + "%");
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                dataTable.Load(sqlDataReader);
            }

            sqlDataReader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            sqlConnection.Close();
        }

        return dataTable;
    }

    public static DataTable GetAllLocalLicenseApplicationsByNNO(string nno)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "SELECT [LocalDrivingLicenseApplicationID]\r\n                      as [L.D.L.ApplicationID]\r\n                      ,[ClassName]\r\n                      ,[NationalNo]\r\n                      ,[FullName]\r\n                      ,[ApplicationDate]\r\n                      ,[PassedTestCount]\r\n                      ,[Status]\r\n                  FROM [dbo].[LocalDrivingLicenseApplications_View]\r\n                 where NationalNo like @nno";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        DataTable dataTable = new DataTable();
        sqlCommand.Parameters.AddWithValue("@nno", nno + "%");
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                dataTable.Load(sqlDataReader);
            }

            sqlDataReader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            sqlConnection.Close();
        }

        return dataTable;
    }

    public static DataTable GetAllLocalLicenseApplicationsByFullName(string fullname)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "SELECT [LocalDrivingLicenseApplicationID]\r\n                      as [L.D.L.ApplicationID]\r\n                      ,[ClassName]\r\n                      ,[NationalNo]\r\n                      ,[FullName]\r\n                      ,[ApplicationDate]\r\n                      ,[PassedTestCount]\r\n                      ,[Status]\r\n                  FROM [dbo].[LocalDrivingLicenseApplications_View]\r\n                 where FullName like @fullname";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        DataTable dataTable = new DataTable();
        sqlCommand.Parameters.AddWithValue("@fullname", fullname + "%");
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                dataTable.Load(sqlDataReader);
            }

            sqlDataReader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            sqlConnection.Close();
        }

        return dataTable;
    }

    public static DataTable GetAllLocalLicenseApplicationsByStatus(string status)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "SELECT [LocalDrivingLicenseApplicationID]\r\n                      as [L.D.L.ApplicationID]\r\n                      ,[ClassName]\r\n                      ,[NationalNo]\r\n                      ,[FullName]\r\n                      ,[ApplicationDate]\r\n                      ,[PassedTestCount]\r\n                      ,[Status]\r\n                  FROM [dbo].[LocalDrivingLicenseApplications_View]\r\n                where Status = @status";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        DataTable dataTable = new DataTable();
        sqlCommand.Parameters.AddWithValue("@status", status);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                dataTable.Load(sqlDataReader);
            }

            sqlDataReader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            sqlConnection.Close();
        }

        return dataTable;
    }

    public static int AddNewLocalLicesenseApplication(int applicationid, int licenseclassid, SqlConnection connection, SqlTransaction transaction)
    {
        int result = -1;
        using (SqlCommand sqlCommand = new SqlCommand("\r\n            INSERT INTO [dbo].[LocalDrivingLicenseApplications]\r\n            ([ApplicationID], [LicenseClassID])\r\n            VALUES (@applicationid, @licenseclassid);\r\n            SELECT SCOPE_IDENTITY();", connection, transaction))
        {
            sqlCommand.Parameters.Add("@applicationid", SqlDbType.Int).Value = applicationid;
            sqlCommand.Parameters.Add("@licenseclassid", SqlDbType.Int).Value = licenseclassid;
            object obj = sqlCommand.ExecuteScalar();
            if (obj != null && int.TryParse(obj.ToString(), out var result2))
            {
                result = result2;
            }
        }

        return result;
    }

    public static bool UpdateLocalLicesenseApplication(int LDLappid, int applicationid, int licenseclassid)
    {
        using SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        using SqlCommand sqlCommand = new SqlCommand("\r\n            UPDATE [dbo].[LocalDrivingLicenseApplications]\r\n            SET [ApplicationID] = @applicationid,\r\n                [LicenseClassID] = @licenseclassid\r\n            WHERE LocalDrivingLicenseApplicationID = @LDLappid", sqlConnection);
        sqlCommand.Parameters.Add("@LDLappid", SqlDbType.Int).Value = LDLappid;
        sqlCommand.Parameters.Add("@applicationid", SqlDbType.Int).Value = applicationid;
        sqlCommand.Parameters.Add("@licenseclassid", SqlDbType.Int).Value = licenseclassid;
        sqlConnection.Open();
        int num = sqlCommand.ExecuteNonQuery();
        return num > 0;
    }

    public static bool DeleteLocalLicenseApplicationByID(int appid, SqlConnection connection, SqlTransaction transaction)
    {
        int num = 0;
        string cmdText = "\r\n            DELETE FROM [dbo].[LocalDrivingLicenseApplications]\r\n            WHERE ApplicationID = @id;";
        using (SqlCommand sqlCommand = new SqlCommand(cmdText, connection, transaction))
        {
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = appid;
            num = sqlCommand.ExecuteNonQuery();
        }

        return num > 0;
    }

    public static bool DeleteLocalLicenseApplicationByLDLappID(int LDLappid, SqlConnection connection, SqlTransaction transaction)
    {
        int num = 0;
        string cmdText = "\r\n            DELETE FROM [dbo].[LocalDrivingLicenseApplications]\r\n            where LocalDrivingLicenseApplicationID = @id;";
        using (SqlCommand sqlCommand = new SqlCommand(cmdText, connection, transaction))
        {
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = LDLappid;
            num = sqlCommand.ExecuteNonQuery();
        }

        return num > 0;
    }

    public static bool GetLDLApplicationByLDLAppID(int ldlapplicationID, ref string classname, ref string NNO, ref string fullname, ref DateTime date, ref byte passedtestcount, ref string status)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from LocalDrivingLicenseApplications_View\r\n            where LocalDrivingLicenseApplicationID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", ldlapplicationID);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                classname = (string)sqlDataReader["ClassName"];
                NNO = (string)sqlDataReader["NationalNo"];
                fullname = (string)sqlDataReader["FullName"];
                date = (DateTime)sqlDataReader["ApplicationDate"];
                passedtestcount = Convert.ToByte(sqlDataReader["PassedTestCount"]);
                status = (string)sqlDataReader["Status"];
                result = true;
            }

            sqlDataReader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            sqlConnection.Close();
        }

        return result;
    }

    public static bool GetLDLApplicationByAppID(int appid, ref int ldlapplicationID, ref string classname, ref string NNO, ref string fullname, ref DateTime date, ref byte passedtestcount, ref string status)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "SELECT ldlview.*\r\n                    FROM LocalDrivingLicenseApplications_View AS ldlview\r\n                    INNER JOIN LocalDrivingLicenseApplications AS ldl\r\n                        ON ldl.LocalDrivingLicenseApplicationID =\r\n                           ldlview.LocalDrivingLicenseApplicationID\r\n                    WHERE ldl.ApplicationID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", appid);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                ldlapplicationID = (int)sqlDataReader["LocalDrivingLicenseApplicationID"];
                classname = (string)sqlDataReader["ClassName"];
                NNO = (string)sqlDataReader["NationalNo"];
                fullname = (string)sqlDataReader["FullName"];
                date = (DateTime)sqlDataReader["ApplicationDate"];
                passedtestcount = Convert.ToByte(sqlDataReader["PassedTestCount"]);
                status = (string)sqlDataReader["Status"];
                result = true;
            }

            sqlDataReader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            sqlConnection.Close();
        }

        return result;
    }

    public static bool isLDLApplicationExisted(string nationalnumber, string classname)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "\r\n                    select Ahmed = 1 from LocalDrivingLicenseApplications_View\r\n                    where (Status = 'New' or Status = 'Completed')\r\n                    and ClassName = @classname\r\n                    and NationalNo = @nationalnumber";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@nationalnumber", nationalnumber);
        sqlCommand.Parameters.AddWithValue("@classname", classname);
        try
        {
            sqlConnection.Open();
            object obj = sqlCommand.ExecuteScalar();
            if (obj != null)
            {
                result = true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            sqlConnection.Close();
        }

        return result;
    }

    public static bool IsLDLAppLinked(int LDLappid)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "SELECT 1\r\n                WHERE \r\n                 EXISTS (SELECT 1 FROM TestAppointments  \r\n                WHERE LocalDrivingLicenseApplicationID = @LDLappid)\r\n                ";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@LDLappid", LDLappid);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            result = sqlDataReader.HasRows;
            sqlDataReader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            sqlConnection.Close();
        }

        return result;
    }

    
}


