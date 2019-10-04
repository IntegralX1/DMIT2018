<Query Kind="Program">
  <Connection>
    <ID>75baaaef-b5fb-4b1a-a673-f8768ef58ae9</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

void Main()
{
	
}

//to display the artists name
//shows only the title, artist name, release year and release label
//use the navigational properties to obtain the artist data.
//new {...} creates a new dataset (class definition) a POCO which is a class, which is a flat dataset
//that describes fields in multiple tables.

//when using the language c# statement(s)
//your work will need to confirm C# statement syntax
//ie datatype variable  = expression; 

var results = from x in Albums
				where x.Artist.Name.Equals("Deep Purple")
				orderby x.ReleaseYear, x.Title
				select new 
				{
					Title = x.Title, 
					ArtistName = x.Artist.Name, 
					RYear = x.ReleaseYear,
					RLable = x.ReleaseLabel
				};
				
//to display the contents of a variable in linqpad
//use the method .Dump()
//this method is only used in LinqPad, it is NOT a C# method
results.Dump();

//CREATE A list of all customers in alaphabetic order by lastname, firstname
//who live in the US with a yahoo email account. List full name (last, first), city
//state and email only. Create the class definition of this list.

var customerlist = from x in Customers
				  where x.Country.Equals("USA")
				  && x.Email.Contains("yahoo.com")
				  orderby x.LastName, x.FirstName
				select new YahooCustomers 
				{
   					Name = x.LastName + ", " + x.FirstName,
					City = x.City,
					State = x.State,
					Email = x.Email
				};
				
				//customerlist.Dump();

public class YahooCustomers
{
   public string Name {get; set;}
   public string City {get; set;}
   public string State {get; set;}
   public string Email {get; set;}
}

//Who is the artist who sang rag Doll (track). List the artist Name,
//the album title, release year and label, along with the song (track) composer.

var whosang = from x in Tracks
				where x.Name.Equals("Rag Doll")
				select new
				{
				//each dot represents the INSTANCE of an OBJECT
				//you can access the parent and child tables of an entity
				//through the navigational properties (objects) of each entity
					ArtistName = x.Album.Artist.Name,
				   Title = x.Album.Title,
				   RYear = x.Album.ReleaseYear,
				   Label = x.Album.ReleaseLabel,
				   Composer = x.Composer
				};
	