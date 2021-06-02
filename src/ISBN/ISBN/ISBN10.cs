using System;

namespace ISBN
{
    /// <summary>
    /// Represents a 10 digit ISBN.
    /// </summary>
    public class ISBN10 : IISBN
    {
        /// <summary>
        /// Gets the 10 digit ISBN.
        /// </summary>
        /// <value>The 10 digit ISBN.</value>
        public string ISBN { get; }

        /// <summary>
        /// Constructs a new instance of <see cref="ISBN10"/>.
        /// </summary>
        /// <param name="isbn">The 10 digit ISBN.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="isbn"/> is invalid.</exception>
        public ISBN10(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("null", nameof(isbn));
            if (isbn.Length != 10)
                throw new ArgumentException("length", nameof(isbn));

            ISBN = isbn;
            if (!CheckISBN())
                throw new ArgumentException("invalid", nameof(isbn));
        }

        /// <summary>
        /// Returns a <see cref="string"/> representation of this object.
        /// </summary>
        /// <returns>The <see cref="string"/> representation of this object.</returns>
        public override string ToString()
        {
            return $"{ISBN[0]}-{ISBN[1..4]}-{ISBN[5..8]}-{ISBN[9]}";
        }

        /// <summary>
        /// Determines whether <see cref="ISBN"/> is valid.
        /// </summary>
        /// <returns><see langword="true"/> if <see cref="ISBN"/> is valid, <see langword="false"/> otherwise.</returns>
        private bool CheckISBN()
        {
            var pos = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            var sum = 0;
            for (var i = 0; i < pos.Length; i++)
            {
                if (!char.IsNumber(ISBN, i) && ISBN[i] != 'X')
                    return false;
                sum += ISBN[i] == 'X' ? pos[i] * 10 : pos[i] * (ISBN[i] - '0');
            }
            return sum % 11 == 0;
        }
    }
}
