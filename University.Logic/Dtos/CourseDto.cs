using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace University.Logic.Dtos
{
    public class CourseDto
    {
        [Required(ErrorMessage = "The field Course ID is required")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "The field Title is required")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The field Credits is required")]
        public int Credits { get; set; }
    }
}
