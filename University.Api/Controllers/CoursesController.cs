using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using University.Logic.Data;
using University.Logic.Dtos;
using University.Logic.Repositories.Implements;
using University.Logic.Services.Implements;

namespace University.Api.Controllers
{
    [RoutePrefix("api/courses")]
    public class CoursesController : ApiController
    {
        private readonly CourseService courseService = new CourseService(new CourseRepository(UniversityContext.Create()));
        private IMapper mapper;

        public CoursesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        [Route("GetAll")]
        //[ActionName("getall")]
        public async Task<IHttpActionResult> GetAll()
        {
            var courses = await courseService.GetAll();
            var coursesDto = courses.Select(x => mapper.Map<CourseDto>(x));

            return Ok(coursesDto);

            //BadRequest
            //InternalServerError
            //NotFound
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var course = await courseService.GetById(id);
            if (course == null) return NotFound();//404

            var courseDto = mapper.Map<CourseDto>(course);
            return Ok(courseDto);           
        }
    }
}
