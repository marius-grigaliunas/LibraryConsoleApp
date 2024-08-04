using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExe
{
    /// <summary>
    /// Data clas for the book object
    /// </summary>
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ISBN { get; set; }
        public bool Taken { get; set; }
        public int Count { get; set; }
        public int TakenCount { get; set; }
        public DateTime WhenTaken { get; set; }
        public DateTime WhenReturned { get; set; }


        public Book(string name, string author, string category, string language, DateTime publicationDate, string isbn)
        {
            this.Name = name;
            this.Author = author;
            this.Category = category;
            this.Language = language;
            this.PublicationDate = publicationDate;
            this.ISBN = isbn;
            this.Taken = false;
            this.Count = 1;
        }

        public override string ToString()
        {
            return String.Format("| {0,-20} | {1,-20} | {2,-20} | {3,-20} | {4,20:yyyy-MM-dd} | {5,20} | {6,10} | {7,10} |",
                this.Name, this.Author, this.Category, this.Language, this.PublicationDate, this.ISBN, this.Count, this.TakenCount);
        }

    }
}
