

using clsDataConnection;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public class clsDriversDataAccessLayer
{
    public static DataTable GetAllDrivers()
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "select \r\n                        DriverID as [Driver ID],\r\n                        PersonID as [Person ID],\r\n                        NationalNo as [National No],\r\n                        FullName as [Full Name],\r\n                        CreatedDate as [Date],\r\n                        NumberOfActiveLicenses as [Active Licenses]\r\n\r\n                        from Drivers_View";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlConnection.Open();
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            dataTable.Load(reader);
        }

        return dataTable;
    }

    public static DataTable GetAllDriversByDriverID(int driverid)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "select \r\n                        DriverID as [Driver ID],\r\n                        PersonID as [Person ID],\r\n                        NationalNo as [National No],\r\n                        FullName as [Full Name],\r\n                        CreatedDate as [Date],\r\n                        NumberOfActiveLicenses as [Active Licenses]\r\n\r\n                        from Drivers_View\r\n                        where DriverID = @id";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = driverid;
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            dataTable.Load(reader);
        }

        return dataTable;
    }

    public static DataTable GetAllDriversByPersonID(int personid)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "select \r\n                        DriverID as [Driver ID],\r\n                        PersonID as [Person ID],\r\n                        NationalNo as [National No],\r\n                        FullName as [Full Name],\r\n                        CreatedDate as [Date],\r\n                        NumberOfActiveLicenses as [Active Licenses]\r\n\r\n                        from Drivers_View\r\n                        where PersonID = @id";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = personid;
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            dataTable.Load(reader);
        }

        return dataTable;
    }

    public static DataTable GetAllDriversByNationalNO(string nno)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "select \r\n                        DriverID as [Driver ID],\r\n                        PersonID as [Person ID],\r\n                        NationalNo as [National No],\r\n                        FullName as [Full Name],\r\n                        CreatedDate as [Date],\r\n                        NumberOfActiveLicenses as [Active Licenses]\r\n\r\n                        from Drivers_View\r\n                        where NationalNo LIKE @nno";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.Add("@nno", SqlDbType.NVarChar).Value = nno + "%";
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            dataTable.Load(reader);
        }

        return dataTable;
    }

    public static DataTable GetAllDriversByFullName(string fullname)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "select \r\n                        DriverID as [Driver ID],\r\n                        PersonID as [Person ID],\r\n                        NationalNo as [National No],\r\n                        FullName as [Full Name],\r\n                        CreatedDate as [Date],\r\n                        NumberOfActiveLicenses as [Active Licenses]\r\n\r\n                        from Drivers_View\r\n                        where FullName LIKE @fullname";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.Add("@fullname", SqlDbType.NVarChar).Value = fullname + "%";
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            dataTable.Load(reader);
        }

        return dataTable;
    }

    public static int AddNewDriver(int personid, int createdbyuserid, DateTime creationdate)
    {
        if (IsDriverExisted(personid))
        {
            return -1;
        }

        int result = -1;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "INSERT INTO [dbo].[Drivers]\r\n                           ([PersonID] , [CreatedByUserID] , [CreatedDate])\r\n                     VALUES\r\n                           (@PersonID , @CreatedByUserID , @CreatedDate)\r\n                       SELECT SCOPE_IDENTITY()";
            sqlConnection.Open();
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.Add("@PersonID", SqlDbType.Int).Value = personid;
            sqlCommand.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdbyuserid;
            sqlCommand.Parameters.Add("@CreatedDate", SqlDbType.SmallDateTime).Value = creationdate;
            object obj = sqlCommand.ExecuteScalar();
            if (obj != null)
            {
                result = Convert.ToInt32(obj);
            }
        }

        return result;
    }

    public static bool GetDriverByPersonID(int personid, ref int driverid, ref int createdbyuserid, ref DateTime creationdate)
    {
        bool result = false;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "select * from Drivers \r\n                        where PersonID = @PersonID";
            sqlConnection.Open();
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.Add("@PersonID", SqlDbType.Int).Value = personid;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                driverid = (int)sqlDataReader["DriverID"];
                createdbyuserid = (int)sqlDataReader["CreatedByUserID"];
                creationdate = (DateTime)sqlDataReader["CreatedDate"];
                result = true;
            }
        }

        return result;
    }

    public static bool IsDriverExisted(int personid)
    {
        bool result = false;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "select Ahmed = 1 from Drivers \r\n                        where PersonID = @PersonID";
            sqlConnection.Open();
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.Add("@PersonID", SqlDbType.Int).Value = personid;
            object obj = sqlCommand.ExecuteScalar();
            if (obj != null)
            {
                result = true;
            }
        }

        return result;
    }
}

