using System;
using console_library.Models;

namespace console_library
{
  class Program
  {
    static void Main(string[] args)
    {
      bool inLibrary = true;
      Console.WriteLine("Welcome to the library!");
      Book whereTheSidewalkEnds = new Book("Where the Sidewalk Ends", "Shel Silverstein");
      Book nameOfTheWind = new Book("Name of the Wind", "Patrick Rothfuss");
      Book houseOfChains = new Book("House of Chains", "Steven Erikson");
      Book gardensOfTheMoon = new Book("Gardens of the Moon", "Steven Erikson");
      Library myLibrary = new Library();
      myLibrary.AddBook(whereTheSidewalkEnds);
      myLibrary.AddBook(nameOfTheWind);
      myLibrary.AddBook(houseOfChains);
      myLibrary.AddBook(gardensOfTheMoon);
      while (inLibrary)
      {
        myLibrary.PrintBooks();
        string selection = Console.ReadLine();
        if (selection == "q" || selection == "quit")
        {
          inLibrary = false;
          continue;
        }
        else if (selection == "r" || selection == "return")
        {
          myLibrary.ReturnBooks();
          continue;
        }
        else
        {
          myLibrary.Checkout(selection);
        }
      }
    }
  }
}
