using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
 
        class Books
        {
            public string BookName;
            public string AuthorName;

            public Books(string bookName, string authorName)
            {
                BookName = bookName;
                AuthorName = authorName;
            }

            public void Display()
            {
                Console.WriteLine("Book Name: {0}", BookName);
                Console.WriteLine("Author Name: {0}", AuthorName);
            }
        }

        class BookShelf
        {
            private Books[] bookArray = new Books[3];

            public Books this[int index]
            {
                get { return bookArray[index]; }
                set { bookArray[index] = value; }
            }

            public void DisplayBooks()
            {
                for (int i = 0; i < bookArray.Length; i++)
                {
                    if (bookArray[i] != null)
                    {
                        Console.WriteLine("Book {0}:", i + 1);
                        bookArray[i].Display();
                        Console.WriteLine();
                    }
                }
            }
        }

        class Question_1_Indexers
        {
            public static void Main()
            {
                BookShelf shelf = new BookShelf();
                shelf[0] = new Books("Mahabharat","Ved Vyas");
                shelf[1] = new Books("Ramayan", "Valmiki");
                shelf[2] = new Books("Bhagavad Gita", "Vyas Maharshi");
                Console.WriteLine("Displaying Books in the Shelf:");
                shelf.DisplayBooks();
                Console.Read();
            }
        }
}

