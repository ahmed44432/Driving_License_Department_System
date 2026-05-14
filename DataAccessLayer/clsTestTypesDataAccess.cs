
using clsDataConnection;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public class clsTestTypesDataAccessLayer
{
    public static DataTable GetTestTypes()
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select\r\n                                    TestTypeID as [ID],\r\n                                    TestTypeTitle as [Title],\r\n                                    TestTypeDescription as [Description],\r\n                                    TestTypeFees as [Fees]\r\n                                    from TestTypes ";
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

    public static bool UpdateTestType(int id, string title, string description, int fees)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        int num = 0;
        string cmdText = "UPDATE [dbo].[TestTypes]\r\n                       SET [TestTypeTitle] = @title\r\n                          ,[TestTypeDescription] = @description \r\n                          ,[TestTypeFees] = @fees\r\n                     WHERE TestTypeID = @id ";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", id);
        sqlCommand.Parameters.AddWithValue("@title", title);
        sqlCommand.Parameters.AddWithValue("@description", description);
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

    public static bool GetTestTypeByID(int id, ref string titel, ref string description, ref int fees)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from TestTypes\r\n                                   where TestTypeID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", id);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                id = (int)sqlDataReader["TestTypeID"];
                titel = (string)sqlDataReader["TestTypeTitle"];
                fees = ((sqlDataReader["TestTypeFees"] != DBNull.Value) ? Convert.ToInt32(sqlDataReader["TestTypeFees"]) : 0);
                description = ((sqlDataReader["TestTypeDescription"] == DBNull.Value) ? "" : ((string)sqlDataReader["TestTypeDescription"]));
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


