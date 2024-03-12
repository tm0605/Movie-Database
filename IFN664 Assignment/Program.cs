using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static System.Console;

namespace IFN664_Assignment
{
    internal class Program
    {
        /// <summary>
        /// Dummy movie array used for testing
        /// To activate, uncomment line 37 of MovieCollection.cs
        /// A set of movies will be generated when application started
        /// </summary>
        static public string[] mov = {
                "The Shawshank Redemption",
                "The Godfather",
                "The Dark Knight",
                "Pulp Fiction",
                "Fight Club",
                "Forrest Gump",
                "The Matrix",
                "Goodfellas",
                "Inception",
                "The Lord of the Rings: The Fellowship of the Ring",
                "The Lord of the Rings: The Two Towers",
                "The Lord of the Rings: The Return of the King",
                "The Departed",
                "The Silence of the Lambs",
                "Gladiator",
                "The Avengers",
                "Avatar",
                "Star Wars: Episode IV - A New Hope",
                "Jurassic Park",
                "Titanic",
                "The Lion King",
                "Inglourious Basterds",
                "The Prestige",
                "Interstellar",
                "Inception",
                "The Grand Budapest Hotel",
                "The Revenant",
                "The Wolf of Wall Street",
                "The Social Network",
                "The Green Mile",
                "The Pianist",
                "Whiplash",
                "La La Land",
                "The Dark Knight Rises",
                "Schindler's List",
                "The Departed",
                "Se7en",
                "Memento",
                "Gone Girl",
                "The Big Lebowski",
                "No Country for Old Men",
                "Casino Royale",
                "The Bourne Identity",
                "The Shawshank Redemption",
                "The Godfather",
                "The Dark Knight",
                "Pulp Fiction",
                "Fight Club",
                "Forrest Gump",
                "The Matrix",
                "Goodfellas",
                "Inception",
                "The Lord of the Rings: The Fellowship of the Ring",
                "The Lord of the Rings: The Two Towers",
                "The Lord of the Rings: The Return of the King",
                "The Departed",
                "The Silence of the Lambs",
                "Gladiator",
                "The Avengers",
                "Avatar",
                "Star Wars: Episode IV - A New Hope",
                "Jurassic Park",
                "Titanic",
                "The Lion King",
                "Inglourious Basterds",
                "The Prestige",
                "Interstellar",
                "Inception",
                "The Grand Budapest Hotel",
                "The Revenant",
                "The Wolf of Wall Street",
                "The Social Network",
                "The Green Mile",
                "The Pianist",
                "Whiplash",
                "La La Land",
                "The Dark Knight Rises",
                "Schindler's List",
                "The Departed",
                "Se7en",
                "Memento",
                "Gone Girl",
                "The Big Lebowski",
                "No Country for Old Men",
                "Casino Royale",
                "The Bourne Identity",
                "Avengers: Endgame",
                "The Irishman",
                "The Shawshank Redemption",
                "The Godfather",
                "The Dark Knight",
                "Pulp Fiction",
                "Fight Club",
                "Forrest Gump",
                "The Matrix",
                "Goodfellas",
                "Inception",
                "The Lord of the Rings: The Fellowship of the Ring",
                "The Lord of the Rings: The Two Towers",
                "The Lord of the Rings: The Return of the King",
                "The Departed",
                "The Silence of the Lambs",
                "Gladiator",
                "The Avengers",
                "Avatar",
                "Star Wars: Episode IV - A New Hope",
                "Jurassic Park",
                "Titanic",
                "The Lion King",
                "Inglourious Basterds",
                "The Prestige",
                "Interstellar",
                "Inception",
                "The Grand Budapest Hotel",
                "The Revenant",
                "The Wolf of Wall Street",
                "The Social Network",
                "The Green Mile",
                "The Pianist",
                "Whiplash",
                "La La Land",
                "The Dark Knight Rises",
                "Schindler's List",
                "The Departed",
                "Se7en",
                "Memento",
                "Gone Girl",
                "The Big Lebowski",
                "No Country for Old Men",
                "Casino Royale",
                "The Bourne Identity",
                "Avengers: Endgame",
                "The Irishman","The Shawshank Redemption",
                "The Godfather",
                "The Dark Knight",
                "Pulp Fiction",
                "Fight Club",
                "Forrest Gump",
                "Inception",
                "The Matrix",
                "The Lord of the Rings: The Fellowship of the Ring",
                "The Lord of the Rings: The Two Towers",
                "The Lord of the Rings: The Return of the King",
                "Star Wars: Episode IV - A New Hope",
                "Star Wars: Episode V - The Empire Strikes Back",
                "Star Wars: Episode VI - Return of the Jedi",
                "Star Wars: Episode I - The Phantom Menace",
                "Star Wars: Episode II - Attack of the Clones",
                "Star Wars: Episode III - Revenge of the Sith",
                "Star Wars: The Force Awakens",
                "Star Wars: The Last Jedi",
                "Star Wars: The Rise of Skywalker",
                "Inglourious Basterds",
                "The Avengers",
                "Avengers: Age of Ultron",
                "Avengers: Infinity War",
                "Avengers: Endgame",
                "The Lion King",
                "Frozen",
                "Finding Nemo",
                "Toy Story",
                "Toy Story 2",
                "Toy Story 3",
                "Jurassic Park",
                "Jurassic World",
                "Jurassic World: Fallen Kingdom",
                "E.T. the Extra-Terrestrial",
                "Jaws",
                "Raiders of the Lost Ark",
                "Indiana Jones and the Last Crusade",
                "Indiana Jones and the Kingdom of the Crystal Skull",
                "Back to the Future",
                "Back to the Future Part II",
                "Back to the Future Part III",
                "The Terminator",
                "Terminator 2: Judgment Day",
                "Terminator 3: Rise of the Machines",
                "The Terminator: Dark Fate",
                "The Exorcist",
                "The Shining",
                "A Clockwork Orange",
                "The Wizard of Oz",
                "Gone with the Wind",
                "Casablanca",
                "Citizen Kane",
                "Lawrence of Arabia",
                "Dr. Strangelove or: How I Learned to Stop Worrying and Love the Bomb",
                "Apocalypse Now",
                "Goodfellas",
                "The Godfather Part II",
                "Scarface",
                "Casino",
                "Fight Club",
                "The Green Mile",
                "Forrest Gump",
                "The Dark Knight Rises",
                "The Dark Knight",
                "The Prestige",
                "Interstellar",
                "Django Unchained",
                "The Wolf of Wall Street",
                "The Great Gatsby",
                "The Social Network",
                "The Matrix",
                "The Matrix Reloaded",
                "The Matrix Revolutions",
                "Gladiator",
                "Braveheart",
                "Saving Private Ryan",
                "Schindler's List",
                "The Pianist",
                "American Beauty",
                "The Shawshank Redemption",
                "The Green Mile",
                "American History X",
                "Se7en",
                "Gone Girl",
                "The Girl with the Dragon Tattoo",
                "Memento",
                "The Sixth Sense",
                "Shutter Island",
                "Eternal Sunshine of the Spotless Mind",
                "Inception",
                "The Departed",
                "The Usual Suspects",
                "Fargo",
                "No Country for Old Men",
                "The Big Lebowski",
                "Pulp Fiction",
                "Reservoir Dogs",
                "Kill Bill: Volume 1",
                "Kill Bill: Volume 2",
                "Django Unchained",
                "Once Upon a Time in Hollywood",
                "The Good, the Bad and the Ugly",
                "A Fistful of Dollars",
                "For a Few Dollars More",
                "Gladiator",
                "Troy",
                "Alexander",
                "300",
                "Braveheart",
                "The Last Samurai",
                "Apocalypto",
                "Crouching Tiger, Hidden Dragon",
                "Hero",
                "House of Flying Daggers",
                "Ip Man",
                "Enter the Dragon",
                "Fist of Fury",
                "Way of the Dragon",
                "Kill Bill: Volume 1",
                "Kill Bill: Volume 2",
                "The Raid",
                "The Raid 2",
                "Ong-Bak: Muay Thai Warrior",
                "Warrior",
                "Bloodsport",
                "Rocky",
                "Creed",
                "Raging Bull",
                "Million Dollar Baby",
                "Ali",
                "Southpaw",
                "The Fighter",
                "The Wrestler",
                "The Social Network",
                "Steve Jobs",
                "The Imitation Game",
                "The Theory of Everything",
                "Bohemian Rhapsody",
                "Rocketman",
                "Straight Outta Compton",
                "Walk the Line",
                "La La Land",
                "A Star Is Born",
                "Whiplash",
                "The Sound of Music",
                "Mary Poppins",
                "The Wizard of Oz",
                "Singin' in the Rain",
                "West Side Story",
                "Grease",
                "Dirty Dancing",
                "Footloose",
                "Moulin Rouge!",
                "Chicago",
                "Les Misérables",
                "The Phantom of the Opera",
                "Cabaret",
                "Gone with the Wind",
                "Titanic",
                "The Notebook",
                "The Fault in Our Stars",
                "A Walk to Remember",
                "Me Before You",
                "Eternal Sunshine of the Spotless Mind",
                "500 Days of Summer",
                "The Vow",
                "Romeo + Juliet",
                "The Great Gatsby",
                "Pride and Prejudice",
                "Sense and Sensibility",
                "Jane Eyre",
                "Anna Karenina",
                "Twilight",
                "Harry Potter and the Sorcerer's Stone",
                "Harry Potter and the Chamber of Secrets",
                "Harry Potter and the Prisoner of Azkaban",
                "Harry Potter and the Goblet of Fire",
                "Harry Potter and the Order of the Phoenix",
                "Harry Potter and the Half-Blood Prince",
                "Harry Potter and the Deathly Hallows – Part 1",
                "Harry Potter and the Deathly Hallows – Part 2",
                "The Hunger Games",
                "Catching Fire",
                "Mockingjay - Part 1",
                "Mockingjay - Part 2",
                "Divergent",
                "Insurgent",
                "Allegiant",
                "The Maze Runner",
                "The Scorch Trials",
                "The Death Cure",
                "The Fault in Our Stars",
                "Paper Towns",
                "The Perks of Being a Wallflower",
                "Twilight",
                "New Moon",
                "Eclipse",
                "Breaking Dawn - Part 1",
                "Breaking Dawn - Part 2",
                "The Chronicles of Narnia: The Lion, the Witch and the Wardrobe",
                "The Chronicles of Narnia: Prince Caspian",
                "The Chronicles of Narnia: The Voyage of the Dawn Treader",
                "The Chronicles of Narnia: The Silver Chair",
                "Percy Jackson & the Olympians: The Lightning Thief",
                "Percy Jackson & the Olympians: The Sea of Monsters",
                "Percy Jackson & the Olympians: The Titan's Curse",
                "Percy Jackson & the Olympians: The Battle of the Labyrinth",
                "Percy Jackson & the Olympians: The Last Olympian",
                "The Hobbit: An Unexpected Journey",
                "The Hobbit: The Desolation of Smaug",
                "The Hobbit: The Battle of the Five Armies",
                "The Lord of the Rings: The Fellowship of the Ring",
                "The Lord of the Rings: The Two Towers",
                "The Lord of the Rings: The Return of the King",
                "The Silmarillion",
                "Alice in Wonderland",
                "Alice Through the Looking Glass",
                "Charlie and the Chocolate Factory",
                "Corpse Bride",
                "Matilda",
                "James and the Giant Peach",
                "The BFG",
                "Coraline",
                "Mary Poppins",
                "Mary Poppins Returns",
                "Beauty and the Beast",
                "The Little Mermaid",
                "Cinderella",
                "Sleeping Beauty",
                "Snow White and the Seven Dwarfs",
                "The Jungle Book",
                "Aladdin",
                "Mulan",
                "Pocahontas",
                "The Lion King",
                "Frozen",
                "Tangled",
                "Moana",
                "Toy Story",
                "Toy Story 2",
                "Toy Story 3",
                "Finding Nemo",
                "The Incredibles",
                "Ratatouille",
                "WALL-E",
                "Up",
                "Inside Out",
                "Coco",
                "Cars",
                "Monsters, Inc.",
                "Brave",
                "Zootopia",
                "Shrek",
                "Shrek 2",
                "Shrek the Third",
                "Shrek Forever After",
                "Despicable Me",
                "Despicable Me 2",
                "Despicable Me 3",
                "Minions",
                "The Secret Life of Pets",
                "Finding Dory",
                "The Lego Movie",
                "The Lego Batman Movie",
                "The Lego Ninjago Movie",
                "The Lego Movie 2: The Second Part",
                "Ice Age",
                "Ice Age: The Meltdown",
                "Ice Age: Dawn of the Dinosaurs",
                "Ice Age: Continental Drift",
                "Ice Age: Collision Course",
                "Madagascar",
                "Madagascar: Escape 2 Africa",
                "Madagascar 3: Europe's Most Wanted",
                "Penguins of Madagascar",
                "Kung Fu Panda",
                "Kung Fu Panda 2",
                "Kung Fu Panda 3",
                "How to Train Your Dragon",
                "How to Train Your Dragon 2",
                "How to Train Your Dragon: The Hidden World",
                "The Boss Baby",
                "Trolls",
                "Trolls World Tour",
                "Sing",
                "Zootopia",
                "Zootopia",
                "Ratatouille",
                "Finding Nemo",
                "Inside Out",
                "Up",
                "Toy Story",
                "The Incredibles",
                "Monsters, Inc.",
                "Frozen",
                "Coco",
                "Moana",
                "Aladdin",
                "The Lion King",
                "The Little Mermaid",
                "Beauty and the Beast",
                "Mulan",
                "Pocahontas",
                "Cinderella",
                "Snow White and the Seven Dwarfs",
                "Sleeping Beauty",
                "Brave",
                "Tangled",
                "The Princess and the Frog",
                "Wreck-It Ralph",
                "Big Hero 6",
                "Zootopia",
                "Frozen II",
                "Raya and the Last Dragon",
                "Soul",
                "The Lego Movie",
                "The Lego Batman Movie",
                "The Lego Ninjago Movie",
                "The Lego Movie 2: The Second Part",
                "Ice Age",
                "Ice Age: The Meltdown",
                "Ice Age: Dawn of the Dinosaurs",
                "Ice Age: Continental Drift",
                "Ice Age: Collision Course",
                "Madagascar",
                "Madagascar: Escape 2 Africa",
                "Madagascar 3: Europe's Most Wanted",
                "Madagascar 4",
                "Shrek",
                "Shrek 2",
                "Shrek the Third",
                "Shrek Forever After",
                "Kung Fu Panda",
                "Kung Fu Panda 2",
                "Kung Fu Panda 3",
                "How to Train Your Dragon",
                "How to Train Your Dragon 2",
                "How to Train Your Dragon 3",
                "Penguins of Madagascar",
                "Trolls",
                "Trolls World Tour",
                "Sing",
                "Despicable Me",
                "Despicable Me 2",
                "Despicable Me 3",
                "Minions",
                "The Secret Life of Pets",
                "The Secret Life of Pets 2",
                "The Grinch",
                "The Lorax",
                "Horton Hears a Who!",
                "Cars",
                "Cars 2",
                "Cars 3",
                "Monsters, Inc.",
                "Monsters University",
                "Finding Nemo",
                "Finding Dory",
                "The Incredibles",
                "The Incredibles 2",
                "Ratatouille",
                "Brave",
                "Up",
                "Wall-E",
                "Inside Out",
                "Coco",
                "Moana",
                "Zootopia",
                "Big Hero 6",
                "Wreck-It Ralph",
                "Tangled",
                "Frozen",
                "Frozen II",
                "Toy Story",
                "Toy Story 2",
                "Toy Story 3",
                "Toy Story 4",
                "Shrek",
                "Shrek 2",
                "Shrek the Third",
                "Shrek Forever After",
                "Despicable Me",
                "Despicable Me 2",
                "Despicable Me 3",
                "Minions",
                "The Secret Life of Pets",
                "The Secret Life of Pets 2",
                "Sing",
                "The Lorax",
                "The Grinch",
                "Ice Age",
                "Ice Age: The Meltdown",
                "Ice Age: Dawn of the Dinosaurs",
                "Ice Age: Continental Drift",
                "Ice Age: Collision Course",
                "Madagascar",
                "Madagascar: Escape 2 Africa",
                "Madagascar 3: Europe's Most Wanted",
                "Penguins of Madagascar",
                "Kung Fu Panda",
                "Kung Fu Panda 2",
                "Kung Fu Panda 3",
                "How to Train Your Dragon",
                "How to Train Your Dragon 2",
                "How to Train Your Dragon 3",
                "Cars",
                "Cars 2",
                "Cars 3",
                "Monsters, Inc.",
                "Monsters University",
                "Finding Nemo",
                "Finding Dory",
                "The Incredibles",
                "The Incredibles 2",
                "Ratatouille",
                "Brave",
                // Add more movie names here
            }; // Dummy movie array used for testing
        static MovieCollection movies = new MovieCollection(1000);
        static MemberCollection members = new MemberCollection();
        static private string password = "staff";
        static private Member currentMember = null;
        static int Display(string title, string[] options)
        {
            bool valid = false;
            int option;
            Clear();
            WriteLine(title);
            WriteLine(
                "---------------------------------------------------------\n" +
                "Select from the following:\n"
                );
            for (int i = 0; i < options.Length; i++) // Display options
            {
                WriteLine($"{i + 1}. {options[i]}");
            }
            do
            {
                Write("Enter your choice ==> ");
                if (!int.TryParse(ReadLine(), out option)) // If not number
                    WriteLine("Invalid");
                else if (option > options.Length || option <= 0) // If number not witthin selections
                    WriteLine($"Enter a number from 1 to {options.Length}");
                else
                    valid = true;
            } while (!valid); // Loop until valid value entered
            return option; // return selected value
        }
        static void MainMenu()
        {
            bool end = false;
            string[] options = { "Staff", "Member", "End the program" };
            string title =
                "========================================================\n" +
                "COMMUNITY LIBRARY MOVIE DVD MANAGEMENT SYSTEM\n" +
                "========================================================\n" +
                "\n" +
                "Main Menu\n";
            while (!end) // While end not selected
            {
                int option = Display(title, options);
                switch (option)
                {
                    case 1: // Staff Login
                        StaffLogin();
                        break;
                    case 2: // Member Login
                        MemberLogin();
                        break;
                    case 3: // End
                        end = true;
                        break;
                }
            }
            Clear();
            WriteLine("See you!");
        }
        static void StaffLogin()
        {
            Clear();
            string title =
               "========================================================\n" +
               "STAFF LOGIN\n" +
               "========================================================\n";
            WriteLine(title);
            Write("Enter password ==> ");
            string input = ReadLine();
            if (input != password)
            {
                WriteLine("Incorrect Password\nPress any key to continue...");
                ReadLine();
                return;
            }
            StaffMenu();
        }
        static void StaffMenu()
        {
            bool end = false;
            string[] options =
            {
                "Add DVDs of a new movie to the system",
                "Add new DVDs of an existing movie to the system",
                "Remove DVDs of an existing movie from the system",
                "Register a new member to the system",
                "Remove a registered member from the system",
                "Find a member's contact phone number, given the member's name",
                "Find members who are currently renting a particular movie",
                "Return to Main Menu"
            };
            string title = "Staff Menu\n";
            while (!end)
            {
                int option = Display(title, options);
                switch (option)
                {
                    case 1: // Add DVDs of a new movie to the system
                        movies.AddNewMovie();
                        break;
                    case 2: // Add new DVDs of an existing movie to the system
                        movies.AddExistingMovie();
                        break;
                    case 3: // Remove DVDs of an existing movei from the system
                        movies.RemoveMovie();
                        break;
                    case 4: // Register a new member to the system
                        members.AddMember();
                        break;
                    case 5: // Remove a registered member from the system
                        members.RemoveMember();
                        break;
                    case 6: // Find a member's contact phone number, given the member's name
                        members.FindMemberPhone();
                        break;
                    case 7: // Find members who are currently renting a particular movie
                        Movie movie = movies.Retrieve();
                        if (movie != null)
                            members.FindRentingMembers(movie);
                        break;
                    case 8:
                        end = true;
                        break;
                }
            }
        }
        static void MemberLogin()
        {
            Clear();
            string title =
               "========================================================\n" +
               "MEMBER LOGIN\n" +
               "========================================================\n";
            WriteLine(title);
            Write("Enter name ==> ");
            string name = ReadLine();
            Write("Enter password ==> ");
            string password = ReadLine();
            Member member = members.Login(name, password);
            if (member == null)
            {
                WriteLine("Incorrect Name or Password\nPress any key to continue...");
                ReadLine();
                return;
            }
            currentMember = member;
            WriteLine($"Welcome {name}!");
            WriteLine("Press any key to continue...");
            ReadLine();
            MemberMenu();
        }
        static void MemberMenu()
        {
            bool end = false;
            string[] options =
            {
                "Browse all the movies",
                "Display all the information about a movie, given the title of the movie",
                "Borrow a movie DVD",
                "Return a movie DVD",
                "List current borrowing movies",
                "Display the top 3 movies rented by members",
                "Return to main menu"
            };
            string title = $"Member Menu | User: {currentMember.GetName()}\n";
            while (!end)
            {
                int option = Display(title, options);
                switch (option)
                {
                    case 1: // Browse all the movies
                        movies.DisplayInfoAll();
                        break;
                    case 2: // Display all the information about a movie
                        movies.DisplayInfo();
                        break;
                    case 3: // Borrow a movie DVD
                        movies.Borrow(currentMember);
                        break;
                    case 4: // Return a movie DVD
                        movies.Return(currentMember);
                        break;
                    case 5: // List curernt borrowing movies
                        currentMember.DisplayLoan();
                        break;
                    case 6: // Dispaly the top 3 movies rented by members
                        movies.DisplayInfoTop3();
                        break;
                    case 7: // End
                        currentMember = null;
                        end = true;
                        break;
                }
            }
        }
        /// <summary>
        /// Test function that check duplicate hashes from a string array.
        /// </summary>
        static void HashTest(string[] arr)
        {
            HashSet<int> hashedValues = new HashSet<int>();
            int duplicatesCount = 0;

            foreach (string title in arr.Distinct())
            {
                byte[] asciiBytes = Encoding.ASCII.GetBytes(title);
                int ascii = 0;
                int prime = 31;

                for (int i = 0; i < asciiBytes.Length; i++)
                {
                    ascii += asciiBytes[i] * prime ^ i; // Less duplication
                    //ascii += asciiBytes[i]; // High chance of duplication
                }
                int M = 1000;
                ascii = ascii % M;

                if (!hashedValues.Add(ascii))
                {
                    duplicatesCount++;
                    WriteLine($"Duplicate movie: {title} {ascii}");
                }
                else
                {
                    WriteLine($"Unique movie: {title} {ascii}");
                }
            }

            WriteLine($"Total duplicates found: {duplicatesCount}/{arr.Distinct().Count()}");
        }
        static void Main(string[] args)
        {
            //HashTest(mov);
            MainMenu(); // Start Application

        }
    }
}
