
using clsDataConnection;
using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer;

public class clsPeopleDataAccessLayer
{
    public static DataTable GetAllPeople()
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select \r\n                                      p.PersonID,\r\n                                      p.FirstName,\r\n                                      p.SecondName,\r\n                                      p.ThirdName,\r\n                                      p.LastName,\r\n                                      c.CountryName as Nationality,\r\n                                      p.Gendor,\r\n                                      p.Phone,\r\n                                      p.Email,\r\n                                      p.ImagePath\r\n                                  from People p\r\n                                  join Countries c\r\n                                      on p.NationalityCountryID = c.CountryID";
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

    public static DataTable GetAllPeopleBYID(int id)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select \r\n                  p.PersonID,\r\n                  p.FirstName,\r\n                  p.SecondName,\r\n                  p.ThirdName,\r\n                  p.LastName,\r\n                  c.CountryName as Nationality,\r\n                  p.Gendor,\r\n                  p.Phone,\r\n                  p.Email,\r\n                  p.ImagePath\r\n              from People p\r\n              join Countries c\r\n                  on p.NationalityCountryID = c.CountryID\r\n                    Where PersonID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        DataTable dataTable = new DataTable();
        sqlCommand.Parameters.AddWithValue("@id", id);
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

    public static DataTable GetAllPeopleByNationalNO(string NNO)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select \r\n                  p.PersonID,\r\n                  p.FirstName,\r\n                  p.SecondName,\r\n                  p.ThirdName,\r\n                  p.LastName,\r\n                  c.CountryName as Nationality,\r\n                  p.Gendor,\r\n                  p.Phone,\r\n                  p.Email,\r\n                  p.ImagePath\r\n              from People p\r\n              join Countries c\r\n                  on p.NationalityCountryID = c.CountryID\r\n                    Where NationalNo = @nno";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        DataTable dataTable = new DataTable();
        sqlCommand.Parameters.AddWithValue("@nno", NNO);
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

    public static DataTable GetAllPeopleByFirstName(string Name)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select \r\n                  p.PersonID,\r\n                  p.FirstName,\r\n                  p.SecondName,\r\n                  p.ThirdName,\r\n                  p.LastName,\r\n                  c.CountryName as Nationality,\r\n                  p.Gendor,\r\n                  p.Phone,\r\n                  p.Email,\r\n                  p.ImagePath\r\n              from People p\r\n              join Countries c\r\n                  on p.NationalityCountryID = c.CountryID\r\n                    Where FirstName like @name";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        DataTable dataTable = new DataTable();
        sqlCommand.Parameters.AddWithValue("@name", Name + "%");
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

    public static DataTable GetAllPeopleBySecondName(string Name)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select \r\n                  p.PersonID,\r\n                  p.FirstName,\r\n                  p.SecondName,\r\n                  p.ThirdName,\r\n                  p.LastName,\r\n                  c.CountryName as Nationality,\r\n                  p.Gendor,\r\n                  p.Phone,\r\n                  p.Email,\r\n                  p.ImagePath\r\n              from People p\r\n              join Countries c\r\n                  on p.NationalityCountryID = c.CountryID\r\n                    Where SecondName like @name";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        DataTable dataTable = new DataTable();
        sqlCommand.Parameters.AddWithValue("@name", Name + "%");
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

    public static DataTable GetAllPeopleByThirdName(string Name)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select \r\n                  p.PersonID,\r\n                  p.FirstName,\r\n                  p.SecondName,\r\n                  p.ThirdName,\r\n                  p.LastName,\r\n                  c.CountryName as Nationality,\r\n                  p.Gendor,\r\n                  p.Phone,\r\n                  p.Email,\r\n                  p.ImagePath\r\n              from People p\r\n              join Countries c\r\n                  on p.NationalityCountryID = c.CountryID\r\n                    Where ThirdName like @name";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        DataTable dataTable = new DataTable();
        sqlCommand.Parameters.AddWithValue("@name", Name + "%");
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

    public static DataTable GetAllPeopleByLastName(string Name)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select \r\n                  p.PersonID,\r\n                  p.FirstName,\r\n                  p.SecondName,\r\n                  p.ThirdName,\r\n                  p.LastName,\r\n                  c.CountryName as Nationality,\r\n                  p.Gendor,\r\n                  p.Phone,\r\n                  p.Email,\r\n                  p.ImagePath\r\n              from People p\r\n              join Countries c\r\n                  on p.NationalityCountryID = c.CountryID\r\n                    Where LastName like @name";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        DataTable dataTable = new DataTable();
        sqlCommand.Parameters.AddWithValue("@name", Name + "%");
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

    public static DataTable GetAllPeopleByNationality(string CountryName)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select \r\n                  p.PersonID,\r\n                  p.FirstName,\r\n                  p.SecondName,\r\n                  p.ThirdName,\r\n                  p.LastName,\r\n                  c.CountryName as Nationality,\r\n                  p.Gendor,\r\n                  p.Phone,\r\n                  p.Email,\r\n                  p.ImagePath\r\n              from People p\r\n              join Countries c\r\n                  on p.NationalityCountryID = c.CountryID\r\n                    Where CountryName like @CountryName";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        DataTable dataTable = new DataTable();
        sqlCommand.Parameters.AddWithValue("@CountryName", CountryName + "%");
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

    public static DataTable GetAllPeopleByGender(string Gender)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select \r\n                  p.PersonID,\r\n                  p.FirstName,\r\n                  p.SecondName,\r\n                  p.ThirdName,\r\n                  p.LastName,\r\n                  c.CountryName as Nationality,\r\n                  p.Gendor,\r\n                  p.Phone,\r\n                  p.Email,\r\n                  p.ImagePath\r\n              from People p\r\n              join Countries c\r\n                  on p.NationalityCountryID = c.CountryID\r\n                    Where Gendor = @Gender";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        DataTable dataTable = new DataTable();
        sqlCommand.Parameters.AddWithValue("@Gender", Gender);
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

    public static DataTable GetAllPeopleByPhone(string Phone)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select \r\n                  p.PersonID,\r\n                  p.FirstName,\r\n                  p.SecondName,\r\n                  p.ThirdName,\r\n                  p.LastName,\r\n                  c.CountryName as Nationality,\r\n                  p.Gendor,\r\n                  p.Phone,\r\n                  p.Email,\r\n                  p.ImagePath\r\n              from People p\r\n              join Countries c\r\n                  on p.NationalityCountryID = c.CountryID\r\n                    Where Phone like @Phone";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        DataTable dataTable = new DataTable();
        sqlCommand.Parameters.AddWithValue("@Phone", Phone + "%");
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

    public static DataTable GetAllPeopleByEmail(string Email)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select \r\n                  p.PersonID,\r\n                  p.FirstName,\r\n                  p.SecondName,\r\n                  p.ThirdName,\r\n                  p.LastName,\r\n                  c.CountryName as Nationality,\r\n                  p.Gendor,\r\n                  p.Phone,\r\n                  p.Email,\r\n                  p.ImagePath\r\n              from People p\r\n              join Countries c\r\n                  on p.NationalityCountryID = c.CountryID\r\n                    Where Email like @Email";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        DataTable dataTable = new DataTable();
        sqlCommand.Parameters.AddWithValue("@Email", Email + "%");
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

    public static bool GetPersonByID(int id, ref string nationalNumber, ref string firstName,
        ref string secondName, ref string thirdName,
        ref string lastName, ref DateTime dateOfBirth, ref char gender,
        ref string address, ref string email, ref string phone, ref string imagePath,
        ref int nationalityCountryID)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from People where PersonID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", id);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                nationalNumber = (string)sqlDataReader["NationalNo"];
                firstName = (string)sqlDataReader["FirstName"];
                secondName = (string)sqlDataReader["SecondName"];
                if (sqlDataReader["ThirdName"] != DBNull.Value)
                {
                    thirdName = (string)sqlDataReader["ThirdName"];
                }
                else
                {
                    thirdName = "";
                }

                lastName = (string)sqlDataReader["LastName"];
                dateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
                gender = Convert.ToChar(sqlDataReader["Gendor"]);
               
                address = (string)sqlDataReader["Address"];
                if (sqlDataReader["Email"] != DBNull.Value)
                {
                    email = (string)sqlDataReader["Email"];
                }
                else
                {
                    email = "";
                }

                phone = (string)sqlDataReader["Phone"];
                if (sqlDataReader["ImagePath"] != DBNull.Value)
                {
                    imagePath = (string)sqlDataReader["ImagePath"];
                }
                else
                {
                    imagePath = "";
                }

                if (sqlDataReader["Email"] != DBNull.Value)
                {
                    email = (string)sqlDataReader["Email"];
                }
                else
                {
                    email = "";
                }

                nationalityCountryID = (int)sqlDataReader["NationalityCountryID"];
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

    public static bool GetPersonByApplicationID(int applicationID, ref int personID, ref string nationalNumber, ref string firstName, ref string secondName, ref string thirdName, ref string lastName, ref DateTime dateOfBirth, ref char gender, ref string address, ref string email, ref string phone, ref string imagePath, ref int nationalityCountryID)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select People.* from People\r\n                inner join Applications \r\n                on Applications.ApplicantPersonID = People.PersonID\r\n                where Applications.ApplicationID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", applicationID);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                personID = (int)sqlDataReader["PersonID"];
                nationalNumber = (string)sqlDataReader["NationalNo"];
                firstName = (string)sqlDataReader["FirstName"];
                secondName = (string)sqlDataReader["SecondName"];
                if (sqlDataReader["ThirdName"] != DBNull.Value)
                {
                    thirdName = (string)sqlDataReader["ThirdName"];
                }
                else
                {
                    thirdName = "";
                }

                lastName = (string)sqlDataReader["LastName"];
                dateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
                gender = (char)sqlDataReader["Gender"];
                address = (string)sqlDataReader["Address"];
                if (sqlDataReader["Email"] != DBNull.Value)
                {
                    email = (string)sqlDataReader["Email"];
                }
                else
                {
                    email = "";
                }

                phone = (string)sqlDataReader["Phone"];
                if (sqlDataReader["ImagePath"] != DBNull.Value)
                {
                    imagePath = (string)sqlDataReader["ImagePath"];
                }
                else
                {
                    imagePath = "";
                }

                if (sqlDataReader["Email"] != DBNull.Value)
                {
                    email = (string)sqlDataReader["Email"];
                }
                else
                {
                    email = "";
                }

                nationalityCountryID = (int)sqlDataReader["NationalityCountryID"];
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

    public static bool GetPersonByNationalNO(ref int id, ref string nationalNumber, ref string firstName, ref string secondName, ref string thirdName, ref string lastName, ref DateTime dateOfBirth, ref char gender, ref string address, ref string email, ref string phone, ref string imagePath, ref int nationalityCountryID)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from People where NationalNo = @nno";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@nno", nationalNumber);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                id = (int)sqlDataReader["PersonID"];
                nationalNumber = (string)sqlDataReader["NationalNo"];
                firstName = (string)sqlDataReader["FirstName"];
                secondName = (string)sqlDataReader["SecondName"];
                if (sqlDataReader["ThirdName"] != DBNull.Value)
                {
                    thirdName = (string)sqlDataReader["ThirdName"];
                }
                else
                {
                    thirdName = "";
                }

                lastName = (string)sqlDataReader["LastName"];
                dateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
                gender = (char)sqlDataReader["Gender"];
                address = (string)sqlDataReader["Address"];
                if (sqlDataReader["Email"] != DBNull.Value)
                {
                    email = (string)sqlDataReader["Email"];
                }
                else
                {
                    email = "";
                }

                phone = (string)sqlDataReader["Phone"];
                if (sqlDataReader["ImagePath"] != DBNull.Value)
                {
                    imagePath = (string)sqlDataReader["ImagePath"];
                }
                else
                {
                    imagePath = "";
                }

                if (sqlDataReader["Email"] != DBNull.Value)
                {
                    email = (string)sqlDataReader["Email"];
                }
                else
                {
                    email = "";
                }

                nationalityCountryID = (int)sqlDataReader["NationalityCountryID"];
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

    public static bool GetPersonByFirstName(ref int id, ref string nationalNumber, ref string firstName, ref string secondName, ref string thirdName, ref string lastName, ref DateTime dateOfBirth, ref char gender, ref string address, ref string email, ref string phone, ref string imagePath, ref int nationalityCountryID)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from People where FirstName like @name";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@name", firstName);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                id = (int)sqlDataReader["PersonID"];
                nationalNumber = (string)sqlDataReader["NationalNo"];
                firstName = (string)sqlDataReader["FirstName"];
                secondName = (string)sqlDataReader["SecondName"];
                if (sqlDataReader["ThirdName"] != DBNull.Value)
                {
                    thirdName = (string)sqlDataReader["ThirdName"];
                }
                else
                {
                    thirdName = "";
                }

                lastName = (string)sqlDataReader["LastName"];
                dateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
                gender = (char)sqlDataReader["Gender"];
                address = (string)sqlDataReader["Address"];
                if (sqlDataReader["Email"] != DBNull.Value)
                {
                    email = (string)sqlDataReader["Email"];
                }
                else
                {
                    email = "";
                }

                phone = (string)sqlDataReader["Phone"];
                if (sqlDataReader["ImagePath"] != DBNull.Value)
                {
                    imagePath = (string)sqlDataReader["ImagePath"];
                }
                else
                {
                    imagePath = "";
                }

                if (sqlDataReader["Email"] != DBNull.Value)
                {
                    email = (string)sqlDataReader["Email"];
                }
                else
                {
                    email = "";
                }

                nationalityCountryID = (int)sqlDataReader["NationalityCountryID"];
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

    public static bool GetPersonBySecondName(ref int id, ref string nationalNumber, ref string firstName, ref string secondName, ref string thirdName, ref string lastName, ref DateTime dateOfBirth, ref char gender, ref string address, ref string email, ref string phone, ref string imagePath, ref int nationalityCountryID)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from People where SecondName like @name";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@name", secondName);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                id = (int)sqlDataReader["PersonID"];
                nationalNumber = (string)sqlDataReader["NationalNo"];
                firstName = (string)sqlDataReader["FirstName"];
                secondName = (string)sqlDataReader["SecondName"];
                if (sqlDataReader["ThirdName"] != DBNull.Value)
                {
                    thirdName = (string)sqlDataReader["ThirdName"];
                }
                else
                {
                    thirdName = "";
                }

                lastName = (string)sqlDataReader["LastName"];
                dateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
                gender = (char)sqlDataReader["Gender"];
                address = (string)sqlDataReader["Address"];
                if (sqlDataReader["Email"] != DBNull.Value)
                {
                    email = (string)sqlDataReader["Email"];
                }
                else
                {
                    email = "";
                }

                phone = (string)sqlDataReader["Phone"];
                if (sqlDataReader["ImagePath"] != DBNull.Value)
                {
                    imagePath = (string)sqlDataReader["ImagePath"];
                }
                else
                {
                    imagePath = "";
                }

                if (sqlDataReader["Email"] != DBNull.Value)
                {
                    email = (string)sqlDataReader["Email"];
                }
                else
                {
                    email = "";
                }

                nationalityCountryID = (int)sqlDataReader["NationalityCountryID"];
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

    public static bool GetPersonByThirdName(ref int id, ref string nationalNumber, ref string firstName, ref string secondName, ref string thirdName, ref string lastName, ref DateTime dateOfBirth, ref char gender, ref string address, ref string email, ref string phone, ref string imagePath, ref int nationalityCountryID)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from People where ThirdName like @name";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@name", thirdName);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                id = (int)sqlDataReader["PersonID"];
                nationalNumber = (string)sqlDataReader["NationalNo"];
                firstName = (string)sqlDataReader["FirstName"];
                secondName = (string)sqlDataReader["SecondName"];
                if (sqlDataReader["ThirdName"] != DBNull.Value)
                {
                    thirdName = (string)sqlDataReader["ThirdName"];
                }
                else
                {
                    thirdName = "";
                }

                lastName = (string)sqlDataReader["LastName"];
                dateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
                gender = (char)sqlDataReader["Gendor"];
                address = (string)sqlDataReader["Address"];
                if (sqlDataReader["Email"] != DBNull.Value)
                {
                    email = (string)sqlDataReader["Email"];
                }
                else
                {
                    email = "";
                }

                phone = (string)sqlDataReader["Phone"];
                if (sqlDataReader["ImagePath"] != DBNull.Value)
                {
                    imagePath = (string)sqlDataReader["ImagePath"];
                }
                else
                {
                    imagePath = "";
                }

                if (sqlDataReader["Email"] != DBNull.Value)
                {
                    email = (string)sqlDataReader["Email"];
                }
                else
                {
                    email = "";
                }

                nationalityCountryID = (int)sqlDataReader["NationalityCountryID"];
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

    public static bool GetPersonByLastName(ref int id, ref string nationalNumber, ref string firstName, ref string secondName, ref string thirdName, ref string lastName, ref DateTime dateOfBirth, ref char gender, ref string address, ref string email, ref string phone, ref string imagePath, ref int nationalityCountryID)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select * from People where LastName like @name";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@name", lastName);
        try
        {
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                id = (int)sqlDataReader["PersonID"];
                nationalNumber = (string)sqlDataReader["NationalNo"];
                firstName = (string)sqlDataReader["FirstName"];
                secondName = (string)sqlDataReader["SecondName"];
                if (sqlDataReader["ThirdName"] != DBNull.Value)
                {
                    thirdName = (string)sqlDataReader["ThirdName"];
                }
                else
                {
                    thirdName = "";
                }

                lastName = (string)sqlDataReader["LastName"];
                dateOfBirth = (DateTime)sqlDataReader["DateOfBirth"];
                gender = (char)sqlDataReader["Gender"];
                address = (string)sqlDataReader["Address"];
                if (sqlDataReader["Email"] != DBNull.Value)
                {
                    email = (string)sqlDataReader["Email"];
                }
                else
                {
                    email = "";
                }

                phone = (string)sqlDataReader["Phone"];
                if (sqlDataReader["ImagePath"] != DBNull.Value)
                {
                    imagePath = (string)sqlDataReader["ImagePath"];
                }
                else
                {
                    imagePath = "";
                }

                if (sqlDataReader["Email"] != DBNull.Value)
                {
                    email = (string)sqlDataReader["Email"];
                }
                else
                {
                    email = "";
                }

                nationalityCountryID = (int)sqlDataReader["NationalityCountryID"];
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

    public static int AddNewPerson(string nationalNumber, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth, char gender, string address, string email, string phone, string imagePath, int nationalityCountryID)
    {
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        int result = -1;
        string cmdText = "INSERT INTO [dbo].[People]\r\n           ([NationalNo]\r\n           ,[FirstName]\r\n           ,[SecondName]\r\n           ,[ThirdName]\r\n           ,[LastName]\r\n           ,[DateOfBirth]\r\n           ,[Gendor]\r\n           ,[Address]\r\n           ,[Phone]\r\n           ,[Email]\r\n           ,[NationalityCountryID]\r\n           ,[ImagePath])\r\n\r\n      VALUES\r\n             (@NationalNo\r\n            , @FirstName\r\n            , @SecondName\r\n            , @ThirdName\r\n            , @LastName\r\n            , @DateOfBirth\r\n            , @Gendor\r\n            , @Address\r\n            , @Phone\r\n            , @Email\r\n            , @NationalityCountryID\r\n            , @ImagePath )\r\n            SELECT SCOPE_IDENTITY();";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@NationalNo", nationalNumber);
        sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
        sqlCommand.Parameters.AddWithValue("@SecondName", secondName);
        if (thirdName != "")
        {
            sqlCommand.Parameters.AddWithValue("@ThirdName", thirdName);
        }
        else
        {
            sqlCommand.Parameters.AddWithValue("@ThirdName", DBNull.Value);
        }

        sqlCommand.Parameters.AddWithValue("@LastName", lastName);
        sqlCommand.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
        sqlCommand.Parameters.AddWithValue("@Gendor", char.ToUpper(gender));
        sqlCommand.Parameters.AddWithValue("@Address", address);
        sqlCommand.Parameters.AddWithValue("@Phone", phone);
        if (email != "")
        {
            sqlCommand.Parameters.AddWithValue("@Email", email);
        }
        else
        {
            sqlCommand.Parameters.AddWithValue("@Email", DBNull.Value);
        }

        sqlCommand.Parameters.AddWithValue("@NationalityCountryID", nationalityCountryID);
        if (imagePath != "")
        {
            sqlCommand.Parameters.AddWithValue("@ImagePath", imagePath);
        }
        else
        {
            sqlCommand.Parameters.AddWithValue("@ImagePath", DBNull.Value);
        }

        try
        {
            sqlConnection.Open();
            object obj = sqlCommand.ExecuteScalar();
            if (obj != null && int.TryParse(obj.ToString(), out var result2))
            {
                result = result2;
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

    public static bool UpdatePerson(int id, string nationalNumber, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth, char gender, string address, string email, string phone, string imagePath, int nationalityCountryID)
    {
        int num = 0;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "UPDATE [dbo].[People]\r\n       SET\r\n       [NationalNo]             = @NationalNo\r\n      ,[FirstName]              = @FirstName\r\n      ,[SecondName]             = @SecondName\r\n      ,[ThirdName]              = @ThirdName\r\n      ,[LastName]               = @LastName\r\n      ,[DateOfBirth]            = @DateOfBirth\r\n      ,[Gendor]                 = @Gendor\r\n      ,[Address]                = @Address\r\n      ,[Phone]                  = @Phone\r\n      ,[Email]                  = @Email\r\n      ,[NationalityCountryID]   = @NationalityCountryID\r\n      ,[ImagePath]              = @ImagePath \r\n       WHERE PersonID = @id ";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", id);
        sqlCommand.Parameters.AddWithValue("@NationalNo", nationalNumber);
        sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
        sqlCommand.Parameters.AddWithValue("@SecondName", secondName);
        if (thirdName != "")
        {
            sqlCommand.Parameters.AddWithValue("@ThirdName", thirdName);
        }
        else
        {
            sqlCommand.Parameters.AddWithValue("@ThirdName", DBNull.Value);
        }

        sqlCommand.Parameters.AddWithValue("@LastName", lastName);
        sqlCommand.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
        sqlCommand.Parameters.AddWithValue("@Gendor", char.ToUpper(gender));
        sqlCommand.Parameters.AddWithValue("@Address", address);
        sqlCommand.Parameters.AddWithValue("@Phone", phone);
        if (email != "")
        {
            sqlCommand.Parameters.AddWithValue("@Email", email);
        }
        else
        {
            sqlCommand.Parameters.AddWithValue("@Email", DBNull.Value);
        }

        sqlCommand.Parameters.AddWithValue("@NationalityCountryID", nationalityCountryID);
        if (imagePath != "")
        {
            sqlCommand.Parameters.AddWithValue("@ImagePath", imagePath);
        }
        else
        {
            sqlCommand.Parameters.AddWithValue("@ImagePath", DBNull.Value);
        }

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

    public static bool isPersonExisted(int id)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select h = 1 from People where PersonID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", id);
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

    public static bool isPersonExisted(string firstname, string lastname)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select h = 1 from People where\r\n            FirstName = @firstname and LastName = @lastname";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@firstname", firstname);
        sqlCommand.Parameters.AddWithValue("@lastname", lastname);
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

    public static bool isPersonExisted(string NationalNumber)
    {
        bool result = false;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "select h = 1 from People where NationalNo = @NationalNumber";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@NationalNumber", NationalNumber);
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

    public static bool IsPersonLinked(int personid)
    {
        bool result = false;
        using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
        {
            string cmdText = "SELECT Ahmed = 1\r\n                    FROM People\r\n                    WHERE EXISTS (\r\n                        SELECT 1 FROM Applications\r\n                        WHERE Applications.ApplicantPersonID = People.PersonID\r\n                    )\r\n                    and People.PersonID = @PersonID";
            sqlConnection.Open();
            using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
            sqlCommand.Parameters.Add("@PersonID", SqlDbType.Int).Value = personid;
            object obj = sqlCommand.ExecuteScalar();
            if (obj != null)
            {
                result = true;
            }
        }

        return result;
    }

    public static bool DeletePerson(int id)
    {
        int num = 0;
        SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString);
        string cmdText = "delete from People where PersonID = @id";
        SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
        sqlCommand.Parameters.AddWithValue("@id", id);
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

        return num != 0;
    }
}


