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
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System.Security.Cryptography;
using System.Text;

namespace ZR.Business.Security
{

    public class RsaCryptograper : IRsaCryptograper
    {
        private readonly RSACryptoServiceProvider _privateKey;
        private readonly RSACryptoServiceProvider _publicKey;

        public RsaCryptograper()
        {
            string public_pem = @"..\_keys\public-key.pem";
            string private_pem = @"..\_keys\private-key.pem";

            _privateKey = GetPrivateKeyFromPemFile(private_pem);
            _publicKey = GetPublicKeyFromPemFile(public_pem);


        }

        /// <summary>
        /// To Encrypt the data using RSA Encrypt we need to pass the text and the pem key file,
        /// which normal is stored in a folder name _Keys or _keys with the file name public-key.pem
        /// </summary>
        /// <param name="text">The Text you want to encrypt</param>
        /// <returns>It will return base64String, which is encrypt</returns>
       public string Encrypt(string text)
        {
            var encryptedBytes = _publicKey.Encrypt(Encoding.UTF8.GetBytes(text), false);
            return Convert.ToBase64String(encryptedBytes);
        }

        /// <summary>
        /// To Decrypt the RSA data we need to pass the encrypted data and the file name with it path,
        /// which normal we keep the file named as private-key.pem and stored in a folder name _Keys or _keys
        /// </summary>
        /// <param name="encrypted">Give the Encrypted Data which you want to Decrypt</param>
        /// <returns></returns>
       public string Decrypt(string encrypted)
        {            
            var decryptedBytes = _privateKey.Decrypt(Convert.FromBase64String(encrypted), false);
            return Encoding.UTF8.GetString(decryptedBytes, 0, decryptedBytes.Length);
        }

        private RSACryptoServiceProvider GetPrivateKeyFromPemFile(string filePath)
        {
            using (TextReader privateKeyTextReader = new StringReader(File.ReadAllText(filePath)))
            {
                AsymmetricCipherKeyPair readKeyPair = (AsymmetricCipherKeyPair)new PemReader(privateKeyTextReader).ReadObject();

                RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)readKeyPair.Private);
                RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
                csp.ImportParameters(rsaParams);
                return csp;
            }
        }

        private RSACryptoServiceProvider GetPublicKeyFromPemFile(string filePath)
        {
            using (TextReader publicKeyTextReader = new StringReader(File.ReadAllText(filePath)))
            {
                RsaKeyParameters publicKeyParam = (RsaKeyParameters)new PemReader(publicKeyTextReader).ReadObject();

                RSAParameters rsaParams = DotNetUtilities.ToRSAParameters(publicKeyParam);

                RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
                csp.ImportParameters(rsaParams);
                return csp;
            }
        }

        public void Dispose()
        {
            GC.Collect();

        }
    }
}
