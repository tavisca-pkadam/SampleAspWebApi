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
            return user.Address.Length > 1 ? true : false;
        }
        public static bool ValidateLastName(string Name)
        {
            return user.Address.Length > 1 ? true : false;
        }
        public static bool ValidateAge(string Name)
        {
            return user.Age < 18 ? true : false;
        }

    }
}