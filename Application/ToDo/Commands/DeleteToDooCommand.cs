using Application.Abstractions;
using Application.Dtos.Todo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ToDo.Commands
{
    public class DeleteToDooCommand:IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteToDooCommand(int id)
        {
            this.Id = id;
        }
    }

    public class DeleteToDooCommandHandler : IRequestHandler<DeleteToDooCommand, bool>
    {
        private readonly IToDoRepository<TodoDto> ToDoRepository;

        public DeleteToDooCommandHandler(IToDoRepository<TodoDto> toDoRepository)
        {
            ToDoRepository = toDoRepository;
        }
        public async Task<bool> Handle(DeleteToDooCommand request, CancellationToken cancellationToken)
        {
            var res = ToDoRepository.Delete(request.Id);
            return await res;
         
        }
    }
}
