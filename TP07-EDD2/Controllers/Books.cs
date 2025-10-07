using TP07_EDD2.Models;

namespace TP07_EDD2.Controllers;

public class Books
{
    private List<Book> Collection { get;} = new List<Book>();

    public void AddBook(Book book)
    {
        Collection.Add(book);
    }

    public Book? SearchBook(Book book)
    {
        return Collection.FirstOrDefault(b => b.Title == book.Title);
    }
}