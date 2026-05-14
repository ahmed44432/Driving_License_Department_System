
using System;
using DataAccessLayer;

namespace BusinessLayer;

public class clsTestAppointmentsDetailsBusinessLayer
{
    private int TestAppointmentID { get; set; }

    private string TestTypeTitel { get; set; }

    private int LDLApplicationID { get; set; }

    private string ClassName { get; set; }

    private DateTime AppointmentDate { get; set; }

    private byte PaidFees { get; set; }

    private string CreatedByFullName { get; set; }

    private bool IsLocked { get; set; }

    public clsTestAppointmentsDetailsBusinessLayer()
    {
        TestAppointmentID = -1;
        TestTypeTitel = "";
        LDLApplicationID = -1;
        ClassName = "";
        AppointmentDate = DateTime.MinValue;
        PaidFees = 0;
        CreatedByFullName = "";
        IsLocked = true;
    }

    private clsTestAppointmentsDetailsBusinessLayer(int testappid, string testtypetitel, int ldlappid, string classname, DateTime appointmentdate, byte paidfees, string createdbyfullname, bool islocked)
    {
        TestAppointmentID = testappid;
        TestTypeTitel = testtypetitel;
        LDLApplicationID = ldlappid;
        ClassName = classname;
        AppointmentDate = appointmentdate;
        PaidFees = paidfees;
        CreatedByFullName = createdbyfullname;
        IsLocked = islocked;
    }

    public static clsTestAppointmentsDetailsBusinessLayer? GetTestAppointmentsDetailsByTestAppID(int testappid)
    {
        int testappid2 = -1;
        string testtypetitel = "";
        int ldlappid = -1;
        string classname = "";
        DateTime appointmentdate = DateTime.MinValue;
        byte paidfees = 0;
        string creaturefullname = "";
        bool islocked = true;
        if (clsTestAppointmentsDetailsDataAccessLayer.GetTestAppointmentsDetailsByTestAppID(testappid2, ref ldlappid, ref testtypetitel, ref classname, ref appointmentdate, ref paidfees, ref creaturefullname, ref islocked))
        {
            return new clsTestAppointmentsDetailsBusinessLayer(testappid2, testtypetitel, ldlappid, classname, appointmentdate, paidfees, creaturefullname, islocked);
        }

        return null;
    }
}
