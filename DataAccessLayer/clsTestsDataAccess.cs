
using clsDataConnection;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public class clsTestsDataAccessLayer
{
    public static int AddNewTest(int testappid, bool testresult, string notes, int createdbyuserid)
    {
        int result = -1;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            sqlConnection.Open();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                string cmdText = "\r\n                        INSERT INTO [dbo].[Tests]\r\n                               ([TestAppointmentID]\r\n                               ,[TestResult]\r\n                               ,[Notes]\r\n                               ,[CreatedByUserID])\r\n                         VALUES\r\n                               (@testappid\r\n                               ,@testresult\r\n                               ,@notes\r\n                               ,@createdbyuserid)\r\n\r\n                        SELECT SCOPE_IDENTITY();";
                using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection, sqlTransaction))
                {
                    sqlCommand.Parameters.Add("@testappid", SqlDbType.Int).Value = testappid;
                    sqlCommand.Parameters.Add("@testresult", SqlDbType.Bit).Value = testresult;
                    if (notes != "")
                    {
                        sqlCommand.Parameters.Add("@notes", SqlDbType.NVarChar).Value = notes;
                    }
                    else
                    {
                        sqlCommand.Parameters.Add("@notes", SqlDbType.NVarChar).Value = DBNull.Value;
                    }

                    sqlCommand.Parameters.Add("@createdbyuserid", SqlDbType.Int).Value = createdbyuserid;
                    object obj = sqlCommand.ExecuteScalar();
                    if (obj != null)
                    {
                        result = Convert.ToInt32(obj);
                    }
                }

                sqlTransaction.Commit();
            }
            catch
            {
                sqlTransaction.Rollback();
                throw;
            }
        }

        return result;
    }

    public static bool IsTestPassed(int testappid, byte testtypeid)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select Ahmed =1\r\n                from Tests\r\n                inner join TestAppointments on \r\n                      Tests.TestAppointmentID = TestAppointments.TestAppointmentID\r\n                where \r\n                     Tests.TestAppointmentID = @id\r\n                and  TestAppointments.TestTypeID = @typeid\r\n                and  Tests.TestResult = 1;";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = testappid;
        sqlCommand.Parameters.Add("@typeid", SqlDbType.Int).Value = testtypeid;
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

    public static bool IsTestFailed(int testappid, byte testtypeid)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select Ahmed =1\r\n                from Tests\r\n                inner join TestAppointments on \r\n                      Tests.TestAppointmentID = TestAppointments.TestAppointmentID\r\n                where \r\n                     Tests.TestAppointmentID = @id\r\n                and  TestAppointments.TestTypeID = @typeid\r\n                and  Tests.TestResult = 0;";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = testappid;
        sqlCommand.Parameters.Add("@typeid", SqlDbType.Int).Value = testtypeid;
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
}

