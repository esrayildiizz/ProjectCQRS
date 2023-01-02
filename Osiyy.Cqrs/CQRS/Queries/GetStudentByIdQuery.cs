using MediatR;
using Osiyy.Cqrs.CQRS.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Osiyy.Cqrs.CQRS.Queries
{
    public class GetStudentByIdQuery:IRequest<GetStudentByIdQueryResult>
    {
        public int Id { get; set; }
        public GetStudentByIdQuery(int id)
        {
            Id = id;

        }
    }
}
