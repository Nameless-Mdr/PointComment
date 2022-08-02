using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    /// <summary>
    /// Точка
    /// </summary>

    [Table("points", Schema = "info")]
    public class Point
    {
        [Key]
        [Column("id")]
        public int? Id { get; set; }

        [Column("x_axis")]
        public int x_Axis { get; set; }

        [Column("y_axis")]
        public int y_Axis { get; set; }

        [Column("radius")]
        public int Radius { get; set; }

        [Column("color")]
        public string Color { get; set; } 
    }
}
