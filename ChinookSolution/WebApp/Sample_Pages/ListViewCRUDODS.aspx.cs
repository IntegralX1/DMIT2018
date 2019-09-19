using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.UserControls
{
    public partial class ListViewCRUDODS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
        {
            messageUserControl.HandleDataBoundException(e);
        }

        protected void AlbumListODS_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {

        }
    }
}