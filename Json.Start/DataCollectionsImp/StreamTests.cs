namespace DataCollectionsImp
{
    public class StreamTests
    {
        [Fact]
        public void WriteAndRead_UnCrypt_UnZipped_ShouldReturnTrue()
        {
            Stream testStream = new Stream();
            string path = Path.GetFullPath("input.txt");
            string message = "Reading from input txt!";
            (string key, string vector) = testStream.WritingMethod(new StreamWriter(path), path, message, gzip: false, crypt: false);
            string decryptedMessage = testStream.ReadingMethod(new StreamReader(path), path, key, vector, gzip: false, crypt: false);

            Assert.Equal(message, decryptedMessage);
        }

        [Fact]
        public void WriteAndRead_UnCrypt_Zipped_ShouldReturnTrue()
        {
            Stream testStream = new Stream();
            string path = Path.GetFullPath("input.txt");
            string message = "Reading from input txt!";
            (string key, string vector) = testStream.WritingMethod(new StreamWriter(path), path, message, gzip: true, crypt: false);
            string decryptedMessage = testStream.ReadingMethod(new StreamReader(path + ".zip" + "_unzipped"), path, key, vector, gzip: true, crypt: false);

            Assert.Equal(message, decryptedMessage);
        }

        [Fact]
        public void WriteAndRead_Crypt_UnZipped_ShouldReturnTrue()
        {
            Stream testStream = new Stream();
            string path = Path.GetFullPath("input.txt");
            string message = "Reading from input txt!";
            (string key, string vector) = testStream.WritingMethod(new StreamWriter(path), path, message, gzip: false, crypt: true);
            string decryptedMessage = testStream.ReadingMethod(new StreamReader(path), path, key, vector, gzip: false, crypt: true);

            Assert.Equal(message, decryptedMessage);
        }

        [Fact]
        public void WriteAndRead_Crypt_Zipped_ShouldReturnTrue()
        {
            Stream testStream = new Stream();
            string path = Path.GetFullPath("input.txt");
            string message = "Reading from input txt!";
            (string key, string vector) = testStream.WritingMethod(new StreamWriter(path), path, message, gzip: true, crypt: true);
            string decryptedMessage = testStream.ReadingMethod(new StreamReader(path), path, key, vector, gzip: true, crypt: true);

            Assert.Equal(message, decryptedMessage);
        }
    }
}
