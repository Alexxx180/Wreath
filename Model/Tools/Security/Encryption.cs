using System.Security.Cryptography;
using System.Text;

namespace Wreath.Model.Tools.Security
{
    public class Encryption
    {
        private static readonly byte[] s_additionalEntropy;

        static Encryption()
        {
            s_additionalEntropy = new byte[] {
                9, 8, 7, 6, 5, 8, 1, 2, 6,
                9, 4, 2, 0, 3, 5, 5, 8, 2
            };
        }

        private static byte[] GetBytes(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        private static string GetString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public static byte[] ProtectData(string data)
        {
            byte[] protectedData = Protect(GetBytes(data));
            return protectedData;
        }

        public static string UnprotectData(byte[] data)
        {
            if (data is null)
                return "";
            byte[] unprotectedData = Unprotect(data);
            return unprotectedData is null ? "" :
                GetString(unprotectedData);
        }

        private static byte[] Protect(byte[] data)
        {
            byte[] protectedData;
            try
            {
                protectedData = ProtectedData.Protect
                    (data, s_additionalEntropy, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException exception)
            {
                throw new CryptographicException(exception.Message);
            }
            return protectedData;
        }

        private static byte[] Unprotect(byte[] data)
        {
            byte[] unprotectedData;
            try
            {
                unprotectedData = ProtectedData.Unprotect
                    (data, s_additionalEntropy, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException exception)
            {
                throw new CryptographicException(exception.Message);
            }
            return unprotectedData;
        }
    }
}