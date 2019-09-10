using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region additional namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace ChinookSystem.Data.Entities
{
    [Table("Artists")]
    public class Artist
    {
        //[Key, Column(Order = n)] //n indicates the order of the fields on the DB table.
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Computed - identity - none)] ---> If you have a character string then select NONE. 
        //This option can be used on a field that is not a primary key. Computer so the framework does not expect that there will be data supplied.
        [Key]
        public int ArtistId { get; set; }

        //Fully implemented property for a nullable field.
        private string _Name; 
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Name = null;
                }
                else
                {
                    _Name = value;
                }
            }
        }

        public virtual ICollection<Album> Albums { get; set; }

    }//eoc
}//eon
