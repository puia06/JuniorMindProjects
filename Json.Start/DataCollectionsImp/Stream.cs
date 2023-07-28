using System.IO.Compression;
using System.Security.Cryptography;

namespace DataCollectionsImp
{
    public class Stream
    {
        public (string, string) WritingMethod(StreamWriter stream, string filePath, string text, bool gzip = false, bool crypt = false)
        {
            string key = "";
            string vector = "";
            if (crypt)
            {
                text = EncryptDataWithAes(text, out string keyBase64, out string vectorBase64);
                key = keyBase64;
                vector = vectorBase64;
            }

            Write(stream, text);

            if (gzip)
            {
                GzipFile(filePath);
            }

            return (key, vector);
        }

        public string ReadingMethod(StreamReader stream, string filePath, string key, string vector, bool gzip = false, bool crypt = false)
        {
            string result = "";
            if (gzip)
            {
                UnGzipFile(filePath + ".zip");
                result = Read(stream);
            }
            else
            {
                result = Read(stream);
            }

            if (crypt)
            {
                result = DecryptDataWithAes(result, key, vector);
            }

            return result;
        }


        private string Read(StreamReader stream)
        {
            string result = stream.ReadToEnd();
            stream.Close();

            return result;
        }

        private void Write(StreamWriter stream, string text)
        {
            stream.Write(text);
            stream.Close();
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
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                using (FileStream outputFileStream = File.Create(outputFilePath))
                {
                    using (var decompressor = new GZipStream(compressedFileStream, CompressionMode.Decompress))
                    {
                        decompressor.CopyTo(outputFileStream);
                    }
                }
            }
        }

        private static string DecryptDataWithAes(string cipherText, string keyBase64, string vectorBase64)
        {
            using (Aes aesAlgorithm = Aes.Create())
            {
                aesAlgorithm.Key = Convert.FromBase64String(keyBase64);
                aesAlgorithm.IV = Convert.FromBase64String(vectorBase64);


                ICryptoTransform decryptor = aesAlgorithm.CreateDecryptor();

                byte[] cipher = Convert.FromBase64String(cipherText);

                using (MemoryStream ms = new MemoryStream(cipher))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }

        public static string EncryptDataWithAes(string plainText, out string keyBase64, out string vectorBase64)
        {
            using (Aes aesAlgorithm = Aes.Create())
            {

                keyBase64 = Convert.ToBase64String(aesAlgorithm.Key);
                vectorBase64 = Convert.ToBase64String(aesAlgorithm.IV);
                ICryptoTransform encryptor = aesAlgorithm.CreateEncryptor();

                byte[] encryptedData;

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(plainText);
                        }
                        encryptedData = ms.ToArray();
                    }
                }

                return Convert.ToBase64String(encryptedData);
            }
        }
    }
}