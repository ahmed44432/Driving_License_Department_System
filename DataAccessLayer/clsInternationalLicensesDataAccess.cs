
using clsDataConnection;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public class clsInternationalLicensesDataAccessLayer
{
    public static DataTable GetAllInternationalLicenses()
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "SELECT \r\n                 InternationalLicenseID as [Int License ID]  ,\r\n                 ApplicationID as [Application ID],\r\n                 DriverID as [Driver ID],\r\n                 IssuedUsingLocalLicenseID as [Local License ID],\r\n                 IssueDate as [Issue Date],\r\n                 ExpirationDate as [Expiration Date], \r\n                 IsActive as [Is Active]\r\n                        FROM InternationalLicenses ";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlConnection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            dataTable.Load(reader);
        }

        return dataTable;
    }

    public static DataTable GetAllInternationalLicensesByIntLicenseID(int intlicenseid)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "SELECT \r\n                 InternationalLicenseID as [Int License ID]  ,\r\n                 ApplicationID as [Application ID],\r\n                 DriverID as [Driver ID],\r\n                 IssuedUsingLocalLicenseID as [Local License ID],\r\n                 IssueDate as [Issue Date],\r\n                 ExpirationDate as [Expiration Date], \r\n                 IsActive as [Is Active]\r\n                        FROM InternationalLicenses\r\n                 Where InternationalLicenseID = @id";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = intlicenseid;
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            dataTable.Load(reader);
        }

        return dataTable;
    }

    public static DataTable GetAllInternationalLicensesByApplicationID(int applicationid)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "SELECT \r\n                 InternationalLicenseID as [Int License ID]  ,\r\n                 ApplicationID as [Application ID],\r\n                 DriverID as [Driver ID],\r\n                 IssuedUsingLocalLicenseID as [Local License ID],\r\n                 IssueDate as [Issue Date],\r\n                 ExpirationDate as [Expiration Date], \r\n                 IsActive as [Is Active]\r\n                        FROM InternationalLicenses\r\n                 Where ApplicationID = @id";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = applicationid;
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            dataTable.Load(reader);
        }

        return dataTable;
    }

    public static DataTable GetAllInternationalLicensesByDriverID(int driverid)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "SELECT \r\n                 InternationalLicenseID as [Int License ID]  ,\r\n                 ApplicationID as [Application ID],\r\n                 DriverID as [Driver ID],\r\n                 IssuedUsingLocalLicenseID as [Local License ID],\r\n                 IssueDate as [Issue Date],\r\n                 ExpirationDate as [Expiration Date], \r\n                 IsActive as [Is Active]\r\n                        FROM InternationalLicenses\r\n                 Where DriverID = @id";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = driverid;
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            dataTable.Load(reader);
        }

        return dataTable;
    }

    public static DataTable GetAllInternationalLicensesByStatus(bool isactive)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "SELECT \r\n                 InternationalLicenseID as [Int License ID]  ,\r\n                 ApplicationID as [Application ID],\r\n                 DriverID as [Driver ID],\r\n                 IssuedUsingLocalLicenseID as [Local License ID],\r\n                 IssueDate as [Issue Date],\r\n                 ExpirationDate as [Expiration Date], \r\n                 IsActive as [Is Active]\r\n                        FROM InternationalLicenses\r\n                 Where IsActive = @status";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.Add("@status", SqlDbType.Int).Value = isactive;
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            dataTable.Load(reader);
        }

        return dataTable;
    }

    public static int AddNewLicense(int applicationID, int driverID, int localLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
    {
        if (IsInternationalLicenseActive(driverID))
        {
            return -1;
        }

        int result = -1;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "INSERT INTO [dbo].[InternationalLicenses]\r\n                           ([ApplicationID]\r\n                           ,[DriverID]\r\n                           ,[IssuedUsingLocalLicenseID]\r\n                           ,[IssueDate]\r\n                           ,[ExpirationDate]\r\n                           ,[IsActive]\r\n                           ,[CreatedByUserID])\r\n                     VALUES\r\n                           (@ApplicationID\r\n                           ,@DriverID\r\n                           ,@IssuedUsingLocalLicenseID\r\n                           ,@IssueDate\r\n                           ,@ExpirationDate\r\n                           ,@IsActive\r\n                           ,@CreatedByUserID)\r\n                       SELECT SCOPE_IDENTITY()";
            sqlConnection.Open();
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;
            sqlCommand.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;
            sqlCommand.Parameters.Add("@IssuedUsingLocalLicenseID", SqlDbType.Int).Value = localLicenseID;
            sqlCommand.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = issueDate;
            sqlCommand.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = expirationDate;
            sqlCommand.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;
            sqlCommand.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;
            object obj = sqlCommand.ExecuteScalar();
            if (obj != null)
            {
                result = Convert.ToInt32(obj);
            }
        }

        return result;
    }

    public static bool GetIntLicenseByApplicationID(int applicationID, ref int internationalLicenseID, ref int driverID, ref int localLicenseID, ref DateTime issueDate, ref DateTime expirationDate, ref bool isActive, ref int createdByUserID)
    {
        bool result = false;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "select * from InternationalLicenses\r\n                        where ApplicationID = @id";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = applicationID;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                internationalLicenseID = (int)sqlDataReader["InternationalLicenseID"];
                driverID = (int)sqlDataReader["DriverID"];
                localLicenseID = (int)sqlDataReader["IssuedUsingLocalLicenseID"];
                issueDate = (DateTime)sqlDataReader["IssueDate"];
                expirationDate = (DateTime)sqlDataReader["ExpirationDate"];
                isActive = (bool)sqlDataReader["IsActive"];
                createdByUserID = (int)sqlDataReader["CreatedByUserID"];
                result = true;
            }
        }

        return result;
    }

    public static bool IsInternationalLicenseActive(int driverid)
    {
        bool result = false;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "select Ahmed = 1 from InternationalLicenses\r\n                    where DriverID = @driverid and IsActive = 1;";
            sqlConnection.Open();
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.Add("@driverid", SqlDbType.Int).Value = driverid;
            object obj = sqlCommand.ExecuteScalar();
            if (obj != null)
            {
                result = true;
            }
        }

        return result;
    }
}


