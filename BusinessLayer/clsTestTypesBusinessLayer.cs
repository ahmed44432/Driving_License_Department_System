
using System.Data;
using DataAccessLayer;

namespace BusinessLayer;

public class clsTestTypesBusinessLayer
{
    public int ID { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int Fees { get; set; }

    private clsTestTypesBusinessLayer(int id, string tilel, string description, int fees)
    {
        ID = id;
        Title = tilel;
        Description = description;
        Fees = fees;
    }

    private bool _UpdateAppType()
    {
        return clsTestTypesDataAccessLayer.UpdateTestType(ID, Title, Description, Fees);
    }

    public bool Save()
    {
        if (_UpdateAppType())
        {
            return true;
        }

        return false;
    }

    public static DataTable GetTestTypes()
    {
        return clsTestTypesDataAccessLayer.GetTestTypes();
    }

    public static clsTestTypesBusinessLayer? GetTestTypeByID(int id)
    {
        string titel = "";
        string description = "";
        int fees = -1;
        if (clsTestTypesDataAccessLayer.GetTestTypeByID(id, ref titel, ref description, ref fees))
        {
            return new clsTestTypesBusinessLayer(id, titel, description, fees);
        }

        return null;
    }
}

