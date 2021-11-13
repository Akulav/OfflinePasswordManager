using System;
using System.IO.Compression;
using System.Windows.Forms;

namespace PasswordManager
{
    class ImportExportClass
    {
        public static void Import()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = Utilities.fileLocation,
                Filter = "Zip files (*.zip)|*.zip*",
                FilterIndex = 0,
                RestoreDirectory = true
            };
            string selection;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selection = openFileDialog1.FileName;
                if (selection != null)
                {
                    try
                    {
                        selection = openFileDialog1.FileName;
                        Crypto.Erase();
                        ZipFile.ExtractToDirectory(selection, Utilities.fileLocation);
                        Application.Restart();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        public static bool Export()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                try
                {
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string startPath = Utilities.fileLocation;
                        string zipPath = fbd.SelectedPath + @"\data.zip";
                        ZipFile.CreateFromDirectory(startPath, zipPath);
                        return true;
                    }

                    else { return false; }
                }
                catch { return false; }
            }
        }
    }
}
