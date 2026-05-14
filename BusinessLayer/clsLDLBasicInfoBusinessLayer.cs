
using System;
using DataAccessLayer;

namespace BusinessLayer;

public class clsLDLBasicInfoBusinessLayer
{
    public int LDLApplicationID { get; set; }

    public string ClassName { get; set; }

    public string NationalNumber { get; set; }

    public string FullName { get; set; }

    public DateTime ApplicationDate { get; set; }

    public byte PassedTestCount { get; set; }

    public string Status { get; set; }

    public string UserName { get; set; }

    public DateTime LastStatusDate { get; set; }

    public byte PaidFees { get; set; }

    public clsLDLBasicInfoBusinessLayer()
    {
        LDLApplicationID = -1;
        ClassName = "";
        NationalNumber = "";
        FullName = "";
        ApplicationDate = DateTime.MinValue;
        PassedTestCount = 0;
        Status = "";
        UserName = "";
        LastStatusDate = DateTime.MinValue;
        PaidFees = 0;
    }

    private clsLDLBasicInfoBusinessLayer(int ldlapplicationID, string classname, string NNO, string fullname, DateTime date, byte passedtestcount, string status, string username, DateTime laststatusdate, byte paidfees)
    {
        LDLApplicationID = ldlapplicationID;
        ClassName = classname;
        NationalNumber = NNO;
        FullName = fullname;
        ApplicationDate = date;
        PassedTestCount = passedtestcount;
        Status = status;
        UserName = username;
        LastStatusDate = laststatusdate;
        PaidFees = paidfees;
    }

    public static clsLDLBasicInfoBusinessLayer? GetLDLBasicInfoByAppID(int appid)
    {
        int ldlappid = -1;
        string classname = "";
        string NNO = "";
        string fullname = "";
        DateTime date = DateTime.MinValue;
        byte passedtestcount = 0;
        string status = "";
        string username = "";
        DateTime laststatusdate = DateTime.MinValue;
        byte paidfees = 0;
        if (clsLDLBasicInfoDataAccessLayer.GetLDLBasicInfoByAppID(appid, ref ldlappid, ref classname, ref NNO, ref fullname, ref date, ref passedtestcount, ref status, ref username, ref laststatusdate, ref paidfees))
        {
            return new clsLDLBasicInfoBusinessLayer(ldlappid, classname, NNO, fullname, date, passedtestcount, status, username, laststatusdate, paidfees);
        }

        return null;
    }

    public static clsLDLBasicInfoBusinessLayer? GetLDLBasicInfoByTestAppID(int testappid)
    {
        int ldlappid = -1;
        string classname = "";
        string NNO = "";
        string fullname = "";
        DateTime date = DateTime.MinValue;
        byte passedtestcount = 0;
        string status = "";
        string username = "";
        DateTime laststatusdate = DateTime.MinValue;
        byte paidfees = 0;
        if (clsLDLBasicInfoDataAccessLayer.GetLDLBasicInfoByTestAppID(testappid, ref ldlappid, ref classname, ref NNO, ref fullname, ref date, ref passedtestcount, ref status, ref username, ref laststatusdate, ref paidfees))
        {
            return new clsLDLBasicInfoBusinessLayer(ldlappid, classname, NNO, fullname, date, passedtestcount, status, username, laststatusdate, paidfees);
        }

        return null;
    }

    public static clsLDLBasicInfoBusinessLayer? GetLDLBasicInfoByLDLAppID(int LDLappid)
    {
        string classname = "";
        string NNO = "";
        string fullname = "";
        DateTime date = DateTime.MinValue;
        byte passedtestcount = 0;
        string status = "";
        string username = "";
        DateTime laststatusdate = DateTime.MinValue;
        byte paidfees = 0;
        if (clsLDLBasicInfoDataAccessLayer.GetLDLBasicInfoByLDLAppID(LDLappid, ref classname, ref NNO, ref fullname, ref date, ref passedtestcount, ref status, ref username, ref laststatusdate, ref paidfees))
        {
            return new clsLDLBasicInfoBusinessLayer(LDLappid, classname, NNO, fullname, date, passedtestcount, status, username, laststatusdate, paidfees);
        }

        return null;
    }
}


