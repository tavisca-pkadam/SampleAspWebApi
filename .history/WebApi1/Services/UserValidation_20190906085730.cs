namespace WebApi1.Services
{
    public static class UserValidation
    {
        public bool ValidateId(int id)
        {
            return id > 0 : true :false
            return System.NotImplementedException;
        }
    }
}