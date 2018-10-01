using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Demo.Utility.Util
{
    /// <summary>
    /// Helper class 
    /// </summary>
    public class HelperAttribute
    {
        public HelperAttribute() { }
        
        #region Encrypt String to Base64
        public static string EncryptStringB64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.Encoding.Unicode.GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
        #endregion
        #region Decrypt Base64 to String
        public static string DecryptStringB64(string encodedData)
        {
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
            string returnValue = System.Text.Encoding.Unicode.GetString(encodedDataAsBytes);
            return returnValue;
        }
        #endregion
    }
}