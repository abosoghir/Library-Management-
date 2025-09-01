using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class Book
    {
        public int ID;
        public string Name;
        public int Qunatity;
        List<string> users;
        public int Totalborrowed;
        public Book()
        {
            ID = Qunatity = 0;
            Name = string.Empty;
            users = new List<string>();
            Totalborrowed = 0;
        }

        public void Add_Book()
        {
            Console.WriteLine("Enter the ID ");
            ID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Name ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter the Qunatity ");
            Qunatity= int.Parse(Console.ReadLine());
        }
        public bool Search_Book(string s)
        {
            if(s.Length >Name.Length) 
                return false;
            for(int i=0;i<s.Length;i++)
            {
                if (s[i] != Name[i])
                    return false;
            }
            return true;
        }
        public void Who_Borrow_Book(string s)
        {
            users.Add(s);
        }
        public bool Borrow(int id)
        {
            if(Totalborrowed >= Qunatity)
                return false;
            else
            {
                Totalborrowed++;
                return true;
            }
        }
        public void Return(int idbook)
        {
            Totalborrowed--;
        }
        public void Print()
        {
            Console.WriteLine($"id = {ID} name = {Name} total_quantity {Qunatity} total_borrowed {Totalborrowed}");
        }


    }
}
