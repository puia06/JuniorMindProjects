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
        public void Reading_crypt_ShouldReturnText()
        {
            var test = new Stream();

            Assert.Equal("Reading from input txt!", test.Read("input.txt", false, true));
        }

        [Fact]
        public void Writing_ShouldReturnText()
        {
            var test = new Stream();
            string text = "Writing from StreamTests!";
            test.Write(text);
            Assert.Equal(text, test.Read("output.txt"));
        }
    }
}
