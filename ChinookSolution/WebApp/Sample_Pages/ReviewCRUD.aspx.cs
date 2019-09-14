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

            //error handling will need to be added (later).
            //The standard lookup is connecting to the controller
            AlbumController sysmgr = new AlbumController();
            Album datainfo = sysmgr.Album_Get(int.Parse(albumid));
            if (datainfo == null)
            {
                //clear the controls
                //throw an exception at dem bitchez
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
        }
    }
}