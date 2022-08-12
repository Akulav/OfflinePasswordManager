using Newtonsoft.Json;
using PasswordManager.Utilities;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace PasswordManager
{
    class Crypto
    {
        public static string GenRandString(int length)
        {
            Random rnd = new Random();
            int alphaNumericalChars = rnd.Next(32);
            return Membership.GeneratePassword(length, alphaNumericalChars);
        }
        public static string Encrypt(string clearText, string EncryptionKey)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            byte[] iv = Utility.GetBytes(getVector());
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, iv);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        private static string getVector()
        {
            Data dt = settingUtilities.getSettings();
            if (dt.encryptVector == "default")
            {
                byte[] iv = Crypto.GenerateIV();
                string result = Encoding.Default.GetString(iv);
                dt.encryptVector = result;
                settingUtilities.saveSettings(dt);
                return result;
            }

            else
            {
                return dt.encryptVector;
            }
        }

        public static string[] GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(input + salt);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            string[] data = { BitConverter.ToString(hash), salt };
            return data;
        }

        public static string FinalKey(string input, string salt, int PIM)
        {
            string result = input + salt;

            for (int i = 0; i < PIM; i++)
            {
                byte[] bytes = Encoding.ASCII.GetBytes(result);
                SHA256Managed sHA256ManagedString = new SHA256Managed();
                byte[] hash = sHA256ManagedString.ComputeHash(bytes);
                result = BitConverter.ToString(hash);
            }

            return result;
        }

        public static void Erase()
        {
            Utility.ForceDeleteDirectory(Paths.fileLocation);

            for (int i = 0; i < 10; i++)
            {
                File.WriteAllText(Paths.database, Crypto.GenRandString(128));
                File.WriteAllText(Paths.settings, Crypto.GenRandString(128));
            }

            Directory.Delete(Paths.fileLocation, true);
        }

        public static byte[] GenerateIV()
        {
            var aes = new AesCryptoServiceProvider();
            byte[] iv = aes.IV;
            return iv;
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

                string[] hashUser = GenerateHash(user, lines[0]);
                string[] hashPass = GenerateHash(pass, lines[2]);
                string[] PIMRead = GenerateHash(pass + user, lines[5]);

                for (int i = 0; i < PIM; i++)
                {
                    PIMRead = GenerateHash(PIMRead[0], PIMRead[1]);
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

        public static string Decrypt(string cipherText, string EncryptionKey)
        {
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] iv = Utility.GetBytes(getVector());
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, iv);
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
