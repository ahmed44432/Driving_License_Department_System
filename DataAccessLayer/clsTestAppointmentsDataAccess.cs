
using clsDataConnection;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public class clsTestAppointmentsDataAccessLayer
{
    public static int AddNewTestAppointment(int testtypeid, int ldlappid, DateTime appdate, byte paidfees, int createdbyuserid, bool islocked)
    {
        int result = -1;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            sqlConnection.Open();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                string cmdText = "\r\n                        INSERT INTO [dbo].[TestAppointments]\r\n                                   ([TestTypeID]\r\n                                   ,[LocalDrivingLicenseApplicationID]\r\n                                   ,[AppointmentDate]\r\n                                   ,[PaidFees]\r\n                                   ,[CreatedByUserID]\r\n                                   ,[IsLocked])\r\n                             VALUES\r\n                                   (@testtypeid   \r\n                                   ,@ldlappid  \r\n                                   ,@appdate \r\n                                   ,@paidfees   \r\n                                   ,@createdbyuserid   \r\n                                   ,@islocked )\r\n\r\n                        SELECT SCOPE_IDENTITY();";
                using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection, sqlTransaction))
                {
                    sqlCommand.Parameters.Add("@testtypeid", SqlDbType.Int).Value = testtypeid;
                    sqlCommand.Parameters.Add("@ldlappid", SqlDbType.Int).Value = ldlappid;
                    sqlCommand.Parameters.Add("@appdate", SqlDbType.SmallDateTime).Value = appdate;
                    sqlCommand.Parameters.Add("@paidfees", SqlDbType.SmallMoney).Value = paidfees;
                    sqlCommand.Parameters.Add("@createdbyuserid", SqlDbType.Int).Value = createdbyuserid;
                    sqlCommand.Parameters.Add("@islocked", SqlDbType.Bit).Value = islocked;
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

    public static bool UpdateTestAppointment(int testappid, DateTime appdate, bool isLocked)
    {
        int num = 0;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            sqlConnection.Open();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                string cmdText = "\r\n                        UPDATE [dbo].[TestAppointments]\r\n                           SET \r\n                              [AppointmentDate] = @appdate\r\n                              ,[IsLocked] = @islocked\r\n                         WHERE TestAppointmentID =  @testappid ;";
                using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection, sqlTransaction))
                {
                    sqlCommand.Parameters.Add("@testappid", SqlDbType.Int).Value = testappid;
                    sqlCommand.Parameters.Add("@appdate", SqlDbType.SmallDateTime).Value = appdate;
                    sqlCommand.Parameters.Add("@islocked", SqlDbType.Bit).Value = isLocked;
                    num = sqlCommand.ExecuteNonQuery();
                }

                sqlTransaction.Commit();
            }
            catch
            {
                sqlTransaction.Rollback();
                throw;
            }
        }

        return num > 0;
    }

    public static bool GetTestAppointmentByTestAppID(int testappid, ref int testTypeID, ref int lDLApplicationID, ref DateTime appointmentDate, ref byte paidFees, ref int createdByUserID, ref bool isLocked)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from TestAppointments\r\n                where TestAppointmentID  = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", testappid);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                testTypeID = (int)sqlDataReader["TestTypeID"];
                lDLApplicationID = (int)sqlDataReader["LocalDrivingLicenseApplicationID"];
                appointmentDate = (DateTime)sqlDataReader["AppointmentDate"];
                createdByUserID = (int)sqlDataReader["CreatedByUserID"];
                paidFees = Convert.ToByte(sqlDataReader["PaidFees"]);
                isLocked = (bool)sqlDataReader["IsLocked"];
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

    public static bool GetTestAppointmentByLdlAppid(int ldlappid, byte testTypeID, ref int testappid, ref DateTime appointmentDate, ref byte paidFees, ref int createdByUserID, ref bool isLocked)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from TestAppointments\r\n                            where TestTypeID = @typeid and\r\n                 LocalDrivingLicenseApplicationID = @id\r\n                    order by TestAppointmentID desc";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", ldlappid);
        sqlCommand.Parameters.AddWithValue("@typeid", testTypeID);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                testappid = (int)sqlDataReader["TestAppointmentID"];
                appointmentDate = (DateTime)sqlDataReader["AppointmentDate"];
                createdByUserID = (int)sqlDataReader["CreatedByUserID"];
                paidFees = Convert.ToByte(sqlDataReader["PaidFees"]);
                isLocked = (bool)sqlDataReader["IsLocked"];
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

    public static bool GetVisionTestAppointmentByLdlAppid(int ldlappis, ref int testappid, ref int testTypeID, ref int lDLApplicationID, ref DateTime appointmentDate, ref byte paidFees, ref int createdByUserID, ref bool isLocked)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from TestAppointments\r\n                            where TestTypeID = 1 and\r\n                 LocalDrivingLicenseApplicationID = @id\r\n                    order by TestAppointmentID desc";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", ldlappis);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                testappid = (int)sqlDataReader["TestAppointmentID"];
                testTypeID = (int)sqlDataReader["TestTypeID"];
                lDLApplicationID = (int)sqlDataReader["LocalDrivingLicenseApplicationID"];
                appointmentDate = (DateTime)sqlDataReader["AppointmentDate"];
                createdByUserID = (int)sqlDataReader["CreatedByUserID"];
                paidFees = Convert.ToByte(sqlDataReader["PaidFees"]);
                isLocked = (bool)sqlDataReader["IsLocked"];
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

    public static DataTable GetTestAppointments()
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select \r\n                            TestAppointmentID as [AppointmentID],\r\n                            AppointmentDate,\r\n                            PaidFees,\r\n                            IsLocked\r\n                            from TestAppointments ";
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

    public static DataTable GetVisionTestAppointmentsByLDLAppID(int ldlappid)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select \r\n                            TestAppointmentID as [AppointmentID],\r\n                            AppointmentDate,\r\n                            PaidFees,\r\n                            IsLocked\r\n                            from TestAppointments\r\n                where TestTypeID = 1\r\n                and LocalDrivingLicenseApplicationID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = ldlappid;
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

    public static DataTable GetALLTestAppointmentsByLDLAppID_ByType(int ldlappid, byte typeid)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select \r\n                            TestAppointmentID as [AppointmentID],\r\n                            AppointmentDate,\r\n                            PaidFees,\r\n                            IsLocked\r\n                            from TestAppointments\r\n                where TestTypeID = @typeid\r\n                and LocalDrivingLicenseApplicationID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = ldlappid;
        sqlCommand.Parameters.Add("@typeid", SqlDbType.Int).Value = typeid;
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

    public static bool DeleteTestAppointmentsByLDLAppID(int LDLappid, byte typeid)
    {
        int num = 0;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            sqlConnection.Open();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                string cmdText = "\r\n                            DELETE FROM [dbo].[TestAppointments]\r\n\r\n                              WHERE TestTypeID = @typeid\r\n                              and \r\n                              LocalDrivingLicenseApplicationID =  @id;";
                using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection, sqlTransaction))
                {
                    sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = LDLappid;
                    sqlCommand.Parameters.Add("@typeid", SqlDbType.Int).Value = typeid;
                    num = sqlCommand.ExecuteNonQuery();
                }

                sqlTransaction.Commit();
            }
            catch
            {
                sqlTransaction.Rollback();
                throw;
            }
        }

        return num > 0;
    }

    public static bool isTestAppointmentsNotLockedExisted(int testappid, byte typeid)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select \r\n                            Ahmed = 1\r\n                            from TestAppointments\r\n                where TestTypeID = @typeid\r\n                and IsLocked = 0\r\n                and TestAppointmentID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = testappid;
        sqlCommand.Parameters.Add("@typeid", SqlDbType.Int).Value = typeid;
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

    public static bool isTestAppointmentsLockedExisted(int testappid, byte typeid)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select \r\n                            Ahmed = 1\r\n                            from TestAppointments\r\n                where TestTypeID = @typeid\r\n                and IsLocked = 1\r\n                and TestAppointmentID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = testappid;
        sqlCommand.Parameters.Add("@typeid", SqlDbType.Int).Value = typeid;
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

    public static bool isTestAppointmentsNotLockedExistedByLDLAppID(int ldlappid, byte typeid)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select \r\n                            Ahmed = 1\r\n                            from TestAppointments\r\n                where TestTypeID = @typeid\r\n                and IsLocked = 0\r\n                and LocalDrivingLicenseApplicationID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = ldlappid;
        sqlCommand.Parameters.Add("@typeid", SqlDbType.Int).Value = ldlappid;
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

    public static bool isTestAppointmentsLockedExistedByLDLAppID(int ldlappid, byte typeid)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select \r\n                            Ahmed = 1\r\n                            from TestAppointments\r\n                where TestTypeID = @typeid\r\n                and IsLocked = 1\r\n                and LocalDrivingLicenseApplicationID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = ldlappid;
        sqlCommand.Parameters.Add("@typeid", SqlDbType.Int).Value = typeid;
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

    public static int GetApplicationID_ByTestappointmentID(int appointmentid)
    {
        string cmdText = "\r\n               select Applications.ApplicationID from Applications \r\n                inner join LocalDrivingLicenseApplications as ldl\r\n                on ldl.ApplicationID = Applications.ApplicationID\r\n                inner join TestAppointments \r\n                on TestAppointments.LocalDrivingLicenseApplicationID \r\n                                = ldl.LocalDrivingLicenseApplicationID\r\n                where TestAppointmentID =  @Id";
        using SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = appointmentid;
        sqlConnection.Open();
        object obj = sqlCommand.ExecuteScalar();
        return (obj == null) ? (-1) : ((int)obj);
    }

    public static int GetTestCountByLDLAppID(int ldlAppId, byte typeid)
    {
        string cmdText = "\r\n                SELECT COUNT(*)\r\n                FROM TestAppointments\r\n                WHERE TestTypeID = @TypeId\r\n                --and IsLocked = 1\r\n                AND LocalDrivingLicenseApplicationID = @Id";
        using SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = ldlAppId;
        sqlCommand.Parameters.Add("@TypeId", SqlDbType.Int).Value = typeid;
        sqlConnection.Open();
        return (int)sqlCommand.ExecuteScalar();
    }
}


