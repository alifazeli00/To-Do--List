using Application.Dtos;
using Application.Dtos.Todo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IToDoRepository<T>
    {
        Task<List<T>> GetAll(PageDto PageDto);
        Task<bool> Add(T AddTodoDto);
        Task<bool> Edit(T editToDoDto);
    }
}
