using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PasswordManager
{
    class Utility
    {
        public static string GetMD5()
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            System.IO.FileStream stream = new System.IO.FileStream(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            md5.ComputeHash(stream);

            stream.Close();

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < md5.Hash.Length; i++)
                sb.Append(md5.Hash[i].ToString("x2"));

            return sb.ToString().ToUpperInvariant();
        }
        public static byte[] GetBytes(string data)
        {
            return Encoding.Default.GetBytes(data);
        }
        public static void EnforceAdminPrivilegesWorkaround()
        {
            RegistryKey rk;
            string registryPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon\";

            try
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    rk = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                }
                else
                {
                    rk = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                }

                rk = rk.OpenSubKey(registryPath, true);
            }
            catch (System.Security.SecurityException)
            {
                MessageBox.Show("Please run as administrator");
                Environment.Exit(1);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static void SetFileReadAccess(string FileName, bool SetReadOnly)
        {
            _ = new FileInfo(FileName)
            {
                IsReadOnly = SetReadOnly
            };

        }

        public static string GetWindowsVersion()
        {
            object os_version = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "ReleaseId", 1);

            if (os_version != null)
            {
                return "Windows Build: " + os_version.ToString();
            }

            else
            {
                return "Could not read Windows Build";
            }
        }
    }
}
