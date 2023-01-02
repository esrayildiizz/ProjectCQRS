using MediatR;
using Microsoft.EntityFrameworkCore;
using Osiyy.Cqrs.CQRS.Queries;
using Osiyy.Cqrs.CQRS.Results;
using Osiyy.Cqrs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Osiyy.Cqrs.CQRS.Handlers
{
    public class GetStudentsQueryHandler:IRequestHandler<GetStudentsQuery,IEnumerable<GetStudentsQueryResult>>
    {
        private readonly StudentContext _context;
        public GetStudentsQueryHandler(StudentContext context)
        {
            _context = context;
        }

        public IEnumerable<GetStudentsQueryResult> Handle(GetStudentsQuery query)
        {
            return _context.Students.Select(x => new GetStudentsQueryResult { Name = x.Name, Surname = x.Surname }).AsNoTracking().AsEnumerable(); 
        }

        public  async Task<IEnumerable<GetStudentsQueryResult>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return await  _context.Students.Select(x => new GetStudentsQueryResult { Name = x.Name, Surname = x.Surname }).AsNoTracking().ToListAsync(); 
        }
    }
}
