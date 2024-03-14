# Movie Database
The project is about developing a software application for a community library that manages movie DVDs. The library is renting out DVDs to a registered member. This software is required to store movies and registered members with the appropriate data structures.

## Requirements
### Movie Class
This class is a class where each movie object will represent a movie. The object will include information such as the title, genre, classification and the duration in minutes.

### MovieCollection Class
This class is a class that stores movies (Movie object). The data structure will be a custom made hashtable where the key being the 􀆟title of the movie and the value being the Movie object. It is assumed that the maximum number of movies will be 1000.

### Member Class
This is a class where each member object will represent a member. The member object will include information such as their name, phone number and the four-digit pin number to access their account.

### MemberCollection Class
This class stores registered members as a Member object. The basic data structure will be an array.

### Staff Menu
- Add DVDs of a new movie to the system
- Add DVDs of an exis􀆟ng movie to the system
- Remove DVDs of a movie from the system – if all the DVDs of a movie are removed, the movie should also be removed from the system
- Register a new member with the system. When a member is being registered via a staff member, a four-digit password is set for the member
- Remove a registered member from the system
- Find a member’s contact phone number, given the member’s full name
- Find all the members who are currently renting a particular movie

### Member Menu
- Display all the information about all the movie DVDs in dictionary order of the movie title, including the number of the movie DVDs currently in the community library
- Display the information about a movie, given the title of the movie DVD
- Return a movie DVD to the community library, given the title of the movie DVD
- List current movie DVDs that are currently borrowing by the registered member
- Display the top three most frequently borrowed movie DVDs by the members in the descending order of their frequency. The display should include the title of the movie and frequency.
 
## Data Structure
### Movie Collection
The movie collection stores movies as a hash table. When adding a new movie to the collection, the title of the movie will be hashed using a hash function. This hash function will generate an integer which will the index of where the movie will be stored. The movie will be stored in a node which will be linked to a bucket. These buckets are located in each storage of the movie collection. For instance, if we were to create a movie collection with 1000 slots, there will be 1000 buckets in total. Each bucket will contain the same amount of nodes as the amount of movies stored.

### Member Collection
The member collection stores members in a list style. Although the base data structure is an array the difference between an array is that is dynamic as it resizes automatically when required. When adding a new member to the collection, the members will be added to the end of the array. Once the array is full and more members are added, the program will create an array that has a doubled size of the original array then copies the original content to the new array. When a member is deleted, all of the other member object will shift within the array to fill in the gap.

## Hashing and Collision
### String to Int
To hash the movie title, it was required to first convert a string into integers. This was done by getting the sum of the ASCII codes of each character in the string. To avoid creating duplicates for strings such as 'abc', 'bac' and 'cba', I have multiplied each code by a prime number which is raised to the power of the index. Therefore, string that contains same characters but in different orders will generate a different integer compared to a simple ASCII code sum.
```C#
byte[] asciiBytes = Encoding.ASCII.GetBytes(title);
int ascii = 0;
int prime = 31;
for (int i = 0; i < asciiBytes.Length; i++)
{
    ascii += asciiBytes[i] * prime ^ i;
}
```

### Int to Hash
After obtaining the transformed movie titles, I have hashed the integers using division method. Division method offers a well distributed hashed key for the given divisor which in this case will be the maximum size of the collection. With the original integer being unique, will be able to reduce the chances of collisions. Another reason for the division method is due to its computational efficiency which only involves a simple division operation. Therefore with this method, the generated keys will be distributed evenly while reducing collisions and being computationally efficient.
```C#
private int Hash(string title)
{
    byte[] asciiBytes = Encoding.ASCII.GetBytes(title);
    int ascii = 0;
    int prime = 31;
    for (int i = 0; i < asciiBytes.Length; i++)
    {
        ascii += asciiBytes[i] * prime ^ i;
    }
    int M = size;
    int key = ascii % M; // Division method
    return key;
}
```

### Collision
To handle with collisions, I have chosen to take the separate chaining method which I have created a linked list for each location of the storage. Although the requirements for this project includes assumption of having maximum 1000 movies in a collection, it can be assumed that there will be many collisions occurring by the time the collection is full. With open addressing technique, the efficiency of the hash table may drastically reduce when collection is near full to linear time O(n) which will be difficult to maintain the strength of hash tables being constant time O(1). Separate changing on the other hand, will also have similar issues although average search time of each linked list compared to the whole collection will be relatively small, keeping the efficiency of the hash table relatively close to O(1).

## Exception Handling and Validation
The program handles exceptions through validation logic in properties. For instance, the movie class properties such as the inventory count, stock count, duration and the view count is equipped with validation logic to avoid invalid values being assigned. Following are the example for inventory count, stock count and view count validation logic.
```C#
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
```
As the validation logic in properties uses Argument Exception which could terminate the program, a pre validation logic is implemented before the value is been sent to the class properties. This will alert the users before the values been sent, avoiding termination of the program. The validation logic in the class properties are there for extra cover as for instance stock count shouldn’t exceed the inventory count or any of the inventory, stock and view count shouldn’t be a number lower than 0.
Validation logics are also implemented in methods which require user input such as options selection in menus. The following are an example validation logic used when displaying user menus.
```C#
do
{
    Write("Enter your choice ==> ");
    if (!int.TryParse(ReadLine(), out option)) // If not number
        WriteLine("Invalid");
                else if (option > options.Length || option <= 0) // If number not witthin selections
        WriteLine($"Enter a number from 1 to {options.Length}");
    else
        valid = true;
} while (!valid);
return option;
```
With these validation logics, user will be able to receive clear and correct error messages, rather than the program simply terminating.
