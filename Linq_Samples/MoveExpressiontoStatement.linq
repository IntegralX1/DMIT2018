<Query Kind="Statements">
  <Connection>
    <ID>75baaaef-b5fb-4b1a-a673-f8768ef58ae9</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>


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