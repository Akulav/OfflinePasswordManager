using Microsoft.Win32;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace PasswordManager
{
    class Utilities
    {
        public static readonly string fileLocation = "C:\\PasswordManager\\";
        public static readonly string viewDataLocation = "C:\\PasswordManager\\localuser";
        public static readonly string users = "c:\\PasswordManager\\users\\";
        public static readonly string database = "c:\\PasswordManager\\users\\data.db";
        public static readonly string database_connection = @"URI=file:C:\PasswordManager\users\data.db";
        public static readonly string user_data = "c:\\PasswordManager\\localuser\\user_data.db";
        public static readonly string user_data_connection = @"URI=file:C:\PasswordManager\localuser\user_data.db";
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
                // Set the IsReadOnly property.
                IsReadOnly = SetReadOnly
            };

        }

        public static void MarkHidden(string Filename)
        {
            FileInfo myFile = new FileInfo(Environment.CurrentDirectory + $@"\{Filename}");
            myFile.Attributes |= FileAttributes.Hidden;
        }

        public void ImportDLL()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    byte[] assemblyData = new byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
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
