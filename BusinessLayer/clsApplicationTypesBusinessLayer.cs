
using System.Data;
using DataAccessLayer;


namespace BusinessLayer;

public class clsApplicationTypesBusinessLayer
{
    public int ID { get; set; }

    public string Title { get; set; }

    public int Fees { get; set; }

    private clsApplicationTypesBusinessLayer(int id, string tilel, int fees)
    {
        ID = id;
        Title = tilel;
        Fees = fees;
    }

    private bool _UpdateAppType()
    {
        return clsApplicationTypesDataAccessLayer.UpdateAppType(ID, Title, Fees);
    }

    public bool Save()
    {
        if (_UpdateAppType())
        {
            return true;
        }

        return false;
    }

    public static DataTable GetAllclsApplicationTypes()
    {
        return clsApplicationTypesDataAccessLayer.GetApplicationTypes();
    }

    public static clsApplicationTypesBusinessLayer? GetAppTypeByID(int id)
    {
        string titel = "";
        int fees = -1;
        if (clsApplicationTypesDataAccessLayer.GetAppTypeByID(id, ref titel, ref fees))
        {
            return new clsApplicationTypesBusinessLayer(id, titel, fees);
        }

        return null;
    }

    public static int GetAppTypeFeesByID(int id)
    {
        return clsApplicationTypesDataAccessLayer.GetAppTypeFeesByID(id);
    }
}


