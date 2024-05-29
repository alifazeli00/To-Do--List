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
    
    public class ComplateToDooCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public bool Done { get; set; }
        public ComplateToDooCommand(int Id,bool Done)
        {
            this.Done = Done;
            this.Id = Id;

        }
    }

    public class ComplateToDooCommandHandler : IRequestHandler<ComplateToDooCommand, bool>
    {
        private readonly IToDoRepository<TodoDto> ToDoRepository;

        public ComplateToDooCommandHandler(IToDoRepository<TodoDto> toDoRepository)
        {
            ToDoRepository = toDoRepository;
        }
        public async Task<bool> Handle(ComplateToDooCommand request, CancellationToken cancellationToken)
        {

            var res = ToDoRepository.Complate( request.Id,request.Done);
            return await res;
        
        }
    }
}
