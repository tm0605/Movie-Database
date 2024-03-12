using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using static System.Console;

namespace IFN664_Assignment
{
    /// <summary>
    /// Hashtable where key is the title of the movie and
    /// the item is an object of Movie class
    /// Assumed that maximum number of the key, object pair is 1000
    /// </summary>
    internal class MovieCollection
    {
        private int type; // Number of Movies
        private int count; // Number of DVDs
        private Bucket[] storage;
        private int size; // storage.Length
        /// <summary>
        /// MovieCollection Constructor
        /// </summary>
        /// <param name="size">Maximum size of the collection (1000 Recommended)</param>
        public MovieCollection(int size)
        {
            storage = new Bucket[size];

            for (int i = 0; i < storage.Length; i++) // For each storage in array
                storage[i] = new Bucket(); // Initialize bucket

            count = 0;
            this.size = size;

            //GenerateDummy(Program.mov); // Test function that generates dummy movies
        }
        /// <summary>
        /// Test Method used to generate dummy movie object from dummy movie array
        /// </summary>
        /// <param name="movies">Dummy Movie Array</param>
        private void GenerateDummy(string[] dummyMovies)
        {
            foreach (string title in dummyMovies)
            {
                Random r = new Random();
                int genre = r.Next(0, 8); // Random genre
                int classification = r.Next(0, 3); // Random class
                int duration = r.Next(60, 180); // Random duration
                Movie movie = new Movie(title, genre, classification, duration);
                AddDummy(movie); // Adds the movie if its new, if existing increments
                type = dummyMovies.Distinct().Count(); // Update types of movie
            }
        }
        /// <summary>
        /// Method that hashes movie title
        /// </summary>
        /// <param name="title">Movie Title</param>
        /// <returns>Hashed key</returns>
        private int Hash(string title)
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes(title);
            int ascii = 0;
            int prime = 31;
            for (int i = 0; i < asciiBytes.Length; i++) // For each ascii code in title
            {
                ascii += asciiBytes[i] * prime ^ i; // Ascii code * prime to the power of index
            }
            int M = size; // Size of the hash table
            int key = ascii % M; // Division method
            return key;
        }
        /// <summary>
        /// Method that gets the specific bucket given the title of the movie
        /// </summary>
        /// <param name="title">Movie Title</param>
        /// <returns>Bucket</returns>
        private Bucket GetBucket(string title)
        {
            int key = Hash(title); // Has the title
            Bucket bucket = storage[key]; // Get bucket
            return bucket;
        }
        /// <summary>
        /// Method that gets the specific bucket given the key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Bucket</returns>
        private Bucket GetBucket(int key)
        {
            Bucket bucket = storage[key]; // Get bucket
            return bucket;
        }
        /// <summary>
        /// Searches whether the Movie exist
        /// </summary>
        /// <param name="title">Title of the Movie</param>
        /// <returns>True if found Flase if not</returns>
        public bool Search(string title)
        {
            Bucket bucket = GetBucket(title);
            return bucket.Search(title); // Excecute search function on bucket
        }
        public Movie Retrieve()
        {
            Clear();
            Write("Enter the movie title ==> ");
            string title = ReadLine();
            Movie movie = Retrieve(title);
            if (movie == null)
            {
                WriteLine($"{title} not found");
                WriteLine("Press any key to continue...");
                ReadLine();
            }
            return movie;
        }
        /// <summary>
        /// Retrieves the movie from collection
        /// </summary>
        /// <param name="title">Movie Title</param>
        /// <returns>Movie object if found, Else null</returns>
        private Movie Retrieve(string title)
        {
            Bucket bucket = GetBucket(title);
            Movie m = bucket.Retrieve(title);
            return m;
        }
        /// <summary>
        /// Method that retrives all movies from the collection
        /// </summary>
        /// <returns>Movie Array, if no movie returns null</returns>
        private Movie[] RetrieveAll()
        {
            if (type == 0) // If no movies stored
                return null;
            Movie[] movies = new Movie[type];
            int index = 0;
            for (int i = 0; i < storage.Length; i++) // For each storage in hashtable
            {
                Movie[] m = storage[i].RetrieveAll(); // Retrieve all movies from bucket
                if (m == null) // If bucket empty
                    continue; // Next storage
                for (int j = 0; j < m.Length; j++) // For each movie in bucket
                {
                    movies[index] = m[j];
                    index++;
                }
            }
            return movies;
        }
        /// <summary>
        /// User facing add new movie function
        /// </summary>
        public void AddNewMovie()
        {
            Clear();
            WriteLine(
                "Add a new movie to the system\n" +
                "---------------------------------------------------------\n"
                );
            Write("Enter the movie title ==> ");
            string title = ReadLine();
            if (Search(title)) // If movie already exists
            {
                WriteLine("The movie already exists\nFailed to add new movie");
                WriteLine("Press any key to continue...");
                ReadLine();
                return;
            }
            Movie movie = new Movie(title);

            Add(movie);
        }
        /// <summary>
        /// User facing add existing movie function
        /// </summary>
        public void AddExistingMovie()
        {
            Clear();
            WriteLine(
                "Add an existing movie to the system\n" +
                "---------------------------------------------------------\n"
                );
            Write("Enter the movie title ==> ");
            string title = ReadLine();

            Add(title);

        }/// <summary>
         /// Test method used to add dummy movies
         /// </summary>
         /// <param name="movie">Movie Object</param>
        private void AddDummy(Movie movie)
        {
            Bucket bucket = GetBucket(movie.GetTitle());

            bucket.InsertDummy(movie);
            count++;
        }
        /// <summary>
        /// Method that adds a movie object to the collection
        /// Used for adding new movies
        /// </summary>
        /// <param name="movie">Movie Object</param>
        private void Add(Movie movie)
        {
            Bucket bucket = GetBucket(movie.GetTitle());

            bucket.Insert(movie);
            type++; // Increment number of movie
            count++; // Increment number of DVD
            WriteLine("Press any key to continue...");
            ReadLine();
        }
        /// <summary>
        /// Method that adds a movie to the collection given the title
        /// Used for adding existing movies
        /// </summary>
        /// <param name="title">Movie Title</param>
        private void Add(string title)
        {
            Bucket bucket = GetBucket(title);
            Movie movie = bucket.Retrieve(title);
            if (movie == null) // If movie doesn't exist
            {
                WriteLine($"{title} not found");
                WriteLine("Press any key to continue...");
                ReadLine();
                return; // end
            }
            bucket.Insert(movie);
            count++;
            WriteLine("Press any key to continue...");
            ReadLine();
        }
        /// <summary>
        /// User facing remove movie function
        /// </summary>
        public void RemoveMovie()
        {
            Clear();
            WriteLine(
                "Remove DVDs of an existing movie from the system\n" +
                "---------------------------------------------------------\n"
                );
            Write("Enter the title of the movie ==> ");
            string title = ReadLine();
            Remove(title);
            WriteLine("Press any key to continue...");
            ReadLine();
        }
        /// <summary>
        /// Remove DVDs of a movie from the system
        /// If all the DVDs of a movie are removed, the movie should also be removed from the system
        /// </summary>
        /// <param name="movie">Movie to be removed</param>
        private bool Remove(string title)
        {
            Bucket bucket = GetBucket(title);

            if (!bucket.Remove(title)) // Execute remove and if fail
                return false;

            count--;
            return true;
        }
        /// <summary>
        /// Display all the information about all the movie DVDs in
        /// dictionary order of the movie title, including the number
        /// of the movie DVDs currently in the community library
        /// </summary>
        public void DisplayInfoAll()
        {
            Clear();
            Movie[] m = RetrieveAll(); // Gather all movies from hashtable
            if (m == null) // If no movies in hash table
            {
                WriteLine("No movies in system");
                WriteLine("Press any key to continue...");
                ReadLine();
                return;
            }
            MovieMergeSort.Sort(m); // Perform merge sort on the array
            for (int i = 0; i < m.Length; i++) // For each movie in sorted movie array
            {
                Write($"{i + 1}. ");
                WriteLine(m[i].GetInfo()); // Display info
            }
            //for (int i = 0; i < storage.Length; i++)
            //    storage[i].DisplayInfoAll();
            WriteLine("Press any key to continue...");
            ReadLine();
        }
        /// <summary>
        /// User facing method for displaying movie info
        /// </summary>
        public void DisplayInfo()
        {
            Clear();
            WriteLine(
                "Display all the information about a movie, given the title of the movie\n" +
                "---------------------------------------------------------\n"
                );
            if (type == 0) // If no movies in system
            {
                WriteLine("No movies in system");
                WriteLine("Press any key to continue...");
                ReadLine();
                return;
            }
            Write("Enter the title of the movie ==> ");
            string title = ReadLine();
            DisplayInfo(title);
            WriteLine("Press any key to continue...");
            ReadLine();
        }
        /// <summary>
        /// Display the information about a movie, given the title of the movie
        /// </summary>
        /// <param name="title">Movie Title</param>
        private void DisplayInfo(string title)
        {
            Bucket bucket = GetBucket(title);
            bucket.DisplayInfo(title);
        }
        /// <summary>
        /// Method that displays the top 3 movies.
        /// Movies with 0 views are not considered.
        /// Movies with same view count will be overwritten.
        /// </summary>
        public void DisplayInfoTop3()
        {
            Clear();
            WriteLine(
                "Top 3 Movies\n" +
                "---------------------------------------------------------\n"
                );
            if (type == 0) // If no movies in system
            {
                WriteLine("No movies in system");
                WriteLine("Press any key to continue...");
                ReadLine();
                return;
            }

            Movie[] top3 = { null, null, null }; // Initialize array
            for (int i = 0; i < storage.Length; i++) // For each bucket
            {
                Bucket bucket = GetBucket(i);
                Movie[] movies = bucket.RetrieveAll(); // Retrieve all from bucket
                if (movies == null) continue; // If bucket empty next iteration
                for (int j = 0; j < movies.Length; j++) // For each movies in bucket
                {
                    int view = movies[j].GetView(); // Retrieve view count
                    if (view == 0) continue; // If not viewed, ignore and move to next iteration
                    if (top3[0] == null || view >= top3[0].GetView()) // If view >= first
                    {
                        top3[2] = top3[1]; // Second to third
                        top3[1] = top3[0]; // First to second
                        top3[0] = movies[j]; // Current movie to first
                    }
                    else if (top3[1] == null || view >= top3[1].GetView()) // If view >= second
                    {
                        top3[2] = top3[1]; // Second to third
                        top3[1] = movies[j]; // Current movie to second
                    }
                    else if (top3[2] == null || view >= top3[2].GetView())
                    {
                        top3[2] = movies[j]; // Current movie to third
                    }
                }
            }
            int count = 0;
            for (int i = 0; i < top3.Length; i++) // For each movie from top 3
            {
                Movie movie = top3[i];
                if (movie != null) // If movie exists
                {
                    WriteLine($"{i + 1}. {movie.GetInfo()}");
                    count++;
                }
            }
            if (count == 0) // If no movie was in top 3
                WriteLine("No Data");
            WriteLine("Press any key to continue...");
            ReadLine();

        }
        /// <summary>
        /// User facing borrow method.
        /// Checks if there is sufficient stock and duplicate loans for user.
        /// If successful, proceeds to execute borrow method for movies.
        /// </summary>
        /// <param name="member">Member Object</param>
        public void Borrow(Member member)
        {
            Clear();
            WriteLine(
                "Borrow a movie DVD\n" +
                "---------------------------------------------------------\n"
                );
            if (type == 0) // If no movies in system
            {
                WriteLine("No movies in system");
                WriteLine("Press any key to continue...");
                ReadLine();
                return;
            }
            Write("Enter the title of the movie ==> ");
            string title = ReadLine();
            Movie movie = Retrieve(title); // Retrieve the movie object

            if (movie == null) // Movie not found
                WriteLine($"{title} not found");

            else if (movie.GetStock() == 0) // No stock left
                WriteLine($"No stock left for {title}");

            else if (!member.Rent(movie)) // Issue with member
                WriteLine("Could not proceed with the rental");

            else // Successful rental
            {
                Borrow(title);
                WriteLine("Successfully borrowed!");
            }
            WriteLine("Press any key to continue...");
            ReadLine();
        }
        /// <summary>
        /// Borrow a movie DVD from the community library, given the title of the movie DVD
        /// </summary>
        /// <param name="title">Movie Title</param>
        /// <returns>Movie object if successfully borrowed, Else null</returns>
        private Movie Borrow(string title)
        {
            Bucket bucket = GetBucket(title);
            Movie movie = bucket.Borrow(title);
            if (movie != null)
                return movie;
            else return null;
        }
        /// <summary>
        /// User facing return method.
        /// Executes return method for users if successful then proceeds with return method for movie.
        /// </summary>
        /// <param name="member">Member Object</param>
        public void Return(Member member)
        {
            Clear();
            WriteLine(
                "Return a movie DVD\n" +
                "---------------------------------------------------------\n"
                );
            Write("Enter the title of the movie ==> ");
            string title = ReadLine();
            Movie movie = Retrieve(title); // Retrieve the movie object

            if (movie == null) // Movie not found
                WriteLine($"{title} not found");

            else if (!member.Return(movie)) // Issue with member
                WriteLine("Could not proceed with the returning");

            else // Successful return
            {
                Return(movie);
                WriteLine("Successfully returned!");
            }
            WriteLine("Press any key to continue...");
            ReadLine();
        }
        /// <summary>
        /// Return a movie DVD to the community library, given the title of the movie DVD
        /// </summary>
        /// <param name="title"></param>
        private void Return(Movie movie)
        {
            Bucket bucket = GetBucket(movie.GetTitle());
            bucket.Return(movie);
        }
        public int GetCount() 
        { 
            return count;
        }
    }
    internal class Node
    {
        public Movie Movie;
        public Node Next;

        public Node(Movie movie) // Constructor
        {
            Movie = movie;
            Next = null;
        }
    }

    internal class Bucket
    {
        private Node Head;
        private int Count; // Number of nodes in the bucket
        public Bucket()
        {
            Head = null;
            Count = 0;
        }
        /// <summary>
        /// Test method used to add dummy movies.
        /// Movies are added if its new.
        /// If there are movies with same title, will be incremented.
        /// </summary>
        /// <param name="movie">Movie Object</param>
        public void InsertDummy(Movie movie)
        {
            Node node = new Node(movie);

            if (Head == null) // If empty bucket
            {
                Head = node;
                Count++;
            }
            else
            {
                Node current = Head;
                while (current.Movie.GetTitle() != movie.GetTitle() && current.Next != null) // While not movie and not last node
                    current = current.Next;

                if (current.Movie.GetTitle() == movie.GetTitle()) // If Movie already exist
                {
                    current.Movie.IncrementInventory();
                }
                else // If new Movie
                {
                    current.Next = node;
                    Count++;
                }
            }
        }
        /// <summary>
        /// Method that inserts one inventory worth of movie
        /// </summary>
        /// <param name="movie">Movie Title</param>
        public void Insert(Movie movie)
        {
            Node node = new Node(movie);

            if (Head == null) // If empty bucket
            {
                Head = node;
                Count++;
            }
            else
            {
                Node current = Head;
                while (current.Movie.GetTitle() != movie.GetTitle() && current.Next != null) // While not movie and not last node
                    current = current.Next;

                if (current.Movie.GetTitle() == movie.GetTitle()) // If Movie already exist
                {
                    current.Movie.IncrementInventory();
                    WriteLine($"Added a stock the following movie");
                    WriteLine(movie.GetInfo());
                }
                else // If new Movie
                {
                    current.Next = node;
                    WriteLine($"Created the following new movie");
                    WriteLine(movie.GetInfo());
                    Count++;
                }
            }
        }
        /// <summary>
        /// Method that removes one inventory from a movie
        /// </summary>
        /// <param name="title">Movie Title</param>
        /// <returns>True if successfully removed. Else false</returns>
        public bool Remove(string title)
        {
            if (Head == null) // If empty bucket
            {
                WriteLine($"\nCould not remove {title}\nMovie not found");
                return false;
            }

            Node current = Head;
            Node prev = null;
            while (current.Movie.GetTitle() != title && current.Next != null) // While not movie and not last node
            {
                prev = current;
                current = current.Next;
            }

            Movie movie = current.Movie;

            if (movie.GetTitle() != title) // Not found return false
            {
                WriteLine($"\nCould not remove {title}\nMovie not found");
                return false;
            }

            if (!movie.DecrementInventory()) // If no stock left to remove
            {
                WriteLine($"\nCould not remove {title}\nOut of Stock");
                return false;
            }

            int remaining = movie.GetInventory(); // Get remaining inventory

            if (remaining == 0) // If no more inventory
            {
                Count--;
                if (current == Head && current.Next == null) // First and Last Node
                    Head = null;
                else if (current == Head) // First Node
                    Head = current.Next;
                else if (current.Next == null) // Last Node
                    prev.Next = null;
                else // In between Node
                    prev.Next = current.Next;
                WriteLine($"\n{title} completely removed from system");
                return true;
            }

            WriteLine("\nRemoved a stock of the following movie");
            WriteLine(movie.GetInfo());
            return true;
        }
        /// <summary>
        /// Method that searches movie from the bucket
        /// </summary>
        /// <param name="title">Movie Title</param>
        /// <returns>True if found. Else null</returns>
        public bool Search(string title)
        {
            if (Retrieve(title) == null) return false;
            return true;
        }
        /// <summary>
        /// Method that retrieves movie from the bucket
        /// </summary>
        /// <param name="title">Movie Title</param>
        /// <returns>Movie object if found.
        /// Else null</returns>
        public Movie Retrieve(string title)
        {
            if (Head == null) return null; // If empty bucket

            Node current = Head;
            while (current.Movie.GetTitle() != title && current.Next != null) // While not movie and not last node
                current = current.Next;

            Movie movie = current.Movie;

            if (movie.GetTitle() == title) // If found
                return movie;

            return null;
        }
        /// <summary>
        /// Method that retrieves all movie from bucket
        /// </summary>
        /// <returns>Array of movie if exists, else null</returns>
        public Movie[] RetrieveAll()
        {
            if (Head == null) return null;

            Movie[] movies = new Movie[Count];
            Node current = Head;
            for (int i = 0; i < Count; i++)
            {
                movies[i] = current.Movie;
                current = current.Next;
            }
            return movies;

        }
        /// <summary>
        /// Method that displays all movie info from bucket
        /// </summary>
        public void DisplayInfoAll()
        {
            if (Head == null) return; // If empty bucket

            Node current = Head;
            while (current.Next != null) // While not last node
            {
                string info = current.Movie.GetInfo();
                WriteLine(info);
                current = current.Next;
            }
        }
        /// <summary>
        /// Method that displays specific movie info from bucket
        /// </summary>
        /// <param name="title">Movie Title</param>
        public void DisplayInfo(string title)
        {
            Movie movie = Retrieve(title);

            if (movie == null)
            {
                WriteLine($"{title} not found");
                return;
            }

            WriteLine(movie.GetInfo());
        }
        /// <summary>
        /// Method for borrowing movie in bucket
        /// </summary>
        /// <param name="title">Movie Title</param>
        /// <returns>Movie object if successfully borrowed, else null</returns>
        public Movie Borrow(string title)
        {
            Movie movie = Retrieve(title); // Retrieve movie

            if (movie == null) return null; // If not found

            if (!movie.DecrementStock()) // If stock not available
            {
                WriteLine($"{title} Out of Stock");
                return null;
            }

            movie.IncrementView(); // Increment View
            return movie;
        }
        public void Return(Movie movie)
        {
            movie.IncrementStock();
        }
        /// <summary>
        /// Method that returns the length of the bucket
        /// </summary>
        /// <returns>Length in int</returns>
        public int GetCount()
        {
            return Count;
        }
    }
}
