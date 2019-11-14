<Query Kind="Statements">
  <Connection>
    <ID>e52ae3b7-5727-4a23-93cf-dcb04678a0c5</ID>
    <Server>.</Server>
    <Database>Chinook</Database>
    <ShowServer>true</ShowServer>
  </Connection>
</Query>

//simplest grouping method
//the selected grouping field is referred to as the group key
from x in Tracks
group x by x.GenreId

//group record collection using multiple fields on the record
//the multiple fields become a group key instance
//referring to a property in the group key instance is by key.property
from x in Tracks
group x by new {x.GenreId, x.MediaTypeId}

//reporting from a group
//place a grouping of a large data selection into a temporary datacollection
//any further reporting on the groups within the temporary datacollection will use the
// temporary datacollection name as its datasource
from x in Tracks
group x by x.GenreId into gGenre
select (gGenre)

//details on each group
from x in Tracks
group x by x.GenreId into gGenre
select new
{
	groupid = gGenre.Key,
	tracks = gGenre.ToList() 
}

//selected fields from within each grou

from x in Tracks
group x by x.GenreId into gGenre
select new
{
	trackid = x.TrackId,
	song = x.Name,
	songlength = x.Milliseconds / 1000000.0
}

from x in Tracks
group x by x.GenreId into gGenre
select new
{
	trackid = x.TrackId,
	song = x.Name,
	artist = x.Album.Artist.Name,
	songlength = x.Milliseconds / 1000000.0
}


//refer to a specific key property
from x in Tracks
group x by new {x.GenreId, x.MediaTypeId} into gTracks
select new
{
genre = gTracks.Key.GenreId,
media = gTracks.Key.Name,
trackcount = gTracks.Count()
}

//group by class
from x in Tracks
group x by x.Genre into gTracks
select (gTracks)

//
from x in Tracks
group x by new {x.GenreId, x.MediaTypeId} into gTracks
select new
{

genre = gTracks.Key.GenreId,
media = gTracks.Key,
trackcount = gTracks.Count()

}

//create a list of albums by release year
// showing the year, number of albums in that year, album title and count of tracks.

from x in Albums
group x by x.ReleaseYear into aList
select new 
{
releaseYear = aList.Key,
albumCount = aList.Count(),
anAlbum = from y in aList 
		  select new
		  {
		    title = y.Title,
			trackCount = (from t in y.Tracks select t).Count()
		  	
		  }
}

//order the previous report by the number of albums per year decending
//tip once you have the group, all further clauses are against the group
from x in Albums
group x by x.ReleaseYear into aList
orderby aList.Count() descending
select new
{
	releaseYear = aList.Key,
	albumCount = aList.Count(),
	anAlbum = from y in aList 
		  select new
		  {
		    title = y.Title,
			trackCount = (from t in y.Tracks select t).Count()
		  	
		  }
}

//order within count by year ascending

from x in Albums
group x by x.ReleaseYear into aList
orderby aList.Count() ascending, aList.Key
select new
{
	releaseYear = aList.Key,
	albumCount = aList.Count(),
	anAlbum = from y in aList 
		  select new
		  {
		    title = y.Title,
			trackCount = (from t in y.Tracks select t).Count()
		  	
		  }
}

//select within a range of years
from x in Albums
//where x.ReleaseYear >= 1990 >>> another method
group x by x.ReleaseYear into aList
orderby aList.Count() ascending, aList.Key
where aList.Key >= 1990
select new
{
	releaseYear = aList.Key,
	albumCount = aList.Count(),
	anAlbum = from y in aList 
		  select new
		  {
		    title = y.Title,
			trackCount = (from t in y.Tracks select t).Count()
		  	
		  }
}