
using System.Data;
using DataAccessLayer;

namespace BusinessLayer;

public class clsUserBusinessLayer
{
    public enum enMode
    {
        add,
        update
    }

    private enMode _Mode;

    public int UserID { get; set; }

    public int PersonID { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public bool IsActive { get; set; }

    public clsUserBusinessLayer()
    {
        UserID = -1;
        PersonID = -1;
        UserName = "";
        Password = "";
        IsActive = false;
        _Mode = enMode.add;
    }

    private clsUserBusinessLayer(int userid, int personid, string username, string password, bool isactive)
    {
        UserID = userid;
        PersonID = personid;
        UserName = username;
        Password = password;
        IsActive = isactive;
        _Mode = enMode.update;
    }

    private bool _AddNewUser()
    {
        UserID = clsUserDataAccessLayer.AddNewUser(PersonID, UserName, Password, IsActive);
        return UserID != -1;
    }

    private bool _UpdateUser()
    {
        return clsUserDataAccessLayer.UpdateUser(UserID, PersonID, UserName, Password, IsActive);
    }

    public bool Save()
    {
        switch (_Mode)
        {
            case enMode.add:
                if (_AddNewUser())
                {
                    _Mode = enMode.update;
                    return true;
                }

                return false;
            case enMode.update:
                if (_UpdateUser())
                {
                    return true;
                }

                return false;
            default:
                return false;
        }
    }

    public static DataTable GetAllUsers()
    {
        return clsUserDataAccessLayer.GetAllUsers();
    }

    public static DataTable GetAllUsersByUserID(int userid)
    {
        return clsUserDataAccessLayer.GetAllUsersByUserID(userid);
    }

    public static DataTable GetAllUsersByPersonID(int personid)
    {
        return clsUserDataAccessLayer.GetAllUsersByPersonID(personid);
    }

    public static DataTable GetAllUsersByUserName(string username)
    {
        return clsUserDataAccessLayer.GetAllUsersByUserName(username);
    }

    public static DataTable GetAllUsersByFullName(string fullname)
    {
        return clsUserDataAccessLayer.GetAllUsersByFullName(fullname);
    }

    public static DataTable GetUsersByActivationStatus(bool isactive)
    {
        return clsUserDataAccessLayer.GetUsersByActivationStatus(isactive);
    }

    public static bool IsUserExistes(string username, string password)
    {
        return clsUserDataAccessLayer.IsUserExist(username, password);
    }

    public static bool IsUserExistes(string username)
    {
        return clsUserDataAccessLayer.IsUserExist(username);
    }

    public static bool IsUserExistes(int personid)
    {
        return clsUserDataAccessLayer.IsUserExist(personid);
    }

    public static bool IsUserActive(string username)
    {
        return clsUserDataAccessLayer.IsUserActive(username);
    }

    public static bool DeleteUser(int userid)
    {
        return clsUserDataAccessLayer.DeleteUser(userid);
    }

    public static bool IsUserLinked(int userid)
    {
        return clsUserDataAccessLayer.IsUserLinked(userid);
    }

    public static clsUserBusinessLayer? GetUserByUserID(int userid)
    {
        int personid = -1;
        string username = "";
        string password = "";
        bool isactive = false;
        if (clsUserDataAccessLayer.GetUserByUserID(userid, ref personid, ref username, ref password, ref isactive))
        {
            return new clsUserBusinessLayer(userid, personid, username, password, isactive);
        }

        return null;
    }

    public static clsUserBusinessLayer? GetUserByPersonID(int personid)
    {
        int userid = -1;
        string username = "";
        string password = "";
        bool isactive = false;
        if (clsUserDataAccessLayer.GetUserByPersonID(ref userid, personid, ref username, ref password, ref isactive))
        {
            return new clsUserBusinessLayer(userid, personid, username, password, isactive);
        }

        return null;
    }

    public static clsUserBusinessLayer? GetUserByUserName(string username)
    {
        int userid = -1;
        int personid = -1;
        string password = "";
        bool isactive = false;
        if (clsUserDataAccessLayer.GetUserByUserName(ref userid, ref personid, ref username, ref password, ref isactive))
        {
            return new clsUserBusinessLayer(userid, personid, username, password, isactive);
        }

        return null;
    }
}

