using PasswordManager.Utilities;
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
                    try
                    {
                        selection = fileSelectionDialog.FileName;
                        Crypto.Erase();
                        ZipFile.ExtractToDirectory(selection, Paths.fileLocation);
                        Application.Restart();
                    }
                    catch
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
                
                
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string startPath = Paths.fileLocation;
                        string zipPath = fbd.SelectedPath + @"\data.zip";
                        ZipFile.CreateFromDirectory(startPath, zipPath);
                        return true;
                    }

                    else { return false; }
                }
                
            
        }
    }
}
