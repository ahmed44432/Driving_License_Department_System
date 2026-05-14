
using clsDataConnection;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public class clsApplicationDataAccessLayer
{
    public static DataTable GetApplication()
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from Applications";
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

    public static int AddNewApplication(int applicationpersonid, DateTime applicationdate, int applicationtypeid, byte applicationstatus, DateTime laststatusdate, short paidfees, int creatbyuserid, int classid)
    {
        int num = -1;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            sqlConnection.Open();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                string cmdText = "\r\n                        INSERT INTO Applications\r\n                        (ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID)\r\n                        VALUES\r\n                        (@applicationpersonid, @applicationdate, @applicationtypeid, @applicationstatus, @laststatusdate, @paidfees, @creatbyuserid);\r\n                        SELECT SCOPE_IDENTITY();";
                using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection, sqlTransaction))
                {
                    sqlCommand.Parameters.Add("@applicationpersonid", SqlDbType.Int).Value = applicationpersonid;
                    sqlCommand.Parameters.Add("@applicationdate", SqlDbType.DateTime).Value = applicationdate;
                    sqlCommand.Parameters.Add("@applicationtypeid", SqlDbType.Int).Value = applicationtypeid;
                    sqlCommand.Parameters.Add("@applicationstatus", SqlDbType.TinyInt).Value = applicationstatus;
                    sqlCommand.Parameters.Add("@laststatusdate", SqlDbType.DateTime).Value = laststatusdate;
                    sqlCommand.Parameters.Add("@paidfees", SqlDbType.SmallMoney).Value = paidfees;
                    sqlCommand.Parameters.Add("@creatbyuserid", SqlDbType.Int).Value = creatbyuserid;
                    object obj = sqlCommand.ExecuteScalar();
                    if (obj != null)
                    {
                        num = Convert.ToInt32(obj);
                    }
                }

                if (num > 0 && applicationtypeid == 1)
                {
                    clsLocalLicenseApplicationDataAccessLayer.AddNewLocalLicesenseApplication(num, classid, sqlConnection, sqlTransaction);
                }

                sqlTransaction.Commit();
            }
            catch
            {
                sqlTransaction.Rollback();
                throw;
            }
        }

        return num;
    }

    public static bool UpdateApplication(int applicationid, int applicationpersonid, DateTime applicationdate, int applicationtypeid, byte applicationstatus, DateTime laststatusdate, short paidfees, int creatbyuserid)
    {
        int num = 0;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            sqlConnection.Open();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                string cmdText = "\r\n                        UPDATE [dbo].[Applications]\r\n                       SET [ApplicantPersonID] = @applicationpersonid\r\n                          ,[ApplicationDate]   = @applicationdate\r\n                          ,[ApplicationTypeID] = @applicationtypeid\r\n                          ,[ApplicationStatus] = @applicationstatus\r\n                          ,[LastStatusDate]    = @laststatusdate\r\n                          ,[PaidFees]          = @paidfees\r\n                          ,[CreatedByUserID]   = @creatbyuserid\r\n                     WHERE ApplicationID = @applicationid ;";
                using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection, sqlTransaction))
                {
                    sqlCommand.Parameters.Add("@applicationid", SqlDbType.Int).Value = applicationid;
                    sqlCommand.Parameters.Add("@applicationpersonid", SqlDbType.Int).Value = applicationpersonid;
                    sqlCommand.Parameters.Add("@applicationdate", SqlDbType.DateTime).Value = applicationdate;
                    sqlCommand.Parameters.Add("@applicationtypeid", SqlDbType.Int).Value = applicationtypeid;
                    sqlCommand.Parameters.Add("@applicationstatus", SqlDbType.TinyInt).Value = applicationstatus;
                    sqlCommand.Parameters.Add("@laststatusdate", SqlDbType.DateTime).Value = laststatusdate;
                    sqlCommand.Parameters.Add("@paidfees", SqlDbType.SmallMoney).Value = paidfees;
                    sqlCommand.Parameters.Add("@creatbyuserid", SqlDbType.Int).Value = creatbyuserid;
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

    public static bool GetApplicationByID(int applicationid, ref int applicationpersonid, ref DateTime applicationdate, ref int applicationtypeid, ref byte applicationstatus, ref DateTime laststatusdate, ref short paidfees, ref int creatbyuserid)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from Applications \r\n                    where ApplicationID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", applicationid);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                applicationpersonid = (int)sqlDataReader["ApplicantPersonID"];
                applicationdate = (DateTime)sqlDataReader["ApplicationDate"];
                applicationtypeid = (int)sqlDataReader["ApplicationTypeID"];
                applicationstatus = (byte)sqlDataReader["ApplicationStatus"];
                laststatusdate = (DateTime)sqlDataReader["LastStatusDate"];
                paidfees = Convert.ToInt16(sqlDataReader["PaidFees"]);
                creatbyuserid = (int)sqlDataReader["CreatedByUserID"];
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

    public static bool GetApplicationByLDLAppID(int LDLappid, ref int applicationid, ref int applicationpersonid, ref DateTime applicationdate, ref int applicationtypeid, ref byte applicationstatus, ref DateTime laststatusdate, ref short paidfees, ref int creatbyuserid)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "SELECT A.*\r\n                FROM Applications A\r\n                LEFT JOIN LocalDrivingLicenseApplications L\r\n                    ON A.ApplicationID = L.ApplicationID\r\n                LEFT JOIN LocalDrivingLicenseApplications_View LV\r\n                    ON LV.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID\r\n                WHERE L.LocalDrivingLicenseApplicationID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", LDLappid);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                applicationid = (int)sqlDataReader["ApplicationID"];
                applicationpersonid = (int)sqlDataReader["ApplicantPersonID"];
                applicationdate = (DateTime)sqlDataReader["ApplicationDate"];
                applicationtypeid = (int)sqlDataReader["ApplicationTypeID"];
                applicationstatus = (byte)sqlDataReader["ApplicationStatus"];
                laststatusdate = (DateTime)sqlDataReader["LastStatusDate"];
                paidfees = Convert.ToInt16(sqlDataReader["PaidFees"]);
                creatbyuserid = (int)sqlDataReader["CreatedByUserID"];
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

    public static bool DeleteApplicationByAppID(int applicationid, int applicationtypeid = 1)
    {
        int num = 0;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            sqlConnection.Open();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                if (applicationtypeid == 1 && !clsLocalLicenseApplicationDataAccessLayer.DeleteLocalLicenseApplicationByID(applicationid, sqlConnection, sqlTransaction))
                {
                    sqlTransaction.Rollback();
                    return false;
                }

                string cmdText = "\r\n                    DELETE FROM [dbo].[Applications]\r\n                    WHERE ApplicationID = @id;";
                using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection, sqlTransaction))
                {
                    sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = applicationid;
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

    public static bool DeleteApplicationByLDLAppID(int LDLappid, byte typeid)
    {
        int num = 0;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            sqlConnection.Open();
            using SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                if (clsLocalLicenseApplicationDataAccessLayer.IsLDLAppLinked(LDLappid))
                {
                    return false;
                }

                if (clsTestAppointmentsDataAccessLayer.isTestAppointmentsNotLockedExisted(LDLappid, typeid) && !clsTestAppointmentsDataAccessLayer.DeleteTestAppointmentsByLDLAppID(LDLappid, typeid))
                {
                    sqlTransaction.Rollback();
                    return false;
                }

                string cmdText = "\r\n                        SELECT A.ApplicationID\r\n                            FROM Applications A\r\n                            LEFT JOIN LocalDrivingLicenseApplications L\r\n                                ON A.ApplicationID = L.ApplicationID\r\n                            LEFT JOIN LocalDrivingLicenseApplications_View LV\r\n                                ON LV.LocalDrivingLicenseApplicationID = L.LocalDrivingLicenseApplicationID\r\n                            WHERE L.LocalDrivingLicenseApplicationID = @id";
                int num2 = -1;
                using (SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection, sqlTransaction))
                {
                    sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = LDLappid;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        num2 = (int)sqlDataReader["ApplicationID"];
                    }

                    sqlDataReader.Close();
                }

                if (!clsLocalLicenseApplicationDataAccessLayer.DeleteLocalLicenseApplicationByLDLappID(LDLappid, sqlConnection, sqlTransaction))
                {
                    sqlTransaction.Rollback();
                    return false;
                }

                string cmdText2 = "DELETE FROM [dbo].[Applications]\r\n                            WHERE ApplicationID =  @appid;";
                using (SqlCommand sqlCommand2 = new SqlCommand(cmdText2, sqlConnection, sqlTransaction))
                {
                    sqlCommand2.Parameters.Add("@appid", SqlDbType.Int).Value = num2;
                    num = sqlCommand2.ExecuteNonQuery();
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

    public static bool isApplicationExisted(int personid, int typeid)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select h= 1 from Applications\r\n                    where ApplicantPersonID = @personid and \r\n                    ApplicationTypeID = @typeid \r\n                    and ApplicationStatus in (1,3)";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@personid", personid);
        sqlCommand.Parameters.AddWithValue("@typeid", typeid);
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

