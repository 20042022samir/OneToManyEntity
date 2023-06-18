using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyProjectEntity.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDaate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
