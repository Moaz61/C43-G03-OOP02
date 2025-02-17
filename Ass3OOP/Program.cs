﻿namespace Ass3OOP
{
    struct HiringDate
    {
        public int Day;
        public int Month;
        public int Year;

        public override string ToString()
        {
            return $"{Day:D2}/{Month:D2}/{Year}";
        }
    }
    enum SecurityLevel
    {
        Guest,
        Developer,
        Secretary,
        DBA
    }

    class Employee
    {
        private int ID {  get; set; }
        private string Name { get; set; }

        private char gender;
        public char Gender
        {
            get { return gender; }
            set 
            {
                if (value == 'M' || value == 'F')
                    gender = value;
                else
                    throw new ArgumentException("Gender must be male or female!");
            }
        }

        private decimal Salary { get; set; }
        public HiringDate HiringDate { get; set; }
        public SecurityLevel SecurityLevel { get; set; }

        public Employee(int iD, string name, char gender, decimal salary, HiringDate hiringDate, SecurityLevel securityLevel)
        {
            ID = iD;
            Name = name;
            Gender = gender;
            Salary = salary;
            HiringDate = hiringDate;
            SecurityLevel = securityLevel;
        }

        public override string ToString()
        {
            return $"ID:{ID}, Name:{Name}, Gender:{Gender}, Salary:{Salary}$, HiringDate:{HiringDate}, SecurityLevel:{SecurityLevel}";
        }

        public static int CompareByHiringDate (Employee e1, Employee e2)
        {
            DateTime date1 = new DateTime(e1.HiringDate.Year , e1.HiringDate.Month , e1.HiringDate.Day);
            DateTime date2 = new DateTime(e2.HiringDate.Year, e2.HiringDate.Month, e2.HiringDate.Day);
            return date1.CompareTo(date2);
        }

    }

    #region 5-Design a program for a library management system where

    /// in this example, inheritance simplifies the design, as it prevents us from code redundancy.
    ///so, in our example we have three classes (book, ebook and printed book),
    /// since we used inheritance, i didn't have to write the basic attributes for ebook and printed book(title, author, isavailable, isbn) because they all inherit from the base class (book)
    /// so, i can add the special attributes for each class (filesize and page count)
    /// also inheritance allowed us (with the use of abstraction) to ensure that every child class contains some functions as (display), and it also forces us to implement this function according to the class

    public abstract class Book
    {

        public string Title { get; private protected set; }
        public string Author { get; private protected set; }
        public bool IsAvailable { get; private protected set; }
        public string ISBN { get; private protected set; }

        protected Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsAvailable = true;
        }

        public abstract void Display();

    }

    public class Ebook : Book
    {
        private double fileSize;

        public double FileSize { get; protected set; }

        public Ebook(String title, string author, string isbn, double fileSize) : base(title, author, isbn)
        {
            FileSize = fileSize;
        }

        public override void Display()
        {
            Console.WriteLine($"title: {Title}");
            Console.WriteLine($"author: {Author}");
            Console.WriteLine($"isbn: {ISBN}");
            Console.WriteLine($"Available: {(IsAvailable ? "Yes" : "No")}");
            Console.WriteLine($"File Size: {FileSize} MB");
        }

    }


    public class PrintedBook : Book
    {
        private int pageCount;

        public int PageCount { get; protected set; }

        public PrintedBook(string title, string author, string isbn, int pageCount) : base(title, author, isbn)
        {
            PageCount = pageCount;
        }


        public override void Display()
        {
            Console.WriteLine($"title: {Title}");
            Console.WriteLine($"author: {Author}");
            Console.WriteLine($"isbn: {ISBN}");
            Console.WriteLine($"Available: {(IsAvailable ? "Yes" : "No")}");
            Console.WriteLine($"page count: {PageCount} MB");
        }


    }
    #endregion



    internal class Program
    {
        static void Main(string[] args)
        {
            #region 3.Create an array of Employees with size three a DBA, Guest and the third one is security officer who have full permissions. (Employee[]EmpArr;) 
            Employee[] employees = new Employee[3];
            try
            {
                employees[0] = new Employee(1, "Moaz", 'M', 500, new HiringDate { Day = 1, Month = 10, Year = 2025 }, securityLevel: SecurityLevel.Developer);
                employees[1] = new Employee(2, "Marwan", 'M', 600, new HiringDate { Day = 1, Month = 10, Year = 2024 }, securityLevel: SecurityLevel.DBA);
                employees[2] = new Employee(3, "Mahmoud", 'M', 700, new HiringDate { Day = 1, Month = 10, Year = 2023 }, securityLevel: SecurityLevel.Guest);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
            #endregion

            #region 4.Sort the employees based on their hire date then Print the sorted array.
                        Console.WriteLine("\nAfter sorting");
            Array.Sort(employees, Employee.CompareByHiringDate);
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }

            int boxingcount = 0;
            foreach (Employee employee in employees)
            {
                object obj = employee; //Boxing
                Employee unboxed = (Employee)obj; //Unboxing
                boxingcount++;
            }
            Console.WriteLine($"\nBoxing&Unboxing occured {boxingcount} times"); 
            #endregion
        }
    }
}
