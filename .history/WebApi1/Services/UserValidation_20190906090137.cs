namespace WebApi1.Services
{
    public static class UserValidation
    {
        public static bool ValidateId(int id)
        {
            return id > 0 ? true : false;
        }
         
        public static bool ValidateFirstName(string FirstName)
        {
            return FirstName.Length > 1 ? true : false;
        }
        public static bool ValidateLastName(string lastName)
        {
            return lastName.Length > 1 ? true : false;
        }
        public static bool ValidateLastName(string address)
        {
            return address.Length > 1 ? true : false;
        }
        public static bool ValidateAge(string age)
        {
            return age < 18 ? true : false;
        }

    }
}