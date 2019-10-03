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
	var results = from x in Albums
					where x.Tracks.Count() > 25
					select new AlbumDTO
					{
						Albumtitle = x.Title,
						AlbumArtist = x.Artist.Name,
						TrackCount = x.Tracks.Count(),
						PlayTime = x.Tracks.Sum(z => z.Milliseconds),
						AlbumTracks = (from y in x.Tracks
							     select new TrackPOCO
								 {
								 	SongName = y.Name,
									SongGenre = y.Genre.Name,
									SongLength = y.Milliseconds
									
								 }).ToList()
					};
results.Dump();
}

public class TrackPOCO
{
	public string SongName {get; set;}
	public string SongGenre {get; set;}
	public int SongLength {get; set;}
}

public class AlbumDTO 
{
	public string Albumtitle {get; set;}
	public string AlbumArtist {get; set;}
	public int TrackCount {get; set;}
	public int PlayTime {get; set;}
	public List<TrackPOCO> AlbumTracks {get; set;}
}
// Define other methods and classes here
