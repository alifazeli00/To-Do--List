using Application.Abstractions;
using Application.Dtos;
using Application.Dtos.Todo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ToDo.Queries
{
    public class GetToDooQuery : IRequest<List<TodoDto>>
    {
        public PageDto PageDto { get; set; }
        public GetToDooQuery(PageDto PageDto)
        {

            this.PageDto = PageDto;
        }
    }

    public class GetToDooQueryHandler : IRequestHandler<GetToDooQuery, List<TodoDto>>
    {
        private readonly IToDoRepository<TodoDto> repository;

        public GetToDooQueryHandler(IToDoRepository<TodoDto> repository)
        {
            this.repository = repository;
        }

        public async Task<List<TodoDto>> Handle(GetToDooQuery request, CancellationToken cancellationToken)
        {
         
            return await repository.GetAll(request.PageDto);
        }
    }
}
