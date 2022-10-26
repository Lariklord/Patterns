using Microsoft.EntityFrameworkCore;

using(IBook book = new BookStoreProxy())
{
    Page page = book.GetPage(1);
    Console.WriteLine(page.Text);

    Page page1 = book.GetPage(2);
    Console.WriteLine(page.Text);

    page = book.GetPage(1);
    Console.WriteLine(page.Text);
}
class Page
{
    public int Id { get; set; }
    public int Number { get; set; }
    public string Text { get; set; }
}

class PageContext:DbContext
{
    public DbSet<Page> Pages { get; set; }
}
interface IBook:IDisposable
{
    Page GetPage(int number);
}
class BookStore:IBook
{
    PageContext db;
    public BookStore()
    {
        db = new PageContext();
    }



    public Page GetPage(int number)
    {
        return db.Pages.FirstOrDefault(x => x.Number == number);
    }
    public void Dispose()
    {
        db.Dispose();
    }
}
class BookStoreProxy : IBook
{ 
    List<Page> pages;
    BookStore bookStore;
    public BookStoreProxy()
    {
        pages = new List<Page>();
    }
    public Page GetPage(int number)
    {
        Page page = pages.FirstOrDefault(x => x.Number == number);
        if(page==null)
        {
            if(bookStore==null)
            {
                bookStore = new BookStore();
            }
            page = bookStore.GetPage(number);
            pages.Add(page);
        }
        return page;
    }
    public void Dispose()
    {
        if (bookStore != null)
            bookStore.Dispose();
    }
}

