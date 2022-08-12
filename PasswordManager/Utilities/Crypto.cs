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
        public static string GetMD5()
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            FileStream stream = new FileStream(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            md5.ComputeHash(stream);

            stream.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < md5.Hash.Length; i++)
                sb.Append(md5.Hash[i].ToString("x2"));

            return sb.ToString().ToUpperInvariant();
        }
        public static string GenRandString(int length)
        {
            Random rnd = new Random();
            int alphaNumericalChars = rnd.Next(32);
            return Membership.GeneratePassword(length, alphaNumericalChars);
        }
        public static string Encrypt(string clearText, string EncryptionKey)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            byte[] iv = Utility.GetBytes(GetVector());
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

        private static string GetVector()
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

        public static string Decrypt(string cipherText, string EncryptionKey)
        {
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] iv = Utility.GetBytes(GetVector());
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
