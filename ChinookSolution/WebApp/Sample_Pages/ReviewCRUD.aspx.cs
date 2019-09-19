using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


#region Additional Namespaces

using ChinookSystem.BLL;
using ChinookSystem.Data.Entities;

#endregion
namespace WebApp.Sample_Pages
{
    public partial class ReviewCRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindArtistList();
                //Set the max value for the validation control
                //RangeEditReleaseYear
                RangeEditReleaseYear.MaximumValue = DateTime.Today.Year.ToString();
            }
        }

        protected void BindArtistList()
        {
            ArtistController sysmgr = new ArtistController();
            List<Artist> info = sysmgr.Artists_List();
            info.Sort((x, y) => x.Name.CompareTo(y.Name));
            ArtistList.DataSource = info;
            ArtistList.DataTextField = nameof(Artist.Name);
            ArtistList.DataValueField = nameof(Artist.ArtistId);
            ArtistList.DataBind();
            //ArtistList.Items.Insert(0, "select...");
        }

        //in code behind to be called from ODS
        protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
        {
            messageUserControl.HandleDataBoundException(e);
        }

        protected void AlbumList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //standard lookup/query

            //get data from the gridview line that was selected
            GridViewRow agvrow = //pointer to the gridview row that we want to look at 
                AlbumList.Rows[AlbumList.SelectedIndex];

            //retreive the value from a web control located within 
            //the GridView cell

            //gets contents within a cell on a webcontrol with type specification ending in
            //the proper access technique.
            string albumid = (agvrow.FindControl("AlbumId") as Label).Text;
            messageUserControl.TryRun(() =>
            {
                AlbumController sysmgr = new AlbumController();
                Album datainfo = sysmgr.Album_Get(int.Parse(albumid));
                if (datainfo == null)
                {
                    ClearControls();
                    //throw an exception at dem bitchez
                    throw new Exception("Record no longer exists on file.");

                }
                else
                {
                    EditAlbumID.Text = datainfo.AlbumId.ToString();
                    EditTitle.Text = datainfo.Title;
                    EditAlbumArtistList.SelectedValue = datainfo.ArtistId.ToString();
                    EditReleaseYear.Text = datainfo.ReleaseYear.ToString();
                    EditReleaseLabel.Text =
                        datainfo.ReleaseLabel == null ? "" : datainfo.ReleaseLabel;
                }
            },"Find Album", "Album found"); //Title and success message

            //error handling will need to be added (later).
            //The standard lookup is connecting to the controller
           
        }

        protected void AlbumListODS_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {

        }

        protected void ClearControls()
        {
            EditAlbumID.Text = "";
            EditTitle.Text = "";
            EditReleaseYear.Text = "";
            EditReleaseLabel.Text = "";
            EditAlbumArtistList.SelectedIndex = 0;

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            //Check validation and additional validation within the code behind.
            //Load up the entity 
            if (Page.IsValid)
            {
                string albumtitle = EditTitle.Text;
                int albumyear = int.Parse(EditReleaseYear.Text);
                string albumlabel = EditReleaseLabel.Text == "" ? null : EditReleaseLabel.Text;
                int albumartist = int.Parse(EditAlbumArtistList.SelectedValue);

                Album theAlbum = new Album();
                //brings in values to the webpage
                theAlbum.Title = albumtitle;
                theAlbum.ArtistId = albumartist;
                theAlbum.ReleaseYear = albumyear;
                theAlbum.ReleaseLabel = albumlabel;

                messageUserControl.TryRun(() => {

                    AlbumController sysmgr = new AlbumController();
                    int albumid = sysmgr.Album_Add(theAlbum);
                    EditAlbumID.Text = albumid.ToString();
                    if (AlbumList.Rows.Count > 0)
                    {
                        AlbumList.DataBind(); //re-executes the ods for the album list
                    }

                },"Successful", "Album added");
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {

        }

        protected void Remove_Click(object sender, EventArgs e)
        {

        }
    }
}