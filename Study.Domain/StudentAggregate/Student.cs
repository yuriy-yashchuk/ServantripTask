using Study.Domain.CourseAggregate;
using Study.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Study.Domain.StudentAggregate
{
    public class Student : Entity
    {
        public string Name { get; private set; }

        public List<StudentCourse> StudentCourses { get; private set; }

        public Student(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            StudentCourses = new List<StudentCourse>();
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public Guid RegisterForCourse(Guid courseId, IEnumerable<Course> courses)
        {
            if (courses.FirstOrDefault(s => s.Id == courseId) == null)
            {
                throw new KeyNotFoundException();
            }

            var studentCourse = StudentCourses.FirstOrDefault(s => s.Id == courseId);
            if (studentCourse != null)
            {
                return studentCourse.Id;
            }
            else
            {
                var newStudentCourse = new StudentCourse(Id, courseId);
                StudentCourses.Add(newStudentCourse);
                return newStudentCourse.Id;
            }
        }

        public void UnregisterFromCourse(Guid courseId)
        {
            var studentCourse = StudentCourses.FirstOrDefault(s => s.Id == courseId);
            if (studentCourse != null)
            {
                if (!StudentCourses.Remove(studentCourse))
                {
                    throw new Exception();
                }
            }
        }
    }
}
