using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Logic.Data;
using University.Logic.Models;

namespace University.Logic.Repositories.Implements
{
    public class StudentRepository : GenericRepository<Student>
    {
        public StudentRepository(UniversityContext universityContext)
            :base(universityContext)
        {

        }
    }
}
