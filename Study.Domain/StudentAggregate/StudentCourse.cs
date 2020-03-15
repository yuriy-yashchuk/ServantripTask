using Study.Domain.Interfaces;
using System;

namespace Study.Domain.StudentAggregate
{
    public class StudentCourse : Entity
    {
        public Guid StudentId { get; private set; }

        public Guid CourseId { get; private set; }

        public StudentCourse(Guid studentId, Guid courseId)
        {
            Id = Guid.NewGuid();
            StudentId = studentId;
            CourseId = courseId;
        }
    }
}
