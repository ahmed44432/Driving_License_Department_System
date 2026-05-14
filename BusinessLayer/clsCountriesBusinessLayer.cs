
using System.Data;
using DataAccessLayer;

namespace BusinessLayer;

public class clsCountriesBusinessLayer
{
    public static DataTable GetAllCoutries()
    {
        return clsCountriesDataAccessLayer.GetAllCoutries();
    }

    public static string GetCountryNameByNumber(int CountryNumber)
    {
        return clsCountriesDataAccessLayer.GetCountryNameByNumber(CountryNumber);
    }
}


