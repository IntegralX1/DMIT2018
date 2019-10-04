<Query Kind="Expression">
  <Connection>
    <ID>75baaaef-b5fb-4b1a-a673-f8768ef58ae9</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//create a list of all albums containing the album title and artist
//along with all the tracks (including song name, genre, length) of that album
//a list within a list

from x in Albums
select new
{
	title = x.Title,
	artist = x.Artist.Name,
	tracks = from y in x.Tracks
		     select new
			 {
			 	name = y.Name,
				genre = y.Genre.Name,
				length = y.Milliseconds
				
			 }
}

from x in Albums
select new
{
	title = x.Title,
	artist = x.Artist.Name,
	tracks = from y in Tracks
		     where x.AlbumId == y.AlbumId
		     select new
			 {
			 	name = y.Name,
				genre = y.Genre.Name,
				length = y.Milliseconds
				
			 }
}

