using Application.Abstractions;
using Application.Dtos;
using Application.Dtos.Todo;
using Application.Exceptions;
using Common;
using Domain;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ToDoRepositoriy<T> : IToDoRepository<TodoDto>
    {
        private readonly DataBaceContext contex;
        public ToDoRepositoriy(DataBaceContext DataBaceContext)
        {
            this.contex = DataBaceContext;
        }
        public async Task<bool> Add(TodoDto AddTodoDto)
        {
            ToDo newTodo = new ToDo()
            {
                createDate = DateTime.Now,
                Text = AddTodoDto.Text,
                Remove = false,
            };

            contex.Add(newTodo);
            contex.SaveChanges();
            return true;
        }
        public async Task<bool> Edit(TodoDto editToDoDto)
        {
            var todo = contex.ToDos.SingleOrDefault(p => p.Id == editToDoDto.Id);
            if (todo == null)
                throw new NotFundException(nameof(todo), editToDoDto.Id);
            todo.Text = editToDoDto.Text;
            contex.SaveChanges();
            return true;
        }

        public async Task<List<TodoDto>> GetAll(PageDto PageDto)
        {
            
            int rowCount = 0;
            var query = contex.ToDos.Select(a => new TodoDto
            {
                Id = a.Id,
                IsDeleted = a.Remove,
                createDate = a.createDate,
                Text = a.Text,
            }).PagedResult(PageDto.pageIndex, PageDto.pageSize, out rowCount).AsQueryable();
            if (query == null)

                throw new Exception();

            if (!string.IsNullOrEmpty(PageDto.SearchKey))
            {
                query = query.Where(p => p.Text.Contains(PageDto.SearchKey));
            }
            PageDto.RowCount = rowCount;
            var sss = query.ToList();
            return query.ToList();
        }
    }
}
