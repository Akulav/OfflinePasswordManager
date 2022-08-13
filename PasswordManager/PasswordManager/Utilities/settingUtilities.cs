using Newtonsoft.Json;
using System.IO;

namespace PasswordManager.Utilities
{
    public static class settingUtilities
    {
        public static Data getSettings()
        {
            return JsonConvert.DeserializeObject<Data>(File.ReadAllText(Paths.settings));
        }

        public static void saveSettings(object dt)
        {
            string result = JsonConvert.SerializeObject(dt);
            using (var tw = new StreamWriter(Paths.settings, false))
            {
                tw.Write(result);
                tw.Close();
            }
        }
    }


}
