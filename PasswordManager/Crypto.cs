﻿using System;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace PasswordManager
{
    class Crypto
    {
        public static string GenerateRandomAlphanumericString(int length)
        {
            Random rnd = new Random();
            int alphaNumericalChars = rnd.Next(32);
            return Membership.GeneratePassword(length, alphaNumericalChars);
        }
        public static string Encrypt(string clearText, string EncryptionKey)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
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

        public static string[] GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(input + salt);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            string[] data = { BitConverter.ToString(hash), salt };
            return data;
        }

        public static string GenerateMasterKey(string input, string salt)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(input + salt);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            string data = BitConverter.ToString(hash);
            return data;
        }

        public static string FinalKey(string input, string salt, int PIM)
        {
            for (int i = 0; i < PIM; i++)
            {
                input = GenerateMasterKey(input, salt);
            }

            return input;
        }

        public static void Erase()
        {

            ForceDeleteDirectory(Utilities.defaultFolder);
            DirectoryInfo di = new DirectoryInfo(Utilities.fileLocation);

            foreach (FileInfo file in di.GetFiles())
            {
                //Utilities.SetFileReadAccess(Utilities.fileLocation + file.ToString(), false);
                string oldData = File.ReadAllText(@file.ToString());
                string newData = Encrypt(oldData, GenerateRandomAlphanumericString(20));
                File.WriteAllText(file.ToString(), newData);
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
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

        public static void ForceDeleteDirectory(string path)
        {
            var directory = new DirectoryInfo(path) { Attributes = FileAttributes.Normal };

            foreach (var info in directory.GetFileSystemInfos("*", SearchOption.AllDirectories))
            {
                info.Attributes = FileAttributes.Normal;
            }
        }

        public static string GenerateRandomFileName(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            Random rnd = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[rnd.Next(chars.Length)];
            }

            var finalString = new string(stringChars);

            return finalString;
        }

        public static bool CheckHash(string user, string pass, int PIM)
        {
            try
            {
                string[] lines = new string[6];
                var con = new SQLiteConnection(Utilities.database_connection);
                con.Open();
                string userQuery = "SELECT username FROM user WHERE id = '1'";
                string usersaltQuery = "SELECT user_salt FROM user WHERE id = '1'";
                string passQuery = "SELECT pass FROM user WHERE id = '1'";
                string passsaltQuery = "SELECT pass_salt FROM user WHERE id = '1'";
                string pimQuery = "SELECT pim FROM user WHERE id = '1'";
                string pimsaltQuery = "SELECT pim_salt FROM user WHERE id = '1'";

                var username = new SQLiteCommand(userQuery, con);
                var user_salt = new SQLiteCommand(usersaltQuery, con);
                var password = new SQLiteCommand(passQuery, con);
                var pass_salt = new SQLiteCommand(passsaltQuery, con);
                var pim = new SQLiteCommand(pimQuery, con);
                var pim_read = new SQLiteCommand(pimsaltQuery, con);

                lines[0] = username.ExecuteScalar().ToString();
                lines[1] = user_salt.ExecuteScalar().ToString();
                lines[2] = password.ExecuteScalar().ToString();
                lines[3] = pass_salt.ExecuteScalar().ToString();
                lines[4] = pim.ExecuteScalar().ToString();
                lines[5] = pim_read.ExecuteScalar().ToString();

                //string[] lines = File.ReadAllLines(Utilities.curfile);
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
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
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
