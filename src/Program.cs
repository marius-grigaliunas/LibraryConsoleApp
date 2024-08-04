using System;
using System.IO;
using System.Linq;

namespace LibraryExe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 200;

            Console.WriteLine("Library application in a console");
            Console.WriteLine(new string('-', 32));

            bool endApp = false;

            BookRegister bookRegister = new BookRegister();
            UserRegister userRegister = new UserRegister();

            Console.WriteLine("Hello");
            Console.WriteLine("To add a book please write " + '"' + "AddBook" + '"' + '.');
            Console.WriteLine("To take a book from the library please write " + '"' + "TakeBook" + '"' + '.');
            Console.WriteLine("To return a book to the library please write " + '"' + "ReturnBook" + '"' + '.');
            Console.WriteLine("To list all books or filter them, please write " + '"' + "ShowBooks" + '"' + '.');
            Console.WriteLine("To remove a book from the library, pelase write " + '"' + "DeleteBook" + '"' + '.');
            Console.WriteLine("To close the application please write " + '"' + "End" + '"' + '.');
            Console.WriteLine("Note*: please write the commands without the parenthesees");
            Console.WriteLine();
            

            //books added for testing from custom made json file Data.json
            //bookRegister.AddBookToCollection(@"Data/Data.json");
            //bookRegister.AddBookToCollection(@"Data/Data.json");
            //bookRegister.AddBookToCollection(@"Data/Data.json");
            //bookRegister.AddBookToCollection(@"Data/Data.json");
            //bookRegister.AddBookToCollection(@"Data/Data.json");

            while (!endApp)
            {
                Console.WriteLine("Your input: ");
                string input = Console.ReadLine();

                Library.Check(input, userRegister, bookRegister);

                if (input == "End") endApp = true;
            }
        }
    }
}
