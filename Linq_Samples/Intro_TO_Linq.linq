<Query Kind="Expression">
  <Connection>
    <ID>75baaaef-b5fb-4b1a-a673-f8768ef58ae9</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
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

from whatever in Artists 
where whatever.Name.Contains("son")
select whatever

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
