
using System.Data;
using DataAccessLayer;

namespace BusinessLayer;

public class clsLicenseClassesbusinessLayer
{
    public static DataTable GetLicenseClasses()
    {
        return clsLicenseClassesDataAccessLayer.GetLicenseClasses();
    }

    public static DataTable GetLicenseClassesNames()
    {
        return clsLicenseClassesDataAccessLayer.GetLicenseClassesNames();
    }

    public static int GetLicenseClassesFeesByID(int id)
    {
        return clsLicenseClassesDataAccessLayer.GetLicenseClassesFeesByID(id);
    }

    public static int GetLicenseClassIDByName(string classname)
    {
        return clsLicenseClassesDataAccessLayer.GetLicenseClassIDByName(classname);
    }

    public static string GetLicenseClassNameByID(int classid)
    {
        return clsLicenseClassesDataAccessLayer.GetLicenseClassNameByID(classid);
    }

    public static int GetLicenseValidityLength(int id)
    {
        return clsLicenseClassesDataAccessLayer.GetLicenseValidityLength(id);
    }
}


