<Query Kind="Expression">
  <Connection>
    <ID>75baaaef-b5fb-4b1a-a673-f8768ef58ae9</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//aggregates are executed against a collection of records
// Count(); .Sum(); 
//.Min(x => x.field); .Max(x => x.field); .Average(x => x.field);

from x in Albums
where x.Tracks.Count() > 25
select new
{
	title = x.Title,
	artist = x.Artist.Name,
	trackcount = x.Tracks.Count(),
	playtime = x.Tracks.Sum(z => z.Milliseconds),
	tracks = from y in x.Tracks
		     select new
			 {
			 	name = y.Name,
				genre = y.Genre.Name,
				length = y.Milliseconds / 60000
				
			 }
}