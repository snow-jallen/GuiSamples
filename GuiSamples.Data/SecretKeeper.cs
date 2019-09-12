using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GuiSamples.Data
{
    public static class SecretKeeper
    {
        const string secretPath = "secret.txt";
        private static byte[] additionalEntropy = { 9, 32, 7, 14, 5, 0, 2, 12 };

        public static bool SecretExists()
        {
            return File.Exists(secretPath);
        }

        public static string GetConnectionString()
        {

            if (!SecretExists())
                throw new FileNotFoundException("Unable to locate secret.txt");

            var encryptedSecret = File.ReadAllText(secretPath);
            var encryptedBytes = Convert.FromBase64String(encryptedSecret);
            var plainBytes = ProtectedData.Unprotect(encryptedBytes, additionalEntropy, DataProtectionScope.CurrentUser);
            var plainText = Encoding.Unicode.GetString(plainBytes);
            return plainText;
        }

        public static void SaveConnectionString(string plainText)
        {
            if (string.IsNullOrWhiteSpace(plainText))
            {
                throw new ArgumentException("Unable to save an empty secret", nameof(plainText));
            }

            var data = Encoding.Unicode.GetBytes(plainText);
            var bytes = ProtectedData.Protect(data, additionalEntropy, DataProtectionScope.CurrentUser);
            var encryptedText = Convert.ToBase64String(bytes);
            File.WriteAllText(secretPath, encryptedText);
        }
    }
}
