namespace AbstractionPolymorphismProject
{
    public class ChoiceTests
    {
        [Fact]
        public void Match_StartsWith_pattern_ShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );
            string test = "012";
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.Equal("12", result.RemainingText());
        }

        [Fact]
        public void Match_StartsWith_StartChar_ShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );
            string test = "12";
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.Equal("2", result.RemainingText());
        }

        [Fact]
        public void Match_StartsWith_EndChar_ShouldReturnTrue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );
            string test = "92";
            var result = digit.Match(test);

            Assert.True(result.Success());
            Assert.Equal("2", result.RemainingText());
        }

        [Fact]
        public void Match_StartsWith_InvalidChar_ShouldReturnFalse()
        {
            var digit = new Choice(
             new Character('0'),
             new Range('1', '9')
         );
            string test = "a9";
            var result = digit.Match(test);

            Assert.False(result.Success());
            Assert.Equal("a9", result.RemainingText());
        }

        [Fact]
        public void Match_NullString_ShouldReturnFalse()
        {
            var digit = new Choice(
                     new Character('0'),
                     new Range('1', '9')
                 );
            var result = digit.Match(null);

            Assert.False(result.Success());
            Assert.Equal(null, result.RemainingText());
        }

        [Fact]
        public void Match_EmptyString_ShouldReturnFalse()
        {
            var digit = new Choice(
                       new Character('0'),
                       new Range('1', '9')
                   );
            var result = digit.Match("");

            Assert.False(result.Success());
            Assert.Equal("", result.RemainingText());
        }

        [Fact]
        public void Match_ComplexChoiceObj_StartsWith_StartChar_Letters_ShouldReturnTrue()
        {
            var digit = new Choice(
                     new Character('0'),
                     new Range('1', '9')
                 );
            var hex = new Choice(
                     digit,
               new Choice(
                   new Range('a', 'f'),
                   new Range('A', 'F')
               )
            );
            string test = "a9";
            var result = hex.Match(test);

            Assert.True(result.Success());
            Assert.Equal("9", result.RemainingText());
        }

        [Fact]
        public void Match_ComplexChoiceObj_StartsWith_EndChar_Letters_ShouldReturnTrue()
        {
            var digit = new Choice(
                     new Character('0'),
                     new Range('1', '9')
                 );
            var hex = new Choice(
                     digit,
               new Choice(
                   new Range('a', 'f'),
                   new Range('A', 'F')
               )
            );
            string test = "f8";
            var result = hex.Match(test);

            Assert.True(result.Success());
            Assert.Equal("8", result.RemainingText());
        }

        [Fact]
        public void Match_ComplexChoiceObj_StartsWith_StartCharr_Letters_ShouldReturnTrue()
        {
            var digit = new Choice(
                     new Character('0'),
                     new Range('1', '9')
                 );
            var hex = new Choice(
                     digit,
               new Choice(
                   new Range('a', 'f'),
                   new Range('A', 'F')
               )
            );
            string test = "A9";
            var result = hex.Match(test);

            Assert.True(result.Success());
            Assert.Equal("9", result.RemainingText());
        }

        [Fact]
        public void Match_ComplexChoiceObj_StartsWith_EndCharr_Letters_ShouldReturnTrue()
        {
            var digit = new Choice(
                     new Character('0'),
                     new Range('1', '9')
                 );
            var hex = new Choice(
                     digit,
               new Choice(
                   new Range('a', 'f'),
                   new Range('A', 'F')
               )
            );
            string test = "F8";
            var result = hex.Match(test);

            Assert.True(result.Success());
            Assert.Equal("8", result.RemainingText());
        }

        [Fact]
        public void Match_ComplexChoiceObj_StartsWith_InvalidChar_ShouldReturnFalse()
        {
            var digit = new Choice(
                    new Character('0'),
                    new Range('1', '9')
                );
            var hex = new Choice(
                     digit,
               new Choice(
                   new Range('a', 'f'),
                   new Range('A', 'F')
               )
            );
            string test = "g8";
            var result = hex.Match(test);

            Assert.False(result.Success());
            Assert.Equal("g8", result.RemainingText());
        }

        [Fact]
        public void Match_ComplexChoiceObj_StartsWith_pattern_ShouldReturnTrue()
        {
            var digit = new Choice(
                    new Character('0'),
                    new Range('1', '9')
                );
            var hex = new Choice(
                     digit,
               new Choice(
                   new Range('a', 'f'),
                   new Range('A', 'F')
               )
            );
            string test = "0ab";
            var result = hex.Match(test);

            Assert.True(result.Success());
            Assert.Equal("ab", result.RemainingText());
        }


        [Fact]
        public void Match_ComplexChoiceObj_StartsWith_ValidChar_ShouldReturnTrue()
        {
            var digit = new Choice(
                    new Character('0'),
                    new Range('1', '9')
                );
            var hex = new Choice(
                     digit,
               new Choice(
                   new Range('a', 'f'),
                   new Range('A', 'F')
               )
            );
            string test = "abc";
            var result = hex.Match(test);

            Assert.True(result.Success());
            Assert.Equal("bc", result.RemainingText());
        }

        [Fact]
        public void Match_ComplexChoiceObj_AddNewArrayPattern_ShouldReturnTrue()
        {
            var value = new Choice(
      new String(),
      new Number(),
      new Text("true"),
      new Text("false"),
      new Text("null")
  );
            var wss = new Choice(new Text(""), new Character('\u0020'), new Character('\u000A'), new Character('\u000D'), new Character('\u0009'));
            var ws = new Choice(
             new Text(""),
             new Sequence(new Character('\u0020'), wss),
             new Sequence(new Character('\u000A'), wss),
             new Sequence(new Character('\u000D'), wss),
             new Sequence(new Character('\u0009'), wss)
         );
            var element = new Sequence(ws, value, ws);
            var elements = new Choice(new Sequence(element, new Character(','), new List(element, new Character(','))), element);
            var array = new Sequence(new Character('['),new Choice(ws, elements), new Character(']'));

            value.Add(array);

            var testJson = "[true, \"abc\"]"; 
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());

        }

        [Fact]
        public void Match_ComplexChoiceObj_AddNewObjectPattern_ShouldReturnTrue()
        {
            var value = new Choice(
      new String(),
      new Number(),
      new Text("true"),
      new Text("false"),
      new Text("null")
  );

            var stringg = new String();
            var ws = new Choice(new Text(""), new Character('\u0020'), new Character('\u000A'), new Character('\u000D'), new Character('\u0009'));
            var element = new Sequence(ws, value, ws);
            var member = new Sequence(ws, stringg, ws, new Character(':'), element);
            var members = new Choice(member, new Sequence(member, new Character(','), new List(member, new Character(','))));

            var objectt = new Sequence(new Character('{'), new Choice(ws, members), new Character('}'));

            value.Add(objectt);

            var testJson = " ";
            var result = value.Match(testJson);

            Assert.True(result.Success());
            Assert.Equal("", result.RemainingText());

        }
    }
}
