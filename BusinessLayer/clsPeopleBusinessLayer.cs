
using System;
using System.Data;
using DataAccessLayer;

namespace BusinessLayer;

public class clsPeopleBusinessLayer
{
    public enum enMode
    {
        AddNew,
        Update
    }

    private enMode Mode;

    public int ID { get; set; }

    public string NationalNumber { get; set; }

    public string FirstName { get; set; }

    public string SecondName { get; set; }

    public string ThirdName { get; set; }

    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }

    public char Gender { get; set; }

    public string Address { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string ImagePath { get; set; }

    public int NationalityCountryID { get; set; }

    public clsPeopleBusinessLayer()
    {
        ID = -1;
        NationalNumber = "";
        FirstName = "";
        SecondName = "";
        ThirdName = "";
        LastName = "";
        DateOfBirth = DateTime.MinValue;
        Gender = ' ';
        Address = "";
        Email = "";
        Phone = "";
        ImagePath = "";
        NationalityCountryID = 0;
        Mode = enMode.AddNew;
    }

    private clsPeopleBusinessLayer(int id, string nationalNumber, string firstName, string secondName, string thirdName, string lastName, DateTime dateOfBirth, char gender, string address, string email, string phone, string imagePath, int nationalityCountryID)
    {
        ID = id;
        NationalNumber = nationalNumber;
        FirstName = firstName;
        SecondName = secondName;
        ThirdName = thirdName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        Address = address;
        Email = email;
        Phone = phone;
        ImagePath = imagePath;
        NationalityCountryID = nationalityCountryID;
        Mode = enMode.Update;
    }

    public static DataTable GetAllPeople()
    {
        return clsPeopleDataAccessLayer.GetAllPeople();
    }

    public static DataTable GetAllPeopleBYID(int id)
    {
        return clsPeopleDataAccessLayer.GetAllPeopleBYID(id);
    }

    public static DataTable GetAllPeopleByNationalNO(string NNO)
    {
        return clsPeopleDataAccessLayer.GetAllPeopleByNationalNO(NNO);
    }

    public static DataTable GetAllPeopleByFirstName(string Name)
    {
        return clsPeopleDataAccessLayer.GetAllPeopleByFirstName(Name);
    }

    public static DataTable GetAllPeopleBySecondName(string Name)
    {
        return clsPeopleDataAccessLayer.GetAllPeopleBySecondName(Name);
    }

    public static DataTable GetAllPeopleByThirdName(string Name)
    {
        return clsPeopleDataAccessLayer.GetAllPeopleByThirdName(Name);
    }

    public static DataTable GetAllPeopleByLastName(string Name)
    {
        return clsPeopleDataAccessLayer.GetAllPeopleByLastName(Name);
    }

    public static DataTable GetAllPeopleByNationality(string CountryName)
    {
        return clsPeopleDataAccessLayer.GetAllPeopleByNationality(CountryName);
    }

    public static DataTable GetAllPeopleByGender(string gender)
    {
        return clsPeopleDataAccessLayer.GetAllPeopleByGender(gender);
    }

    public static DataTable GetAllPeopleByPhone(string phone)
    {
        return clsPeopleDataAccessLayer.GetAllPeopleByPhone(phone);
    }

    public static DataTable GetAllPeopleByEmail(string email)
    {
        return clsPeopleDataAccessLayer.GetAllPeopleByEmail(email);
    }

    public static clsPeopleBusinessLayer? GetPersonByID(int id)
    {
        string nationalNumber = "";
        string firstName = "";
        string secondName = "";
        string thirdName = "";
        string lastName = "";
        DateTime dateOfBirth = DateTime.MinValue;
        char gender = ' ';
        string address = "";
        string email = "";
        string phone = "";
        string imagePath = "";
        int nationalityCountryID = 0;

        if (clsPeopleDataAccessLayer.GetPersonByID(id, ref nationalNumber, ref firstName,
            ref secondName, ref thirdName, ref lastName, ref dateOfBirth, ref gender,
            ref address, ref email, ref phone, ref imagePath, ref nationalityCountryID))
        {
            return new clsPeopleBusinessLayer(id, nationalNumber, firstName, secondName,
                thirdName, lastName, dateOfBirth,
                gender, address, email, phone, imagePath, nationalityCountryID);
        }

        return null;
    }

    public static clsPeopleBusinessLayer? GetPersonByApplicationID(int applicationid)
    {
        int personID = -1;
        string nationalNumber = "";
        string firstName = "";
        string secondName = "";
        string thirdName = "";
        string lastName = "";
        DateTime dateOfBirth = DateTime.MinValue;
        char gender = ' ';
        string address = "";
        string email = "";
        string phone = "";
        string imagePath = "";
        int nationalityCountryID = 0;
        if (clsPeopleDataAccessLayer.GetPersonByApplicationID(applicationid, ref personID, ref nationalNumber, ref firstName, ref secondName, ref thirdName, ref lastName, ref dateOfBirth, ref gender, ref address, ref email, ref phone, ref imagePath, ref nationalityCountryID))
        {
            return new clsPeopleBusinessLayer(personID, nationalNumber, firstName, secondName, thirdName, lastName, dateOfBirth, gender, address, email, phone, imagePath, nationalityCountryID);
        }

        return null;
    }

    public static clsPeopleBusinessLayer? GetPersonByNationalNO(string NNO)
    {
        int id = -1;
        string firstName = "";
        string secondName = "";
        string thirdName = "";
        string lastName = "";
        DateTime dateOfBirth = DateTime.MinValue;
        char gender = ' ';
        string address = "";
        string email = "";
        string phone = "";
        string imagePath = "";
        int nationalityCountryID = 0;
        if (clsPeopleDataAccessLayer.GetPersonByNationalNO(ref id, ref NNO, ref firstName, ref secondName, ref thirdName, ref lastName, ref dateOfBirth, ref gender, ref address, ref email, ref phone, ref imagePath, ref nationalityCountryID))
        {
            return new clsPeopleBusinessLayer(id, NNO, firstName, secondName, thirdName, lastName, dateOfBirth, gender, address, email, phone, imagePath, nationalityCountryID);
        }

        return null;
    }

    public static clsPeopleBusinessLayer? GetPersonByFirstName(string FirstName)
    {
        int id = -1;
        string nationalNumber = "";
        string secondName = "";
        string thirdName = "";
        string lastName = "";
        DateTime dateOfBirth = DateTime.MinValue;
        char gender = ' ';
        string address = "";
        string email = "";
        string phone = "";
        string imagePath = "";
        int nationalityCountryID = 0;
        if (clsPeopleDataAccessLayer.GetPersonByFirstName(ref id, ref nationalNumber, ref FirstName, ref secondName, ref thirdName, ref lastName, ref dateOfBirth, ref gender, ref address, ref email, ref phone, ref imagePath, ref nationalityCountryID))
        {
            return new clsPeopleBusinessLayer(id, nationalNumber, FirstName, secondName, thirdName, lastName, dateOfBirth, gender, address, email, phone, imagePath, nationalityCountryID);
        }

        return null;
    }

    public static clsPeopleBusinessLayer? GetPersonBySecondName(string SecondName)
    {
        int id = -1;
        string nationalNumber = "";
        string firstName = "";
        string thirdName = "";
        string lastName = "";
        DateTime dateOfBirth = DateTime.MinValue;
        char gender = ' ';
        string address = "";
        string email = "";
        string phone = "";
        string imagePath = "";
        int nationalityCountryID = 0;
        if (clsPeopleDataAccessLayer.GetPersonBySecondName(ref id, ref nationalNumber, ref firstName, ref SecondName, ref thirdName, ref lastName, ref dateOfBirth, ref gender, ref address, ref email, ref phone, ref imagePath, ref nationalityCountryID))
        {
            return new clsPeopleBusinessLayer(id, nationalNumber, firstName, SecondName, thirdName, lastName, dateOfBirth, gender, address, email, phone, imagePath, nationalityCountryID);
        }

        return null;
    }

    public static clsPeopleBusinessLayer? GetPersonByThirdName(string ThirdName)
    {
        int id = -1;
        string nationalNumber = "";
        string firstName = "";
        string secondName = "";
        string lastName = "";
        DateTime dateOfBirth = DateTime.MinValue;
        char gender = ' ';
        string address = "";
        string email = "";
        string phone = "";
        string imagePath = "";
        int nationalityCountryID = 0;
        if (clsPeopleDataAccessLayer.GetPersonByThirdName(ref id, ref nationalNumber, ref firstName, ref secondName, ref ThirdName, ref lastName, ref dateOfBirth, ref gender, ref address, ref email, ref phone, ref imagePath, ref nationalityCountryID))
        {
            return new clsPeopleBusinessLayer(id, nationalNumber, firstName, secondName, ThirdName, lastName, dateOfBirth, gender, address, email, phone, imagePath, nationalityCountryID);
        }

        return null;
    }

    public static clsPeopleBusinessLayer? GetPersonByLastName(string LastName)
    {
        int id = -1;
        string nationalNumber = "";
        string firstName = "";
        string secondName = "";
        string thirdName = "";
        DateTime dateOfBirth = DateTime.MinValue;
        char gender = ' ';
        string address = "";
        string email = "";
        string phone = "";
        string imagePath = "";
        int nationalityCountryID = 0;
        if (clsPeopleDataAccessLayer.GetPersonByLastName(ref id, ref nationalNumber, ref firstName, ref secondName, ref thirdName, ref LastName, ref dateOfBirth, ref gender, ref address, ref email, ref phone, ref imagePath, ref nationalityCountryID))
        {
            return new clsPeopleBusinessLayer(id, nationalNumber, firstName, secondName, thirdName, LastName, dateOfBirth, gender, address, email, phone, imagePath, nationalityCountryID);
        }

        return null;
    }

    private bool _AddNewPerson()
    {
        ID = clsPeopleDataAccessLayer.AddNewPerson(NationalNumber, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Email, Phone, ImagePath, NationalityCountryID);
        return ID != -1;
    }

    private bool _UpdatePerson()
    {
        return clsPeopleDataAccessLayer.UpdatePerson(ID, NationalNumber, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Email, Phone, ImagePath, NationalityCountryID);
    }

    public bool Save()
    {
        switch (Mode)
        {
            case enMode.AddNew:
                if (_AddNewPerson())
                {
                    Mode = enMode.Update;
                    return true;
                }

                return false;
            case enMode.Update:
                if (_UpdatePerson())
                {
                    return true;
                }

                return false;
            default:
                return false;
        }
    }

    public static bool IsPersonExist(int id)
    {
        return clsPeopleDataAccessLayer.isPersonExisted(id);
    }

    public static bool IsPersonExist(string firstname, string lastname)
    {
        return clsPeopleDataAccessLayer.isPersonExisted(firstname, lastname);
    }

    public static bool IsPersonExist(string NationalNumber)
    {
        return clsPeopleDataAccessLayer.isPersonExisted(NationalNumber);
    }

    public static bool IsPersonLinked(int personid)
    {
        return clsPeopleDataAccessLayer.IsPersonLinked(personid);
    }

    public static bool DeletePerson(int id)
    {
        return clsPeopleDataAccessLayer.DeletePerson(id);
    }
}
