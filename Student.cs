using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyProjectEntity.Models
{
    public class Student:BaseModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int GroupId { get; set; }
        public Group group { get; set; }
    }
}
