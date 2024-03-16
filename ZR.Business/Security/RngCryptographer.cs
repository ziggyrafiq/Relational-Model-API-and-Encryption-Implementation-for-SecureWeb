/************************************************************************************************************
*  COPYRIGHT BY ZIGGY RAFIQ (ZAHEER RAFIQ)
*  LinkedIn Profile URL Address: https://www.linkedin.com/in/ziggyrafiq/ 
*
*  System   :  	ZR Demo Project 01 - Book Api
*  Date     :  	25/09/2022
*  Author   :  	Ziggy Rafiq (https://www.ziggyrafiq.com)
*  Notes    :  	
*  Reminder :	PLEASE DO NOT CHANGE OR REMOVE AUTHOR NAME.
*
************************************************************************************************************/


using ZR.Business.Security.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace ZR.Business.Security
{
    public class RngCryptographer : IRngCryptographer
    {

        /// <summary>
        /// Create Salt Key, which can be use to encrypt user passwords.
        /// </summary>
        /// <returns> Base64String</returns>
        public string CreateSalt()
        {

            byte[] data = new byte[0x10];
            new RNGCryptoServiceProvider().GetBytes(data);


            return Convert.ToBase64String(data);
        }


        /// <summary>
        /// The HashPassword will create a encrypt password for the
        /// user by using the user pasword and the salt and return base64string
        /// </summary>
        /// <param name="password">User Password</param>
        /// <param name="salt">Salt, which is generated using the CreatSalt method</param>
        /// <returns></returns>
        public string HashPassword(string password, string salt)
        {
            password = password.Trim();
            salt = salt.Trim();

            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] src = Convert.FromBase64String(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            byte[] inArray = null;
            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            inArray = algorithm.ComputeHash(dst);


            return Convert.ToBase64String(inArray);
        }


        /// <summary>
        /// This fuction which create a Unique Key
        /// base on the length number and the length has to be more then 1
        /// and less then the guidResult Length
        /// </summary>
        /// <param name="length">enter number and its more then 0 so 1 is fine</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public string CreateUniqueKey(int length)
        {
            string guidResult = string.Empty;


            while (guidResult.Length < length)
            {

                guidResult += Guid.NewGuid().ToString().GetHashCode().ToString("x");
            }


            if (length <= 0 || length > guidResult.Length)
            {
                throw new ArgumentException("Length must be between 1 and " + guidResult.Length);
            }

            return guidResult.Substring(0, length);
        }
        public void Dispose()
        {
            GC.Collect();

        }
    }
}
