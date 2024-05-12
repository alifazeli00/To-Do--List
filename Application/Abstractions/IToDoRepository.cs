using Application.Dtos;
using Application.Dtos.Todo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IToDoRepository
    {
       Task<List<TodoDto>> GetAll(PageDto PageDto);
      Task<bool> Add(AddTodoDto AddTodoDto);
    //   void Delete(int Id);
        Task<bool> Edit(EditToDoDto editToDoDto);
    }
}
