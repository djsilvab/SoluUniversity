using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Logic.Data;
using University.Logic.Models;

namespace University.Logic.Repositories.Implements
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(UniversityContext universityContext)
            :base(universityContext)
        {

        }
    }
}
