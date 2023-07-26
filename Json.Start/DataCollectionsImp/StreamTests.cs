using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            testStream.Write(path, message, gzip: false, crypt: false);
            string decryptedMessage = testStream.Read(path, gzip: false, crypt: false);

            Assert.Equal(message, decryptedMessage);
        }

        [Fact]
        public void WriteAndRead_Crypt_UnZipped_ShouldReturnTrue()
        {
            Stream testStream = new Stream();
            string path = @"C:\Users\puiac\Desktop\MyProjects\GitProjects\JuniorMindProjects\Json.Start\DataCollectionsImp\input.txt";
            string message = "Reading from input txt!";
            testStream.Write(path, message, gzip: false, crypt: true);
            string decryptedMessage = testStream.Read(path, gzip: false, crypt: true);

            Assert.Equal(message, decryptedMessage);
        }

        [Fact]
        public void WriteAndRead_UnCrypt_Zipped_ShouldReturnTrue()
        {
            Stream testStream = new Stream();
            string path = @"C:\Users\puiac\Desktop\MyProjects\GitProjects\JuniorMindProjects\Json.Start\DataCollectionsImp\output.txt";
            string zipPath = path + ".zip";
            string message = "Reading from input txt!";
            testStream.Write(path, message, gzip: true, crypt: false);
            string decryptedMessage = testStream.Read(zipPath, gzip: true, crypt: false);

            Assert.Equal(message, decryptedMessage);
        }


        [Fact]
        public void WriteAndRead_Crypt_Zipped_ShouldReturnTrue()
        {
            Stream testStream = new Stream();
            string path = @"C:\Users\puiac\Desktop\MyProjects\GitProjects\JuniorMindProjects\Json.Start\DataCollectionsImp\input.txt";
            string zipPath = path + ".zip";
            string message = "Reading from input txt!";
            testStream.Write(path, message, gzip: true, crypt: true);
            string decryptedMessage = testStream.Read(zipPath, gzip: true, crypt: true);

            Assert.Equal(message, decryptedMessage);
        }
    }
}
