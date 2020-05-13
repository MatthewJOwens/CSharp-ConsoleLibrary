namespace console_library.Models
{
  public class Book
  {
    public Book(string title, string author)
    {
      Title = title;
      Author = author;
      Available = true;
    }
    //Properties
    public string Title { get; set; }
    public string Author { get; set; }
    public bool Available { get; set; }
  }
}