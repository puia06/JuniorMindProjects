using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionsImp
{
    public class StreamTests
    {
        [Fact]
        public void WriteAndRead_UnCrypt_UnZipped_ShouldReturnTrue()
        {
            Stream testStream = new Stream();
            string path = @"C:\Users\puiac\Desktop\MyProjects\GitProjects\JuniorMindProjects\Json.Start\DataCollectionsImp\input.txt";
            string message = "Reading from input txt!";
            (string key, string vector) = testStream.WritingMethod(path, message, gzip: false, crypt: false);
            string decryptedMessage = testStream.ReadingMethod(path, key, vector, gzip: false, crypt: false);

            Assert.Equal(message, decryptedMessage);
        }

        [Fact]
        public void WriteAndRead_UnCrypt_Zipped_ShouldReturnTrue()
        {
            Stream testStream = new Stream();
            string path = @"C:\Users\puiac\Desktop\MyProjects\GitProjects\JuniorMindProjects\Json.Start\DataCollectionsImp\input.txt";
            string message = "Reading from input txt!";
            (string key, string vector) = testStream.WritingMethod(path, message, gzip: true, crypt: false);
            string decryptedMessage = testStream.ReadingMethod(path, key, vector, gzip: true, crypt: false);

            Assert.Equal(message, decryptedMessage);
        }

        [Fact]
        public void WriteAndRead_Crypt_UnZipped_ShouldReturnTrue()
        {
            Stream testStream = new Stream();
            string path = @"C:\Users\puiac\Desktop\MyProjects\GitProjects\JuniorMindProjects\Json.Start\DataCollectionsImp\input.txt";
            string message = "Reading from input txt!";
            (string key, string vector) = testStream.WritingMethod(path, message, gzip: false, crypt: true);
            string decryptedMessage = testStream.ReadingMethod(path, key, vector, gzip: false, crypt: true);

            Assert.Equal(message, decryptedMessage);
        }

        [Fact]
        public void WriteAndRead_Crypt_Zipped_ShouldReturnTrue()
        {
            Stream testStream = new Stream();
            string path = @"C:\Users\puiac\Desktop\MyProjects\GitProjects\JuniorMindProjects\Json.Start\DataCollectionsImp\input.txt";
            string message = "Reading from input txt!";
            (string key, string vector) = testStream.WritingMethod(path, message, gzip: true, crypt: true);
            string decryptedMessage = testStream.ReadingMethod(path, key, vector, gzip: true, crypt: true);

            Assert.Equal(message, decryptedMessage);
        }

        /*
        [Fact]
        public void TestWriteRead()
        {
            Stream testStream = new Stream();
            string text = "Reading from input txt!";
            string path = @"C:\Users\puiac\Desktop\MyProjects\GitProjects\JuniorMindProjects\Json.Start\DataCollectionsImp\input.txt";
            testStream.Write(path, text);
            string result = testStream.Read(path);

            Assert.Equal(text, result);
        }

        [Fact]
        public void TestEncDec()
        {
            var text = "Encrypt/Decrypt test text";

            var encryptedText = Stream.EncryptDataWithAes(text, out string keyBase64, out string vectorBase64);

            var decryptedText = Stream.DecryptDataWithAes(encryptedText, keyBase64, vectorBase64);

            Assert.Equal(text, decryptedText);
        }

        [Fact]
        public void TestZipUnzip()
        {
            Stream testStream = new Stream();
            string text = "Reading from input txt!";
            string path = @"C:\Users\puiac\Desktop\MyProjects\GitProjects\JuniorMindProjects\Json.Start\DataCollectionsImp\input.txt";
            string pathZip = path + ".zip";
            string pathZipUnzip = pathZip + "_unzipped";
            testStream.Write(path, text);
            Stream.GzipFile(path);
            Stream.UnGzipFile(pathZip);
            string result = testStream.Read(pathZipUnzip);

            Assert.Equal(text, result);
        }
        */
    }
}
