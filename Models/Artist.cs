using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb3v4.Models
{

  
    public class Artist
    {
        //id is the PK
        public int ArtistId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public virtual ICollection<Cd>? Cds { get; set; }

    }
}
