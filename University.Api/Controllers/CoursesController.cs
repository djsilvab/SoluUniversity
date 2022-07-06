using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using University.Logic.Data;
using University.Logic.Dtos;
using University.Logic.Models;
using University.Logic.Repositories.Implements;
using University.Logic.Services.Implements;

namespace University.Api.Controllers
{    
    [RoutePrefix("api/courses")]
    //[Authorize]
    public class CoursesController : ApiController
    {
        private readonly CourseService courseService = new CourseService(new CourseRepository(UniversityContext.Create()));
        private IMapper mapper;

        public CoursesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        /// <summary>
        /// Obtiene una lista de cursos
        /// </summary>
        /// <returns>Listado de cursos</returns>
        /// <response code="200">Ok. Devuelve el listado de objetos solicitados.</response>
        [HttpGet]
        [Route("GetAll")]
        [ResponseType(typeof(IEnumerable<CourseDto>))]
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

        /// <summary>
        /// Obtiene un objeto Course por su Id
        /// </summary>
        /// <param name="id">Id del objeto</param>
        /// <returns>Objeto Course</returns>
        /// <response code="200">Ok. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        [HttpGet]
        [Route("GetById/{id}")]
        [ResponseType(typeof(CourseDto))]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var course = await courseService.GetById(id);
            if (course == null) return NotFound();//404

            var courseDto = mapper.Map<CourseDto>(course);
            return Ok(courseDto);           
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<IHttpActionResult> InsertOne(CourseDto courseDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            try
            {
                var course = mapper.Map<Course>(courseDto);
                course = await courseService.Insert(course);
                return Ok(course);
            }
            catch (Exception ex) {return InternalServerError(ex); }
            
        }

        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IHttpActionResult> UpdateOne(CourseDto courseDto, int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id.Equals(0) || !courseDto.CourseID.Equals(id)) return BadRequest();

            var course = await courseService.GetById(id);
            if (course == null) return NotFound();

            try
            {
                course = mapper.Map<Course>(courseDto);
                course = await courseService.Update(course);
                return Ok(course);
            }
            catch (Exception ex) { return InternalServerError(ex); }            
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IHttpActionResult> DeleteOne(int id)
        {
            var course = await courseService.GetById(id);
            if (course == null) return NotFound();

            try
            {
                if (!await courseService.DeleteCheckOnEntity(id)) await courseService.Delete(id);
                else throw new Exception("ForeignKeys");

                return Ok();
            }
            catch (Exception ex) { return InternalServerError(ex); }
            
        }
    }
}
