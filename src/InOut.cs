using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace LibraryExe
{
    /// <summary>
    /// Class working with reading and prrinting objects
    /// </summary>
    static class InOut
    {
        /// <summary>
        /// Book read method from json file
        /// </summary>
        /// <param name="path"> path of the file</param>
        /// <returns>Book object with all properties</returns>
        public static Book ReadBook(string path)
        {
            using (StreamReader fileJSON = new StreamReader(path))
            {
                try
                {
                    //get a string of a JSON file
                    string rawJSON = fileJSON.ReadToEnd();

                    // convert JSON string to objects
                    Book book = JsonConvert.DeserializeObject<Book>(rawJSON);
                    return book;
                }
                catch (Exception)
                {
                    Console.WriteLine("Problem reading file at path: " + path);

                    return null;
                }
            }
        }

        /// <summary>
        /// User reading method for reading the name and lastname from console and putting them into an object
        /// </summary>
        /// <returns>User object</returns>
        public static User ReadUser()
        {
            string persString = Console.ReadLine();
            string[] person = persString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            User user = new User(person[0], person[1]);

            return user;
        }
        
        /// <summary>
        /// Book printing method
        /// </summary>
        /// <param name="bookRegister">book register object, where the list of books are stored</param>
        public static void PrintBooks(BookRegister bookRegister)
        {
            string dashes = new string('-', 165);

            Console.WriteLine(dashes);
            Console.WriteLine("| {0,-20} | {1,-20} | {2,-20} | {3,-20} | {4,-20} | {5,-20} | {6,-10} | {7,-10} |",
                "Name", "Author", "Category", "Language", "Publication Date", "ISBN", "Count", "Taken");
            Console.WriteLine(dashes);
            foreach (var book in bookRegister.GetBooks())
            {
                Console.WriteLine(book.ToString());
            }
            Console.WriteLine(dashes);
            Console.WriteLine();
        }

        /// <summary>
        /// book printing method after manipulations with linq
        /// </summary>
        /// <param name="books">IEnumerable object of type Book which is generated after Linq manioulations</param>
        public static void PrintBooks(IEnumerable<Book> books)
        {
            string dashes = new string('-', 165);

            Console.WriteLine(dashes);
            Console.WriteLine("| {0,-20} | {1,-20} | {2,-20} | {3,-20} | {4,-20} | {5,-20} | {6,-10} | {7,-10} |",
                            "Name", "Author", "Category", "Language", "Publication Date", "ISBN", "Count", "Taken");
            Console.WriteLine(dashes);
            foreach (var book in books)
            {
                Console.WriteLine(book.ToString());
            }
            Console.WriteLine(dashes);
            Console.WriteLine();
        }
    }
}
