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
	string artistname = "Deep Purple";
	var results = from x in Albums
				where x.Artist.Name.Equals(artistname)
				orderby x.ReleaseYear, x.Title
				select new AlbumsOfArtist
				{
					Title = x.Title, 
					ArtistName = x.Artist.Name, 
					RYear = x.ReleaseYear,
					RLabel = x.ReleaseLabel
				};
				
//to display the contents of a variable in linqpad
//use the method .Dump()
//this method is only used in LinqPad, it is NOT a C# method
results.Dump();
}

// Define other methods and classes here
public class AlbumsOfArtist
{
	public string Title {get; set;}
	public string Artist {get; set;}
	public int RYear {get; set;}
	public string RLabel {get; set;}
	public string ArtistName {get; set;}
}