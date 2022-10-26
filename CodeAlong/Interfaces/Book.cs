namespace LendingLibrary.Interfaces{
    public class Book{
        public string Title {get; set;}
        public int NumberOfPages {get; set;}
        public Author Author {get; set;}
    }
    public class Author{
        public string FirstName {get;set;}
        public string LastName {get;set;}
    }
}