namespace PasswordManager.Utilities
{
    public class Data
    {
        public string username;
        public string password;
        public string pim;
        public bool dark = true;
        public string username_salt;
        public string password_salt;
        public string pim_salt;
        public string encryptVector = "default";
        public string version = "7.1.0";
        public int Timeout = 10000;
        public bool userFlag = false;
    }
}
