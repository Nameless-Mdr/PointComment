using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    /// <summary>
    /// Точка
    /// </summary>
    
    [Table("notes", Schema = "info")]
    public class Note
    {
        [Key]
        [Column("id")]
        public int? Id { get; set; }

        [Column("comment")]
        public string Comment { get; set; }

        [Column("color")]
        public string Color { get; set; }
        
        [Column("point_id")]
        public int PointId { get; set; }
    }
}
