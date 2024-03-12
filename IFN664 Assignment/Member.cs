using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using static System.Console;

namespace IFN664_Assignment
{
    /// <summary>
    /// Each registered member is represented by an object of class Member
    /// </summary>
    class Member
    {
        private int _password;
        private string Name { get; set; }
        private int Password
        {
            get { return _password; }
            set
            {
                if (value.ToString().Length != 4)
                    throw new ArgumentException("Invalid Password");

                _password = value;
            }
        }

        private string Phone { get; set; }
        private Movie[] Loan { get; set; }
        public Member(string name, int password, string phone)
        {
            Name = name;
            Password = password;
            Phone = phone;
            Loan = new Movie[5];
        }
        public bool Rent(Movie movie)
        {
            for (int i = 0; i < Loan.Length; i++)
            {
                if (Loan[i] == movie)
                {
                    WriteLine($"You already have {movie.GetTitle()} in your loan");
                    return false;
                }
            }
            for (int i = 0; i < Loan.Length; i++)
            {
                if (Loan[i] == null)
                {
                    Loan[i] = movie;
                    return true;
                }
            }
            WriteLine("Your loan list is already full");
            return false;
        }
        public bool Return(Movie movie)
        {
            for (int i = 0; i < Loan.Length;i++)
            {
                if (Loan[i] == movie)
                {
                    Loan[i] = null;
                    return true;
                }
            }
            WriteLine($"You do not have {movie.GetTitle()} in your loan list");
            return false;
        }
        public void DisplayLoan()
        {
            Clear();
            WriteLine(
                $"{Name}'s Loan\n" +
                "---------------------------------------------------------\n"
                );
            Movie[] loan = GetLoan();
            int count = 0;
            for (int i = 0; i < loan.Length; i++)
            {
                if (loan[i] == null)
                    continue;
                count++;
                WriteLine($"{i + 1}. {loan[i].GetInfo()}");
            }
            if (count == 0)
                WriteLine("No movies in loan list");
            WriteLine("Press any key to continue...");
            ReadLine();
        }
        public string GetName()
        {
            return Name;
        }
        public string GetPhone()
        {
            return Phone;
        }
        public Movie[] GetLoan()
        {
            return Loan;
        }
        public int GetPassword()
        {
            return Password;
        }
    }
}
