using System;

namespace PasswordManager.Utilities
{
    public static class UserValidation
    {
        public static string CheckInput(string username, string password, string pim)
        {
            try
            {
                if (username == "")
                {
                    return "Username must not be null";
                    throw new Exception();
                }

                if (int.TryParse(pim, out _))
                {
                    int PIM = int.Parse(pim);
                    if (PIM > 100000 || PIM < 100)
                    {
                        return "PIM must be between 100 and 100000";
                        throw new Exception();
                    }
                }

                if (!int.TryParse(pim, out _))
                {
                    return "PIM must be a number";
                    throw new Exception();
                }

                if (!ValidatePassword(password))
                {
                    return "Password must be at least 12 characters\n long and contain alphanumeric chars";
                    throw new Exception();
                }
            }

            catch { }
            return "success";
        }
        public static bool ValidatePassword(string password)
        {
            const int MIN_LENGTH = 12;
            const int MAX_LENGTH = int.MaxValue - 1;

            if (password == null) throw new ArgumentNullException();

            bool meetsLengthRequirements = password.Length >= MIN_LENGTH && password.Length <= MAX_LENGTH;
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;

            if (meetsLengthRequirements)
            {
                foreach (char c in password)
                {
                    if (char.IsUpper(c)) hasUpperCaseLetter = true;
                    else if (char.IsLower(c)) hasLowerCaseLetter = true;
                    else if (char.IsDigit(c)) hasDecimalDigit = true;
                }
            }

            bool isValid = meetsLengthRequirements
                        && hasUpperCaseLetter
                        && hasLowerCaseLetter
                        && hasDecimalDigit
                        ;
            return isValid;

        }

        public static bool CheckHash(string user, string pass, int PIM)
        {
            try
            {
                Data dt = settingUtilities.getSettings();
                string[] lines = new string[6];
                lines[0] = dt.username;
                lines[1] = dt.username_salt;
                lines[2] = dt.password;
                lines[3] = dt.password_salt;
                lines[4] = dt.pim;
                lines[5] = dt.pim_salt;

                string[] hashUser = Crypto.GenerateHash(user, lines[0]);
                string[] hashPass = Crypto.GenerateHash(pass, lines[2]);
                string[] PIMRead = Crypto.GenerateHash(pass + user, lines[5]);

                for (int i = 0; i < PIM; i++)
                {
                    PIMRead = Crypto.GenerateHash(PIMRead[0], PIMRead[1]);
                }

                if (hashUser[1] == lines[0])
                {

                    if (hashPass[1] == lines[2])
                    {
                        if (PIMRead[0] == lines[4])
                        {
                            return true;
                        }
                        else { return false; }
                    }

                    else { return false; }
                }

                else { return false; }
            }

            catch { return false; }
        }
        public static bool CheckIfUser()
        {
            Data dt = settingUtilities.getSettings();
            if (!dt.userFlag)
            {
                return false;
            }
            else return true;
        }
    }
}
