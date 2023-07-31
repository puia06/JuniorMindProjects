using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class GZipStreamDecorator : StreamDecorator
    {
        private GZipStream gzipStream;
        public GZipStreamDecorator(Stream stream) : base(stream)
        {
            gzipStream = new GZipStream(stream, CompressionMode.Compress);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            gzipStream.Write(buffer, offset, count);
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return gzipStream.Read(buffer, offset, count);
        }
    }
}