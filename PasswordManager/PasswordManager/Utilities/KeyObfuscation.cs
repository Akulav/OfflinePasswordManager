namespace PasswordManager.Utilities
{
    public static class KeyObfuscation
    {
        public static string[] Obfuscate(string fullkey)
        {
            string[] obfuscatedKey = new string[2];
            string secondaryKey = Crypto.GenRandString(128);
            obfuscatedKey[0] = Crypto.Encrypt(fullkey, secondaryKey);
            obfuscatedKey[1] = secondaryKey;
            return obfuscatedKey;
        }
    }
}
