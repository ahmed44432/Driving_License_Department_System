
using clsDataConnection;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public class clsLicenseClassesDataAccessLayer
{
    public static DataTable GetLicenseClasses()
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from LicenseClasses ";
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

    public static DataTable GetLicenseClassesNames()
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select ClassName from LicenseClasses";
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

    public static int GetLicenseClassesFeesByID(int id)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select ClassFees from LicenseClasses\r\n                                    where LicenseClassID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
        object obj = 0;
        try
        {
            sqlConnection.Open();
            obj = sqlCommand.ExecuteScalar();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            sqlConnection.Close();
        }

        return (obj != null) ? Convert.ToInt32(obj) : 0;
    }

    public static int GetLicenseClassIDByName(string classname)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select LicenseClassID from LicenseClasses\r\n                        where ClassName = @classname";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.Add("@classname", SqlDbType.NVarChar).Value = classname;
        object obj = 0;
        try
        {
            sqlConnection.Open();
            obj = sqlCommand.ExecuteScalar();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            sqlConnection.Close();
        }

        return (obj != null) ? Convert.ToInt32(obj) : 0;
    }

    public static string? GetLicenseClassNameByID(int classid)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select ClassName from LicenseClasses\r\n                where LicenseClassID =  @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.Add("@id", SqlDbType.NVarChar).Value = classid;
        object obj = "";
        try
        {
            sqlConnection.Open();
            obj = sqlCommand.ExecuteScalar();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            sqlConnection.Close();
        }

        return (obj != null) ? Convert.ToString(obj) : "";
    }

    public static int GetLicenseValidityLength(int id)
    {
        int result = 0;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "select DefaultValidityLength from LicenseClasses\r\n                            where LicenseClassID = @id";
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlConnection.Open();
            sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
            object value = sqlCommand.ExecuteScalar() ?? ((object)0);
            result = Convert.ToInt32(value);
        }

        return result;
    }
}
