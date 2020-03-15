using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Study.Domain.CourseAggregate;
using Study.Domain.Interfaces;
using Study.Domain.StudentAggregate;

namespace ServantripTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IRepository<Student> _repository;
        private readonly IRepository<Course> _coursesRepository;

        public StudentsController(
            IRepository<Student> studentsRepository,
            IRepository<Course> coursesRepository)
        {
            _repository = studentsRepository;
            _coursesRepository = coursesRepository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            List<Student> allStudents;

            try
            {
                allStudents = _repository.GetAll().ToList();
            }
            catch
            {
                return BadRequest();
            }

            return allStudents;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            if (Guid.TryParse(id, out var guidId))
            {
                var student = _repository.GetById(guidId);

                if (student == null)
                {
                    return NotFound();
                }

                return student;
            }
            else
            {
                return BadRequest();
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] string name)
        {
            var newStudent = new Student(name);

            try
            {
                _repository.Create(newStudent);
                _repository.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] string name)
        {
            var student = _repository.GetById(id);
            if (student == null)
            {
                return NotFound();
            }

            student.SetName(name);

            try
            {
                _repository.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }

        // POST api/values
        [HttpPost("{studentId}/register/{courseId}")]
        public ActionResult RegisterForCourse(Guid studentId, Guid courseId)
        {
            var student = _repository.GetById(studentId);
            if (student == null)
            {
                return NotFound();
            }

            try
            {
                student.RegisterForCourse(courseId, _coursesRepository.GetAll());
                _repository.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost("{studentId}/unregister/{courseId}")]
        public ActionResult UnregisterFromCourse(Guid studentId, Guid courseId)
        {
            var student = _repository.GetById(studentId);
            if (student == null)
            {
                return BadRequest();
            }

            try
            {
                student.UnregisterFromCourse(courseId);
                _repository.SaveChanges();
            }
            catch
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
