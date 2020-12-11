using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuditScaner
{
    public partial class ImportConfirm : Form
    {
        public ImportConfirm()
        {
            InitializeComponent();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            erase();
            import();
            Application.Restart();
        }

        private void import()
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
                ZipFile.ExtractToDirectory(selection, extractPath);
            }
            try
            {
                selection = openFileDialog1.FileName;
                ZipFile.ExtractToDirectory(selection, extractPath);
            }
            catch (IOException)
            {
                
            }

            catch (ArgumentNullException)
            {

            }

        }

        private void erase()
        {
            string fileLocation = "C:\\PasswordManager\\Storage";
            string curFile = @"c:\PasswordManager\user";

            string[] fileList = Directory.GetFiles(fileLocation);
            for (int i = 0; i < fileList.Length; i++)
            {
                string data = File.ReadAllText(fileList[i]);
                string newData = Encrypt(data, GenerateRandomAlphanumericString());
                File.WriteAllText(fileList[i], newData);
                File.Encrypt(fileList[i]);
                File.Delete(fileList[i]);
            }

            File.Delete(curFile);
        }

        public string GenerateRandomAlphanumericString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[40];
            Random rnd = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[rnd.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }

        public string Encrypt(string clearText, string EncryptionKey)
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
    }
}
