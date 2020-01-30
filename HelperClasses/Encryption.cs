using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HelperClasses
{
    public static class Encryption
    {
        public sealed class SecureStringWrapper : IDisposable
        {
            private readonly Encoding encoding;
            private readonly SecureString secureString;
            private byte[] _bytes = null;

            public SecureStringWrapper(SecureString secureString)
                  : this(secureString, Encoding.UTF8)
            { }

            public SecureStringWrapper(SecureString secureString, Encoding encoding)
            {
                if (secureString == null)
                {
                    throw new ArgumentNullException(nameof(secureString));
                }

                this.encoding = encoding ?? Encoding.UTF8;
                this.secureString = secureString;
            }

            public unsafe byte[] ToByteArray()
            {

                int maxLength = encoding.GetMaxByteCount(secureString.Length);

                IntPtr bytes = IntPtr.Zero;
                IntPtr str = IntPtr.Zero;

                try
                {
                    bytes = Marshal.AllocHGlobal(maxLength);
                    str = Marshal.SecureStringToBSTR(secureString);

                    char* chars = (char*)str.ToPointer();
                    byte* bptr = (byte*)bytes.ToPointer();
                    int len = encoding.GetBytes(chars, secureString.Length, bptr, maxLength);

                    _bytes = new byte[len];
                    for (int i = 0; i < len; ++i)
                    {
                        _bytes[i] = *bptr;
                        bptr++;
                    }

                    return _bytes;
                }
                finally
                {
                    if (bytes != IntPtr.Zero)
                    {
                        Marshal.FreeHGlobal(bytes);
                    }
                    if (str != IntPtr.Zero)
                    {
                        Marshal.ZeroFreeBSTR(str);
                    }
                }
            }

            private bool _disposed = false;

            public void Dispose()
            {
                if (!_disposed)
                {
                    Destroy();
                    _disposed = true;
                }
                GC.SuppressFinalize(this);
            }

            private void Destroy()
            {
                if (_bytes == null) { return; }

                for (int i = 0; i < _bytes.Length; i++)
                {
                    _bytes[i] = 0;
                }
                _bytes = null;
            }

            ~SecureStringWrapper()
            {
                Dispose();
            }
        }

        public const string DefaultPasswordHash = "^�H��(\u0004qQ��o��)'s`=\rj���*\u0011�r\u001d\u0015B�";
        public static string PasswordHash = "^�H��(\u0004qQ��o��)'s`=\rj���*\u0011�r\u001d\u0015B�";

        public static string CreateHash(SecureString pass)
        {
            SecureStringWrapper ss = new SecureStringWrapper(pass);
            byte[] data = ss.ToByteArray();
            SHA256 shaM = new SHA256Managed();
            return System.Text.Encoding.UTF8.GetString(shaM.ComputeHash(data));
        }

        public static bool TestPassword(SecureString pass, string stored)
        {
            string test = CreateHash(pass);
            if (test == stored)
                return true;

            return false;
        }


        /// <summary>
        /// Encrypt the given string using AES.  The string can be decrypted using 
        /// DecryptStringAES().  The sharedSecret parameters must match.
        /// </summary>
        /// <param name="plainText">The text to encrypt.</param>
        /// <param name="sharedSecret">A password used to generate a key for encryption.</param>
        public static string EncryptStringAES(string plainText, string sharedSecret)
        {
            byte[] salt = Encoding.UTF8.GetBytes(sharedSecret);

            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException("plainText");
            if (string.IsNullOrEmpty(sharedSecret))
                throw new ArgumentNullException("sharedSecret");

            string outStr = null;                       // Encrypted string to return
            RijndaelManaged aesAlg = null;              // RijndaelManaged object used to encrypt the data.

            try
            {
                // generate the key from the shared secret and the salt
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, salt);

                // Create a RijndaelManaged object
                aesAlg = new RijndaelManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);

                // Create a decryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    // prepend the IV
                    msEncrypt.Write(BitConverter.GetBytes(aesAlg.IV.Length), 0, sizeof(int));
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                    }
                    outStr = Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            // Return the encrypted bytes from the memory stream.
            return outStr;
        }

        /// <summary>
        /// Decrypt the given string.  Assumes the string was encrypted using 
        /// EncryptStringAES(), using an identical sharedSecret.
        /// </summary>
        /// <param name="cipherText">The text to decrypt.</param>
        /// <param name="sharedSecret">A password used to generate a key for decryption.</param>
        public static string DecryptStringAES(string cipherText, string sharedSecret)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException("cipherText");
            if (string.IsNullOrEmpty(sharedSecret))
                throw new ArgumentNullException("sharedSecret");

            // Declare the RijndaelManaged object
            // used to decrypt the data.
            RijndaelManaged aesAlg = null;

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            try
            {
                // generate the key from the shared secret and the salt
                Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, Encoding.UTF8.GetBytes(sharedSecret));

                // Create the streams used for decryption.                
                byte[] bytes = Convert.FromBase64String(cipherText);
                using (MemoryStream msDecrypt = new MemoryStream(bytes))
                {
                    // Create a RijndaelManaged object
                    // with the specified key and IV.
                    aesAlg = new RijndaelManaged();
                    aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                    // Get the initialization vector from the encrypted stream
                    aesAlg.IV = ReadByteArray(msDecrypt);
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            finally
            {
                // Clear the RijndaelManaged object.
                if (aesAlg != null)
                    aesAlg.Clear();
            }

            return plaintext;
        }

        private static byte[] ReadByteArray(Stream s)
        {
            byte[] rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
            {
                throw new SystemException("Stream did not contain properly formatted byte array");
            }

            byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new SystemException("Did not read byte array properly");
            }

            return buffer;
        }
    }
}
