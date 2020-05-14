using console_library.Models;
using System;
using System.Collections.Generic;

namespace console_library
{
  public class Library
  {

    private List<Book> Books { get; set; } = new List<Book>();
    private List<Book> CheckedOut { get; set; } = new List<Book>();

    public void PrintBooks()
    {
      Console.Clear();
      Console.WriteLine("Available books:");
      for (int i = 0; i < Books.Count; i++)
      {
        Console.WriteLine($"{i + 1}) {Books[i].Title} - {Books[i].Author}");
      }
      Console.WriteLine("Select a book number to check out. Or (Q)uit or (R)eturn a book.");
    }
    public void AddBook(Book book)
    {
      Books.Add(book);
    }
    public void BorrowBook(int i)
    {
      Books[i].Available = false;
      CheckedOut.Add(Books[i]);
      Console.Clear();
      System.Console.WriteLine($"You checked out {Books[i].Title} by {Books[i].Author}");
      Books.RemoveAt(i);
    }
    private Book ValidateBook(int index, List<Book> booklist)
    {
      if (booklist[index] == null)
      {
        return null;
      }
      else
      {
        return booklist[index];
      }

    }
    public void Checkout(string selection)
    {
      int index;
      if (int.TryParse(selection, out index) != false && index <= Books.Count && index > 0)
      {
        index--; // reduce index by 1 to match array
        if (ValidateBook(index, Books) != null)
        {
          if (Books[index].Available == true)
          {
            BorrowBook(index);
          }
          else
          {
            Console.Clear();
            Console.WriteLine("That book is already checked out.");
            // continue;
          }
        }
        else
        {
          Console.Clear();
          Console.WriteLine("That is not a valid selection.");
        }
      }
      else
      {
        Console.Clear();
        Console.WriteLine("Invalid selection.");
      }
    }
    public void ReturnBooks()
    {
      bool inReturn = true;
      while (inReturn)
      {
        Console.Clear();
        Console.WriteLine("These are the currently checked out books:");
        for (int i = 0; i < CheckedOut.Count; i++)
        {
          Console.WriteLine($"{i + 1}) {CheckedOut[i].Title} - {CheckedOut[i].Author}");
        }
        Console.WriteLine("Select a book number to return. Or (Q)uit to go back");
        string selection = Console.ReadLine();

        if (selection == "q" || selection == "quit")
        {
          inReturn = false;
          continue;
        }
        else
        {
          int index;
          if (int.TryParse(selection, out index) != false)
          {
            index--;
            if (index > -1 && index < CheckedOut.Count)
            {
              Return(index);
              continue;
            }
          }
          else
          {
            Console.Clear();
            Console.WriteLine("Invalid Selection");
            continue;
          }
        }
      }
    }
    private void Return(int i)
    {
      CheckedOut[i].Available = true;
      Books.Add(CheckedOut[i]);
      Console.Clear();
      Console.WriteLine($"You returned {CheckedOut[i].Title} by {CheckedOut[i].Author}.");
      CheckedOut.RemoveAt(i);
    }
  }
}