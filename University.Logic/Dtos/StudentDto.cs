using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.Logic.Dtos
{
    public class StudentDto
    {        
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstMidName { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        public string FullName
        {
            get { return $"{LastName} {FirstMidName}"; }
        }
    }
}
