using System.ComponentModel.DataAnnotations;

namespace H2_skoleprojekt.Server.Models
{
    public class PlantDbModel
    {
        [Key]
        public int? plantid { get; set; }
        public string? planttype { get; set; }
        public string? diseasename { get; set; }
        public string? description { get; set; }
        public string? assessment { get; set; }
        public string? stringlabel { get; set; }
    }
}
