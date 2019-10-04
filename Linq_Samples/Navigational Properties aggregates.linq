<Query Kind="Statements">
  <Connection>
    <ID>75baaaef-b5fb-4b1a-a673-f8768ef58ae9</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

var playlist = from x in Playlists
			   where x.PlaylistTracks.Count() > 0
			   select new 
			   {
			      name = x.Name,
				  unitPrice = x.PlaylistTracks.Sum(y => y.Track.UnitPrice),
				  dataSize = x.PlaylistTracks.Sum(z => z.Track.Bytes / 1000000.0),
				  trackCount = x.PlaylistTracks.Count()
			   };
			   
			   
			   playlist.Dump();
				
				
				
				
//list all albums with tracks showing the album title, artist name, number of tracks
// and the album cost.

var albumList = from x in Albums
				where x.Tracks.Count() > 0
				select new
				{
				   title = x.Title,
				   artist = x.Artist.Name,
				   trackCount = x.Tracks.Count()
				};
				
				albumList.Dump();
				
//What is the artist with the maximum count of albums
//create a list of all the albums by artist
var albumList2 = from x in Albums
				 select new
				 {
				 	Title = x.Title,
				    ArtistName = x.Artist.Name,
					TracksCount = x.Tracks.Count()
				 
				 };
				 
				 albumList2.Dump();
				 
var maxCount = (Artists.Select(x => x.Albums.Count())).Max();
maxCount.Dump();