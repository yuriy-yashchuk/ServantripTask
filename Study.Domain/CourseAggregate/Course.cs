using Study.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Study.Domain.CourseAggregate
{
    public class Course : Entity
    {
        public string Title { get; set; }

        public Course(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
        }
    }
}
