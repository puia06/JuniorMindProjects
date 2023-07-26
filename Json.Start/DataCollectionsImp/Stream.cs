using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class Stream
    {
        public string Read(string filePath, bool gzip = false, bool crypt = false)
        {
            string result = "";
            if (gzip)
            {
                UnGzipFile(filePath);
            }

            using (StreamReader reader = new StreamReader(filePath))
             {
                result = reader.ReadToEnd();

                if (crypt)
                {
                    result = DecryptString(result);
                }
            }

            return result;
        }

        public void Write(string filePath, string text, bool gzip = false, bool crypt = false)
        {
            if (crypt)
            {
                byte[] encryptedBytes = EncryptString(text);
                text = Encoding.UTF8.GetString(encryptedBytes); 
            }

            if (gzip)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (StreamWriter writer = new StreamWriter(ms))
                    {
                        writer.Write(text);
                    }

                    byte[] compressedData = ms.ToArray();
                    GzipFile(filePath);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(text);
                }
            }
   
        }

        static byte[] EncryptString(string plainText)
        {
            using (Aes encodeAlg = Aes.Create())
            {
                ICryptoTransform encryptor = encodeAlg.CreateEncryptor(encodeAlg.Key, encodeAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }

                       return msEncrypt.ToArray();
                    }
                }
            }
        }

        static string DecryptString(string cipherText)
        {
            byte[] cipherTextByte = Encoding.UTF8.GetBytes(cipherText);

            using (Aes aesAlg = Aes.Create())
            {
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherTextByte))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        private static void GzipFile(string filePath)
        {
            using (FileStream originalFileStream = File.Open(filePath, FileMode.Open))
            {
                using (FileStream compressedFileStream = File.Create(filePath + ".zip "))
                {
                    using (var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressor);
                    }
                }
            }
        }

        private static void UnGzipFile(string filePath)
        {
            string outputFilePath = filePath + "_unzipped";

            using (FileStream compressedFileStream = File.Open(filePath, FileMode.Open))
            {
                using (FileStream outputFileStream = File.Create(outputFilePath))
                {
                    using (var decompressor = new GZipStream(compressedFileStream, CompressionMode.Decompress))
                    {
                        decompressor.CopyTo(outputFileStream);
                    }
                }
            }
        }
    }
}
