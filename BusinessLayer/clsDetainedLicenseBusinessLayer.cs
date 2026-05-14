using System;
using System.Collections.Generic;
using System.Text;
using clsDataConnection;

namespace BusinessLayer
{
    public class clsDetainedLicenseBusinessLayer
    {

        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public byte FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ReleasedByUserID { get; set; }
        public int ReleaseApplicationID { get; set; }


        public enum enMode{ add, update}

        private enMode _Mode;


        public clsDetainedLicenseBusinessLayer()
        {
            DetainID = -1;
            LicenseID = -1;
            DetainDate = DateTime.MinValue;
            FineFees = 0;
            CreatedByUserID = -1;
            IsReleased = false;

            ReleaseDate = DateTime.MinValue;
            ReleasedByUserID = -1;
            ReleaseApplicationID = -1;
            _Mode = enMode.add;

        }

        public clsDetainedLicenseBusinessLayer(int detainID,int licenseID,DateTime detainDate,
            byte fineFees,int createdByUserID,bool isReleased,DateTime releaseDate,
             int releasedByUserID,int releaseApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;
            _Mode = enMode.update;
        }


        private bool _AddDetainedLicense()
        {
            this.DetainID = clsDetainedLicenseDataAccessLayer.
                AddLicense(LicenseID, DetainDate, FineFees,
                CreatedByUserID, IsReleased,
                ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            return DetainID != -1;
        }

        public bool _UpdateDetainedLicense()
        {
            return clsDetainedLicenseDataAccessLayer.UpdateLicense(DetainID,  LicenseID,  DetainDate,  FineFees,
                CreatedByUserID,  IsReleased,
                 ReleaseDate,  ReleasedByUserID,  ReleaseApplicationID);
           
        }


        public static clsDetainedLicenseBusinessLayer? GetDetainLicenseByDetainID(int detainID)
        {
            int licenseID = -1;
            DateTime detainDate = DateTime.MinValue;
            byte fineFees = 0;
            int createdByUserID = -1;
            bool isReleased = false;
            DateTime releaseDate = DateTime.MinValue;
            int releasedByUserID = -1;
            int releaseApplicationID = -1;

            if (clsDetainedLicenseDataAccessLayer.GetDetainLicenseByDetainID(detainID, ref licenseID,
                ref detainDate,ref fineFees,
                ref createdByUserID, ref isReleased, ref releaseDate,
                ref releasedByUserID,ref releaseApplicationID))
            {
                return new clsDetainedLicenseBusinessLayer(
                    detainID, licenseID,detainDate,fineFees,
                    createdByUserID,isReleased,releaseDate,releasedByUserID,
                    releaseApplicationID
                );
            }

            return null;
        }



        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.add:
                    if (_AddDetainedLicense())
                    {
                        _Mode = enMode.update;
                        return true;
                    }

                    return false;
                case enMode.update:
                    if (_UpdateDetainedLicense())
                    {
                        return true;
                    }

                    return false;
                default:
                    return false;
            }
        }


        public static bool IsLicenseDetainedByLicenseID(int licenseID)
        {
            return clsDetainedLicenseDataAccessLayer.IsLicenseDetainedByLicenseID(licenseID);
        }















    }



}
