<Query Kind="Expression">
  <Connection>
    <ID>fbb61d69-118b-4bb3-a792-af6176680921</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//sample of query syntax to dump the artist data.
from x in Artists
select x

//sample of method syntax to dump the artist data.
Artists.Select (x => x)

//sort datainfo.sort((x,y) => x.AttributeName.CompareTo(y.AttributeName))

//find any artist whose name contains the string 'son'
//query syntax

from x in Artists 
where x.Name.Contains("son")
select x

//method syntax
Artists
	.Where(whatever => whatever.Name.Contains("son"))
	.Select(whatever => whatever)
	
//create a list of albums released in 1970
//orderby title
Albums
	.Where (x => x.ReleaseYear == 1970)
	.OrderBy(x => x.Title)
	.Select (x => x)
	
from x in Albums
where x.ReleaseYear == 2000
orderby x.Title
select x

//creat a list of albums between 2007 and 2018
from x in Albums
where x.ReleaseYear >= 2007 && x.ReleaseYear <= 2018
orderby x.ReleaseYear, x.Title
select x

//decending order
from x in Albums
where x.ReleaseYear >= 2007 && x.ReleaseYear <= 2018
orderby x.ReleaseYear descending, x.Title
select x

//note the difference in method names using the method syntax
//a descending orderby is .OrderByDescending
//secondary and beyond ordering is .ThenBy

Albums
   .Where (x => ((x.ReleaseYear >= 2007) && (x.ReleaseYear <= 2018)))
   .OrderByDescending (x => x.ReleaseYear)
   .ThenBy (x => x.Title)
   
//Can navigational properties be used in queries?
//Create a list of albums by Deep Purple 
//order by release year and title
from x in Albums
where x.Artist.Name.Contains("Deep Purple")
orderby x.ReleaseYear, x.Title
select x

//to display the artists name
//shows only the title, artist name, release year and release label
//use the navigational properties to obtain the artist data.
//new {...} creates a new dataset (class definition) a POCO which is a class, which is a flat dataset
//that describes fields in multiple tables.
from x in Albums
where x.Artist.Name.Equals("Deep Purple")
orderby x.ReleaseYear, x.Title
select new 
{
	Title = x.Title, 
	ArtistName = x.Artist.Name, 
	RYear = x.ReleaseYear,
	RLable = x.ReleaseLabel
}