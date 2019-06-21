using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppUniv.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [Column("student_id")]
        public int StudentId { get; set; }
        [Column("last_name")]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Column("first_mid_name")]
        [Display(Name = "Nome")]
        public string FirstMidName { get; set; }

        [Column("dt_enrollment")]
        [Display(Name = "Data da Matricula")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
