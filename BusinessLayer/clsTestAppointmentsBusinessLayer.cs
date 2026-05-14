
using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer;

public class clsTestAppointmentsBusinessLayer
{
    public enum enMode
    {
        AddNew,
        Update
    }

    private enMode Mode;

    public int TestAppointmentID { get; set; }

    public int TestTypeID { get; set; }

    public int LDLApplicationID { get; set; }

    public DateTime AppointmentDate { get; set; }

    public byte PaidFees { get; set; }

    public int CreatedByUserID { get; set; }

    public bool IsLocked { get; set; }

    public clsTestAppointmentsBusinessLayer()
    {
        TestAppointmentID = -1;
        TestTypeID = -1;
        LDLApplicationID = -1;
        AppointmentDate = DateTime.MinValue;
        PaidFees = 0;
        CreatedByUserID = -1;
        IsLocked = false;
        Mode = enMode.AddNew;
    }

    private clsTestAppointmentsBusinessLayer(int testappid, int testtypeid, int ldlappid, DateTime appdate, byte paidfees, int createdbyuserid, bool islocked)
    {
        TestAppointmentID = testappid;
        TestTypeID = testtypeid;
        LDLApplicationID = ldlappid;
        AppointmentDate = appdate;
        PaidFees = paidfees;
        CreatedByUserID = createdbyuserid;
        IsLocked = islocked;
        Mode = enMode.Update;
    }

    private bool _AddNewTestAppointment()
    {
        TestAppointmentID = clsTestAppointmentsDataAccessLayer.AddNewTestAppointment(TestTypeID, LDLApplicationID, AppointmentDate, PaidFees, CreatedByUserID, IsLocked);
        return TestAppointmentID != -1;
    }

    private bool _UpdateTestAppointment()
    {
        return clsTestAppointmentsDataAccessLayer.UpdateTestAppointment(TestAppointmentID, AppointmentDate, IsLocked);
    }

    public bool Save()
    {
        switch (Mode)
        {
            case enMode.AddNew:
                if (_AddNewTestAppointment())
                {
                    Mode = enMode.Update;
                    return true;
                }

                return false;
            case enMode.Update:
                if (_UpdateTestAppointment())
                {
                    return true;
                }

                return false;
            default:
                return false;
        }
    }

    public static clsTestAppointmentsBusinessLayer? GetTestAppointmentByTestAppID(int testappid)
    {
        int testTypeID = -1;
        int lDLApplicationID = -1;
        DateTime appointmentDate = DateTime.MinValue;
        byte paidFees = 0;
        int createdByUserID = -1;
        bool isLocked = false;
        if (clsTestAppointmentsDataAccessLayer.GetTestAppointmentByTestAppID(testappid, ref testTypeID, ref lDLApplicationID, ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked))
        {
            return new clsTestAppointmentsBusinessLayer(testappid, testTypeID, lDLApplicationID, appointmentDate, paidFees, createdByUserID, isLocked);
        }

        return null;
    }

    public static clsTestAppointmentsBusinessLayer? GetTestAppointmentByLdlAppid(int ldlappid, byte typeid)
    {
        int testappid = -1;
        DateTime appointmentDate = DateTime.MinValue;
        byte paidFees = 0;
        int createdByUserID = -1;
        bool isLocked = false;
        if (clsTestAppointmentsDataAccessLayer.GetTestAppointmentByLdlAppid(ldlappid, typeid, ref testappid, ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked))
        {
            return new clsTestAppointmentsBusinessLayer(testappid, typeid, ldlappid, appointmentDate, paidFees, createdByUserID, isLocked);
        }

        return null;
    }

    public static clsTestAppointmentsBusinessLayer? GetVisionTestAppointmentByLDLappID(int ldlappid)
    {
        int testappid = -1;
        int testTypeID = 1;
        int lDLApplicationID = -1;
        DateTime appointmentDate = DateTime.MinValue;
        byte paidFees = 0;
        int createdByUserID = -1;
        bool isLocked = false;
        if (clsTestAppointmentsDataAccessLayer.GetVisionTestAppointmentByLdlAppid(ldlappid, ref testappid, ref testTypeID, ref lDLApplicationID, ref appointmentDate, ref paidFees, ref createdByUserID, ref isLocked))
        {
            return new clsTestAppointmentsBusinessLayer(testappid, testTypeID, lDLApplicationID, appointmentDate, paidFees, createdByUserID, isLocked);
        }

        return null;
    }

    public static DataTable GetALLTestAppointments()
    {
        return clsTestAppointmentsDataAccessLayer.GetTestAppointments();
    }

    public static DataTable GetALLTestAppointmentsByLDLAppID_ByType(int ldlappid, byte typeid)
    {
        return clsTestAppointmentsDataAccessLayer.GetALLTestAppointmentsByLDLAppID_ByType(ldlappid, typeid);
    }

    public static DataTable GetALLVisionTestAppointmentsByLDLAppID(int ldlappid)
    {
        return clsTestAppointmentsDataAccessLayer.GetVisionTestAppointmentsByLDLAppID(ldlappid);
    }

    public static bool isTestAppointmentsNotLockedExisted(int testappid, byte typeid)
    {
        return clsTestAppointmentsDataAccessLayer.isTestAppointmentsNotLockedExisted(testappid, typeid);
    }

    public static bool isTestAppointmentsLockedExisted(int testappid, byte typeid)
    {
        return clsTestAppointmentsDataAccessLayer.isTestAppointmentsLockedExisted(testappid, typeid);
    }

    public static bool isTestAppointmentsNotLockedExistedByLDLAppID(int ldlappid, byte typeid)
    {
        return clsTestAppointmentsDataAccessLayer.isTestAppointmentsNotLockedExistedByLDLAppID(ldlappid, typeid);
    }

    public static bool isTestAppointmentsLockedExistedByLDLAppID(int ldlappid, byte typeid)
    {
        return clsTestAppointmentsDataAccessLayer.isTestAppointmentsLockedExistedByLDLAppID(ldlappid, typeid);
    }

    public static int GetTestCountByLDLAppID(int ldlAppId, byte typeid)
    {
        return clsTestAppointmentsDataAccessLayer.GetTestCountByLDLAppID(ldlAppId, typeid);
    }

    public static bool DeleteTestAppointmentsByLDLAppID(int LDLappid, byte typeid)
    {
        return clsTestAppointmentsDataAccessLayer.DeleteTestAppointmentsByLDLAppID(LDLappid, typeid);
    }

    public static int GetApplicationID_ByTestappointmentID(int appointmentid)
    {
        return clsTestAppointmentsDataAccessLayer.GetApplicationID_ByTestappointmentID(appointmentid);
    }
}

