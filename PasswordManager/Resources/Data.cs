namespace PasswordManager.Resources
{
    public class Data
    {
        public string username;
        public string password;
        public string pim;
        public bool dark = false;
        public string username_salt;
        public string password_salt;
        public string pim_salt;
        public string encryptVector = "default";
        public string version = "7.0.0";
        public int Timeout = 10000;
    }
}
