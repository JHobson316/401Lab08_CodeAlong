using System.Collections;
namespace LendingLibrary.Interfaces
{
    public interface ILibrary : IReadOnlyCollection<Book>
    {
        /// <summary>
        /// Add a Book to the library.
        /// </summary>
        void Add(string title, string firstName, string lastName, int numberOfPages);

        /// <summary>
        /// Remove a Book from the library with the given title.
        /// </summary>
        /// <returns>The Book, or null if not found.</returns>
        Book Borrow(string title);

        /// <summary>
        /// Return a Book to the library.
        /// </summary>
        void Return(Book book);
    }

    public class Library : ILibrary
    {
        private readonly Dictionary<string, Book> books = new Dictionary<string, Book>();
        public int Count => books.Count; // Counts how many books are in our library
        public void Add(string title, string firstName, string lastName, int numberOfPages){
            Book book = new Book{
                Title = title,
                Author = new Author{
                    FirstName = firstName,
                    LastName = lastName,
                },
            NumberOfPages = numberOfPages,
        };
        books.Add(title, book);
        }
        public Book Borrow(string title){
            if(!books.ContainsKey(title)){
                return null;
            }
            Book book = books[title];
            books.Remove(title);
            return book;
        }
        public void Return(Book book){
            books.Add(book.Title, book);
        }
        public IEnumerator<Book> GetEnumerator(){
            foreach (Book book in books.Values)
            yield return book;
        }
        IEnumerator IEnumerable.GetEnumerator(){
            return GetEnumerator();
        }
    
    }
    
}