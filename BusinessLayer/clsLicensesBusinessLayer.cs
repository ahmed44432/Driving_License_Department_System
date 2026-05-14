
using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer;

public class clsLicensesBusinessLayer
{
    public enum enMode
    {
        add,
        update
    }

    private enMode _Mode;

    public int LicenseID { get; set; }

    public int ApplicationID { get; set; }

    public int DriverID { get; set; }

    public byte LicenseClass { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime ExpirationDate { get; set; }

    public string Notes { get; set; }

    public int PaidFees { get; set; }

    public bool IsActive { get; set; }

    public byte IssueReasonID { get; set; }

    public int CreatedByUserID { get; set; }

    public clsLicensesBusinessLayer()
    {
        LicenseID = -1;
        ApplicationID = -1;
        DriverID = -1;
        LicenseClass = 0;
        IssueDate = DateTime.MinValue;
        ExpirationDate = DateTime.MinValue;
        Notes = string.Empty;
        PaidFees = 0;
        IsActive = false;
        IssueReasonID = 0;
        CreatedByUserID = -1;
        _Mode = enMode.add;
    }

    private clsLicensesBusinessLayer(int licenseID, int applicationID, int driverID, byte licenseClass, DateTime issueDate, DateTime expirationDate, string notes, int paidFees, bool isActive, byte issueReasonID, int createdByUserID)
    {
        LicenseID = licenseID;
        ApplicationID = applicationID;
        DriverID = driverID;
        LicenseClass = licenseClass;
        IssueDate = issueDate;
        ExpirationDate = expirationDate;
        Notes = notes;
        PaidFees = paidFees;
        IsActive = isActive;
        IssueReasonID = issueReasonID;
        CreatedByUserID = createdByUserID;
        _Mode = enMode.update;
    }

    private bool _AddNewLicense()
    {
        LicenseID = clsLicensesDataAccessLayer.AddNewLicense(ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReasonID, CreatedByUserID);
        return LicenseID != -1;
    }

    private bool _UpdateLicesne()
    {
        return clsLicensesDataAccessLayer.UpdateLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReasonID, CreatedByUserID);
    }

    public static clsLicensesBusinessLayer? GetLicenseByLicenseID(int licensid)
    {
        int applicationID = -1;
        int driverID = -1;
        byte licenseClass = 0;
        DateTime issueDate = DateTime.MinValue;
        DateTime expirationDate = DateTime.MinValue;
        string notes = string.Empty;
        int paidFees = 0;
        bool isActive = false;
        byte issueReasonID = 0;
        int createdByUserID = -1;
        if (clsLicensesDataAccessLayer.GetLicenseByLicenseID(licensid, ref applicationID, ref driverID, ref licenseClass, ref issueDate, ref expirationDate, ref notes, ref paidFees, ref isActive, ref issueReasonID, ref createdByUserID))
        {
            return new clsLicensesBusinessLayer(licensid, applicationID, driverID, licenseClass, issueDate, expirationDate, notes, paidFees, isActive, issueReasonID, createdByUserID);
        }

        return null;
    }

    public static clsLicensesBusinessLayer? GetLicenseByLDLAppID(int ldlappid)
    {
        int licenseID = -1;
        int applicationID = -1;
        int driverID = -1;
        byte licenseClass = 0;
        DateTime issueDate = DateTime.MinValue;
        DateTime expirationDate = DateTime.MinValue;
        string notes = string.Empty;
        int paidFees = 0;
        bool isActive = false;
        byte issueReasonID = 0;
        int createdByUserID = -1;
        if (clsLicensesDataAccessLayer.GetLicenseByLDLAppID(ldlappid, ref licenseID, ref applicationID, ref driverID, ref licenseClass, ref issueDate, ref expirationDate, ref notes, ref paidFees, ref isActive, ref issueReasonID, ref createdByUserID))
        {
            return new clsLicensesBusinessLayer(licenseID, applicationID, driverID, licenseClass, issueDate, expirationDate, notes, paidFees, isActive, issueReasonID, createdByUserID);
        }

        return null;
    }

    public bool Save()
    {
        switch (_Mode)
        {
            case enMode.add:
                if (_AddNewLicense())
                {
                    _Mode = enMode.update;
                    return true;
                }

                return false;
            case enMode.update:
                if (_UpdateLicesne())
                {
                    return true;
                }

                return false;
            default:
                return false;
        }
    }

    public static DataTable? GetAllLocalLicensesByNNO(string nno)
    {
        return clsLicensesDataAccessLayer.GetAllLocalLicensesByNNO(nno);
    }

    public static DataTable? GetAllInternationalLicensesByNNO(string nno)
    {
        return clsLicensesDataAccessLayer.GetAllInternationalLicensesByNNO(nno);
    }

    public static bool IsLicenseExist(int Applicationid)
    {
        return clsLicensesDataAccessLayer.IsLicenseExist(Applicationid);
    }
}

