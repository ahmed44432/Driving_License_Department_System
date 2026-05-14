
using clsDataConnection;
using System;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public class clsLDLBasicInfoDataAccessLayer
{
    public static bool GetLDLBasicInfoByAppID(int applicationID, ref int ldlappid, ref string classname, ref string NNO, ref string fullname, ref DateTime date, ref byte passedtestcount, ref string status, ref string username, ref DateTime laststatusdate, ref byte paidfees)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "SELECT ldlv.*\r\n            FROM LocalDrivingLicenseApplicationsDetails_View ldlv\r\n            INNER JOIN LocalDrivingLicenseApplications ldl\r\n                ON ldl.LocalDrivingLicenseApplicationID = ldlv.LocalDrivingLicenseApplicationID\r\n            WHERE ldl.ApplicationID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", applicationID);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                ldlappid = (int)sqlDataReader["LocalDrivingLicenseApplicationID"];
                classname = (string)sqlDataReader["ClassName"];
                NNO = (string)sqlDataReader["NationalNo"];
                fullname = (string)sqlDataReader["FullName"];
                date = (DateTime)sqlDataReader["ApplicationDate"];
                passedtestcount = Convert.ToByte(sqlDataReader["PassedTestCount"]);
                status = (string)sqlDataReader["Status"];
                laststatusdate = (DateTime)sqlDataReader["LastStatusDate"];
                paidfees = Convert.ToByte(sqlDataReader["PaidFees"]);
                username = (string)sqlDataReader["UserName"];
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

    public static bool GetLDLBasicInfoByTestAppID(int testappid, ref int ldlappid, ref string classname, ref string NNO, ref string fullname, ref DateTime date, ref byte passedtestcount, ref string status, ref string username, ref DateTime laststatusdate, ref byte paidfees)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "SELECT ldlv.*\r\n            FROM LocalDrivingLicenseApplicationsDetails_View ldlv\r\n            INNER JOIN TestAppointments testapp\r\n                ON testapp.LocalDrivingLicenseApplicationID = ldlv.LocalDrivingLicenseApplicationID\r\n            where testapp.TestAppointmentID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", testappid);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                ldlappid = (int)sqlDataReader["LocalDrivingLicenseApplicationID"];
                classname = (string)sqlDataReader["ClassName"];
                NNO = (string)sqlDataReader["NationalNo"];
                fullname = (string)sqlDataReader["FullName"];
                date = (DateTime)sqlDataReader["ApplicationDate"];
                passedtestcount = Convert.ToByte(sqlDataReader["PassedTestCount"]);
                status = (string)sqlDataReader["Status"];
                laststatusdate = (DateTime)sqlDataReader["LastStatusDate"];
                paidfees = Convert.ToByte(sqlDataReader["PaidFees"]);
                username = (string)sqlDataReader["UserName"];
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

    public static bool GetLDLBasicInfoByLDLAppID(int ldlapplicationID, ref string classname, ref string NNO, ref string fullname, ref DateTime date, ref byte passedtestcount, ref string status, ref string username, ref DateTime laststatusdate, ref byte paidfees)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "SELECT ldlv.*\r\n            FROM LocalDrivingLicenseApplicationsDetails_View ldlv\r\n            INNER JOIN LocalDrivingLicenseApplications ldl\r\n                ON ldl.LocalDrivingLicenseApplicationID = ldlv.LocalDrivingLicenseApplicationID\r\n            WHERE ldl.LocalDrivingLicenseApplicationID = @id";
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
                laststatusdate = (DateTime)sqlDataReader["LastStatusDate"];
                paidfees = Convert.ToByte(sqlDataReader["PaidFees"]);
                username = (string)sqlDataReader["UserName"];
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
}
