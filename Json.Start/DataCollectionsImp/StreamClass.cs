using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace DataCollectionsImp
{
    public class StreamClass
    {
        public (string, string) WritingMethod(Stream stream, string text, bool gzip = false, bool crypt = false)
        {
            string key = "";
            string vector = "";

            if (crypt)
            {
                using (Aes aesAlgorithm = Aes.Create())
                {
                    key = Convert.ToBase64String(aesAlgorithm.Key);
                    vector = Convert.ToBase64String(aesAlgorithm.IV);
                    CryptoStreamDecorator cryptoStreamDecorator = new CryptoStreamDecorator(stream, aesAlgorithm.Key, aesAlgorithm.IV);
                    stream = cryptoStreamDecorator;
                }
            }

            if (gzip)
            {
                GZipStreamDecorator gzipStreamDecorator = new GZipStreamDecorator(stream);
                stream = gzipStreamDecorator;
            }

            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
            {
                writer.Write(text);
            }

            return (key, vector);
        }

        public string ReadingMethod(Stream stream, string key, string vector, bool gzip = false, bool crypt = false)
        {
            if (crypt)
            {
                using (Aes aesAlgorithm = Aes.Create())
                {
                    aesAlgorithm.Key = Convert.FromBase64String(key);
                    aesAlgorithm.IV = Convert.FromBase64String(vector);
                    CryptoStreamDecorator cryptoStreamDecorator = new CryptoStreamDecorator(stream, aesAlgorithm.Key, aesAlgorithm.IV);
                    stream = cryptoStreamDecorator;
                }
            }

            if (gzip)
            {
                GZipStreamDecorator gzipStreamDecorator = new GZipStreamDecorator(stream);
                stream = gzipStreamDecorator;
            }

            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
