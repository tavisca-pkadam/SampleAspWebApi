namespace WebApi1.Services
{
    public static class UserValidation
    {
        public static bool ValidateId(int id)
        {
            return id > 0 ? true : false;
        }
        
        public static bool ValidateFirstName(int id)
        {
            return id > 0 ? true : false;
        }

    }
}