using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class Stream
    {
        public string Read(string fileName, bool gzip = false, bool crypt = false)
        {
            string result = "";
            string filePath = @"C:\Users\puiac\Desktop\MyProjects\GitProjects\JuniorMindProjects\Json.Start\DataCollectionsImp\" + fileName;
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    result += line;
                }
            }

            if (!gzip)
            {
                GzipFile(filePath);
            }
            else
            {
                UnGzipFile(filePath);
            }

            if (!crypt)
            {
                EncryptString(result);
            }
            else
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(result);
                result = DecryptString(byteArray);
            }

            return result;
        } 

        public void Write(string text, bool gzip = false, bool crypt = false)
        {
            string filePath = @"C:\Users\puiac\Desktop\MyProjects\GitProjects\JuniorMindProjects\Json.Start\DataCollectionsImp\output.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(text);
            }
        }

        static byte[] EncryptString(string plainText)
        {
            byte[] Key = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            byte[] IV = new byte[] { 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80 };
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException("plainText");
            }
            if (Key == null || Key.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }
            if (IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException("IV");
            }
            byte[] encrypted;
            using (Aes encodeAlg = Aes.Create())
            {
                encodeAlg.Key = Key;
                encodeAlg.IV = IV;

                ICryptoTransform encryptor = encodeAlg.CreateEncryptor(encodeAlg.Key, encodeAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }

        static string DecryptString(byte[] cipherText)
        {
            byte[] Key = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            byte[] IV = new byte[] { 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80 };
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException("cipherText");
            }
            if (Key == null || Key.Length <= 0)
            {
                throw new ArgumentNullException("Key");
            }
            if (IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException("IV");
            }

            string plaintext = "";

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        private static void GzipFile(string filePath)
        {
            using FileStream originalFileStream = File.Open(filePath, FileMode.Open);
            using FileStream compressedFileStream = File.Create(filePath);
            using var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress);
            originalFileStream.CopyTo(compressor);
        }

        private static void UnGzipFile(string filePath)
        {
            using FileStream compressedFileStream = File.Open(filePath, FileMode.Open);
            using FileStream outputFileStream = File.Create(filePath);
            using var decompressor = new GZipStream(compressedFileStream, CompressionMode.Decompress);
            decompressor.CopyTo(outputFileStream);
        }
    }
}
