using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.Logic.Dtos
{
    public enum Grade
    {
        A, B, C, D, E
    }

    public class EnrollmentDto
    {
        public int EnrollmentID { get; set; }        
        public int CourseID { get; set; }        
        public int StudentID { get; set; }
        public Grade Grade { get; set; }
        public CourseDto Course { get; set; }
        public StudentDto Student { get; set; }
    }
}
