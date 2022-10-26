using System.Collections;
namespace LendingLibrary.Interfaces{
    class Program{
        private static readonly Library library = new Library();
        private static readonly Backpack<Book> bookBag = new Backpack<Book>();
        static void Main(string[] args){
            //Books are loaded in and the user interface is displayed
            LoadBooks();
            UserInterface();
        }
        static void UserInterface(){
            while (true){
                // Options are presented to the user on what they can do
                Console.WriteLine("Welcome to the Lending Library!");
                Console.WriteLine("Pick an option, please.");
                Console.WriteLine("1. View All Books");
                Console.WriteLine("2. Add New book");
                Console.WriteLine("3. Borrow a Book");
                Console.WriteLine("4. Return a Book");
                Console.WriteLine("5. View BookBag");
                Console.WriteLine("6. Exit");
                string answer = Console.ReadLine();
                switch(answer){
                    // Switch cases are used instead of if else statements because they are more efficient
                    // Each case brings a different response
                    case "1":
                    Console.Clear();
                    Console.WriteLine(" Library ");
                    Console.WriteLine("=========");
                    OutputBooks(library);
                    break;

                    case "2":
                    Console.Clear();
                    AddBook();
                    Console.Clear();
                    break;

                    case "3":
                    Console.Clear();
                    BorrowBook();
                    Console.Clear();
                    break;

                    case "4":
                    Console.Clear();
                    ReturnBook();
                    Console.Clear();
                    break;

                    case "5":
                    Console.Clear();
                    Console.WriteLine("=========");
                    OutputBooks(bookBag);
                    Console.Clear();
                    break;
                    
                    case "6":
                    return;

                    default:
                    Console.WriteLine("Incorrect. Please try again.");
                    break;
                }
            }
        }
        static void LoadBooks(){
            // Books are loaded into teh library to have default books already in
            library.Add("Alice in Wonderland", "Lewis", "Carol", 146);
            library.Add("The Great Gatsby", "F. Scott", "Fitzgerald", 218);
            library.Add("To Kill A Mockingbird", "Harper", "Lee", 281);
            library.Add("Lord of the Flies", "William", "Golding", 224);
            library.Add("(Percy Jackson)The Lightning Thief", "Rick", "Riordan", 384);
        }
        static void OutputBooks(IEnumerable<Book> books){
            int Counter = 1;
            // Each book is displayed on the console with its title and author
            foreach (Book book in books){
                Console.WriteLine($"{Counter++}. {book.Title}, by {book.Author.FirstName} {book.Author.LastName}");
            }
            Console.WriteLine();
        }
        private static void AddBook(){
            // The console prompts the user to add the title, author's first and last names
            // and the number of pages in the book
            Console.WriteLine("Please enter the following details:");
            Console.WriteLine("What's the title of the book?");
            string title = Console.ReadLine();
            Console.WriteLine("The author's first name?");
            string firstName = Console.ReadLine();
            Console.WriteLine("The author's last name?");
            string lastName = Console.ReadLine();
            Console.WriteLine("Number of pages?");
            int numberOfPages = Convert.ToInt32(Console.ReadLine());
            // The answers are then placed into their own book and added to the library
            library.Add(title, firstName, lastName, numberOfPages);
        }
        private static void BorrowBook(){
            // Each book in the library is printed out
            foreach (Book book in library){
                Console.WriteLine(book.Title);
            }
            Console.WriteLine();
            // Console prompts a response of which book is being requested
            Console.WriteLine("Which book would you like to borrow?");
            string selection = Console.ReadLine();
            // The book that matches the selection is moved out of the library
            // and into a container called bookBag
            Book borrowed = library.Borrow(selection);
            bookBag.Pack(borrowed);
        }
        static void ReturnBook(){
            //The book in the bookBag container are written out and
            // the user is asked which book is to be returned
            OutputBooks(bookBag);
            Console.WriteLine("Which book would you like to return?");
            int selection = Convert.ToInt32(Console.ReadLine());
            // The selected book is removed from the bookBag at the index of the selection - 1
            Book bookToReturn = bookBag.Unpack(selection - 1);
            Console.WriteLine("=======");
            Console.WriteLine($"{selection} has been returned to the library.");
            // Book is returned to the library
            library.Return(bookToReturn);
            Console.WriteLine("Thank you! Have a great day!");
        }
    }
}