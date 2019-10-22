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
            //code to go here
 
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
            //code to go here
            
        }

    }
}