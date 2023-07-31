using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class CryptoStreamDecorator : StreamDecorator
    {
        private CryptoStream cryptoStream;

        public CryptoStreamDecorator(Stream stream, byte[] key, byte[] iv) : base(stream)
        {
            Aes aesAlgorithm = Aes.Create();
            aesAlgorithm.Key = key;
            aesAlgorithm.IV = iv;

            cryptoStream = new CryptoStream(stream, aesAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            cryptoStream.Write(buffer, offset, count);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return cryptoStream.Read(buffer, offset, count);
        }
    }
}
