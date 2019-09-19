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
        #region Queries
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

                //throw new Exception("Boom!");

                return results.ToList();
            }
        }

        #endregion

        #region Add, Update, Delete

        public int Album_Add(Album item)
        {
            using (var context = new ChinookContext())
            {
                context.Albums.Add(item); //staging step, not on db.
                context.SaveChanges(); //now committed to the db.
                return item.AlbumId;    //returns new id value.
            }
        }

        public int Album_Update(Album item)
        {
            using (var context  = new ChinookContext())
            {
                context.Entry(item).State = System.Data.Entity.EntityState.Modified; //staged
                return context.SaveChanges();
            }
        }

        public int Album_Delete(int albumid)
        {
            using(var context = new ChinookContext())
            {
                var existing = context.Albums.Find(albumid);
                if (existing == null)
                {

                    throw new Exception("Album not on file. Delete was not completed.");

                }
                else
                {
                    context.Albums.Remove(existing);
                    return context.SaveChanges();

                }
            }
        }
        #endregion
    }
}
