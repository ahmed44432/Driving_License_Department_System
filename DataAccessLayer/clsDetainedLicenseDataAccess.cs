using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace clsDataConnection
{
    public class clsDetainedLicenseDataAccessLayer
    {

        public static int AddLicense(int licenseID, DateTime detainDate,
            byte fineFees, int createdByUserID, bool isReleased, DateTime releaseDate,
             int releasedByUserID, int releaseApplicationID)
        {
            int detainid = -1;
            using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
            {
                string cmdText = @"INSERT INTO [dbo].[DetainedLicenses]
                                   ([LicenseID]
                                   ,[DetainDate]
                                   ,[FineFees]
                                   ,[CreatedByUserID]
                                   ,[IsReleased]
                                   ,[ReleaseDate]
                                   ,[ReleasedByUserID]
                                   ,[ReleaseApplicationID])
                             VALUES
                                   (@LicenseID
                                   ,@DetainDate
                                   ,@FineFees
                                   ,@CreatedByUserID
                                   ,@IsReleased
                                   ,@ReleaseDate
                                   ,@ReleasedByUserID
                                   ,@ReleaseApplicationID)      
                        SELECT SCOPE_IDENTITY()";
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
                sqlCommand.Parameters.Add("@LicenseID", SqlDbType.Int).Value = licenseID;
                sqlCommand.Parameters.Add("@DetainDate", SqlDbType.SmallDateTime).Value = detainDate;
                sqlCommand.Parameters.Add("@FineFees", SqlDbType.SmallMoney).Value = fineFees;
                sqlCommand.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = createdByUserID;
                sqlCommand.Parameters.Add("@IsReleased", SqlDbType.Bit).Value = isReleased;
                if (releaseDate != DateTime.MinValue)
                {
                    sqlCommand.Parameters.Add("@ReleaseDate", SqlDbType.SmallDateTime).Value = releaseDate;
                }
                else
                {
                    sqlCommand.Parameters.Add("@ReleaseDate", SqlDbType.SmallDateTime).Value = DBNull.Value;
                }
                if (releasedByUserID != -1)
                {
                    sqlCommand.Parameters.Add("@ReleasedByUserID", SqlDbType.Int).Value = releasedByUserID;
                }
                else
                {
                    sqlCommand.Parameters.Add("@ReleasedByUserID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (releaseApplicationID != -1)
                {
                    sqlCommand.Parameters.Add("@ReleaseApplicationID", SqlDbType.Int).Value = releaseApplicationID;
                }
                else
                {
                    sqlCommand.Parameters.Add("@ReleaseApplicationID", SqlDbType.Int).Value = DBNull.Value;
                }

                object obj = sqlCommand.ExecuteScalar();
                if (obj != null)
                {
                    detainid = Convert.ToInt32(obj);
                }

            }

            return detainid;
        }



        public static bool UpdateLicense(int DetainID,  int LicenseID, DateTime DetainDate, byte FineFees,
                int CreatedByUserID, bool IsReleased,
                DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            bool result = false;
            using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
            {
                string cmdText = @"UPDATE [dbo].[DetainedLicenses]
                       SET [LicenseID] = <LicenseID, int,>
                          ,[DetainDate] = <DetainDate, smalldatetime,>
                          ,[FineFees] = <FineFees, smallmoney,>
                          ,[CreatedByUserID] = <CreatedByUserID, int,>
                          ,[IsReleased] = <IsReleased, bit,>
                          ,[ReleaseDate] = <ReleaseDate, smalldatetime,>
                          ,[ReleasedByUserID] = <ReleasedByUserID, int,>
                          ,[ReleaseApplicationID] = <ReleaseApplicationID, int,>

                     WHERE DetainID =  @DetainID";
                sqlConnection.Open();
                using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
                sqlCommand.Parameters.Add("@LicenseID", SqlDbType.Int).Value = LicenseID;
                sqlCommand.Parameters.Add("@DetainDate", SqlDbType.SmallDateTime).Value = DetainDate;
                sqlCommand.Parameters.Add("@FineFees", SqlDbType.SmallMoney).Value = FineFees;
                sqlCommand.Parameters.Add("@CreatedByUserID", SqlDbType.Int).Value = CreatedByUserID;
                sqlCommand.Parameters.Add("@IsReleased", SqlDbType.Bit).Value = IsReleased;
                if (ReleaseDate != DateTime.MinValue)
                {
                    sqlCommand.Parameters.Add("@ReleaseDate", SqlDbType.SmallDateTime).Value = ReleaseDate;
                }
                else
                {
                    sqlCommand.Parameters.Add("@ReleaseDate", SqlDbType.SmallDateTime).Value = DBNull.Value;
                }
                if (ReleasedByUserID != -1)
                {
                    sqlCommand.Parameters.Add("@ReleasedByUserID", SqlDbType.Int).Value = ReleasedByUserID;
                }
                else
                {
                    sqlCommand.Parameters.Add("@ReleasedByUserID", SqlDbType.Int).Value = DBNull.Value;
                }
                if (ReleaseApplicationID != -1)
                {
                    sqlCommand.Parameters.Add("@ReleaseApplicationID", SqlDbType.Int).Value = ReleaseApplicationID;
                }
                else
                {
                    sqlCommand.Parameters.Add("@ReleaseApplicationID", SqlDbType.Int).Value = DBNull.Value;
                }

                sqlCommand.Parameters.Add("@DetainID", SqlDbType.Int).Value = DetainID;
                int rowsAffected = sqlCommand.ExecuteNonQuery();
                result = rowsAffected > 0;
            }
            return result;



        }


        public static bool GetDetainLicenseByDetainID(int detainID, ref int licenseID,
                ref DateTime detainDate, ref byte fineFees,
                ref int createdByUserID, ref bool isReleased, ref DateTime releaseDate,
                ref int releasedByUserID, ref int releaseApplicationID)
        {

            bool result = false;
            using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
            {
                string cmdText = @"select * from DetainedLicenses
                    where DetainID =  @id";
                using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = detainID;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    licenseID = (int)sqlDataReader["LicenseID"];
                    detainDate = (DateTime)sqlDataReader["DetainDate"];
                    fineFees = Convert.ToByte(sqlDataReader["FineFees"]);
                    createdByUserID = (int)sqlDataReader["CreatedByUserID"];
                    isReleased = (bool)sqlDataReader["IsReleased"];
                    releaseDate = (sqlDataReader["ReleaseDate"] != DBNull.Value) ? (DateTime)sqlDataReader["ReleaseDate"] : DateTime.MinValue;
                    releasedByUserID = (sqlDataReader["ReleasedByUserID"] != DBNull.Value) ? (int)sqlDataReader["ReleasedByUserID"] : -1;
                    releaseApplicationID = (sqlDataReader["ReleaseApplicationID"] != DBNull.Value) ? (int)sqlDataReader["ReleaseApplicationID"] : -1;
                    
                    result = true;
                }
            }

            return result;

        }


        public static bool IsLicenseDetainedByLicenseID(int licenseID)
        {
            bool result = false;
            using (SqlConnection sqlConnection = new SqlConnection(clsConnection.ConnectString))
            {
                string cmdText = @"select Ahmed = 1 from DetainedLicenses
                where LicenseID = @id and IsReleased = 0;";
                using SqlCommand sqlCommand = new SqlCommand(cmdText, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = licenseID;
                object obj = sqlCommand.ExecuteScalar();
                result = obj != null;
            }

            return result;
        }









    }



}
