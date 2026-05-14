
using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer;

public class clsLocalLicenseApplicationBusinnessLayer
{
    public int LDLApplicationID { get; set; }

    public string ClassName { get; set; }

    public string NationalNumber { get; set; }

    public string FullName { get; set; }

    public DateTime ApplicationDate { get; set; }

    public byte PassedTestCount { get; set; }

    public string Status { get; set; }

    public clsLocalLicenseApplicationBusinnessLayer()
    {
        LDLApplicationID = -1;
        ClassName = "";
        NationalNumber = "";
        FullName = "";
        ApplicationDate = DateTime.MinValue;
        PassedTestCount = 0;
        Status = "";
    }

    private clsLocalLicenseApplicationBusinnessLayer(int ldlapplicationID, string classname, string NNO, string fullname, DateTime date, byte passedtestcount, string status)
    {
        LDLApplicationID = ldlapplicationID;
        ClassName = classname;
        NationalNumber = NNO;
        FullName = fullname;
        ApplicationDate = date;
        PassedTestCount = passedtestcount;
        Status = status;
    }

    public static clsLocalLicenseApplicationBusinnessLayer? GetLDLApplicationByLDLAppID(int LDLid)
    {
        string classname = "";
        string NNO = "";
        string fullname = "";
        DateTime date = DateTime.MinValue;
        byte passedtestcount = 0;
        string status = "";
        if (clsLocalLicenseApplicationDataAccessLayer.GetLDLApplicationByLDLAppID(LDLid, ref classname, ref NNO, ref fullname, ref date, ref passedtestcount, ref status))
        {
            return new clsLocalLicenseApplicationBusinnessLayer(LDLid, classname, NNO, fullname, date, passedtestcount, status);
        }

        return null;
    }

    public static clsLocalLicenseApplicationBusinnessLayer? GetLDLApplicationByAppID(int appid)
    {
        int ldlapplicationID = -1;
        string classname = "";
        string NNO = "";
        string fullname = "";
        DateTime date = DateTime.MinValue;
        byte passedtestcount = 0;
        string status = "";
        if (clsLocalLicenseApplicationDataAccessLayer.GetLDLApplicationByAppID(appid, ref ldlapplicationID, ref classname, ref NNO, ref fullname, ref date, ref passedtestcount, ref status))
        {
            return new clsLocalLicenseApplicationBusinnessLayer(ldlapplicationID, classname, NNO, fullname, date, passedtestcount, status);
        }

        return null;
    }

    public bool UpdateLocalLicesenseApplication(int applicationid, int licenseclassid)
    {
        return clsLocalLicenseApplicationDataAccessLayer.UpdateLocalLicesenseApplication(LDLApplicationID, applicationid, licenseclassid);
    }

    public static DataTable GetLocalLicenseApplication()
    {
        return clsLocalLicenseApplicationDataAccessLayer.GetLocalLicenseApplication();
    }

    public static DataTable GetAllLocalLicenseApplicationsByAppID(int appid)
    {
        return clsLocalLicenseApplicationDataAccessLayer.GetAllLocalLicenseApplicationsByAppID(appid);
    }

    public static DataTable GetAllLocalLicenseApplicationsByNNO(string nno)
    {
        return clsLocalLicenseApplicationDataAccessLayer.GetAllLocalLicenseApplicationsByNNO(nno);
    }

    public static DataTable GetAllLocalLicenseApplicationsByFullName(string fullname)
    {
        return clsLocalLicenseApplicationDataAccessLayer.GetAllLocalLicenseApplicationsByFullName(fullname);
    }

    public static DataTable GetAllLocalLicenseApplicationsByStatus(string status)
    {
        return clsLocalLicenseApplicationDataAccessLayer.GetAllLocalLicenseApplicationsByStatus(status);
    }

    public static bool isLDLApplicationExisted(string nationalnumber, string classname)
    {
        return clsLocalLicenseApplicationDataAccessLayer.isLDLApplicationExisted(nationalnumber, classname);
    }

    public static bool IsLDLAppLinked(int LDLappid)
    {
        return clsLocalLicenseApplicationDataAccessLayer.IsLDLAppLinked(LDLappid);
    }
}


