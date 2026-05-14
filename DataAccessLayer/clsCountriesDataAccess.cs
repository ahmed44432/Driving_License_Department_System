
using clsDataConnection;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public class clsCountriesDataAccessLayer
{
    public static DataTable GetAllCoutries()
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from Countries";
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

    public static string GetCountryNameByNumber(int CountryNumber)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select Countries.CountryName from Countries \r\n                                                where CountryID = @CountryNumber";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@CountryNumber", CountryNumber);
        string result = "";
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                result = (string)sqlDataReader["CountryName"];
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

