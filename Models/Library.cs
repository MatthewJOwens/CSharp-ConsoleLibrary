using console_library.Models;
using System;
using System.Collections.Generic;

namespace console_library
{
  public class Library
  {

    private List<Book> Books { get; set; } = new List<Book>();

    public void PrintBooks()
    {
      Console.WriteLine("Available books:");
      for (int i = 0; i < Books.Count; i++)
      {
        Console.WriteLine($"{i + 1}) {Books[i].Title} - {Books[i].Author}");
      }
      Console.WriteLine("Select a book number to check out. Or (Q)uit or (R)eturn a book.");
      string selection = Console.ReadLine();
      int index;
      if (int.TryParse(selection, out index) != false && Books[index] != null && Books[index].Available == true)
      {
        BorrowBook(index);
      }
      else
      {
        switch (selection.ToLower())
        {
          case "q":
          case "quit":
            break;
          case "r":
          case "return":
            break;
          default:
            Console.WriteLine("Invalid selection.");
            break;
        }
      }
    }
    public void AddBook(Book book)
    {
      Books.Add(book);
    }
    public void BorrowBook(int i)
    {
      Books[i - 1].Available = false;
    }
  }
}