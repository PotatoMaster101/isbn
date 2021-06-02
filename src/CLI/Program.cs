using System;
using ISBN;

namespace CLI
{
    /// <summary>
    /// Entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">Arguments from CLI.</param>
        static void Main(string[] args)
        {
            if (args.Length == 0)
                Console.Error.WriteLine("ERROR: no ISBN provided");
            
            foreach (var isbn in args)
            {
                var nums = isbn.Replace("-", string.Empty);
                if (ProcessISBN(nums) is null)
                    Console.WriteLine($"{isbn}: bad");
                else
                    Console.WriteLine($"{isbn}: good");
            }
        }

        /// <summary>
        /// Processes the specified ISBN.
        /// </summary>
        /// <param name="isbn">The ISBN to process.</param>
        /// <returns>The <see cref="IISBN"/> generated.</returns>
        static IISBN ProcessISBN(string isbn)
        {
            IISBN ret = null;
            try
            {
                if (isbn.Length == 10)
                    ret = new ISBN10(isbn);
                else if (isbn.Length == 13)
                    ret = new ISBN13(isbn);
            }
            catch { }   // don't care
            return ret;
        }
    }
}
