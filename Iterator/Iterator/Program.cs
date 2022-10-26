Reader reader = new Reader();
Library library1 = new Library();

reader.SeeBooks(library1);
class Reader
{
    public void SeeBooks(Library library)
    {
        IBookIterator iterator = library.CreateNumerator();
        while(iterator.HasNext())
        {
            Console.WriteLine(iterator.Next().Name);
        }
    }
}
class Book
{
    public string Name { get; set; }
}

interface IBookIterator
{
    bool HasNext();
    Book Next();
}
interface IBookNumerable
{
    IBookIterator CreateNumerator();
    int Count { get; }
    Book this[int index] { get; }
}
class Library:IBookNumerable
{
    private Book[] books;
    public Library()
    {
        books = new Book[]
        {
            new Book {Name="Война и мир" },
            new Book{Name="Отцы и дети" },
            new Book{Name="Вишнёвый сад" }
        };
    }
    public int Count { get { return books.Length; } }
    public Book this[int index]
    {
        get { return books[index]; }
    }
    public IBookIterator CreateNumerator()
    {
        return new LibraryNumerator(this);
    }
}
class LibraryNumerator:IBookIterator
{
    IBookNumerable aggregate;
    int index = 0;
    public LibraryNumerator(IBookNumerable bookNumerable)
    {
        aggregate = bookNumerable;
    }
    public bool HasNext()
    {
        return index < aggregate.Count;
    }
    public Book Next()
    {
        return aggregate[index++];
    }
}