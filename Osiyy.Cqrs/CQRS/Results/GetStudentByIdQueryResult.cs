using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Osiyy.Cqrs.CQRS.Results
{
    public class GetStudentByIdQueryResult
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
