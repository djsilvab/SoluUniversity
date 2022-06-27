using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.Logic.Models;

namespace University.Logic.Repositories
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<bool> DeleteCheckOnEntity(int id);
    }
}
