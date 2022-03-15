using System.ComponentModel.DataAnnotations;

namespace Labb3v4.Models
{
    public class Cd
    {
        //PK
        public int CdId { get; set; }
        public string? CdName { get; set; }
        public string? CdInfo { get; set; }
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }
    }
}
