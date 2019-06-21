using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppUniv.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    [Table("enrollment")]
    public class Enrollment
    {
        [Key]
        [Column("enrollment_id")]
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}