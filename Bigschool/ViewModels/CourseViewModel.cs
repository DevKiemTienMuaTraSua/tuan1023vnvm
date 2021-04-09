using Bigschool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Bigschool.ViewModels
{
    public class CourseViewModel
    {
        [Required]
        public string Place { get; set; }
        [Required]
        [FutureDate]
        public string Date { get; set; }
        [Required]
        [ValidTime]
        public string Time { get; set; }
        [Required]
        public byte Category { get; set; }
        public IEnumerable<Category> Categories { set; get; }
        public DateTime GetDateTime()
        {
            string D = Date;
            string S = Time;
            return DateTime.ParseExact(D, "dd/M/yyyy",
                CultureInfo.InvariantCulture);
        }
    }
}