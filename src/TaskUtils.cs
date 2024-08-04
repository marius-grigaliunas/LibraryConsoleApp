using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryExe
{
    /// <summary>
    /// Simple Task class for more structured code
    /// </summary>
    public static class TaskUtils
    {
        /// <summary>
        /// book addition method
        /// </summary>
        /// <param name="bookRegister">wehere to add the book</param>
        public static void AddBook(ref BookRegister bookRegister)
        {
            Console.WriteLine("If you want to add bokk, a JSON data file, containing all inforamtion, should be in the Data folder");
            Console.WriteLine("Write the name of the file(with extension)");
            string path = @"Data/" + Console.ReadLine();
            if (File.Exists(path))
            {
                bookRegister.AddBookToCollection(path);
                Console.WriteLine("Addition succesful");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Error: there is no file named like that.");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Method for taking a bokk from a library
        /// </summary>
        /// <param name="bookRegister">book register, where all books are stored</param>
        /// <param name="userRegister">user register, where all users are stored, needed to check if user hasn't gone over limit</param>
        public static void TakeBook(ref BookRegister bookRegister, ref UserRegister userRegister)
        {
            Console.WriteLine("Please enter the Name and the Lastname of the person, who will take the book:");
            User user = InOut.ReadUser();

            if (userRegister.CheckIfExists(user) == true)
            {
                if (userRegister.GetUser(user).TakenBooks > 3)
                {
                    Console.WriteLine("Unfortunately this person has taken 3 books, so he cannot take more");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Enter the name of the book, which will be taken");
                    string wantedBook = Console.ReadLine();

                    if (bookRegister.CheckIfAvailable(wantedBook) == true)
                    {
                        Console.WriteLine("Enter how long the book will be taken in days");
                        int howLong = int.Parse(Console.ReadLine());

                        if (howLong > 60)
                        {
                            Console.WriteLine("Unfortunately we can't lend our books for longer than 60 days");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Enter the full date when the book was taken (YYYY-MM-DD)");
                            DateTime dateWhenTaken = DateTime.Parse(Console.ReadLine());

                            userRegister.GetUser(user).TakenBooks += 1;
                            bookRegister.SetBookToTaken(wantedBook, dateWhenTaken);

                            Console.WriteLine("Person has successfully taken this book!");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Unfortunately we don't have this book or it is currently taken");
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                userRegister.AddUsersToRegister(user);
                Console.WriteLine("Enter the name of the book, which will be taken");
                string wantedBook = Console.ReadLine();

                if (bookRegister.CheckIfAvailable(wantedBook) == true)
                {
                    Console.WriteLine("Enter how long the book will be taken in days");
                    int howLong = int.Parse(Console.ReadLine());

                    if (howLong > 60)
                    {
                        Console.WriteLine("Unfortunately we can't lend our books for longer than 60 days");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Enter the full date when the book was taken (YYYY-MM-DD)");
                        DateTime dateWhenTaken = DateTime.Parse(Console.ReadLine());

                        userRegister.GetUser(user).TakenBooks += 1;
                        bookRegister.SetBookToTaken(wantedBook, dateWhenTaken);

                        Console.WriteLine("Person has successfully taken this book!");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Unfortunately we don't have this book or it is currently taken");
                    Console.WriteLine();
                }   
            }
        }

        /// <summary>
        /// Method for returnig a method
        /// </summary>
        /// <param name="name">name of the returned book</param>
        /// <param name="bookRegister">book register to check if the book was in our library, and store to it if it was from our library</param>
        /// <param name="userRegister">user register to check if this user is registered in our user register, and to reduce his taken book count</param>
        public static void ReturnBook(string name, ref BookRegister bookRegister, ref UserRegister userRegister)
        {
            if (bookRegister.CheckIfExists(name) == true)
            {
                Console.WriteLine("Please enter the name of the person who is returning the book");
                User user = InOut.ReadUser();

                if (userRegister.CheckIfExists(user) == true)
                {
                    Console.WriteLine("Please enter the date when the book is being returned (YYYY-MM-DD):");
                    DateTime dateWhenReturned = DateTime.Parse(Console.ReadLine());

                    userRegister.GetUser(user).TakenBooks--;
                    bookRegister.SetBookToReturned(name, dateWhenReturned);

                    if (bookRegister.CalculateTime(name) > 60)
                        Console.WriteLine("If I would get a nickel everytime someone returns the book late, I'd be tired of all the waiting:)");

                    Console.WriteLine("This person has returned the book successfully!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Unfortunately this person isn't registered in our UserBase");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Unfortunately this book isn't registered in our Book dataBase");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Method for deleting one instance of the book or all of the instances
        /// </summary>
        /// <param name="name">name of the book</param>
        /// <param name="bookRegister">book register whwere the book is stored</param>
        public static void DeleteBook(string name, ref BookRegister bookRegister)
        {
            if (bookRegister.CheckCount(name) > 1)
            {
                Console.WriteLine("Detected multiple instances of the book in the library, write Remove to remove one, write RemoveAll to remove all instances of this book.");
                string removal = Console.ReadLine();

                switch (removal)
                {
                    case "Remove":
                        bookRegister.ReduceCount(name);
                        Console.WriteLine("One book with the name of " + '"' + name + '"' + " had been removed successfully!");
                        Console.WriteLine();
                        break;
                    case "RemoveAll":
                        bookRegister.RemoveFromLibrary(name);
                        Console.WriteLine("All books with the name of " + '"' + name + '"' + " had been removed successfully!");
                        Console.WriteLine();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                bookRegister.RemoveFromLibrary(name);
                Console.WriteLine("Book removed successfully!");
            }
        }

        /// <summary>
        /// Method for filtering or just printing books
        /// </summary>
        /// <param name="input">Command from the app user</param>
        /// <param name="bookRegister">which register books to show or filter</param>
        public static void ShowBooks(string input, BookRegister bookRegister)
        {
            switch (input)
            {
                case "AllBooks":
                    InOut.PrintBooks(bookRegister);
                    break;
                case "FilterByAuthor":
                    Console.WriteLine("Please enter the author");
                    string author = Console.ReadLine();

                    var byAuthor = from book in bookRegister.GetBooks()
                                where book.Author == author
                                select book;

                    InOut.PrintBooks(byAuthor);
                    break;
                case "FilterByCategory":
                    Console.WriteLine("Please enter the category");
                    string category = Console.ReadLine();
                    var byCategory = from book in bookRegister.GetBooks()
                                 where book.Category == category
                                 select book;

                    InOut.PrintBooks(byCategory);
                    break;
                case "FilterByLanguage":
                    Console.WriteLine("Please enter the language");
                    string language = Console.ReadLine();
                    var byLanguage = from book in bookRegister.GetBooks()
                                 where book.Language == language
                                 select book;

                    InOut.PrintBooks(byLanguage);
                    break;
                case "FilterByName":
                    Console.WriteLine("Please enter the name");
                    string name = Console.ReadLine();
                    var byName = from book in bookRegister.GetBooks()
                                 where book.Name == name
                                 select book;

                    InOut.PrintBooks(byName);
                    break;
                case "FilterByAvailable":
                    var byTaken = from book in bookRegister.GetBooks()
                                 where book.Taken == false
                                 select book;

                    InOut.PrintBooks(byTaken);
                    break;
                case "FilterByTaken":
                    var byAvailable = from book in bookRegister.GetBooks()
                                 where book.Taken == true || book.TakenCount > 0
                                 select book;

                    InOut.PrintBooks(byAvailable);
                    break;
                default:
                    break;
            }
        }
    }
}
