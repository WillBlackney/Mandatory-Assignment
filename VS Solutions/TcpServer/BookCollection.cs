using Book_Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace TcpServer
{
    public static class BookCollection
    {
        public static List<Book> books;

        public static void PopulateCollection()
        {
            books = new List<Book>()
            {
            new Book("Mein Kampf", "Adolf Hitler", "0000000000001", 52),
            new Book("Animal Farm", "George Orwell", "0000000000002", 183),
            new Book("American Psycho", "Brett Easton Ellis", "0000000000003", 220),
            new Book("A Brief History Of Time", "Steven Hawking", "0000000000004", 279),
            new Book("Origin Of Species", "Charles Darwin", "0000000000005", 312)
            };
        }
    }
}
