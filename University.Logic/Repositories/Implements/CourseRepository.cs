using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Logic.Data;
using University.Logic.Models;

namespace University.Logic.Repositories.Implements
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly UniversityContext universityContext;
        public CourseRepository(UniversityContext universityContext)
            :base(universityContext)
        {
            this.universityContext = universityContext;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            var flag = await universityContext.Enrollments.AnyAsync(x => x.CourseID.Equals(id));
            return flag;
        }
    }
}
