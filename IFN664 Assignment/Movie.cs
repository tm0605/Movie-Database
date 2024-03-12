using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Console;

namespace IFN664_Assignment
{
    /// <summary>
    /// Each movie is represented by an object of class Movie
    /// </summary>
    internal class Movie
    {
        public static string[] L_Genre =
        {
            "Drama",
            "Adventure",
            "Family",
            "Action",
            "Sci-Fi",
            "Comedy",
            "Animated",
            "Thriller",
            "Other"
        };
        public static string[] L_Classification =
        {
            "General (G)",
            "Parental Guidance (PG)",
            "Mature (M15+)",
            "Mature Accompanied (MA15+)"
        };
        private string _genre;
        private string _classification;
        private int _duration;
        private int _inventory;
        private int _stock;
        private int _view;
        private string Title { get; set; }
        private string Genre
        {
            get { return _genre; }
            set
            {
                if (!L_Genre.Contains(value))
                    throw new ArgumentException("Invalid Genre");

                _genre = value;
            }
        }
        private string Classification
        {
            get { return _classification; }
            set
            {
                if (!L_Classification.Contains(value))
                    throw new ArgumentException("Invalid Classification");

                _classification = value;
            }
        }
        private int Duration
        {
            get { return _duration; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Invalid duration");
                _duration = value;
            }
        }
        private int Inventory
        {
            get { return _inventory; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Invalid Inventory");
                _inventory = value;
            }
        }
        private int Stock
        {
            get { return _stock; }
            set
            {
                if (value > Inventory || value < 0)
                    throw new ArgumentException("Invalid Stock");
                _stock = value;
            }
        }
        private int View
        {
            get { return _view; }
            set
            {
                if (value < _view || value < 0)
                    throw new ArgumentException("Invalid View");
                _view = value;
            }
        }
        /// <summary>
        /// Movie constructor used for users
        /// Prompts for the Genre, Classification and Duration
        /// </summary>
        /// <param name="title">Movie Title</param>
        public Movie(string title)
        {
            Title = title;
            SetGenre();
            SetClassification();
            SetDuration();
            Inventory = 1;
            Stock = 1;
            View = 0;
        }
        /// <summary>
        /// Movie constructor used for systems such as to create dummy movie
        /// </summary>
        /// <param name="title">Movie Title</param>
        /// <param name="genre">Movie Genre No</param>
        /// <param name="classification">Movie Classification No</param>
        /// <param name="duration">Movie Duration</param>
        public Movie(string title, int genre, int classification, int duration)
        {
            Title = title;
            Genre = L_Genre[genre];
            Classification = L_Classification[classification];
            Duration = duration;
            Inventory = 1;
            Stock = 1;
            View = 0;
        }
        /// <summary>
        /// Prompt user for Genre No
        /// </summary>
        private void SetGenre()
        {
            bool valid = false;
            int genre;
            for (int i = 0; i < L_Genre.Length; i++)
                WriteLine($"{i + 1}. {L_Genre[i]}");
            do
            {
                Write("Enter the Genre No ==> ");
                if (!int.TryParse(ReadLine(), out genre))
                    WriteLine("Invalid");
                else if (genre > L_Genre.Length || genre <= 0)
                    WriteLine($"Enter a number from 1 to {L_Genre.Length}");
                else
                    valid = true;
            } while (!valid);
            Genre = L_Genre[genre - 1];
        }
        /// <summary>
        /// Prompt user for classification no
        /// </summary>
        private void SetClassification()
        {
            bool valid = false;
            int classification;
            for (int i = 0; i < L_Classification.Length; i++)
                WriteLine($"{i + 1}. {L_Classification[i]}");
            do
            {
                Write("Enter the Classification No ==> ");
                if (!int.TryParse(ReadLine(), out classification))
                    WriteLine("Invalid");
                else if (classification > L_Classification.Length || classification <= 0)
                    WriteLine($"Enter a nubmber from 1 to {L_Classification.Length}");
                else
                    valid = true;
            } while (!valid);
            Classification = L_Classification[classification - 1];
        }
        /// <summary>
        /// Prompt user for duration
        /// </summary>
        private void SetDuration()
        {
            bool valid = false;
            int duration;
            do
            {
                Write("Enter the Duration (min) ==> ");
                if (!int.TryParse(ReadLine(), out duration))
                    WriteLine("Invalid");
                else if (duration <= 0)
                    WriteLine("Enter a number greater than 0");
                else
                    valid = true;
            } while (!valid);
            Duration = duration;
        }
        /// <summary>
        /// Method that returns the info for the movie
        /// </summary>
        /// <returns>Movie Info</returns>
        public string GetInfo()
        {
            string info = 
                $"{Title} | {Duration} mins\n" +
                $"Genre: {Genre} Class: {Classification}\n" +
                $"Stock {Stock}/{Inventory} Rented {View} times\n";
            return info;
        }
        /// <summary>
        /// Method that gets movie title
        /// </summary>
        /// <returns>Movie Title</returns>
        public string GetTitle()
        {
            return Title;
        }
        /// <summary>
        /// Method that gets movie inventory
        /// </summary>
        /// <returns>Movie Inventory</returns>
        public int GetInventory()
        {
            return Inventory;
        }
        /// <summary>
        /// Method that gets movie stock
        /// </summary>
        /// <returns>Movie Stock</returns>
        public int GetStock()
        {
            return Stock;
        }
        public int GetView()
        {
            return View;
        }
        /// <summary>
        /// Method executed when a DVD is added
        /// </summary>
        public void IncrementInventory()
        {
            Inventory++;
            Stock++;
        }
        /// <summary>
        /// Method executed when a DVD is removed
        /// </summary>
        /// <returns>True if sufficient stock, else false</returns>
        public bool DecrementInventory()
        {
            if (Stock > 0) // If there are remaining stock
            {
                Inventory--;
                Stock--;
                return true; // Successful
            }
            return false; // Fail
        }
        /// <summary>
        /// Method executed when a member returns a DVD
        /// </summary>
        public void IncrementStock()
        {
            if (Stock < Inventory) // If stock is less than the inventory
                Stock++;
        }
        /// <summary>
        /// Method executed when a member borrows a DVD
        /// </summary>
        /// <returns>True if sufficient stock, else false</returns>
        public bool DecrementStock()
        {
            if (Stock > 0) // If there are remining stock
            {
                Stock--;
                return true; // Successful
            }
            return false; // Fail
        }
        /// <summary>
        /// Method that increments view count when a member borrows a DVD
        /// </summary>
        public void IncrementView()
        {
            View++;
        }
    }
}
