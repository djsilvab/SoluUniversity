using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Logic.Models;
using University.Logic.Repositories;

namespace University.Logic.Services.Implements
{
    public class CourseService : GenericService<Course>, ICourseService
    {
        private readonly ICourseRepository courseRepository;
        public CourseService(ICourseRepository courseRepository)
            :base(courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<bool> DeleteCheckOnEntity(int id)
        {
            return await courseRepository.DeleteCheckOnEntity(id);
        }
    }
}
