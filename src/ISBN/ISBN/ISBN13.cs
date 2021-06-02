using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBN
{
    /// <summary>
    /// Represents a 13 digit ISBN.
    /// </summary>
    public class ISBN13 : IISBN
    {
        /// <summary>
        /// Gets the 13 digit ISBN.
        /// </summary>
        /// <value>The 13 digit ISBN.</value>
        public string ISBN { get; }

        /// <summary>
        /// Constructs a new instance of <see cref="ISBN13"/>.
        /// </summary>
        /// <param name="isbn">The 10 digit ISBN.</param>
        /// <exception cref="ArgumentException">Thrown when <paramref name="isbn"/> is invalid.</exception>
        public ISBN13(string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("null", nameof(isbn));
            if (isbn.Length != 13)
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
            return $"{ISBN[0..2]}-{ISBN[3]}-{ISBN[4..7]}-{ISBN[9..11]}-{ISBN[12]}";
        }

        /// <summary>
        /// Determines whether <see cref="ISBN"/> is valid.
        /// </summary>
        /// <returns><see langword="true"/> if <see cref="ISBN"/> is valid, <see langword="false"/> otherwise.</returns>
        private bool CheckISBN()
        {
            var nums = new int[] { 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1, 3, 1 };
            var sum = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (!char.IsNumber(ISBN, i))
                    return false;
                sum += nums[i] * (ISBN[i] - '0');
            }
            return sum % 10 == 0;
        }
    }
}
