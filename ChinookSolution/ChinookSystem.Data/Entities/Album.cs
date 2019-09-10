using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.Data.Entities
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public int ReleaseYear { get; set; }

        private string _ReleaseLable;

        public string ReleaseLable
        {
            get
            {
                return _ReleaseLable;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _ReleaseLable = null;
                }
                else
                {
                    _ReleaseLable = value;
                }
            }
        }

        public virtual Artist Artist { get; set; }

    }
}
