using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSystem.Data.Entities
{
    public class Track
    {
        [Key]
        public int TrackId { get; set; }

        public string Name { get; set; }
        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int GenreId { get; set;}

        private string _Composer;
        public string Composer
        {
            get
            {
                return _Composer;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Composer = null;
                }
                else
                {
                    _Composer = value;
                }
            }
        }

        public int Milliseconds { get; set; }

        private string _Bytes;
        public string Bytes
        {
            get
            {
                return _Bytes;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _Bytes = null;
                }
                else
                {
                    _Bytes = value;
                }
            }
        }

        public decimal UnitPrice { get; set; }
    }
}
