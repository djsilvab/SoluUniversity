using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using University.Logic.Models;
using University.Logic.Dtos;

namespace University.Logic.Dtos
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Course, CourseDto>();//response
                cfg.CreateMap<CourseDto, Course>();//request

                cfg.CreateMap<Student, StudentDto>();
                cfg.CreateMap<StudentDto, Student>();

                cfg.CreateMap<Enrollment, EnrollmentDto>();
                cfg.CreateMap<EnrollmentDto, Enrollment>();
            });
        }
    }
}
