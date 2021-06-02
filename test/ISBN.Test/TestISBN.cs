using System;
using Xunit;
using ISBN;

namespace ISBN.Test
{
    /// <summary>
    /// Tests <see cref="ISBN10"/> and <see cref="ISBN13"/>.
    /// </summary>
    public class TestISBN
    {
        /// <summary>
        /// Tests good ISBN numbers.
        /// </summary>
        [Fact]
        public void TestGoodISBN()
        {
            _ = new ISBN10("0205080057");
            _ = new ISBN10("0716703440");
            _ = new ISBN10("013603599X");
            _ = new ISBN13("9780136006176");
            _ = new ISBN13("9780495011606");
        }

        /// <summary>
        /// Tests bad ISBN numbers.
        /// </summary>
        [Fact]
        public void TestBadISBN()
        {
            Assert.Throws<ArgumentException>(() => new ISBN10(""));
            Assert.Throws<ArgumentException>(() => new ISBN10(null));
            Assert.Throws<ArgumentException>(() => new ISBN10("1231231231"));
            Assert.Throws<ArgumentException>(() => new ISBN13(""));
            Assert.Throws<ArgumentException>(() => new ISBN13(null));
            Assert.Throws<ArgumentException>(() => new ISBN13("1231231231231"));
        }
    }
}
