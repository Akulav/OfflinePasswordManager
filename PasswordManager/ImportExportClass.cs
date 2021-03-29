using System;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using PasswordManager;

namespace PasswordManager
{
    class ImportExportClass
    {
        public static void import(string fileLocation)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\PasswordManager";
            openFileDialog1.Filter = "Zip files (*.zip)|*.zip*";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;
            string selection;
            string extractPath = @"c:\PasswordManager";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selection = openFileDialog1.FileName;
                if (selection != null)
                {
                    try
                    {
                        selection = openFileDialog1.FileName;
                        Crypto.erase(fileLocation);
                        ZipFile.ExtractToDirectory(selection, extractPath);
                    }
                    catch (IOException)
                    {

                    }

                    catch (ArgumentNullException)
                    {

                    }
                }
            }

            Application.Restart();
        }

        public static void export()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string startPath = @"c:\PasswordManager";
                    string zipPath = fbd.SelectedPath + @"\data.zip";

                    ZipFile.CreateFromDirectory(startPath, zipPath);

                }
            }
        }
    }
}
