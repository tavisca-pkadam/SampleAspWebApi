namespace WebApi1.Services
{
    public static class UserValidation
    {
        public static bool ValidateId(int id)
        {
            return id > 0 ? true : false;
        }
         
        public static bool ValidateFirstName(string Name)
        {
            return FirstName.Length > 1 ? true : false;
        }
        public static bool ValidateLastName(string Name)
        {
            return LastName.Length > 1 ? true : false;
        }
        public static bool ValidateLastName(string Address)
        {
            return Address.Length > 1 ? true : false;
        }
        public static bool ValidateAge(string Name)
        {
            return user.Age < 18 ? true : false;
        }

    }
}