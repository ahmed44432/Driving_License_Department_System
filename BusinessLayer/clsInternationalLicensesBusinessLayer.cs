
using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer;

public class clsInternationalLicensesBusinessLayer
{
    public enum enMode
    {
        add,
        update
    }

    private enMode _Mode;

    public int InternationalLicenseID { get; set; }

    public int ApplicationID { get; set; }

    public int DriverID { get; set; }

    public int LocalLicenseID { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public bool IsActive { get; set; }

    public int CreatedByUserID { get; set; }

    public clsInternationalLicensesBusinessLayer()
    {
        InternationalLicenseID = -1;
        ApplicationID = -1;
        DriverID = -1;
        LocalLicenseID = -1;
        IssueDate = DateTime.MinValue;
        ExpirationDate = DateTime.MinValue;
        IsActive = false;
        CreatedByUserID = -1;
        _Mode = enMode.add;
    }

    private clsInternationalLicensesBusinessLayer(int internationalLicenseID, int applicationID, int driverID, int localLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
    {
        InternationalLicenseID = internationalLicenseID;
        ApplicationID = applicationID;
        DriverID = driverID;
        LocalLicenseID = localLicenseID;
        IssueDate = issueDate;
        ExpirationDate = expirationDate;
        IsActive = isActive;
        CreatedByUserID = createdByUserID;
        _Mode = enMode.update;
    }

    public static clsInternationalLicensesBusinessLayer? GetIntLicenseByApplicationID(int applicationid)
    {
        int internationalLicenseID = -1;
        int driverID = -1;
        int localLicenseID = -1;
        DateTime issueDate = DateTime.MinValue;
        DateTime expirationDate = DateTime.MinValue;
        bool isActive = false;
        int createdByUserID = -1;
        if (clsInternationalLicensesDataAccessLayer.GetIntLicenseByApplicationID(applicationid, ref internationalLicenseID, ref driverID, ref localLicenseID, ref issueDate, ref expirationDate, ref isActive, ref createdByUserID))
        {
            return new clsInternationalLicensesBusinessLayer(internationalLicenseID, applicationid, driverID, localLicenseID, issueDate, expirationDate, isActive, createdByUserID);
        }

        return null;
    }

    private bool _AddNewLicense()
    {
        InternationalLicenseID = clsInternationalLicensesDataAccessLayer.AddNewLicense(ApplicationID, DriverID, LocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
        return InternationalLicenseID != -1;
    }

    public bool Save()
    {
        if (_Mode == enMode.add)
        {
            if (_AddNewLicense())
            {
                _Mode = enMode.update;
                return true;
            }

            return false;
        }

        return false;
    }

    public static DataTable GetAllInternationalLicenses()
    {
        return clsInternationalLicensesDataAccessLayer.GetAllInternationalLicenses();
    }

    public static DataTable GetAllInternationalLicensesByIntLicenseID(int intlicenseid)
    {
        return clsInternationalLicensesDataAccessLayer.GetAllInternationalLicensesByIntLicenseID(intlicenseid);
    }

    public static DataTable GetAllInternationalLicensesByApplicationID(int applicationid)
    {
        return clsInternationalLicensesDataAccessLayer.GetAllInternationalLicensesByApplicationID(applicationid);
    }

    public static DataTable GetAllInternationalLicensesByDriverID(int driverid)
    {
        return clsInternationalLicensesDataAccessLayer.GetAllInternationalLicensesByDriverID(driverid);
    }

    public static DataTable GetAllInternationalLicensesByStatus(bool isactive)
    {
        return clsInternationalLicensesDataAccessLayer.GetAllInternationalLicensesByStatus(isactive);
    }

    public static bool IsInternationalLicenseActive(int driverid)
    {
        return clsInternationalLicensesDataAccessLayer.IsInternationalLicenseActive(driverid);
    }
}

