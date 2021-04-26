using Bigschool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bigschool.ViewModels
{
    public class CoursesViewModel
    {
        public IEnumerable<Course> UpcommingCourses { set; get; }
        public IEnumerable<Following> Followings { get; set; }
        public IEnumerable<Attendance> Attendances { get; set; }
        public bool ShowAction { get; set; }
    }
}