namespace StudentPortalBackEnd2021.App_Start
{
    internal class AuthRepository
    {
        public bool ValidateUser(string username, string password)
        {
            if (username == "mshahnawaz9935" && password == "123456789")
                return true;
            else return false;
        }
    }
}