<Query Kind="Statements">
  <Connection>
    <ID>75baaaef-b5fb-4b1a-a673-f8768ef58ae9</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>


//get a list showing the track length average

var results = (from x in Tracks
			select x.Milliseconds).Average();	
			
	results.Dump();
	
	var resultsreport = from x in Tracks
						select new
						{
							song = x.Name,
							length = x.Milliseconds,
							LongShortAvg = x.Milliseconds > results ? "Long" : x.Milliseconds < results ? "Short" : "Average"
						};
		resultsreport.Dump(); 