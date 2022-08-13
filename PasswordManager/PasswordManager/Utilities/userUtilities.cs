namespace PasswordManager.Utilities
{
    public static class UserUtilities
    {
        public static void CreateUser(string username, string password, string pim)
        {
            int pimINT = int.Parse(pim);
            string[] datapass = Crypto.GenerateHash(password, Crypto.GenRandString(64));
            string[] dataname = Crypto.GenerateHash(username, Crypto.GenRandString(64));
            string[] PIMRead = Crypto.GenerateHash(password + username, Crypto.GenRandString(64));

            for (int i = 0; i < pimINT; i++)
            {
                PIMRead = Crypto.GenerateHash(PIMRead[0], PIMRead[1]);
            }

            Data dt = new Data
            {
                username = datapass[0],
                username_salt = datapass[1],
                password = dataname[0],
                password_salt = dataname[1],
                pim = PIMRead[0],
                pim_salt = PIMRead[1],
                userFlag = true
            };

            settingUtilities.saveSettings(dt);
            Utility.SetFileReadAccess(Paths.database, true);
        }

    }
}
