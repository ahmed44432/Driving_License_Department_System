
using DataAccessLayer;

namespace BusinessLayer;

public class clsTestsBusinessLayer
{
    public int TestID { get; set; }

    public int TestAppointmentID { get; set; }

    public bool TestResult { get; set; }

    public string Notes { get; set; }

    public int CreatedByUserID { get; set; }

    public clsTestsBusinessLayer()
    {
        TestID = -1;
        TestAppointmentID = -1;
        TestResult = false;
        Notes = "";
        CreatedByUserID = -1;
    }

    public clsTestsBusinessLayer(int testid, int testappid, bool testresult, string notes, int createdbyuserid)
    {
        TestID = testid;
        TestAppointmentID = testappid;
        TestResult = testresult;
        Notes = notes;
        CreatedByUserID = createdbyuserid;
    }

    private bool _AddNewTest()
    {
        TestID = clsTestsDataAccessLayer.AddNewTest(TestAppointmentID, TestResult, Notes, CreatedByUserID);
        return TestID != -1;
    }

    public bool Save()
    {
        if (_AddNewTest())
        {
            return true;
        }

        return false;
    }

    public static bool IsTestPassed(int testappid, byte testtypeid)
    {
        return clsTestsDataAccessLayer.IsTestPassed(testappid, testtypeid);
    }

    public static bool IsTestFailed(int testappid, byte testtypeid)
    {
        return clsTestsDataAccessLayer.IsTestFailed(testappid, testtypeid);
    }
}


