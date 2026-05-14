

using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer;

public class clsDriversBusinessLayer
{
    public enum enMode
    {
        add,
        update
    }

    private enMode _Mode;

    public int DriverID { get; set; }

    public int PersonID { get; set; }

    public int CreatedByUserID { get; set; }

    public DateTime CreationDate { get; set; }

    public clsDriversBusinessLayer()
    {
        DriverID = -1;
        PersonID = -1;
        CreatedByUserID = -1;
        CreationDate = DateTime.MinValue;
        _Mode = enMode.add;
    }

    public clsDriversBusinessLayer(int driverid, int personid, int createdbyuserid, DateTime creationdate)
    {
        DriverID = driverid;
        PersonID = personid;
        CreatedByUserID = createdbyuserid;
        CreationDate = creationdate;
        _Mode = enMode.update;
    }

    private bool _AddNewDriver()
    {
        DriverID = clsDriversDataAccessLayer.AddNewDriver(PersonID, CreatedByUserID, CreationDate);
        return DriverID != -1;
    }

    public static clsDriversBusinessLayer? GetDriverByPersonID(int personid)
    {
        int driverid = -1;
        int createdbyuserid = -1;
        DateTime creationdate = DateTime.MinValue;
        if (clsDriversDataAccessLayer.GetDriverByPersonID(personid, ref driverid, ref createdbyuserid, ref creationdate))
        {
            return new clsDriversBusinessLayer(driverid, personid, createdbyuserid, creationdate);
        }

        return null;
    }

    public bool Save()
    {
        if (_Mode == enMode.add)
        {
            if (_AddNewDriver())
            {
                _Mode = enMode.update;
                return true;
            }

            return false;
        }

        return false;
    }

    public static DataTable GetAllDrivers()
    {
        return clsDriversDataAccessLayer.GetAllDrivers();
    }

    public static DataTable GetAllDriversByDriverID(int driverid)
    {
        return clsDriversDataAccessLayer.GetAllDriversByDriverID(driverid);
    }

    public static DataTable GetAllDriversByPersonID(int personid)
    {
        return clsDriversDataAccessLayer.GetAllDriversByPersonID(personid);
    }

    public static DataTable GetAllDriversByNationalNO(string nno)
    {
        return clsDriversDataAccessLayer.GetAllDriversByNationalNO(nno);
    }

    public static DataTable GetAllDriversByFullName(string fullname)
    {
        return clsDriversDataAccessLayer.GetAllDriversByFullName(fullname);
    }

    public static bool IsDriverExisted(int personid)
    {
        return clsDriversDataAccessLayer.IsDriverExisted(personid);
    }
}

