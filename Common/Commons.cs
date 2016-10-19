using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Common
{
    public class ComonFuction
    {

        /// <summary>
        /// Developer Joginder Singh
        /// Dated : 17-12-2015
        /// This is a common function help to slove another problem.
        /// </summary>
        /// <param name="encodedServername"></param>
        /// <returns></returns>
        public static string Decode(string stringValue)
        {
            try
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(stringValue));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string Encode(string stringValue)
        {
            try
            {
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(stringValue));
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static byte[] ConvertStringToByteArray(object name)
        {
            try
            {
                byte[] bytes = new byte[name.ToString().Length * sizeof(char)];
                System.Buffer.BlockCopy(name.ToString().ToCharArray(), 0, bytes, 0, bytes.Length);
                return bytes;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static byte[] FromBase64Bytes(byte[] base64Bytes)
        {
            try
            {
                string base64String = Encoding.UTF8.GetString(base64Bytes, 0, base64Bytes.Length);
                return Convert.FromBase64String(base64String);
            }
            catch (Exception)
            {

                throw;
            }


        }

        public static string FixBase64ForImage(string image)
        {
            try
            {
                System.Text.StringBuilder sbText = new System.Text.StringBuilder(image, image.Length);
                sbText.Replace("\r\n", String.Empty); sbText.Replace(" ", String.Empty);
                return sbText.ToString();

            }
            catch (Exception)
            {

                throw;
            }

        }

        public static string ConvertByteArrayToString(byte[] bytes)
        {
            try
            {
                char[] chars = new char[bytes.Length / sizeof(char)];
                System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
                return new string(chars);

            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// Return the Month Name Like 01-Dec-2015
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public static string ConvertMonth(string date)
        {
            try
            {
                if (ValidateStringValue(date))
                {

                    date = date.Replace('/', '-');
                    string[] Dateformat = date.Split('-');

                    date = Dateformat[0] + "-" + MonthName(Convert.ToInt32(Dateformat[1])) + "-" + Dateformat[2];
                    return date;
                }
                else
                    return "No Values";

            }
            catch (Exception)
            {

                throw;
            }

        }

        private static string MonthName(int m)
        {
            try
            {

                string res;
                switch (m)
                {
                    case 1:
                        res = "Jan";
                        break;
                    case 2:
                        res = "Feb";
                        break;
                    case 3:
                        res = "Mar";
                        break;
                    case 4:
                        res = "Apr";
                        break;
                    case 5:
                        res = "May";
                        break;
                    case 6:
                        res = "Jun";
                        break;
                    case 7:
                        res = "Jul";
                        break;
                    case 8:
                        res = "Aug";
                        break;
                    case 9:
                        res = "Sep";
                        break;
                    case 10:
                        res = "Oct";
                        break;
                    case 11:
                        res = "Nov";
                        break;
                    case 12:
                        res = "Dec";
                        break;
                    default:
                        res = "Null";
                        break;
                }
                return res;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static bool ValidateStringValue(string stringValue)
        {
            try
            {
                if (stringValue != string.Empty && stringValue != "" && stringValue != null)

                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Add Row Data in the tables 
        /// </summary>
        /// <param name="TempraryTable"></param>
        /// <param name="NodeName"></param>
        /// <param name="conditionValue"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
  

        public static string ConvertToUpperCase(string text)
        {
            try
            {
                return text.ToUpper();
            }
            catch (Exception)
            {

                throw;
            }

        }

        // Encrypt a byte array into a byte array using a key and an IV 
        //
        public static byte[] Encrypt(byte[] clearData, byte[] key, byte[] iv)
        {
            try
            {
                // Create a MemoryStream to accept the encrypted bytes 
                MemoryStream ms = new MemoryStream();

                // Create a symmetric algorithm. 
                // We are going to use Rijndael because it is strong and
                // available on all platforms. 
                // You can use other algorithms, to do so substitute the
                // next line with something like 
                //      TripleDES alg = TripleDES.Create(); 
                Rijndael alg = Rijndael.Create();

                // Now set the key and the IV. 
                // We need the IV (Initialization Vector) because
                // the algorithm is operating in its default 
                // mode called CBC (Cipher Block Chaining).
                // The IV is XORed with the first block (8 byte) 
                // of the data before it is encrypted, and then each
                // encrypted block is XORed with the 
                // following block of plaintext.
                // This is done to make encryption more secure. 

                // There is also a mode called ECB which does not need an IV,
                // but it is much less secure. 
                alg.Key = key;
                alg.IV = iv;

                // Create a CryptoStream through which we are going to be
                // pumping our data. 
                // CryptoStreamMode.Write means that we are going to be
                // writing data to the stream and the output will be written
                // in the MemoryStream we have provided. 
                CryptoStream cs = new CryptoStream(ms,
                   alg.CreateEncryptor(), CryptoStreamMode.Write);

                // Write the data and make it do the encryption 
                cs.Write(clearData, 0, clearData.Length);

                // Close the crypto stream (or do FlushFinalBlock). 
                // This will tell it that we have done our encryption and
                // there is no more data coming in, 
                // and it is now a good time to apply the padding and
                // finalize the encryption process. 
                cs.Close();

                // Now get the encrypted data from the MemoryStream.
                // Some people make a mistake of using GetBuffer() here,
                // which is not the right way. 
                byte[] encryptedData = ms.ToArray();

                return encryptedData;

            }
            catch (Exception)
            {

                throw;
            }

        }

        // Encrypt a string into a string using a password 
        //    Uses Encrypt(byte[], byte[], byte[]) 

        public static string Encrypt(string clearText, string password)
        {
            try
            {
                // First we need to turn the input string into a byte array. 
                byte[] clearBytes =
                  System.Text.Encoding.Unicode.GetBytes(clearText);

                // Then, we need to turn the password into Key and IV 
                // We are using salt to make it harder to guess our key
                // using a dictionary attack - 
                // trying to guess a password by enumerating all possible words. 
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(password,
                    new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

                // Now get the key/IV and do the encryption using the
                // function that accepts byte arrays. 
                // Using PasswordDeriveBytes object we are first getting
                // 32 bytes for the Key 
                // (the default Rijndael key length is 256bit = 32bytes)
                // and then 16 bytes for the IV. 
                // IV should always be the block size, which is by default
                // 16 bytes (128 bit) for Rijndael. 
                // If you are using DES/TripleDES/RC2 the block size is
                // 8 bytes and so should be the IV size. 
                // You can also read KeySize/BlockSize properties off
                // the algorithm to find out the sizes. 
                byte[] encryptedData = Encrypt(clearBytes,
                         pdb.GetBytes(32), pdb.GetBytes(16));

                // Now we need to turn the resulting byte array into a string. 
                // A common mistake would be to use an Encoding class for that.
                //It does not work because not all byte values can be
                // represented by characters. 
                // We are going to be using Base64 encoding that is designed
                //exactly for what we are trying to do. 
                return Convert.ToBase64String(encryptedData);

            }
            catch (Exception)
            {

                throw;
            }


        }

        // Encrypt bytes into bytes using a password 
        //    Uses Encrypt(byte[], byte[], byte[]) 

        public static byte[] Encrypt(byte[] clearData, string password)
        {
            try
            {
                // We need to turn the password into Key and IV. 
                // We are using salt to make it harder to guess our key
                // using a dictionary attack - 
                // trying to guess a password by enumerating all possible words. 
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(password,
                    new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

                // Now get the key/IV and do the encryption using the function
                // that accepts byte arrays. 
                // Using PasswordDeriveBytes object we are first getting
                // 32 bytes for the Key 
                // (the default Rijndael key length is 256bit = 32bytes)
                // and then 16 bytes for the IV. 
                // IV should always be the block size, which is by default
                // 16 bytes (128 bit) for Rijndael. 
                // If you are using DES/TripleDES/RC2 the block size is 8
                // bytes and so should be the IV size. 
                // You can also read KeySize/BlockSize properties off the
                // algorithm to find out the sizes. 
                return Encrypt(clearData, pdb.GetBytes(32), pdb.GetBytes(16));

            }
            catch (Exception)
            {

                throw;
            }


        }

        // Encrypt a file into another file using a password 
        //
        public static void Encrypt(string fileIn, string fileOut, string password)
        {
            try
            {
                // First we are going to open the file streams 
                FileStream fsIn = new FileStream(fileIn,
                    FileMode.Open, FileAccess.Read);
                FileStream fsOut = new FileStream(fileOut,
                    FileMode.OpenOrCreate, FileAccess.Write);

                // Then we are going to derive a Key and an IV from the
                // Password and create an algorithm 
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(password,
                    new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

                Rijndael alg = Rijndael.Create();
                alg.Key = pdb.GetBytes(32);
                alg.IV = pdb.GetBytes(16);

                // Now create a crypto stream through which we are going
                // to be pumping data. 
                // Our fileOut is going to be receiving the encrypted bytes. 
                CryptoStream cs = new CryptoStream(fsOut,
                    alg.CreateEncryptor(), CryptoStreamMode.Write);

                // Now will will initialize a buffer and will be processing
                // the input file in chunks. 
                // This is done to avoid reading the whole file (which can
                // be huge) into memory. 
                int bufferLen = 4096;
                byte[] buffer = new byte[bufferLen];
                int bytesRead;

                do
                {
                    // read a chunk of data from the input file 
                    bytesRead = fsIn.Read(buffer, 0, bufferLen);

                    // encrypt it 
                    cs.Write(buffer, 0, bytesRead);
                } while (bytesRead != 0);

                // close everything 

                // this will also close the unrelying fsOut stream
                cs.Close();
                fsIn.Close();
            }
            catch (Exception)
            {

                throw;
            }


        }

        // Decrypt a byte array into a byte array using a key and an IV 
        //
        public static byte[] Decrypt(byte[] cipherData, byte[] key, byte[] iv)
        {

            try
            {
                // Create a MemoryStream that is going to accept the
                // decrypted bytes 
                MemoryStream ms = new MemoryStream();

                // Create a symmetric algorithm. 
                // We are going to use Rijndael because it is strong and
                // available on all platforms. 
                // You can use other algorithms, to do so substitute the next
                // line with something like 
                //     TripleDES alg = TripleDES.Create(); 
                Rijndael alg = Rijndael.Create();

                // Now set the key and the IV. 
                // We need the IV (Initialization Vector) because the algorithm
                // is operating in its default 
                // mode called CBC (Cipher Block Chaining). The IV is XORed with
                // the first block (8 byte) 
                // of the data after it is decrypted, and then each decrypted
                // block is XORed with the previous 
                // cipher block. This is done to make encryption more secure. 
                // There is also a mode called ECB which does not need an IV,
                // but it is much less secure. 
                alg.Key = key;
                alg.IV = iv;

                // Create a CryptoStream through which we are going to be
                // pumping our data. 
                // CryptoStreamMode.Write means that we are going to be
                // writing data to the stream 
                // and the output will be written in the MemoryStream
                // we have provided. 
                CryptoStream cs = new CryptoStream(ms,
                    alg.CreateDecryptor(), CryptoStreamMode.Write);

                // Write the data and make it do the decryption 
                cs.Write(cipherData, 0, cipherData.Length);

                // Close the crypto stream (or do FlushFinalBlock). 
                // This will tell it that we have done our decryption
                // and there is no more data coming in, 
                // and it is now a good time to remove the padding
                // and finalize the decryption process. 
                cs.Close();

                // Now get the decrypted data from the MemoryStream. 
                // Some people make a mistake of using GetBuffer() here,
                // which is not the right way. 
                byte[] decryptedData = ms.ToArray();

                return decryptedData;

            }
            catch (Exception)
            {

                throw;
            }

        }

        // Decrypt a string into a string using a password 
        //    Uses Decrypt(byte[], byte[], byte[]) 

        public static string Decrypt(string cipherText, string password)
        {
            try
            {

                // First we need to turn the input string into a byte array. 
                // We presume that Base64 encoding was used 
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                // Then, we need to turn the password into Key and IV 
                // We are using salt to make it harder to guess our key
                // using a dictionary attack - 
                // trying to guess a password by enumerating all possible words. 
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(password,
                    new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 
            0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

                // Now get the key/IV and do the decryption using
                // the function that accepts byte arrays. 
                // Using PasswordDeriveBytes object we are first
                // getting 32 bytes for the Key 
                // (the default Rijndael key length is 256bit = 32bytes)
                // and then 16 bytes for the IV. 
                // IV should always be the block size, which is by
                // default 16 bytes (128 bit) for Rijndael. 
                // If you are using DES/TripleDES/RC2 the block size is
                // 8 bytes and so should be the IV size. 
                // You can also read KeySize/BlockSize properties off
                // the algorithm to find out the sizes. 
                byte[] decryptedData = Decrypt(cipherBytes,
                    pdb.GetBytes(32), pdb.GetBytes(16));

                // Now we need to turn the resulting byte array into a string. 
                // A common mistake would be to use an Encoding class for that.
                // It does not work 
                // because not all byte values can be represented by characters. 
                // We are going to be using Base64 encoding that is 
                // designed exactly for what we are trying to do. 
                return System.Text.Encoding.Unicode.GetString(decryptedData);
            }
            catch (Exception)
            {

                throw;
            }

        }

        // Decrypt bytes into bytes using a password 
        //    Uses Decrypt(byte[], byte[], byte[]) 

        public static byte[] Decrypt(byte[] cipherData, string password)
        {
            try
            {
                // We need to turn the password into Key and IV. 
                // We are using salt to make it harder to guess our key
                // using a dictionary attack - 
                // trying to guess a password by enumerating all possible words. 
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(password,
                    new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});

                // Now get the key/IV and do the Decryption using the 
                //function that accepts byte arrays. 
                // Using PasswordDeriveBytes object we are first getting
                // 32 bytes for the Key 
                // (the default Rijndael key length is 256bit = 32bytes)
                // and then 16 bytes for the IV. 
                // IV should always be the block size, which is by default
                // 16 bytes (128 bit) for Rijndael. 
                // If you are using DES/TripleDES/RC2 the block size is
                // 8 bytes and so should be the IV size. 

                // You can also read KeySize/BlockSize properties off the
                // algorithm to find out the sizes. 
                return Decrypt(cipherData, pdb.GetBytes(32), pdb.GetBytes(16));

            }
            catch (Exception)
            {

                throw;
            }

        }

        // Decrypt a file into another file using a password 
        //
        public static void Decrypt(string fileIn, string fileOut, string password)
        {
            try
            {
                // First we are going to open the file streams 
                FileStream fsIn = new FileStream(fileIn,
                            FileMode.Open, FileAccess.Read);
                FileStream fsOut = new FileStream(fileOut,
                            FileMode.OpenOrCreate, FileAccess.Write);

                // Then we are going to derive a Key and an IV from
                // the Password and create an algorithm 
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(password,
                    new byte[] {0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 
            0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
                Rijndael alg = Rijndael.Create();

                alg.Key = pdb.GetBytes(32);
                alg.IV = pdb.GetBytes(16);

                // Now create a crypto stream through which we are going
                // to be pumping data. 
                // Our fileOut is going to be receiving the Decrypted bytes. 
                CryptoStream cs = new CryptoStream(fsOut,
                    alg.CreateDecryptor(), CryptoStreamMode.Write);

                // Now will will initialize a buffer and will be 
                // processing the input file in chunks. 
                // This is done to avoid reading the whole file (which can be
                // huge) into memory. 
                int bufferLen = 4096;
                byte[] buffer = new byte[bufferLen];
                int bytesRead;

                do
                {
                    // read a chunk of data from the input file 
                    bytesRead = fsIn.Read(buffer, 0, bufferLen);

                    // Decrypt it 
                    cs.Write(buffer, 0, bytesRead);

                } while (bytesRead != 0);

                // close everything 
                cs.Close(); // this will also close the unrelying fsOut stream 
                fsIn.Close();

            }
            catch (Exception)
            {

                throw;
            }


        }

      
     
        public static string ValidateDate(string date)
        {
            if (ValidateStringValue(date))
            {
                return date;

            }
            else
                return "00000000";
        }
        
      




    }

    public class CommonProperty
    {
      
        public enum IsSuccess
        {
            Success,
            NoSuccess,
            Error,
            SomthingWrong

        }
       

    }

}
