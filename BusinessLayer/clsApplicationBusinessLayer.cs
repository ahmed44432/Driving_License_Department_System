

using System;
using System.Data;
using DataAccessLayer;




namespace BusinessLayer;

public class clsApplicationBusinessLayer
{
    public enum enMode
    {
        AddNew,
        Update
    }

    private enMode Mode;

    public int ApplicationID { get; set; }

    public int ApplicationPersonID { get; set; }

    public DateTime ApplicationDate { get; set; }

    public int ApplicationTypeID { get; set; }

    public byte ApplicationStatus { get; set; }

    public DateTime LastStatusDate { get; set; }

    public short PaidFees { get; set; }

    public int CreatedByUserID { get; set; }

    public clsApplicationBusinessLayer()
    {
        ApplicationID = -1;
        ApplicationPersonID = -1;
        ApplicationStatus = 1;
        CreatedByUserID = -1;
        ApplicationDate = DateTime.MinValue;
        ApplicationTypeID = -1;
        LastStatusDate = DateTime.MinValue;
        PaidFees = 0;
        Mode = enMode.AddNew;
    }

    private clsApplicationBusinessLayer(int appid, int personid, byte appstatus, int userid, DateTime appdate, int apptypeid, DateTime laststatusdate, short paidfees)
    {
        ApplicationID = appid;
        ApplicationPersonID = personid;
        ApplicationStatus = appstatus;
        CreatedByUserID = userid;
        ApplicationDate = appdate;
        ApplicationTypeID = apptypeid;
        LastStatusDate = laststatusdate;
        PaidFees = paidfees;
        Mode = enMode.Update;
    }

    public static DataTable GetApplication()
    {
        return clsApplicationDataAccessLayer.GetApplication();
    }

    public static clsApplicationBusinessLayer? GetApplicatinByID(int id)
    {
        int applicationpersonid = -1;
        byte applicationstatus = 1;
        int creatbyuserid = -1;
        DateTime applicationdate = DateTime.MinValue;
        int applicationtypeid = -1;
        DateTime laststatusdate = DateTime.MinValue;
        short paidfees = 0;
        if (clsApplicationDataAccessLayer.GetApplicationByID(id, ref applicationpersonid, ref applicationdate, ref applicationtypeid, ref applicationstatus, ref laststatusdate, ref paidfees, ref creatbyuserid))
        {
            return new clsApplicationBusinessLayer(id, applicationpersonid, applicationstatus, creatbyuserid, applicationdate, applicationtypeid, laststatusdate, paidfees);
        }

        return null;
    }

    public static clsApplicationBusinessLayer? GetApplicationByLDLAppID(int LDLappid)
    {
        int applicationid = -1;
        int applicationpersonid = -1;
        byte applicationstatus = 1;
        int creatbyuserid = -1;
        DateTime applicationdate = DateTime.MinValue;
        int applicationtypeid = -1;
        DateTime laststatusdate = DateTime.MinValue;
        short paidfees = 0;
        if (clsApplicationDataAccessLayer.GetApplicationByLDLAppID(LDLappid, ref applicationid, ref applicationpersonid, ref applicationdate, ref applicationtypeid, ref applicationstatus, ref laststatusdate, ref paidfees, ref creatbyuserid))
        {
            return new clsApplicationBusinessLayer(applicationid, applicationpersonid, applicationstatus, creatbyuserid, applicationdate, applicationtypeid, laststatusdate, paidfees);
        }

        return null;
    }

    private bool _AddNewApplication(int classid)
    {
        ApplicationID = clsApplicationDataAccessLayer.AddNewApplication(ApplicationPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID, classid);
        return ApplicationID != -1;
    }

    private bool _UpdateApplication()
    {
        return clsApplicationDataAccessLayer.UpdateApplication(ApplicationID, ApplicationPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
    }

    public bool Save(int classid)
    {
        switch (Mode)
        {
            case enMode.AddNew:
                if (_AddNewApplication(classid))
                {
                    Mode = enMode.Update;
                    return true;
                }

                return false;
            case enMode.Update:
                if (_UpdateApplication())
                {
                    return true;
                }

                return false;
            default:
                return false;
        }
    }

    public static bool isApplicationExisted(int personid, int typeid)
    {
        return clsApplicationDataAccessLayer.isApplicationExisted(personid, typeid);
    }

    public static bool DeleteApplicationByAppID(int applicationid, int applicationtypeid = 1)
    {
        return clsApplicationDataAccessLayer.DeleteApplicationByAppID(applicationid, applicationtypeid);
    }

    public static bool DeleteApplicationByLDLAppID(int LDLappid, byte typeid)
    {
        return clsApplicationDataAccessLayer.DeleteApplicationByLDLAppID(LDLappid, typeid);
    }
}


