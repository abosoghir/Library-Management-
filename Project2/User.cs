using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class User
    {
        public int Id;
        public string Name;
        List<int> bookborrow;
        public User()
        {
            Id = 0;
            Name = string.Empty;
            bookborrow = new List<int>();
        }
        public void Add_User()
        {
            Console.WriteLine("Enter the ID ");
            Id= int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Name");
            Name = Console.ReadLine();
        }
        public void Print_User()
        {
            Console.Write($"User {Name} ID {Id} borrowed books ids : ");
            foreach (int i in bookborrow)
            {
                Console.Write(i);
                Console.WriteLine(" ");
            }
            Console.WriteLine();
        }
        public void Borrow_Book(int idbook)
        {
            bookborrow.Add(idbook);
        }
        public void Return_Book(int id)
        {
            if(bookborrow.Contains(id))
            bookborrow.Remove(id);
            else
                Console.WriteLine($"the user {Name} not borrow the book {id}");
        }
        public bool IsBorrowed(int bookId)
        {
            return bookborrow.Contains(bookId);
        }

    }
}
