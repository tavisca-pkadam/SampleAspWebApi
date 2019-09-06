using System.Collections.Generic;
using WebApi1.Models;

namespace WebApi1.Services
{
    public static class UserValidation
    {
        public static bool TryValidateId(int id, List<string> message)
        {
            bool isValid = true;

            if( id < 0){
                message.Add("Invalid Id, Should Be Positive");
                return false;
            }
            return isValid;
        }

        public static bool TryValidateFirstName(string firstName, List<string> message)
        {
            bool isValid = true;

            if( firstName.Length < 1) {
                isValid = false;
                message.Add("Invalid FirstName, Cannot Be Empty");
                return false;
            }
            return isValid;
        }
        public static bool TryValidateLastName(string lastName, List<string> message)
        {
            bool isValid = true;

            if( lastName.Length < 1) {
                isValid = false;
                message.Add("Invalid LastName, Cannot Be Empty");
                return false;
            }
            return isValid;
        }
        public static bool TryValidateAddress(string address, List<string> message)
        {
            bool isValid = true;

            if( address.Length < 1 ) {
                isValid = false;
                message.Add("Invalid Address, Cannot Be Empty");
                return false;
            }
            return isValid;
        }
        public static bool TryValidateAge(int age, List<string> message)
        {
            bool isValid = true;

            if( age < 19 ){
                isValid = false;
                message.Add("Invalid Age, Should Not Be  18+");
                return false;
            }
            return isValid;
        }

        public static void ValidationStatusAndOperation(bool newValidationStatus, ref bool isValid)
        {
            isValid = isValid && newValidationStatus;
        }

        public static bool TryValidateAllFields(UserModel userModel, List<string> message)
        {
            bool isValid = true;

            ValidationStatusAndOperation(TryValidateId(userModel.Id, message), ref isValid);
            ValidationStatusAndOperation(TryValidateAddress(userModel.Address, message), ref isValid);
            ValidationStatusAndOperation(TryValidateFirstName(userModel.FirstName, message), ref isValid);
            ValidationStatusAndOperation(TryValidateLastName(userModel.LastName, message), ref isValid);
            ValidationStatusAndOperation(TryValidateAge(userModel.Age, message), ref isValid);
           
            return isValid;
        }

    }


}