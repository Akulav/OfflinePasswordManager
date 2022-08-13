using Microsoft.Win32;
using Newtonsoft.Json;
using PasswordManager.Utilities;
using System;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PasswordManager
{
    class Utility
    {
        public static byte[] GetBytes(string data)
        {
            return Encoding.Default.GetBytes(data);
        }

        public static void InitializeDataSet()
        {
            try
            {
                if (!File.Exists(Paths.settings))
                {
                    File.WriteAllText(Paths.settings, null);
                    Data dt = new Data();
                    string result = JsonConvert.SerializeObject(dt);
                    using (var tw = new StreamWriter(Paths.settings, true))
                    {
                        tw.WriteLine(result.ToString());
                        tw.Close();
                    }

                }

                if (!File.Exists(Paths.database))
                {
                    File.WriteAllText(Paths.database, null);
                    var con = new SQLiteConnection(Paths.database_connection);
                    con.Open();
                    var data_cmd = new SQLiteCommand(con)
                    {
                        CommandText = @"CREATE TABLE data(username VARCRHAR(250), pass VARCRHAR(250),domain VARCRHAR(250))"
                    };

                    data_cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch { }
        }

        public static void ForceDeleteDirectory(string path)
        {
            var directory = new DirectoryInfo(path) { Attributes = FileAttributes.Normal };

            foreach (var info in directory.GetFileSystemInfos("*", SearchOption.AllDirectories))
            {
                info.Attributes = FileAttributes.Normal;
            }
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
