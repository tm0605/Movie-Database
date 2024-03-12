using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;
using static System.Console;

namespace IFN664_Assignment
{
    /// <summary>
    /// This class must use an Array as its basic data structure to
    /// store a collection of Member objects
    /// </summary>
    internal class MemberCollection
    {
        private Member[] _data;
        private int _size;
        public int Count { get { return _size; } }
        /// <summary>
        /// Member collection Constructor.
        /// Original capacity set to 4 by default
        /// </summary>
        /// <param name="capacity">Member Collection Capacity</param>
        public MemberCollection(int capacity = 4)
        {
            _data = new Member[capacity];
            _size = 0;
        }
        /// <summary>
        /// A method that resizes the array automatically when full capacity
        /// </summary>
        /// <param name="capacity">New Capacity</param>
        private void Resize(int capacity)
        {
            Member[] newArray = new Member[capacity]; // Create a new array
            Array.Copy(_data, newArray, _size); // Copy contents from original array to the new array
            _data = newArray;
        }
        /// <summary>
        /// Method that returns the member object given the correct name and password.
        /// </summary>
        /// <param name="name">Member Name</param>
        /// <param name="password">Member Password</param>
        /// <returns>Member object if successful login, else null</returns>
        public Member Login(string name, string password)
        {
            for (int i = 0; i < _size; i++) // For each member in member collection
            {
                if (name == _data[i].GetName() && password == _data[i].GetPassword().ToString()) // If name and password matches
                    return _data[i]; // Return member object
            }
            return null; // Else null
        }
        /// <summary>
        /// User facing add member method
        /// </summary>
        public void AddMember()
        {
            Clear();
            WriteLine(
                "Add a member to the system\n" +
                "---------------------------------------------------------\n"
                );
            Write("Enter the name of the member ==> ");
            string name = ReadLine();
            Write("Enter the phone number ==> ");
            string phone = ReadLine();
            int pw;
            bool valid = false;
            do // Ask for the password until the user enters a valid password
            {
                Write("Enter the 4 digit password ==> ");
                if (!int.TryParse(ReadLine(), out pw)) // If password not int
                    WriteLine("Invalid");
                else if (pw.ToString().Length != 4) // If password not 4 digits
                    WriteLine("Password needs to be 4 ditits");
                else // If valid
                    valid = true; // End while
            } while (!valid);
            if (FindDuplicates(name, phone)) // If duplicates are found
            {
                WriteLine($"{name} already exists.");
                WriteLine("Press any key to continue...");
                ReadLine();
                return; // End
            }
            Member member = new Member(name, pw, phone); // If no duplicates, create the member object
            Register(member); // Add the member object to the collection
            WriteLine($"Successfully added {name}");
            WriteLine("Press any key to continue...");
            ReadLine();
        }
        /// <summary>
        /// A method that finds duplicates
        /// </summary>
        /// <param name="name">Member Name</param>
        /// <param name="phone">Member Phone Number</param>
        /// <returns>True if duplicates are found, False if not</returns>
        private bool FindDuplicates(string name, string phone)
        {
            for (int i = 0; i < _data.Length; i++) // For each member in member collection
            {
                if (_data[i] == null) // If reached to the end without duplicates
                    return false;
                else if (name == _data[i].GetName() && phone == _data[i].GetPhone()) // If matching member
                    return true;
            }
            return false; // If reaching to the end of the array without duplicates
        }
        /// <summary>
        /// Register a new member with the system.
        /// When a member is being registered via a staff member,
        /// a four-digit password is set for the member
        /// </summary>
        private void Register(Member member)
        {
            if (_size == _data.Length) // If current array is full
                Resize(_data.Length * 2); // Resize

            _data[_size++] = member; // Add member
        }
        /// <summary>
        /// User facing remove member method
        /// </summary>
        public void RemoveMember()
        {
            Clear();
            WriteLine(
                "Remove a member from the system\n" +
                "---------------------------------------------------------\n"
                );
            Write("Enter the name of the member ==> ");
            string name = ReadLine();
            Write("Enter password ==> ");
            string password = ReadLine();

            Unregister(name, password);
            WriteLine("Press any key to continue...");
            ReadLine();
        }
        /// <summary>
        /// Remove a registered member from the system
        /// </summary>
        /// <param name="name">Member Name</param>
        /// <returns>True if unregistered, else false</returns>
        private bool Unregister(string name, string password)
        {
            int index = FindMemberIndex(name, password); // Find member

            if (index == -1) // Memmber not found
            {
                WriteLine($"Incorrect Name or Password");
                return false;
            }

            for (int i = index + 1; i < _size; i++) // Shift the members in the array
                _data[i - 1] = _data[i];

            _size--;
            _data[_size] = null; // Clear the last member to avoid dupliation
            WriteLine($"{name} successfully removed");
            return true;
        }
        /// <summary>
        /// Retrun the index of the member given the name
        /// </summary>
        /// <param name="name">Member Name</param>
        /// <returns>Index if found, -1 if not found</returns>
        private int FindMemberIndex(string name, string password)
        {
            for (int i = 0; i < _size; i++) // For each member in member collection
            {
                Member member = _data[i];
                if (name == member.GetName() && password == member.GetPassword().ToString()) // If matching name and password
                    return i;
            }
            return -1; // Not found
        }
        /// <summary>
        /// User facing find member phone method
        /// </summary>
        public void FindMemberPhone()
        {
            Clear();
            WriteLine(
                "Find a member's contact phone number, given the member's name\n" +
                "---------------------------------------------------------\n"
                );
            Write("Enter the name of the member ==> ");
            string name = ReadLine();
            FindMemberPhone(name);
            WriteLine("Press any key to continue...");
            ReadLine();
        }
        /// <summary>
        /// Find a member's contact phone number, given the member's full name
        /// </summary>
        /// <param name="name">Member's full name</param>
        /// <returns>Member's phone number</returns>
        private string FindMemberPhone(string name)
        {
            
            for (int i = 0; i < _size; i++) // For each member in array
            {
                Member member = _data[i];
                if (member.GetName() == name) // If given name matches
                {
                    WriteLine($"Phone No: {member.GetPhone()}");
                    return member.GetPhone();
                }
            }
            WriteLine($"{name} not found");
            return null;
        }
        /// <summary>
        /// Find all the members who are currently renting a particular movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public Member[] FindRentingMembers(Movie movie)
        {
            Member[] members = new Member[movie.GetInventory()]; // Initialize members list
            int rentingMembers = 0;
            for (int i = 0; i < _size; i++) // For each member in collection
            {
                Member member = _data[i];
                Movie[] movies = member.GetLoan(); // Retrieve loan list
                foreach (Movie mov in movies) // For each movie in loan list
                {
                    if (mov == movie) // If member was loaning the movie
                    {
                        members[rentingMembers] = member;
                        WriteLine($"{rentingMembers + 1}. {member.GetName()}");
                        rentingMembers++;
                    }
                }
            }
            if (rentingMembers == 0)
                WriteLine($"No one is currently borrowing {movie.GetTitle()}");
            WriteLine("Press any key to continue...");
            ReadLine();
            return members;
        }
    }
}
