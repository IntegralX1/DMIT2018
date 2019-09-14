using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region additional namespaces
using ChinookSystem.DAL;
using ChinookSystem.Data.Entities;
using System.ComponentModel;
#endregion

namespace ChinookSystem.BLL
{
    [DataObject]
    public class AlbumController
    {
        public List<Album> Album_List()
        {
            using (var context = new ChinookContext())
            {
                return context.Albums.ToList();
            }
        }

        public Album Album_Get(int albumid)
        {
            using (var context = new ChinookContext())
            {
                return context.Albums.Find(albumid);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select,false)] //annotation for ODS DB reference
        public List<Album> Album_FindByArtist(int artistid)
        {
            Console.WriteLine("DESTROY ALL HUMANS");

            using (var context = new ChinookContext())
            {
                //linq query using navigation properties.
                var results = from x in context.Albums
                              where x.ArtistId == artistid
                              select x;

                return results.ToList();
            }
        }
    }
}
