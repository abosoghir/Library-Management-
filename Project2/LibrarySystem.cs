using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    internal class LibrarySystem
    {
        List<User> users;
        List<Book> books;
        public LibrarySystem()
        {
            users = new List<User>();
            books = new List<Book>();
        }

        public void Run()
        {
            while (true)
            {
                int choice = Menu();

                if (choice == 1) add_book();
                else if (choice == 2) search_books_by_prifix();
                else if (choice == 3) print_who_borrowed_book_by_name();
                else if (choice == 4) print_library_by_id();
                else if (choice == 5) print_library_by_name();
                else if (choice == 6) add_user();
                else if (choice == 7) user_borrow_book();
                else if (choice == 8) user_return_book();
                else if (choice == 9) print_users();
                else break;
            }
        }

        private int Menu()
        {
            int choice = -1;
            while (choice == -1)
            {
                Console.WriteLine("\nLibrary Menu;");
                Console.WriteLine("1) add_book");
                Console.WriteLine("2) search_books_by_prefix");
                Console.WriteLine("3) print_who_borrowed_book_by_name");
                Console.WriteLine("4) print_library_by_id");
                Console.WriteLine("5) print_library_by_name");
                Console.WriteLine("6) add_user");
                Console.WriteLine("7) user_borrow_book");
                Console.WriteLine("8) user_return_book");
                Console.WriteLine("9) print_users");
                Console.WriteLine("10) Exit");

                Console.Write("Enter your menu choice [1 - 10]: ");
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 10)
                {
                    Console.WriteLine("Invalid choice. Try again");
                    choice = -1;
                }
            }
            return choice;
        }
        private void add_book()
        {
            Book book = new Book();
            book.Add_Book();
            books.Add(book);
        }
        private void search_books_by_prifix()
        {
            Console.WriteLine("Enter Book name prifix: ");
            string name = Console.ReadLine();
            int number = 0;
            foreach (Book book in books)
            {
                if (book.Search_Book(name) == true)
                {
                    Console.WriteLine(book.Name);
                    number++;
                }
            }

            if (number == 0)
            {
                Console.WriteLine("No Books with such prifix");
            }   
        }
        private void print_library_by_id()
        {
            //books.Sort(CompareByID<Book>);
            foreach (Book book in books.OrderBy(b => b.ID))
            {
                book.Print();
            }
        }
        private void print_library_by_name()
        {
            foreach (Book book in books.OrderBy(b => b.Name))
            {
                book.Print();
            }
        }
        private void add_user()
        {
            User user = new User();
            user.Add_User();
            users.Add(user);
        }
        private int user_id(string name)
        {
            User user= users.FirstOrDefault(b => b.Name == name);
            if (user == null)
                return 0;
            else
                return user.Id;
        }
        private int book_id(string name)
        {
            Book book= books.FirstOrDefault(b => b.Name == name);
            if (book == null)
                return 0;
            else
                return book.ID;

        }

        private void user_borrow_book()
        {
            int userid, bookid;
            bool borrow = borrow_return_book(out userid,out bookid);
            if (borrow)
            {
                bool borrow_book = books.FirstOrDefault(b => b.ID == bookid).Borrow(bookid);
                if (borrow_book)
                {
                    users.FirstOrDefault(u => u.Id == userid).Borrow_Book(bookid);
                }
                else
                {
                    Console.WriteLine("No more copies available right now");
                }
            }
            else return;
        }
        private void user_return_book()
        {
            int userid, bookid;
            bool return_book = borrow_return_book(out userid, out bookid);
            if (return_book)
            {
                books.FirstOrDefault(b => b.ID == bookid).Return(bookid);

            }
            else return;
        }
        private void print_who_borrowed_book_by_name()
        {
            Console.WriteLine("Enter the name of the book");
            string book_name = Console.ReadLine();
            int bookid =book_id(book_name);
            if(bookid==0)
            {
                Console.WriteLine($"Invalid book name ");
                return;
            }
            foreach (var u in users.Where(u => u.IsBorrowed(bookid)))
            {
                Console.WriteLine(u.Name);
            }
                
        }





        private void print_users()
        {
            foreach(User user in users)
            {
                user.Print_User();
            }
        }

        private bool borrow_return_book(out int username,out int bookname)
        {
            int counter = 3;
            username = 0;
            bookname = 0;
            while(counter-->0)
            {
                Console.WriteLine("Enter the name of the user :");
                string name_user = Console.ReadLine();
                Console.WriteLine("Enter the name of the book :");
                string book_book = Console.ReadLine();
                username=user_id(name_user);
                if (username == 0)
                {
                    Console.WriteLine("this user not login please add this user ");
                    continue;
                }
                
                bookname = book_id(book_book);
                if(bookname == 0)
                {
                    Console.WriteLine("The Library not conatin on this book ");
                    continue;
                }
               
                    return true;
                
            }
            Console.WriteLine("You did several trials! Try later.");
            return false;
        }

    }
}
