using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LibraryExe
{
    /// <summary>
    /// simple class for more structured code
    /// </summary>
    class Library
    {
    
        public static void Check(string input, UserRegister userRegister, BookRegister bookRegister)
        {
            
            switch (input)
            {
                case "AddBook":
                    TaskUtils.AddBook(ref bookRegister);
                    break;
                case "TakeBook":
                    TaskUtils.TakeBook(ref bookRegister, ref userRegister);
                    break;
                case "ReturnBook":
                    Console.WriteLine("Please enter which book is being returned");
                    string returnedName = Console.ReadLine();
                    TaskUtils.ReturnBook(returnedName, ref bookRegister, ref userRegister);
                    break;
                case "ShowBooks":
                    Console.WriteLine("To show all books please enter AllBooks, to filter them please enter FilterBy(Your seleceted filter) (example: FilterByAuthor");
                    string filterInput = Console.ReadLine();
                    TaskUtils.ShowBooks(filterInput, bookRegister);
                    break;
                case "DeleteBook":
                    Console.WriteLine("Please enter the name of the book to remove:");
                    string removeName = Console.ReadLine();
                    TaskUtils.DeleteBook(removeName, ref bookRegister);
                    break;
                default:
                    break;
            }
        }
    }
}
