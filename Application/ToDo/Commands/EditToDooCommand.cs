﻿using Application.Abstractions;
using Application.Dtos.Todo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ToDo.Commands
{
    public class EditToDooCommand:IRequest<bool> 
    {
        public EditToDoDto EditToDoDto { get; set; }
        public EditToDooCommand(EditToDoDto EditToDoDto)
        {
            this.EditToDoDto=EditToDoDto; 

        }

    }

    public class EditToDooCommandHandler : IRequestHandler<EditToDooCommand, bool>
    {
        private readonly IToDoRepository ToDoRepository;

        public EditToDooCommandHandler(IToDoRepository toDoRepository)
        {
            ToDoRepository = toDoRepository;
        }

        public async Task<bool> Handle(EditToDooCommand request, CancellationToken cancellationToken)
        {
         return await   ToDoRepository.Edit(request.EditToDoDto);
        
        }
    }
}
