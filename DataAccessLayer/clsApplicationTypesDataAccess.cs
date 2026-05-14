
using clsDataConnection;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public class clsApplicationTypesDataAccessLayer
{
    public static DataTable GetApplicationTypes()
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select\r\n                                    ApplicationTypeID as ID,\r\n                                    ApplicationTypeTitle as Title,\r\n                                    ApplicationFees as Fees\r\n                                    from ApplicationTypes";
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

    public static bool UpdateAppType(int id, string title, int fees)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        int num = 0;
        string cmdText = "UPDATE [dbo].[ApplicationTypes]\r\n             SET [ApplicationTypeTitle] = @title\r\n                  ,[ApplicationFees] = @fees\r\n             WHERE ApplicationTypeID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", id);
        sqlCommand.Parameters.AddWithValue("@title", title);
        sqlCommand.Parameters.AddWithValue("@fees", fees);
        try
        {
            sqlConnection.Open();
            num = sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            sqlConnection.Close();
        }

        return num > 0;
    }

    public static bool GetAppTypeByID(int id, ref string titel, ref int fees)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from ApplicationTypes \r\n                                    where ApplicationTypeID = @id ";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", id);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                id = (int)sqlDataReader["ApplicationTypeID"];
                titel = (string)sqlDataReader["ApplicationTypeTitle"];
                fees = ((sqlDataReader["ApplicationFees"] != DBNull.Value) ? Convert.ToInt32(sqlDataReader["ApplicationFees"]) : 0);
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

    public static int GetAppTypeFeesByID(int id)
    {
        string cmdText = "\r\n                select ApplicationFees from ApplicationTypes \r\n                where ApplicationTypeID = @id";
        using SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;
        sqlConnection.Open();
        object obj = sqlCommand.ExecuteScalar();
        if (obj == null || obj == DBNull.Value)
        {
            return 0;
        }

        return Convert.ToInt32(obj);
    }
}

