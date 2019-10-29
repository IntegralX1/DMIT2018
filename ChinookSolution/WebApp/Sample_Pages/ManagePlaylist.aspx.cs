using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additonal Namespaces
using ChinookSystem.BLL;
using ChinookSystem.Data.POCOs;
#endregion

namespace Jan2018DemoWebsite.SamplePages
{
    public partial class ManagePlaylist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TracksSelectionList.DataSource = null;
        }

        protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
        {
            messageUserControl.HandleDataBoundException(e);
        }

        protected void ArtistFetch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ArtistName.Text))
            {
                messageUserControl.ShowInfo("Missing Data", "Enter a partial artist name.");

            }
            else
            {
                messageUserControl.TryRun(() =>
                {
                    SearchArg.Text = ArtistName.Text;
                    TracksBy.Text = "Artist";
                    TracksSelectionList.DataBind(); //causes the ODS to execute

                }, "Track Search", "Select from the following list to add to your playlist."); 
            }

        }

        protected void MediaTypeFetch_Click(object sender, EventArgs e)
        {
           
                messageUserControl.TryRun(() =>
                {
                    SearchArg.Text = MediaTypeDDL.SelectedValue;
                    TracksBy.Text = "MediaType";
                    TracksSelectionList.DataBind(); //causes the ODS to execute

                }, "Track Search", "Select from the following list to add to your playlist.");
            

        }

        protected void GenreFetch_Click(object sender, EventArgs e)
        {

            messageUserControl.TryRun(() =>
            {
                SearchArg.Text = GenreDDL.SelectedValue;
                TracksBy.Text = "Genre";
                TracksSelectionList.DataBind(); //causes the ODS to execute

            }, "Track Search", "Select from the following list to add to your playlist.");

        }

        protected void AlbumFetch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AlbumTitle.Text))
            {
                messageUserControl.ShowInfo("Missing Data", "Enter a partial album title.");

            }
            else
            {
                messageUserControl.TryRun(() =>
                {
                    SearchArg.Text = AlbumTitle.Text;
                    TracksBy.Text = "Album";
                    TracksSelectionList.DataBind(); //causes the ODS to execute

                }, "Album Search", "Select from the following list to add to your playlist.");
            }

        }

        protected void PlayListFetch_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(PlaylistName.Text))
            {
                messageUserControl.ShowInfo("Required Data", "Play list name is required to fetch a play list");
            }
            else
            {
                string playlistname = PlaylistName.Text;
                //Until we do security, we will use a hard coded username.
                string username = "HansenB";

                //do a standard query lookup to your controller
                //use messageUserControl for error handling
                messageUserControl.TryRun(() => {
                    PlaylistTracksController sysmgr = new PlaylistTracksController();
                    List<UserPlaylistTrack> datainfo = sysmgr.List_TracksForPlaylist(playlistname, username);
                    PlayList.DataSource = datainfo;
                    PlayList.DataBind();

                }, "Playlist Tracks", "See current tracks on playlist below");
            }
        }

        protected void MoveDown_Click(object sender, EventArgs e)
        {
            //code to go here
 
        }

        protected void MoveUp_Click(object sender, EventArgs e)
        {
            //code to go here
 
        }

        protected void MoveTrack(int trackid, int tracknumber, string direction)
        {
            //call BLL to move track
 
        }


        protected void DeleteTrack_Click(object sender, EventArgs e)
        {
            //code to go here
 
        }

        protected void TracksSelectionList_ItemCommand(object sender, 
            ListViewCommandEventArgs e)
        {
            //do we have the playlist name?
            if (string.IsNullOrEmpty(PlaylistName.Text))
            {
                messageUserControl.ShowInfo("Required data", "Playlist name is required to add a track");

            }
            else
            {
                //collect the required data for the event
                string playlistname = PlaylistName.Text;
                //the user name will come from the security form, which we don't have at this point.
                //we will use a hard coded string instead for HansenB
                string username = "HansenB";
                //obtain the track id from the ListView
                //the track id will be in the commandArg property of the
                // ListViewCommandEventArgs e instance
                //the commandarg in e is returned as an object and 
                //needs to be cast as a string in order to parse it as an int.
                int trackid = int.Parse(e.CommandArgument.ToString());

                //using the obtained data, issue your call to the BLL method.
                //this work will be done within a TryRun() as we need some error handling
                messageUserControl.TryRun(() =>
                {
                    PlaylistTracksController sysmgr = new PlaylistTracksController();
                    //there is only one call to add the data to the database
                    sysmgr.Add_TrackToPLaylist(playlistname, username, trackid);
                    //refresh the playlist is a READ only.
                    List<UserPlaylistTrack> datainfo = sysmgr.List_TracksForPlaylist(playlistname, username);
                    PlayList.DataSource = datainfo;
                    PlayList.DataBind();
                }, "Adding a Track", "Track has been added to the playlist");


            }

        }

    }
}