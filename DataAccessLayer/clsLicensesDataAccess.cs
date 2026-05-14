

using System;
using System.Data;
using Microsoft.Data.SqlClient;
using clsDataConnection;


namespace DataAccessLayer;

public class clsLicensesDataAccessLayer
{
   
    public static DataTable GetAllLocalLicensesByNNO(string nno)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "SELECT \r\n                            L.LicenseID,\r\n                            L.ApplicationID,\r\n                            LC.ClassName,\r\n                            L.IssueDate ,\r\n                            L.ExpirationDate , \r\n                            L.IsActive\r\n                        FROM Licenses L\r\n                        INNER JOIN Applications A \r\n                            ON L.ApplicationID = A.ApplicationID\r\n                        INNER JOIN People P\r\n                            ON A.ApplicantPersonID = P.PersonID\r\n                        INNER JOIN LicenseClasses LC\r\n                            ON LC.LicenseClassID = L.LicenseClass\r\n                        WHERE P.NationalNo =  @nno";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.Add("@nno", SqlDbType.NVarChar).Value = nno;
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            dataTable.Load(reader);
        }

        return dataTable;
    }

  
    public static DataTable GetAllInternationalLicensesByNNO(string nno)
    {
        DataTable dataTable = new DataTable();
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "SELECT \r\n                        INTL.InternationalLicenseID,\r\n                        INTL.ApplicationID,\r\n                        L.LicenseID,\r\n                        LC.ClassName,\r\n                        INTL.IssueDate,\r\n                        INTL.ExpirationDate, \r\n                        INTL.IsActive\r\n                    FROM InternationalLicenses INTL\r\n                    INNER JOIN Applications A \r\n                        ON INTL.ApplicationID = A.ApplicationID\r\n                    INNER JOIN Licenses L\r\n                        ON INTL.IssuedUsingLocalLicenseID = L.LicenseID  \r\n                    INNER JOIN People P\r\n                        ON A.ApplicantPersonID = P.PersonID\r\n                    INNER JOIN LicenseClasses LC\r\n                        ON LC.LicenseClassID = L.LicenseClass\r\n                    WHERE P.NationalNo = @nno";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.Add("@nno", SqlDbType.NVarChar).Value = nno;
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            dataTable.Load(reader);
        }

        return dataTable;
    }

   
    public static int AddNewLicense(int applicationID, int driverID, byte licenseClass, DateTime issueDate, DateTime expirationDate, string notes, int paidFees, bool isActive, int issueReasonID, int createdByUserID)
    {
        int result = -1;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "INSERT INTO [dbo].[Licenses] ([ApplicationID], [DriverID],\r\n                        [LicenseClass], [IssueDate], [ExpirationDate], [Notes],\r\n                        [PaidFees], [IsActive], [IssueReason], [CreatedByUserID])\r\n\r\n                VALUES (@ApplicationID , \r\n                        @DriverID , \r\n                        @LicenseClass ,\r\n                        @IssueDate ,\r\n                        @ExpirationDate ,\r\n                        @Notes ,\r\n                        @PaidFees ,\r\n                        @IsActive ,\r\n                        @IssueReason ,\r\n                        @CreatedByUserID)\r\n                       SELECT SCOPE_IDENTITY()";
            sqlConnection.Open();
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;
            sqlCommand.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;
            sqlCommand.Parameters.Add("@LicenseClass", SqlDbType.Int).Value = licenseClass;
            sqlCommand.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = issueDate;
            sqlCommand.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = expirationDate;
            if (string.IsNullOrWhiteSpace(notes))
            {
                sqlCommand.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                sqlCommand.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
            }

            sqlCommand.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = paidFees;
            sqlCommand.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;
            sqlCommand.Parameters.Add("@IssueReason", SqlDbType.TinyInt).Value = issueReasonID;
            sqlCommand.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;
            object obj = sqlCommand.ExecuteScalar();
            if (obj != null)
            {
                result = Convert.ToInt32(obj);
            }
        }

        return result;
    }


    public static bool UpdateLicense(int licenseID, int applicationID, int driverID, byte licenseClass, DateTime issueDate, DateTime expirationDate, string notes, int paidFees, bool isActive, byte issueReasonID, int createdByUserID)
    {
        int num = 0;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            sqlConnection.Open();
            string cmdText = "\r\n                   UPDATE [dbo].[Licenses]\r\n                      SET [ApplicationID] =    @ApplicationID\r\n                         ,[DriverID] =         @DriverID\r\n                         ,[LicenseClass] =     @LicenseClass\r\n                         ,[IssueDate] =        @IssueDate\r\n                         ,[ExpirationDate] =   @ExpirationDate\r\n                         ,[Notes] =            @Notes\r\n                         ,[PaidFees] =         @PaidFees\r\n                         ,[IsActive] =         @IsActive\r\n                         ,[IssueReason] =      @IssueReason\r\n                         ,[CreatedByUserID] =  @CreatedByUserID\r\n                    WHERE LicenseID = @licenseid;";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.Add("@ApplicationID", SqlDbType.Int).Value = applicationID;
            sqlCommand.Parameters.Add("@DriverID", SqlDbType.Int).Value = driverID;
            sqlCommand.Parameters.Add("@LicenseClass", SqlDbType.Int).Value = licenseClass;
            sqlCommand.Parameters.Add("@IssueDate", SqlDbType.DateTime).Value = issueDate;
            sqlCommand.Parameters.Add("@ExpirationDate", SqlDbType.DateTime).Value = expirationDate;
            if (string.IsNullOrWhiteSpace(notes))
            {
                sqlCommand.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = DBNull.Value;
            }
            else
            {
                sqlCommand.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = notes;
            }

            sqlCommand.Parameters.Add("@PaidFees", SqlDbType.SmallMoney).Value = paidFees;
            sqlCommand.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;
            sqlCommand.Parameters.Add("@IssueReason", SqlDbType.TinyInt).Value = issueReasonID;
            sqlCommand.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;
            sqlCommand.Parameters.Add("@licenseid", SqlDbType.Int).Value = licenseID;
            num = sqlCommand.ExecuteNonQuery();
        }

        return num > 0;
    }

    
    public static bool GetLicenseByLicenseID(int licenseID, ref int applicationID, ref int driverID, ref byte licenseClass, ref DateTime issueDate, ref DateTime expirationDate, ref string notes, ref int paidFees, ref bool isActive, ref byte issueReasonID, ref int createdByUserID)
    {
        bool result = false;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "select Licenses.* from Licenses\r\n                        where Licenses.LicenseID = @id";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = licenseID;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                applicationID = (int)sqlDataReader["ApplicationID"];
                driverID = (int)sqlDataReader["DriverID"];
                licenseClass = Convert.ToByte(sqlDataReader["LicenseClass"]);
                issueDate = (DateTime)sqlDataReader["IssueDate"];
                expirationDate = (DateTime)sqlDataReader["ExpirationDate"];
                notes = ((sqlDataReader["Notes"] != DBNull.Value) ? ((string)sqlDataReader["Notes"]) : "");
                paidFees = Convert.ToInt32(sqlDataReader["PaidFees"]);
                isActive = (bool)sqlDataReader["IsActive"];
                issueReasonID = Convert.ToByte(sqlDataReader["IssueReason"]);
                createdByUserID = (int)sqlDataReader["CreatedByUserID"];
                result = true;
            }
        }

        return result;
    }

 
    public static bool GetLicenseByLDLAppID(int ldlappid, ref int licenseID, ref int applicationID, ref int driverID, ref byte licenseClass, ref DateTime issueDate, ref DateTime expirationDate, ref string notes, ref int paidFees, ref bool isActive, ref byte issueReasonID, ref int createdByUserID)
    {
        bool result = false;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "select Licenses.* from Licenses\r\n                        inner join LocalDrivingLicenseApplications as ldl\r\n                        ON ldl.ApplicationID = Licenses.ApplicationID\r\n                        where ldl.LocalDrivingLicenseApplicationID = @id";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = ldlappid;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                licenseID = (int)sqlDataReader["LicenseID"];
                applicationID = (int)sqlDataReader["ApplicationID"];
                driverID = (int)sqlDataReader["DriverID"];
                licenseClass = Convert.ToByte(sqlDataReader["LicenseClass"]);
                issueDate = (DateTime)sqlDataReader["IssueDate"];
                expirationDate = (DateTime)sqlDataReader["ExpirationDate"];
                notes = ((sqlDataReader["Notes"] != DBNull.Value) ? ((string)sqlDataReader["Notes"]) : "");
                paidFees = Convert.ToInt32(sqlDataReader["PaidFees"]);
                isActive = (bool)sqlDataReader["IsActive"];
                issueReasonID = Convert.ToByte(sqlDataReader["IssueReason"]);
                createdByUserID = (int)sqlDataReader["CreatedByUserID"];
                result = true;
            }
        }

        return result;
    }

 
    public static bool IsLicenseExist(int Applicationid)
    {
        bool result = false;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "select Ahmed = 1 from Licenses\r\n                        where ApplicationID = @id";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = Applicationid;
            object obj = sqlCommand.ExecuteScalar();
            result = obj != null;
        }

        return result;
    }

}

