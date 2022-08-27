using PasswordManager.Utilities;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace PasswordManager
{
    class ImportExportClass
    {
        public static void Import()
        {
            OpenFileDialog fileSelectionDialog = new OpenFileDialog
            {
                InitialDirectory = Paths.fileLocation,
                Filter = "Zip files (*.zip)|*.zip*",
                FilterIndex = 0,
                RestoreDirectory = true
            };
            string selection;

            if (fileSelectionDialog.ShowDialog() == DialogResult.OK)
            {
                selection = fileSelectionDialog.FileName;
                if (selection != null)
                {
                    
                        selection = fileSelectionDialog.FileName;
                        Crypto.Erase();
                        ZipFile.ExtractToDirectory(selection, Paths.fileLocation);
                        Application.Restart();
                   
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
                    string[] files = { Paths.settings, Paths.database };
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string zipPath = fbd.SelectedPath + @"\data.zip";
                        var zip = ZipFile.Open(zipPath, ZipArchiveMode.Create);

                        foreach (var file in files)
                        {
                            // Add the entry for each file
                            zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
                        }
                        // Dispose of the object when we are done
                        zip.Dispose();
                        return true;
                    }

                    else { return false; }
                }
                catch { return false; }
            }
        }
    }
}
