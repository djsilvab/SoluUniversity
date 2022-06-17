using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Logic.Models;
using University.Logic.Repositories;

namespace University.Logic.Services.Implements
{
    public class StudentService : GenericService<Student>
    {
        public StudentService(IStudentRepository studentRepository)
            :base(studentRepository)
        {

        }
    }
}
