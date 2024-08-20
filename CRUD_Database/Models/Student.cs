using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Database.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StudentNo { get; set; }
        public decimal GPA { get; set; }
        public int Age {  get; set; }
    }
}