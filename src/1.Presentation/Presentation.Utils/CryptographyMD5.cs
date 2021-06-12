using System;
using System.Security.Cryptography;
using System.Text;

namespace Presentation.Utils
{
    public class CryptographyMD5
    {
        public static string StringToMD5(string toEncrypt)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return ReturnHash(md5Hash, toEncrypt);
            }
        }

        public static bool CompareStringToMD5(string unencrypted, string encrypted)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                StringComparer compara = StringComparer.OrdinalIgnoreCase;

                if (compara.Compare(StringToMD5(unencrypted), encrypted) == 0)
                    return true;
                else
                    return false;
            }
        }

        private static string ReturnHash(MD5 md5Hash, string toEncrypt)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(toEncrypt));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}