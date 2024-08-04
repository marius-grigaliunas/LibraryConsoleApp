using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Simple Book collection storing class
/// </summary>
namespace LibraryExe
{
    public sealed class BookRegister
    {
        private List<Book> Books;

        public BookRegister()
        {
            Books = new List<Book>();
        }

        private void AddBook(Book data)
        {
            Book book = Books.Find(x => x.ISBN == data.ISBN);

            if (Books.Contains(book))
            {
                book.Count += 1;
            }
            else
                Books.Add(data);
        }

        public void AddBookToCollection(string path)
        {
            Book data = InOut.ReadBook(path);
            AddBook(data);
        }

        public List<Book> GetBooks()
        {
            return Books;
        }

        private Book FindBook(string data)
        {
            Book book = Books.Find(x => x.Name == data);

            return book;
        }
        
        public bool CheckIfAvailable(string data)
        {
            Book book = FindBook(data);
            if(Books.Contains(book) == true)
                if (book.Taken == false && book.Count > book.TakenCount )
                    return true;
            return false;

        }

        public bool CheckIfExists(string data)
        {
            Book book = FindBook(data);

            if (Books.Contains(book))
                return true;

            return false;
        }

        public int CheckCount(string data)
        {
            int count = 0;

            Book book = FindBook(data);
            if (Books.Contains(book) == true)
                count = book.Count;

            return count;    
        }

        public void SetBookToTaken(string data, DateTime whenTaken)
        {
            Book book = FindBook(data);

            if (book.TakenCount < book.Count-1)
            {
                book.TakenCount++;
            }
            else
            {
                book.Taken = true;
                book.TakenCount++;
            }
                

            book.WhenTaken = whenTaken;
        }

        public void SetBookToReturned(string data, DateTime whenReturned)
        {
            Book book = FindBook(data);

            if (book.TakenCount >= book.Count)
            {
                book.TakenCount--;
                book.Taken = false;
            }
            else
                book.TakenCount--;

            book.WhenReturned = whenReturned;
        }

        public void ReduceCount(string data)
        {
            Book book = FindBook(data);

            book.Count--;
        }

        public void RemoveFromLibrary(string data)
        {
            Book book = FindBook(data);

            if (Books.Contains(book) == true)
                if(book.Count > 0)
                Books.Remove(book);
            else
                Console.WriteLine("This book isn't in this library");
        }

        public int CalculateTime(string data)
        {
            Book book = FindBook(data);

            TimeSpan time = book.WhenReturned - book.WhenTaken;

            return time.Days;
        }



    }
}
