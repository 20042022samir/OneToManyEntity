using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyProjectEntity.Models
{
    public class Group:BaseModel
    {
        public string name { get; set; }
        public List<Student> students { get; set; }
    }
}
