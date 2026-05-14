
using clsDataConnection;
using System;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public class clsTestAppointmentsDetailsDataAccessLayer
{
    public static bool GetTestAppointmentsDetailsByTestAppID(int testappid, ref int ldlappid, ref string testtypetitel, ref string classname, ref DateTime appointmentdate, ref byte paidfees, ref string creaturefullname, ref bool islocked)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from TestAppointments_View\r\n            WHERE TestAppointmentID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", testappid);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                ldlappid = (int)sqlDataReader["LocalDrivingLicenseApplicationID"];
                testtypetitel = (string)sqlDataReader["TestTypeTitle"];
                appointmentdate = (DateTime)sqlDataReader["AppointmentDate"];
                creaturefullname = (string)sqlDataReader["FullName"];
                islocked = (bool)sqlDataReader["IsLocked"];
                paidfees = Convert.ToByte(sqlDataReader["PaidFees"]);
                classname = (string)sqlDataReader["ClassName"];
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


