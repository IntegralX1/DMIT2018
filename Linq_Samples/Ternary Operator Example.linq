<Query Kind="Statements">
  <Connection>
    <ID>75baaaef-b5fb-4b1a-a673-f8768ef58ae9</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//create a list of albums released in 2001
//list the album title, artist name, label 
//if the release label is 'null' use the string Unkown, or something else.


var results = from x in Albums
			where x.ReleaseYear.Equals(2001)
			select new
			{
			  Title = x.Title,
			  Artist = x.Artist.Name,
			  //A turnary operator works as an if/else statement
			  RLabel = x.ReleaseLabel == null ? "Santa's Classic Albums" : x.ReleaseLabel,
			  RYear = x.ReleaseYear
			
			};
			results.Dump();
			
//list of all albums specifying if they were released in the 70's, 80's, 90's or > 2000 as modern
//list the title and decade

var moreResults = from x in Albums
				  where x.ReleaseYear >= 1970 && x.ReleaseYear <= 2019
				  orderby x.ReleaseYear ascending
				  select new
				  {
				     Title = x.Title,
					 ReleaseYear = x.ReleaseYear > 1969 & x.ReleaseYear < 1980 ? "70s" : 
					 x.ReleaseYear > 1979 & x.ReleaseYear < 1990 ? "80s" : 
					 x.ReleaseYear > 1989 & x.ReleaseYear < 2000 ? "90s" : "Modern"
				  }
				  
				  moreResults.Dump();