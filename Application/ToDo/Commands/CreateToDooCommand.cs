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
    public class CreateToDooCommand: IRequest<bool>
    {
        public AddTodoDto AddTodoDto { get; set; }
        public CreateToDooCommand(AddTodoDto AddTodoDto)
        {
            this.AddTodoDto = AddTodoDto;
        }
    }

    public class CreateToDooCommandHandler : IRequestHandler<CreateToDooCommand, bool>
    {
        private readonly IToDoRepository ToDoRepository;

        public CreateToDooCommandHandler(IToDoRepository toDoRepository)
        {
            ToDoRepository = toDoRepository;
        }

        public async Task<bool> Handle(CreateToDooCommand request, CancellationToken cancellationToken)
        {
            var todo = new AddTodoDto 
            {
               /* Categores=request.AddTodoDto.Categores,*/Text=request.AddTodoDto.Text
            };

            var res = ToDoRepository.Add(todo);

            return await res;

        //    throw new NotImplementedException();
        }
    }
}
