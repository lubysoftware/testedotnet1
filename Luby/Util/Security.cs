using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Luby.Util
{
    public static class Security
    {
        public static string encryptSHA256(string message)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            SHA256Managed sha256 = new SHA256Managed();
            byte[] encrypt_data = utf8.GetBytes(message);
            byte[] hashValue = sha256.ComputeHash(encrypt_data);
            string strHex = "";
            foreach (byte b in hashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            return strHex;
        }
    }
 }
