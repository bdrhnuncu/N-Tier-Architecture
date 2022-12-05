using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kirala.com.Business.Constants.Messages
{
    public static class ConstantMessage
    {
        public static string Transactionsuccesfully => "Transaction succesfully";
        public static string LoginSuccesfully => "Login Succesfully Welcome";
        public static string WrongValidationType => "Wrong validator type enter correctly pls";

        #region User

        public static string PhoneUsed => "This Phone number ıs used";
        public static string EmailUsed => "This Email is used";
        public static string UserNameUsed => "This UserName is used";
        public static string UserPasswordWrong => "This password is wrong";
        public static string UserNameNotExist => "UserName is wrong or u don't register before";
        public static string UserIdNotExist => "User with id not found";
        public static string UserUpdateNoChange => "No change has been made";
        public static string UserNameNotNull => "Username is cannot to be null or empty";
        public static string UserNameMaxChar => "Number of username character can be max. 20 characters";
        public static string UserPasswordNotNull => "User password is cannot to be null or empty";
        public static string UserPasswordMaxChar => "User password is can be max. 20 characters";
        public static string UserPhoneNotNull => "User phone is cannot to be null or empty";
        public static string UserPhoneMinChar => "User phone lenght is must min. can be 12 characters";
        public static string UserPhoneMaxChar => "User phone lenght is must max. 14 characters";
        public static string UserPhoneFormat => "Phone number format not correct";
        public static string UserEmailNotNull => "User email is cannot to be null or empty";
        public static string UserExist => "This user exist";
        public static string UserNotExist => "This user not exist";
        public static string EmailFormat => "E-mail format is not correct";
        public static string NameMinChar => "Name can be min. 4 characters";
        public static string PasswordMinChar => "Password can be min. 7 characters";

        #endregion

        #region Address

        public static string AdressNull => "Address cannot to be null";
        public static string CityNull => "City Cannot to be null or empty";
        public static string DistrictNull => "District cannot to be null or empty";
        public static string AddressNotExist => "This Address not exist";

        #endregion

        #region Advert

        public static string AdvertDescription => "Advert description can be max. 1000 characters";
        public static string SameAdvertNotAdd => "Same advert cannot to be add";
        public static string AdvertIdNotExist => "Advert with id not found";
        public static string YearNotNull => "Year cannot to be null or empty";
        public static string PriceNotNull => "Price cannot to be null";
        public static string PriceFormat => "Price is invalid";
        public static string MileNotNull => "Mile cannot to be null or empty";
        #endregion
    }
}
